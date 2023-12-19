using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reflex.Data.Migrations
{
    public partial class iipax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecrecyVisibility",
                table: "IipaxConfigs",
                newName: "FileSecrecyVisibility");

            migrationBuilder.RenameColumn(
                name: "PulPersonalSecrecyVisibility",
                table: "IipaxConfigs",
                newName: "FilePulPersonalSecrecyVisibility");

            migrationBuilder.RenameColumn(
                name: "OtherSecrecyVisibility",
                table: "IipaxConfigs",
                newName: "FileOtherSecrecyVisibility");

            migrationBuilder.AddColumn<int>(
                name: "CaseOtherSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasePulPersonalSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaseSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocOtherSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocPulPersonalSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocSecrecyVisibility",
                table: "IipaxConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseOtherSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.DropColumn(
                name: "CasePulPersonalSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.DropColumn(
                name: "CaseSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.DropColumn(
                name: "DocOtherSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.DropColumn(
                name: "DocPulPersonalSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.DropColumn(
                name: "DocSecrecyVisibility",
                table: "IipaxConfigs");

            migrationBuilder.RenameColumn(
                name: "FileSecrecyVisibility",
                table: "IipaxConfigs",
                newName: "SecrecyVisibility");

            migrationBuilder.RenameColumn(
                name: "FilePulPersonalSecrecyVisibility",
                table: "IipaxConfigs",
                newName: "PulPersonalSecrecyVisibility");

            migrationBuilder.RenameColumn(
                name: "FileOtherSecrecyVisibility",
                table: "IipaxConfigs",
                newName: "OtherSecrecyVisibility");
        }
    }
}
