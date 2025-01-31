﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakLims.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    container_number = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_containers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "healthcare_organizations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_healthcare_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "panels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    panel_number = table.Column<string>(type: "text", nullable: true),
                    panel_code = table.Column<string>(type: "text", nullable: true),
                    panel_name = table.Column<string>(type: "text", nullable: true),
                    turn_around_time = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    race = table.Column<string>(type: "text", nullable: true),
                    ethnicity = table.Column<string>(type: "text", nullable: true),
                    internal_id = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true),
                    permission = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_number = table.Column<string>(type: "text", nullable: true),
                    test_code = table.Column<string>(type: "text", nullable: true),
                    test_name = table.Column<string>(type: "text", nullable: true),
                    methodology = table.Column<string>(type: "text", nullable: true),
                    platform = table.Column<string>(type: "text", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identifier = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accession_number = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: true),
                    healthcare_organization_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_accessions_healthcare_organizations_healthcare_organization",
                        column: x => x.healthcare_organization_id,
                        principalTable: "healthcare_organizations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_accessions_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "samples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sample_number = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<decimal>(type: "numeric", nullable: true),
                    collection_date = table.Column<DateOnly>(type: "date", nullable: true),
                    received_date = table.Column<DateOnly>(type: "date", nullable: true),
                    collection_site = table.Column<string>(type: "text", nullable: true),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: true),
                    parent_sample_id = table.Column<Guid>(type: "uuid", nullable: true),
                    container_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samples", x => x.id);
                    table.ForeignKey(
                        name: "fk_samples_containers_container_id",
                        column: x => x.container_id,
                        principalTable: "containers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_samples_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_samples_samples_parent_sample_id",
                        column: x => x.parent_sample_id,
                        principalTable: "samples",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "panel_test",
                columns: table => new
                {
                    panels_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tests_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panel_test", x => new { x.panels_id, x.tests_id });
                    table.ForeignKey(
                        name: "fk_panel_test_panels_panels_id",
                        column: x => x.panels_id,
                        principalTable: "panels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_panel_test_tests_tests_id",
                        column: x => x.tests_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accession_comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    initial_accession_state = table.Column<string>(type: "text", nullable: true),
                    ending_accession_state = table.Column<string>(type: "text", nullable: true),
                    accession_id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_comment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    parent_accession_comment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accession_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_accession_comments_accession_comments_parent_accession_comm",
                        column: x => x.parent_accession_comment_id,
                        principalTable: "accession_comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_accession_comments_accessions_accession_id",
                        column: x => x.accession_id,
                        principalTable: "accessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "healthcare_organization_contacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    npi = table.Column<string>(type: "text", nullable: true),
                    healthcare_organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    accession_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_healthcare_organization_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_healthcare_organization_contacts_accessions_accession_id",
                        column: x => x.accession_id,
                        principalTable: "accessions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_healthcare_organization_contacts_healthcare_organizations_h",
                        column: x => x.healthcare_organization_id,
                        principalTable: "healthcare_organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "panel_orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    state = table.Column<string>(type: "text", nullable: true),
                    panel_id = table.Column<Guid>(type: "uuid", nullable: true),
                    accession_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panel_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_panel_orders_accessions_accession_id",
                        column: x => x.accession_id,
                        principalTable: "accessions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_panel_orders_panels_panel_id",
                        column: x => x.panel_id,
                        principalTable: "panels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "test_orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    state = table.Column<string>(type: "text", nullable: true),
                    test_id = table.Column<Guid>(type: "uuid", nullable: true),
                    accession_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_test_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_test_orders_accessions_accession_id",
                        column: x => x.accession_id,
                        principalTable: "accessions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_test_orders_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "tests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_accession_comments_accession_id",
                table: "accession_comments",
                column: "accession_id");

            migrationBuilder.CreateIndex(
                name: "ix_accession_comments_parent_accession_comment_id",
                table: "accession_comments",
                column: "parent_accession_comment_id");

            migrationBuilder.CreateIndex(
                name: "ix_accessions_healthcare_organization_id",
                table: "accessions",
                column: "healthcare_organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_accessions_patient_id",
                table: "accessions",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_healthcare_organization_contacts_accession_id",
                table: "healthcare_organization_contacts",
                column: "accession_id");

            migrationBuilder.CreateIndex(
                name: "ix_healthcare_organization_contacts_healthcare_organization_id",
                table: "healthcare_organization_contacts",
                column: "healthcare_organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_panel_orders_accession_id",
                table: "panel_orders",
                column: "accession_id");

            migrationBuilder.CreateIndex(
                name: "ix_panel_orders_panel_id",
                table: "panel_orders",
                column: "panel_id");

            migrationBuilder.CreateIndex(
                name: "ix_panel_test_tests_id",
                table: "panel_test",
                column: "tests_id");

            migrationBuilder.CreateIndex(
                name: "ix_samples_container_id",
                table: "samples",
                column: "container_id");

            migrationBuilder.CreateIndex(
                name: "ix_samples_parent_sample_id",
                table: "samples",
                column: "parent_sample_id");

            migrationBuilder.CreateIndex(
                name: "ix_samples_patient_id",
                table: "samples",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_test_orders_accession_id",
                table: "test_orders",
                column: "accession_id");

            migrationBuilder.CreateIndex(
                name: "ix_test_orders_test_id",
                table: "test_orders",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accession_comments");

            migrationBuilder.DropTable(
                name: "healthcare_organization_contacts");

            migrationBuilder.DropTable(
                name: "panel_orders");

            migrationBuilder.DropTable(
                name: "panel_test");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "samples");

            migrationBuilder.DropTable(
                name: "test_orders");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "panels");

            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "accessions");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "healthcare_organizations");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
