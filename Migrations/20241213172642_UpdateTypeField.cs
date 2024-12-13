using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teledok.Migrations
{
    public partial class UpdateTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Clients",
                newName: "IsLegalEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLegalEntity",
                table: "Clients",
                newName: "Type");
        }
    }
}
