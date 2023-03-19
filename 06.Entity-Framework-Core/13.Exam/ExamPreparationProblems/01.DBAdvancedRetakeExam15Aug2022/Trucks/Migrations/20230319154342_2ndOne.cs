using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trucks.Migrations
{
    public partial class _2ndOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TankCapcacity",
                table: "Trucks",
                newName: "TankCapacity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TankCapacity",
                table: "Trucks",
                newName: "TankCapcacity");
        }
    }
}
