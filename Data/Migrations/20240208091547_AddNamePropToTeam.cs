using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tickets.Migrations
{
    /// <inheritdoc />
    public partial class AddNamePropToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5253277f-2d8a-4b2b-b734-fb721cd90036"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("8059ce3c-6f3f-4ba1-8b48-e1e00a10c527"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("f4faf8d9-0e73-4c83-9ac4-b50844ee33c0"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teams");

            migrationBuilder.InsertData(
                table: "Teams",
                column: "Id",
                values: new object[]
                {
                    new Guid("5253277f-2d8a-4b2b-b734-fb721cd90036"),
                    new Guid("8059ce3c-6f3f-4ba1-8b48-e1e00a10c527"),
                    new Guid("f4faf8d9-0e73-4c83-9ac4-b50844ee33c0")
                });
        }
    }
}
