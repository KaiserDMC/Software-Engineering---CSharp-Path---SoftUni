using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Footballers.Migrations
{
    public partial class fourthdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Footballers",
                newName: "PositionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionType",
                table: "Footballers",
                newName: "Position");
        }
    }
}
