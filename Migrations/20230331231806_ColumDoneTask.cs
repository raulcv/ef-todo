using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_todo.Migrations
{
    /// <inheritdoc />
    public partial class ColumDoneTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Scale",
                table: "Category",
                newName: "Weight");

            migrationBuilder.AddColumn<double>(
                name: "Done",
                table: "Task",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Category",
                newName: "Scale");
        }
    }
}
