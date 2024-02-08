using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tickets.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedPropToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("2b15cd05-7e64-471d-9690-78d5e071856c"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("af3a3ca9-796c-4e58-a05c-d1c9e1742f28"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("b033d049-9958-462a-a410-683f857cfefd"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("e8f6acd0-3530-4191-bdd8-cfd0de2e895c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18500936-fd11-4f4b-bb7c-854435c152a3"), "Team #2" },
                    { new Guid("78542b41-01e6-477d-9d60-1dcb806a4f25"), "Team #4" },
                    { new Guid("cddd43cd-916b-4e98-9057-9a8af37520ed"), "Team #3" },
                    { new Guid("d12af04c-fd7d-4dd2-9198-28d9037160fc"), "Team #1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("18500936-fd11-4f4b-bb7c-854435c152a3"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("78542b41-01e6-477d-9d60-1dcb806a4f25"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("cddd43cd-916b-4e98-9057-9a8af37520ed"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("d12af04c-fd7d-4dd2-9198-28d9037160fc"));

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b15cd05-7e64-471d-9690-78d5e071856c"), "Team #2" },
                    { new Guid("af3a3ca9-796c-4e58-a05c-d1c9e1742f28"), "Team #4" },
                    { new Guid("b033d049-9958-462a-a410-683f857cfefd"), "Team #1" },
                    { new Guid("e8f6acd0-3530-4191-bdd8-cfd0de2e895c"), "Team #3" }
                });
        }
    }
}
