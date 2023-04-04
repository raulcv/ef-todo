using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_todo.Migrations
{
    /// <inheritdoc />
    public partial class ColumDoneTaskv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Done",
                table: "Task",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Done",
                table: "Task",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
