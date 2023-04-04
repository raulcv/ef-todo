using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_todo.Migrations
{
    /// <inheritdoc />
    public partial class ColumScaleCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Scale",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scale",
                table: "Category");
        }
    }
}
