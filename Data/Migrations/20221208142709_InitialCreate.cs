using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reflex.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumedTime",
                table: "PersistedGrants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PersistedGrants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "PersistedGrants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DeviceCodes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "DeviceCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultConfigId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTab",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "\"Cases\"");

            migrationBuilder.CreateTable(
                name: "AgsConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchWay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstateNameSearch = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgsConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgsSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgsSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ByggrConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccurenceTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonRoles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diarieprefixes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tabs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingMaterial = table.Column<bool>(type: "bit", nullable: false),
                    HideConfidentialOccurences = table.Column<int>(type: "int", nullable: false),
                    HideCasesWithTextMatching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideOccurencesWithTextMatching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideDocumentsWithNoteTextMatching = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlyCasesWithoutMainDecision = table.Column<bool>(type: "bit", nullable: false),
                    OnlyActiveCases = table.Column<bool>(type: "bit", nullable: false),
                    MinCaseStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statuses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByggrConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ByggrSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByggrSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tabs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcosConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideConfidentialCases = table.Column<int>(type: "int", nullable: false),
                    HideConfidentialDocuments = table.Column<int>(type: "int", nullable: false),
                    DocumentTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccurrenceTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessTypes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcosSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FbSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FbServiceDatabase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbServicePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbServiceUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbBoendeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbByggnadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbByggnadUsrUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbFastighetUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbFastighetUsrUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FbWebbLagenhetUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FbSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IipaxConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecrecyVisibility = table.Column<int>(type: "int", nullable: false),
                    PulPersonalSecrecyVisibility = table.Column<int>(type: "int", nullable: false),
                    OtherSecrecyVisibility = table.Column<int>(type: "int", nullable: false),
                    ObjectTypes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IipaxConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IipaxSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IipaxSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgsConfigConfig",
                columns: table => new
                {
                    AgsConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgsConfigConfig", x => new { x.AgsConfigsId, x.ConfigsId });
                    table.ForeignKey(
                        name: "FK_AgsConfigConfig_AgsConfigs_AgsConfigsId",
                        column: x => x.AgsConfigsId,
                        principalTable: "AgsConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgsConfigConfig_Configs_ConfigsId",
                        column: x => x.ConfigsId,
                        principalTable: "Configs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ByggrConfigConfig",
                columns: table => new
                {
                    ByggrConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByggrConfigConfig", x => new { x.ByggrConfigsId, x.ConfigsId });
                    table.ForeignKey(
                        name: "FK_ByggrConfigConfig_ByggrConfigs_ByggrConfigsId",
                        column: x => x.ByggrConfigsId,
                        principalTable: "ByggrConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ByggrConfigConfig_Configs_ConfigsId",
                        column: x => x.ConfigsId,
                        principalTable: "Configs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigEcosConfig",
                columns: table => new
                {
                    ConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcosConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigEcosConfig", x => new { x.ConfigsId, x.EcosConfigsId });
                    table.ForeignKey(
                        name: "FK_ConfigEcosConfig_Configs_ConfigsId",
                        column: x => x.ConfigsId,
                        principalTable: "Configs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigEcosConfig_EcosConfigs_EcosConfigsId",
                        column: x => x.EcosConfigsId,
                        principalTable: "EcosConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigIipaxConfig",
                columns: table => new
                {
                    ConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IipaxConfigsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigIipaxConfig", x => new { x.ConfigsId, x.IipaxConfigsId });
                    table.ForeignKey(
                        name: "FK_ConfigIipaxConfig_Configs_ConfigsId",
                        column: x => x.ConfigsId,
                        principalTable: "Configs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigIipaxConfig_IipaxConfigs_IipaxConfigsId",
                        column: x => x.IipaxConfigsId,
                        principalTable: "IipaxConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DefaultConfigId",
                table: "AspNetUsers",
                column: "DefaultConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_AgsConfigConfig_ConfigsId",
                table: "AgsConfigConfig",
                column: "ConfigsId");

            migrationBuilder.CreateIndex(
                name: "IX_ByggrConfigConfig_ConfigsId",
                table: "ByggrConfigConfig",
                column: "ConfigsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigEcosConfig_EcosConfigsId",
                table: "ConfigEcosConfig",
                column: "EcosConfigsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigIipaxConfig_IipaxConfigsId",
                table: "ConfigIipaxConfig",
                column: "IipaxConfigsId");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Configs_DefaultConfigId",
                table: "AspNetUsers",
                column: "DefaultConfigId",
                principalTable: "Configs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Configs_DefaultConfigId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AgsConfigConfig");

            migrationBuilder.DropTable(
                name: "AgsSettings");

            migrationBuilder.DropTable(
                name: "ByggrConfigConfig");

            migrationBuilder.DropTable(
                name: "ByggrSettings");

            migrationBuilder.DropTable(
                name: "ConfigEcosConfig");

            migrationBuilder.DropTable(
                name: "ConfigIipaxConfig");

            migrationBuilder.DropTable(
                name: "EcosSettings");

            migrationBuilder.DropTable(
                name: "FbSettings");

            migrationBuilder.DropTable(
                name: "IipaxSettings");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "AgsConfigs");

            migrationBuilder.DropTable(
                name: "ByggrConfigs");

            migrationBuilder.DropTable(
                name: "EcosConfigs");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "IipaxConfigs");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DefaultConfigId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConsumedTime",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "DefaultConfigId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DefaultTab",
                table: "AspNetUsers");
        }
    }
}
