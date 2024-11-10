using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Inter.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ClientServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ClientServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
