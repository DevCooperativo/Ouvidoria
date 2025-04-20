using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ouvidoria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsAnonima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnonima",
                table: "Registros",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnonima",
                table: "Registros");
        }
    }
}
