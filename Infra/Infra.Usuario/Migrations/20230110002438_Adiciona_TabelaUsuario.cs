using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Usuario.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Usuario");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Usuario",
                columns: table => new
                {
                    UsuId = table.Column<int>(name: "Usu_Id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuUserName = table.Column<string>(name: "Usu_UserName", type: "text", nullable: false),
                    UsuPassword = table.Column<string>(name: "Usu_Password", type: "text", nullable: false),
                    UsuRole = table.Column<string>(name: "Usu_Role", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Usuario");
        }
    }
}
