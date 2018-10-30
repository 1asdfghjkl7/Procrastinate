using Microsoft.EntityFrameworkCore.Migrations;

namespace Procrastinate.Data.Migrations
{
    public partial class updatesavedarticlestohaveappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2467aebd-48cd-4d7d-84a0-86b311011384", "24fbd0c7-26d0-4942-8134-a1de7e157cc6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "332726fd-737c-4d09-a19e-86960d50769e", "195dea5c-7ddb-4e1f-8e9b-3437f431ef1d" });

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SavedArticles",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SavedArticles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "36189507-a813-4d7e-a4e3-765b86401755", 0, "c0d4e6d5-0489-4a41-8959-9c5bbb186a53", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBaXi9yKZF4a+yQCjUkPGbDGS/LXM/nPj8nsX+WyeYIPFa/c7tfXtidgpmVY0foIGQ==", null, false, "6a977e75-9215-4d7d-be45-6a1849dc9364", false, "admin@admin.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "d2df3b32-5a70-4a35-9db8-9b63fc2a1af4", 0, "ec21d849-6825-4102-ad3f-49194f778268", "ApplicationUser", "ladyface@faces.com", true, false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAELV1S/CHvfMBjTDdCR8brecNSulk6+w/zojCf3AsLpAdVwarpj7+p4jVTdlHIol95w==", null, false, "d38c1db9-42ae-4eff-b3f4-6231b544cb19", false, "LadyFace@Faces.com", "April", "AwesomeLastName" });

            migrationBuilder.CreateIndex(
                name: "IX_SavedArticles_ApplicationUserId",
                table: "SavedArticles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedArticles_AspNetUsers_ApplicationUserId",
                table: "SavedArticles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedArticles_AspNetUsers_ApplicationUserId",
                table: "SavedArticles");

            migrationBuilder.DropIndex(
                name: "IX_SavedArticles_ApplicationUserId",
                table: "SavedArticles");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "36189507-a813-4d7e-a4e3-765b86401755", "c0d4e6d5-0489-4a41-8959-9c5bbb186a53" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d2df3b32-5a70-4a35-9db8-9b63fc2a1af4", "ec21d849-6825-4102-ad3f-49194f778268" });

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "SavedArticles",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SavedArticles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "332726fd-737c-4d09-a19e-86960d50769e", 0, "195dea5c-7ddb-4e1f-8e9b-3437f431ef1d", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKMq1qTM8jAbOTdvwzjnfjbFDdqFKOKzv/8eyDm9zr80SHs2+QWsLcBPq3F2hn/Tuw==", null, false, "2ea98b71-90b6-4b9d-99fb-6411dd916de2", false, "admin@admin.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "2467aebd-48cd-4d7d-84a0-86b311011384", 0, "24fbd0c7-26d0-4942-8134-a1de7e157cc6", "ApplicationUser", "ladyface@faces.com", true, false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEOE0DLqPJ8Ni+5ekXfUfdNpaHo5KnEJCMRWgYRtFyPhFjitE0e9U2/hz1/e62T33Eg==", null, false, "a1539e9a-6c37-4e47-ad90-c563b078284e", false, "LadyFace@Faces.com", "April", "AwesomeLastName" });
        }
    }
}
