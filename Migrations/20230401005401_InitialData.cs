using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ef_todo.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1900, 1, 1, 5, 8, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deleted_at",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1900, 1, 1, 5, 8, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("fdbda192-37af-49e1-a125-21a5fa03e302"), null, "Personal Activities", 50 },
                    { new Guid("fdbda192-37af-49e1-a125-21a5fa03e3e8"), null, "Pendant Activities", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CategoryId", "Created_at", "Description", "Done", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("fdbda192-37af-49e1-a125-21a5fa03e3f4"), new Guid("fdbda192-37af-49e1-a125-21a5fa03e3e8"), new DateTime(2023, 4, 1, 0, 54, 1, 604, DateTimeKind.Utc).AddTicks(1880), "I need to go to the post office to get ticket and pay the ammount ehehe", "False", 1, "Pay Taxes in Lost country" },
                    { new Guid("fdbda192-37af-49e1-a125-21a5fa03e3f5"), new Guid("fdbda192-37af-49e1-a125-21a5fa03e302"), new DateTime(2023, 4, 1, 0, 54, 1, 604, DateTimeKind.Utc).AddTicks(1880), "I need to 10 kilometers", "False", 2, "Go to the Gym" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fdbda192-37af-49e1-a125-21a5fa03e3f4"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fdbda192-37af-49e1-a125-21a5fa03e3f5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fdbda192-37af-49e1-a125-21a5fa03e302"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fdbda192-37af-49e1-a125-21a5fa03e3e8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(1900, 1, 1, 5, 8, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deleted_at",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(1900, 1, 1, 5, 8, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
