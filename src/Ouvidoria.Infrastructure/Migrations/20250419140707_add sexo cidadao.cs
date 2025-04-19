using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ouvidoria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addsexocidadao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Cidadoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Cidadoes");
        }
    }
}
