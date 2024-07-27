using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ElectroUG.Migrations
{
    /// <inheritdoc />
    public partial class creaciondB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carrito_User_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "carrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrito_UsuarioId",
                table: "carrito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_CarritoId",
                table: "producto",
                column: "CarritoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "carrito");
        }
    }
}
