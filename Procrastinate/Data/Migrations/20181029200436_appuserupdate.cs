using Microsoft.EntityFrameworkCore.Migrations;

namespace Procrastinate.Data.Migrations
{
    public partial class appuserupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "1949dc0b-cde8-49ed-b889-184e1e392a02", 0, "fc57b389-4f63-4b1c-90ba-e807ee1ef152", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGiho3cnE12LbSq/LfSElL8AKBrwgnQ20/8xvENGrB5bGDjQnZOcom7DTLrE9DeBZA==", null, false, "beb4a41b-ee07-483d-94cb-5db49b77caf9", false, "admin@admin.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "b0f5f810-6029-4eb2-8a30-01fcea10e69f", 0, "32f645b8-75d1-40ea-814d-459cf29c0817", "ApplicationUser", "ladyface@faces.com", true, false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEOAFGm/EbVy0UhX6RvQEVPCfizekT3pyfzPt8Wv2CtR6PGONme5SjV23rAK7ARvZjA==", null, false, "ad5fac27-657d-48a6-95cc-4946944c6254", false, "LadyFace@Faces.com", "April", "AwesomeLastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1949dc0b-cde8-49ed-b889-184e1e392a02", "fc57b389-4f63-4b1c-90ba-e807ee1ef152" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b0f5f810-6029-4eb2-8a30-01fcea10e69f", "32f645b8-75d1-40ea-814d-459cf29c0817" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
