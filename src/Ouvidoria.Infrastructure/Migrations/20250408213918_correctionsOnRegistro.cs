using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ouvidoria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctionsOnRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Administradores_AdministradorId",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Cidadoes_AutorId",
                table: "Registros");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Registros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdministradorId",
                table: "Registros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Administradores_AdministradorId",
                table: "Registros",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Cidadoes_AutorId",
                table: "Registros",
                column: "AutorId",
                principalTable: "Cidadoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Administradores_AdministradorId",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Cidadoes_AutorId",
                table: "Registros");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Registros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdministradorId",
                table: "Registros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Administradores_AdministradorId",
                table: "Registros",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Cidadoes_AutorId",
                table: "Registros",
                column: "AutorId",
                principalTable: "Cidadoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
