using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ElectroUG.Migrations
{
    /// <inheritdoc />
    public partial class Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Localization",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
