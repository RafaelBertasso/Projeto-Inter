using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Inter.Migrations
{
    /// <inheritdoc />
    public partial class ExcludeServiceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Service_ServiceId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_ServiceId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "ClientServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "ClientServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_ServiceId",
                table: "Client",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Service_ServiceId",
                table: "Client",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId");
        }
    }
}
