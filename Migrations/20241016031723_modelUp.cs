using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetoTecnico.Migrations
{
    /// <inheritdoc />
    public partial class modelUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PorInteresMomento",
                table: "Alhaja",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PreOroMomento",
                table: "Alhaja",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorInteresMomento",
                table: "Alhaja");

            migrationBuilder.DropColumn(
                name: "PreOroMomento",
                table: "Alhaja");
        }
    }
}
