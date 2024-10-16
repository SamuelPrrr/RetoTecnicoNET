using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetoTecnico.Migrations
{
    /// <inheritdoc />
    public partial class atributoFaltante2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoDeuda",
                table: "Alhaja",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoDeuda",
                table: "Alhaja");
        }
    }
}
