using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ElectroUG.Migrations
{
    /// <inheritdoc />
    public partial class ProductImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImgUrl",
                table: "Product",
                newName: "ProductImg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImg",
                table: "Product",
                newName: "ProductImgUrl");
        }
    }
}
