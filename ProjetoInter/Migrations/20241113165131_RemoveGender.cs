using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Inter.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
