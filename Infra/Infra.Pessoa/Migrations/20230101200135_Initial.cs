using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Pessoa.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "End_Endereco",
                columns: table => new
                {
                    EndId = table.Column<Guid>(name: "End_Id", type: "uuid", nullable: false),
                    EndCep = table.Column<string>(name: "End_Cep", type: "character varying(8)", maxLength: 8, nullable: false),
                    EndLogradouro = table.Column<string>(name: "End_Logradouro", type: "text", nullable: false),
                    EndComplemento = table.Column<string>(name: "End_Complemento", type: "text", nullable: false),
                    EndBairro = table.Column<string>(name: "End_Bairro", type: "text", nullable: false),
                    EndUf = table.Column<string>(name: "End_Uf", type: "character varying(2)", maxLength: 2, nullable: false),
                    PessoaFisicaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PessoaJuridicaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesCriadoEm = table.Column<DateTime>(name: "Pes_CriadoEm", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_End_Endereco", x => x.EndId);
                });

            migrationBuilder.CreateTable(
                name: "PeF_PessoaFisica",
                columns: table => new
                {
                    PesId = table.Column<Guid>(name: "Pes_Id", type: "uuid", nullable: false),
                    PeFCpf = table.Column<string>(name: "PeF_Cpf", type: "character varying(11)", maxLength: 11, nullable: false),
                    PeFIdade = table.Column<string>(name: "PeF_Idade", type: "text", nullable: false),
                    PesCriadoEm = table.Column<DateTime>(name: "Pes_CriadoEm", type: "timestamp with time zone", nullable: false),
                    PesNome = table.Column<string>(name: "Pes_Nome", type: "text", nullable: false),
                    PesEmail = table.Column<string>(name: "Pes_Email", type: "text", nullable: false),
                    PesTelefone = table.Column<string>(name: "Pes_Telefone", type: "text", nullable: false),
                    PesTipo = table.Column<byte>(name: "Pes_Tipo", type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeF_PessoaFisica", x => x.PesId);
                    table.ForeignKey(
                        name: "FK_PeF_PessoaFisica_End_Endereco_Pes_Id",
                        column: x => x.PesId,
                        principalTable: "End_Endereco",
                        principalColumn: "End_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeJ_PessoaJuridica",
                columns: table => new
                {
                    PesId = table.Column<Guid>(name: "Pes_Id", type: "uuid", nullable: false),
                    PeJCnpj = table.Column<string>(name: "PeJ_Cnpj", type: "character varying(14)", maxLength: 14, nullable: false),
                    PesCriadoEm = table.Column<DateTime>(name: "Pes_CriadoEm", type: "timestamp with time zone", nullable: false),
                    PesNome = table.Column<string>(name: "Pes_Nome", type: "text", nullable: false),
                    PesEmail = table.Column<string>(name: "Pes_Email", type: "text", nullable: false),
                    PesTelefone = table.Column<string>(name: "Pes_Telefone", type: "text", nullable: false),
                    PesTipo = table.Column<byte>(name: "Pes_Tipo", type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeJ_PessoaJuridica", x => x.PesId);
                    table.ForeignKey(
                        name: "FK_PeJ_PessoaJuridica_End_Endereco_Pes_Id",
                        column: x => x.PesId,
                        principalTable: "End_Endereco",
                        principalColumn: "End_Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeF_PessoaFisica");

            migrationBuilder.DropTable(
                name: "PeJ_PessoaJuridica");

            migrationBuilder.DropTable(
                name: "End_Endereco");
        }
    }
}
