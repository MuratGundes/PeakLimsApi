namespace PeakLims.Domain.Accessions;

using PeakLims.Domain.Accessions.Dtos;
using PeakLims.Domain.Accessions.DomainEvents;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using AccessionStatuses;
using Sieve.Attributes;
using PeakLims.Domain.Patients;
using PeakLims.Domain.HealthcareOrganizations;
using PeakLims.Domain.HealthcareOrganizationContacts;
using PeakLims.Domain.PanelOrders;
using PeakLims.Domain.TestOrders;
using PeakLims.Domain.AccessionComments;
using SharedKernel.Exceptions;

public class Accession : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public virtual string AccessionNumber { get; }

    public AccessionStatus Status { get; private set; }

    [JsonIgnore]
    [IgnoreDataMember]
    [ForeignKey("Patient")]
    public virtual Guid? PatientId { get; private set; }
    public virtual Patient Patient { get; }

    [JsonIgnore]
    [IgnoreDataMember]
    [ForeignKey("HealthcareOrganization")]
    public virtual Guid? HealthcareOrganizationId { get; private set; }
    public virtual HealthcareOrganization HealthcareOrganization { get; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<HealthcareOrganizationContact> Contacts { get; } = new List<HealthcareOrganizationContact>();

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<PanelOrder> PanelOrders { get; private set; } = new List<PanelOrder>();

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<TestOrder> TestOrders { get; private set; } = new List<TestOrder>();

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<AccessionComment> Comments { get; private set; } = new List<AccessionComment>();


    public static Accession Create(AccessionForCreationDto accessionForCreationDto)
    {
        var newAccession = new Accession();

        newAccession.Status = AccessionStatus.Draft();
        newAccession.PatientId = accessionForCreationDto.PatientId;
        newAccession.HealthcareOrganizationId = accessionForCreationDto.HealthcareOrganizationId;

        newAccession.QueueDomainEvent(new AccessionCreated(){ Accession = newAccession });
        
        return newAccession;
    }

    public void Update(AccessionForUpdateDto accessionForUpdateDto)
    {
        if (Status != AccessionStatus.Draft()) return;
        
        PatientId = accessionForUpdateDto.PatientId;
        HealthcareOrganizationId = accessionForUpdateDto.HealthcareOrganizationId;
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    public void SetStatusToReadyForTesting()
    {
        new ValidationException(nameof(Accession),
                $"A patient is required in order to set an accession to {AccessionStatus.ReadyForTesting().Value}")
            .ThrowWhenNullOrEmpty(PatientId);
        new ValidationException(nameof(Accession),
                $"An organization is required in order to set an accession to {AccessionStatus.ReadyForTesting().Value}")
            .ThrowWhenNullOrEmpty(HealthcareOrganizationId);
        if (PanelOrders.Count <= 0 && TestOrders.Count <= 0)
            throw new ValidationException(nameof(Accession),
                $"At least 1 panel or test is required in order to set an accession to {AccessionStatus.ReadyForTesting().Value}");
        if (Contacts.Count <= 0)
            throw new ValidationException(nameof(Accession),
                $"At least 1 organization contact is required in order to set an accession to {AccessionStatus.ReadyForTesting().Value}");
        
        Status = AccessionStatus.ReadyForTesting();
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    public void AddPanelOrder(PanelOrder panelOrder)
    {
        // TODO unit test
        if(Status.IsFinalState())
            throw new ValidationException(nameof(Accession),
                $"This accession is in a final state. Panel orders can not be modified.");
        
        var hasNonActiveTests = panelOrder.Panel.Tests.Any(x => !x.Status.IsActive());
        if(hasNonActiveTests)
            throw new ValidationException(nameof(Accession),
                $"This panel has one or more tests that are not active. Only active tests can be added to an accession.");

        PanelOrders.Add(panelOrder);
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    public void RemovePanelOrder(PanelOrder panelOrder)
    {
        // TODO unit test
        if(Status.IsFinalState())
            throw new ValidationException(nameof(Accession),
                $"This accession is in a final state. Panel orders can not be modified.");

        var alreadyExists = PanelOrders.Any(x => panelOrder.Panel.Id == x.Panel.Id);
        if (!alreadyExists)
            return;
        
        PanelOrders.Remove(panelOrder);
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    public void AddContact(HealthcareOrganizationContact contact)
    {
        var alreadyExists = HealthcareOrganizationContactAlreadyExists(contact);
        if (alreadyExists)
            return;
        
        Contacts.Add(contact);
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    public void RemoveContact(HealthcareOrganizationContact contact)
    {
        var alreadyExists = HealthcareOrganizationContactAlreadyExists(contact);
        if (!alreadyExists)
            return;
        
        Contacts.Remove(contact);
        QueueDomainEvent(new AccessionUpdated(){ Id = Id });
    }

    private bool HealthcareOrganizationContactAlreadyExists(HealthcareOrganizationContact contact)
    {
        var alreadyExists = Contacts.Any(x => contact.Id == x.Id);
        return alreadyExists;
    }
    
    protected Accession() { } // For EF + Mocking
}