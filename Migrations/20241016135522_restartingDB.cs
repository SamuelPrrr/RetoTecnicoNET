using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetoTecnico.Migrations
{
    /// <inheritdoc />
    public partial class restartingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.IdEstatus);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    ParametroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrecioGramo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoAcumulado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    limOperaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.ParametroID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alhaja",
                columns: table => new
                {
                    AlhajaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    FolioID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PesoKG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreOroMomento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorInteresMomento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoEmpeño = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoDeuda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaOperacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaLiquidacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdEstatus = table.Column<int>(type: "int", nullable: false),
                    EstatusIdEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alhaja", x => x.AlhajaID);
                    table.ForeignKey(
                        name: "FK_Alhaja_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alhaja_Estatus_EstatusIdEstatus",
                        column: x => x.EstatusIdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alhaja_ClienteID",
                table: "Alhaja",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Alhaja_EstatusIdEstatus",
                table: "Alhaja",
                column: "EstatusIdEstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alhaja");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
