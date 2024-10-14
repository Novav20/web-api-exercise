using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiRouteResponses.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
