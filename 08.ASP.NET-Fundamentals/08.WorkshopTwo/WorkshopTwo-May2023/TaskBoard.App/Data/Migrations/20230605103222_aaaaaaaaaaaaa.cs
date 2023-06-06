using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.App.Data.Migrations
{
    public partial class aaaaaaaaaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Boards",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Boards", x => x.Id);
               });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed",  "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "test-user-id-guid", 0, "3b99da7b-1439-42bf-975a-0809e95935d5", "test@softuni.bg", false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEHmA31CU0EXwa/S8NPuQBh0pTSYGPq7IM4cRPqgu37nXjJH/zbEl8AbVX1jmNgTuog==", null, false, "8f8ffde5-2be3-45c7-b73d-2323cf0c9f7e", false, "test@softuni.bg" });


            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("1a3e5384-9e67-416c-9552-cb367b4530c8"), 2, new DateTime(2023, 6, 4, 12, 32, 22, 273, DateTimeKind.Local).AddTicks(1835), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "test-user-id-guid", "Desktop Client App"},
                    { new Guid("20c9259f-7f25-4a04-8f53-fddac57b05cc"), 3, new DateTime(2022, 6, 5, 12, 32, 22, 273, DateTimeKind.Local).AddTicks(1839), "Implement [Create Task] page for adding new tasks", "test-user-id-guid", "Create Tasks"},
                    { new Guid("71466380-d167-48b6-b467-160e3714635c"), 1, new DateTime(2023, 5, 31, 12, 32, 22, 273, DateTimeKind.Local).AddTicks(1831), "Create Android client app for the TaskBoard RESTful API", "test-user-id-guid", "Android Client App"},
                    { new Guid("c6fc434f-0416-43bf-bbbb-b0f2ea42b418"), 1, new DateTime(2022, 11, 17, 12, 32, 22, 273, DateTimeKind.Local).AddTicks(1797), "Implement better styling for all public pages", "test-user-id-guid", "Improve CSS styles"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1a3e5384-9e67-416c-9552-cb367b4530c8"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("20c9259f-7f25-4a04-8f53-fddac57b05cc"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("71466380-d167-48b6-b467-160e3714635c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c6fc434f-0416-43bf-bbbb-b0f2ea42b418"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test-user-id-guid",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "314aeb28-a0eb-4836-ba85-1f76277616a0", "AQAAAAEAACcQAAAAEMhHI2/aw5+5Qp1ugCGwalviyPx412c/J7i1ng3RfT15zUbrjggNYN9UpSYA9zCPIA==", "690657bd-8b28-40d1-b667-047ed98972a4" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0120a268-ed93-474c-ad21-3f7368a66452"), 1, new DateTime(2023, 5, 31, 12, 13, 21, 723, DateTimeKind.Local).AddTicks(1497), "Create Android client app for the TaskBoard RESTful API", "test-user-id-guid", "Android Client App", null },
                    { new Guid("5ab29a17-6b89-4340-ae5d-ab381a41d69d"), 1, new DateTime(2022, 11, 17, 12, 13, 21, 723, DateTimeKind.Local).AddTicks(1458), "Implement better styling for all public pages", "test-user-id-guid", "Improve CSS styles", null },
                    { new Guid("65868af1-cf1a-4646-a7ee-9dd47ef2660c"), 3, new DateTime(2022, 6, 5, 12, 13, 21, 723, DateTimeKind.Local).AddTicks(1506), "Implement [Create Task] page for adding new tasks", "test-user-id-guid", "Create Tasks", null },
                    { new Guid("6ba3edc2-08bc-4e99-a4ca-5533e3bc83e1"), 2, new DateTime(2023, 6, 4, 12, 13, 21, 723, DateTimeKind.Local).AddTicks(1501), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "test-user-id-guid", "Desktop Client App", null }
                });
        }
    }
}
