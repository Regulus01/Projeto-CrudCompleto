using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Usuario.Migrations
{
    /// <inheritdoc />
    public partial class AlteraNomeTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                schema: "Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                schema: "Usuario",
                newName: "Usu_Usuario",
                newSchema: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usu_Usuario",
                schema: "Usuario",
                table: "Usu_Usuario",
                column: "Usu_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usu_Usuario",
                schema: "Usuario",
                table: "Usu_Usuario");

            migrationBuilder.RenameTable(
                name: "Usu_Usuario",
                schema: "Usuario",
                newName: "Usuario",
                newSchema: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                schema: "Usuario",
                table: "Usuario",
                column: "Usu_Id");
        }
    }
}
