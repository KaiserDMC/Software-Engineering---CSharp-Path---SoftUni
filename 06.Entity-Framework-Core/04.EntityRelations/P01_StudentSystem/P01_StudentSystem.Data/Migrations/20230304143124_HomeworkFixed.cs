using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_StudentSystem.Data.Migrations
{
    public partial class HomeworkFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseHomework");

            migrationBuilder.DropTable(
                name: "HomeworkStudent");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_CourseId",
                table: "Homeworks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_CourseId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_StudentId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Homeworks");

            migrationBuilder.CreateTable(
                name: "CourseHomework",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    HomeworksHomeworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseHomework", x => new { x.CoursesCourseId, x.HomeworksHomeworkId });
                    table.ForeignKey(
                        name: "FK_CourseHomework_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseHomework_Homeworks_HomeworksHomeworkId",
                        column: x => x.HomeworksHomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkStudent",
                columns: table => new
                {
                    HomeworksHomeworkId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkStudent", x => new { x.HomeworksHomeworkId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_HomeworkStudent_Homeworks_HomeworksHomeworkId",
                        column: x => x.HomeworksHomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseHomework_HomeworksHomeworkId",
                table: "CourseHomework",
                column: "HomeworksHomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkStudent_StudentsStudentId",
                table: "HomeworkStudent",
                column: "StudentsStudentId");
        }
    }
}
