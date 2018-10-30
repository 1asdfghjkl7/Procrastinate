using Microsoft.EntityFrameworkCore.Migrations;

namespace Procrastinate.Data.Migrations
{
    public partial class updateuseridtostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1949dc0b-cde8-49ed-b889-184e1e392a02", "fc57b389-4f63-4b1c-90ba-e807ee1ef152" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b0f5f810-6029-4eb2-8a30-01fcea10e69f", "32f645b8-75d1-40ea-814d-459cf29c0817" });

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SavedArticles",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "332726fd-737c-4d09-a19e-86960d50769e", 0, "195dea5c-7ddb-4e1f-8e9b-3437f431ef1d", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKMq1qTM8jAbOTdvwzjnfjbFDdqFKOKzv/8eyDm9zr80SHs2+QWsLcBPq3F2hn/Tuw==", null, false, "2ea98b71-90b6-4b9d-99fb-6411dd916de2", false, "admin@admin.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "2467aebd-48cd-4d7d-84a0-86b311011384", 0, "24fbd0c7-26d0-4942-8134-a1de7e157cc6", "ApplicationUser", "ladyface@faces.com", true, false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEOE0DLqPJ8Ni+5ekXfUfdNpaHo5KnEJCMRWgYRtFyPhFjitE0e9U2/hz1/e62T33Eg==", null, false, "a1539e9a-6c37-4e47-ad90-c563b078284e", false, "LadyFace@Faces.com", "April", "AwesomeLastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2467aebd-48cd-4d7d-84a0-86b311011384", "24fbd0c7-26d0-4942-8134-a1de7e157cc6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "332726fd-737c-4d09-a19e-86960d50769e", "195dea5c-7ddb-4e1f-8e9b-3437f431ef1d" });

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SavedArticles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "1949dc0b-cde8-49ed-b889-184e1e392a02", 0, "fc57b389-4f63-4b1c-90ba-e807ee1ef152", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGiho3cnE12LbSq/LfSElL8AKBrwgnQ20/8xvENGrB5bGDjQnZOcom7DTLrE9DeBZA==", null, false, "beb4a41b-ee07-483d-94cb-5db49b77caf9", false, "admin@admin.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "b0f5f810-6029-4eb2-8a30-01fcea10e69f", 0, "32f645b8-75d1-40ea-814d-459cf29c0817", "ApplicationUser", "ladyface@faces.com", true, false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEOAFGm/EbVy0UhX6RvQEVPCfizekT3pyfzPt8Wv2CtR6PGONme5SjV23rAK7ARvZjA==", null, false, "ad5fac27-657d-48a6-95cc-4946944c6254", false, "LadyFace@Faces.com", "April", "AwesomeLastName" });
        }
    }
}
