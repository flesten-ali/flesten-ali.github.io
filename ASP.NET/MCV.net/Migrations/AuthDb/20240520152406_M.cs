using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCV.net.Migrations.AuthDb
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2582621b-3de2-4255-9766-aaae346c85c7");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2582621b-3de2-4255-9766-aaae346c85c7", 0, "9902ca1c-647e-48e7-9f2a-f82f0c9b1a58", "flesten.ali@gmail.com", false, false, null, "FLESTEN.ALI@GMAIL.COM", "FLESTEN.ALI@GMAIL.COM", "AQAAAAEAACcQAAAAELRgATWIxIdc+hz+Cjlp7CzywMk7Mzq75kt4a41SqDg6iuFpS06WDsYqKSCgYQZoZw==", null, false, "0e87c4d7-a7d3-4ac6-b688-667e445cb326", false, "flesten.ali@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2582621b-3de2-4255-9766-aaae346c85c7", 0, "89a17c7d-b225-4f01-901f-5334201344e0", "IdentityUser", "flesten.ali@gmail.com", false, false, null, "FLESTEN.ALI@GMAIL.COM", "FLESTEN.ALI@GMAIL.COM", "AQAAAAEAACcQAAAAEAxKMiq3A9XYsX100hecuM4E9Grt9q7Uq7qJMnIYC94kVBSKiaQPsx6NL1GbSOd3jg==", null, false, "906c5052-b324-4403-b9e8-2dcb2dfb00c9", false, "flesten.ali@gmail.com" });
        }
    }
}
