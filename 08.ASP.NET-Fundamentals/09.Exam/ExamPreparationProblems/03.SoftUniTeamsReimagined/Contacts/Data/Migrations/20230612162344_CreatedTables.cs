using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersContacts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersContacts", x => new { x.ApplicationUserId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "Website" },
                values: new object[] { new Guid("3516c104-bce6-4b7d-bcb5-c5001d253b42"), "Gotham City", "imbatman@batman.com", "Bruce", "Wayne", "+359881223344", "www.batman.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersContacts_ContactId",
                table: "ApplicationUsersContacts",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersContacts");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
