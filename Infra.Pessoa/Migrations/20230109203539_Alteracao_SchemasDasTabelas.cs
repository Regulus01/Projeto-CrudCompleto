using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Pessoa.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoSchemasDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Usuario");

            migrationBuilder.RenameTable(
                name: "PeJ_PessoaJuridica",
                newName: "PeJ_PessoaJuridica",
                newSchema: "Usuario");

            migrationBuilder.RenameTable(
                name: "PeF_PessoaFisica",
                newName: "PeF_PessoaFisica",
                newSchema: "Usuario");

            migrationBuilder.RenameTable(
                name: "End_Endereco",
                newName: "End_Endereco",
                newSchema: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PeJ_PessoaJuridica",
                schema: "Usuario",
                newName: "PeJ_PessoaJuridica");

            migrationBuilder.RenameTable(
                name: "PeF_PessoaFisica",
                schema: "Usuario",
                newName: "PeF_PessoaFisica");

            migrationBuilder.RenameTable(
                name: "End_Endereco",
                schema: "Usuario",
                newName: "End_Endereco");
        }
    }
}
