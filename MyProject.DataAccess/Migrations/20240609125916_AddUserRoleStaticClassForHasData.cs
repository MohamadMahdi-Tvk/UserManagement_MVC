using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleStaticClassForHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertDate", "IsDeleted", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8131), false, "Admin", new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8141) },
                    { 2, new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8214), false, "Operator", new DateTime(2024, 6, 9, 16, 29, 15, 109, DateTimeKind.Local).AddTicks(8215) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
