using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ElectroUG.Migrations
{
    /// <inheritdoc />
    public partial class SupplierAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisable",
                table: "User",
                newName: "IsDisabled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                table: "User",
                newName: "IsDisable");
        }
    }
}
