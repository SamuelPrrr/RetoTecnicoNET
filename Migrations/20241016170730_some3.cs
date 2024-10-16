using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetoTecnico.Migrations
{
    /// <inheritdoc />
    public partial class some3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alhaja_Estatus_EstatusIdEstatus",
                table: "Alhaja");

            migrationBuilder.DropIndex(
                name: "IX_Alhaja_EstatusIdEstatus",
                table: "Alhaja");

            migrationBuilder.DropColumn(
                name: "EstatusIdEstatus",
                table: "Alhaja");

            migrationBuilder.CreateIndex(
                name: "IX_Alhaja_IdEstatus",
                table: "Alhaja",
                column: "IdEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Alhaja_Estatus_IdEstatus",
                table: "Alhaja",
                column: "IdEstatus",
                principalTable: "Estatus",
                principalColumn: "IdEstatus",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alhaja_Estatus_IdEstatus",
                table: "Alhaja");

            migrationBuilder.DropIndex(
                name: "IX_Alhaja_IdEstatus",
                table: "Alhaja");

            migrationBuilder.AddColumn<int>(
                name: "EstatusIdEstatus",
                table: "Alhaja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alhaja_EstatusIdEstatus",
                table: "Alhaja",
                column: "EstatusIdEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Alhaja_Estatus_EstatusIdEstatus",
                table: "Alhaja",
                column: "EstatusIdEstatus",
                principalTable: "Estatus",
                principalColumn: "IdEstatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
