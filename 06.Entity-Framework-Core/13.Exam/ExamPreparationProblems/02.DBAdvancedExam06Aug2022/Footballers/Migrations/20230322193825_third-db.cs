using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Footballers.Migrations
{
    public partial class thirddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BestSkill",
                table: "Footballers",
                newName: "BestSkillType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BestSkillType",
                table: "Footballers",
                newName: "BestSkill");
        }
    }
}
