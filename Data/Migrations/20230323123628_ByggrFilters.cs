using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reflex.Data.Migrations
{
    public partial class ByggrFilters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HideNotesInPreview",
                table: "ByggrConfigs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HideNotesInPreview",
                table: "ByggrConfigs");
        }
    }
}
