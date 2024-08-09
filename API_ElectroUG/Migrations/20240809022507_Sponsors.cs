using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ElectroUG.Migrations
{
    /// <inheritdoc />
    public partial class Sponsors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstaCompleto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinadores",
                columns: table => new
                {
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationSponsor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinadores", x => x.SponsorId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CarritoId",
                table: "Product",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PedidoId",
                table: "Product",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Carritos_CarritoId",
                table: "Product",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Pedidos_PedidoId",
                table: "Product",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Carritos_CarritoId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pedidos_PedidoId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Patrocinadores");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Product_CarritoId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_PedidoId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Product");
        }
    }
}
