using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiRouteResponses.Migrations
{
    /// <inheritdoc />
    public partial class addPhonAndDescriptionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("63cd31a5-68c5-49e7-aef8-dafb48629f79"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8746d8f6-6e61-415d-aaa8-49a421ada2b8"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b82276ff-e75a-4f07-b359-8f167c448e8c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3e918cb1-fb70-44e2-86ce-1120d75d37df"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9bd4c9dd-181f-45e5-8971-2b17ae9a2694"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e5bf7599-f991-4a5e-ab0a-1c201eacba33"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Age", "CreationDate", "LastName", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("23723961-4278-4f31-8744-fbbf7dbc4572"), true, 22, new DateTime(2024, 10, 12, 19, 49, 20, 143, DateTimeKind.Local).AddTicks(1108), "Vera", "Vero", null },
                    { new Guid("28e24e4e-ce62-4371-9adf-d51bfd5e6964"), true, 23, new DateTime(2024, 10, 12, 19, 49, 20, 143, DateTimeKind.Local).AddTicks(1109), "Valdiviezo", "Yamileth", null },
                    { new Guid("9ae11445-5ba0-48ef-a227-198bbaa43f37"), true, 23, new DateTime(2024, 10, 12, 19, 49, 20, 143, DateTimeKind.Local).AddTicks(1083), "Julio", "Juan", null }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Active", "Description", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ba701c8-4be9-4843-958a-880506657ef7"), true, null, "Admin", new Guid("9ae11445-5ba0-48ef-a227-198bbaa43f37") },
                    { new Guid("53328b9f-6225-47db-a4a6-e230c6cba090"), true, null, "User", new Guid("23723961-4278-4f31-8744-fbbf7dbc4572") },
                    { new Guid("b7819cc9-b721-48b7-9ea1-36416c24cdd5"), true, null, "Support", new Guid("28e24e4e-ce62-4371-9adf-d51bfd5e6964") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("4ba701c8-4be9-4843-958a-880506657ef7"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("53328b9f-6225-47db-a4a6-e230c6cba090"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b7819cc9-b721-48b7-9ea1-36416c24cdd5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("23723961-4278-4f31-8744-fbbf7dbc4572"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28e24e4e-ce62-4371-9adf-d51bfd5e6964"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9ae11445-5ba0-48ef-a227-198bbaa43f37"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Age", "CreationDate", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("3e918cb1-fb70-44e2-86ce-1120d75d37df"), true, 22, new DateTime(2024, 10, 12, 19, 37, 33, 254, DateTimeKind.Local).AddTicks(7317), "Vera", "Vero" },
                    { new Guid("9bd4c9dd-181f-45e5-8971-2b17ae9a2694"), true, 23, new DateTime(2024, 10, 12, 19, 37, 33, 254, DateTimeKind.Local).AddTicks(7280), "Julio", "Juan" },
                    { new Guid("e5bf7599-f991-4a5e-ab0a-1c201eacba33"), true, 23, new DateTime(2024, 10, 12, 19, 37, 33, 254, DateTimeKind.Local).AddTicks(7319), "Valdiviezo", "Yamileth" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Active", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("63cd31a5-68c5-49e7-aef8-dafb48629f79"), true, "Admin", new Guid("9bd4c9dd-181f-45e5-8971-2b17ae9a2694") },
                    { new Guid("8746d8f6-6e61-415d-aaa8-49a421ada2b8"), true, "User", new Guid("3e918cb1-fb70-44e2-86ce-1120d75d37df") },
                    { new Guid("b82276ff-e75a-4f07-b359-8f167c448e8c"), true, "Support", new Guid("e5bf7599-f991-4a5e-ab0a-1c201eacba33") }
                });
        }
    }
}
