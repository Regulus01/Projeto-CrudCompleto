using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Pessoa.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoAlteraTabelasPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeF_PessoaFisica_End_Endereco_Pes_Id",
                table: "PeF_PessoaFisica");

            migrationBuilder.DropForeignKey(
                name: "FK_PeJ_PessoaJuridica_End_Endereco_Pes_Id",
                table: "PeJ_PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Pes_CriadoEm",
                table: "End_Endereco");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "End_Endereco");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                table: "End_Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "End_EnderecoId",
                table: "PeJ_PessoaJuridica",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "End_EnderecoId",
                table: "PeF_PessoaFisica",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PeJ_PessoaJuridica_End_EnderecoId",
                table: "PeJ_PessoaJuridica",
                column: "End_EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeF_PessoaFisica_End_EnderecoId",
                table: "PeF_PessoaFisica",
                column: "End_EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PeF_PessoaFisica_End_Endereco_End_EnderecoId",
                table: "PeF_PessoaFisica",
                column: "End_EnderecoId",
                principalTable: "End_Endereco",
                principalColumn: "End_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeJ_PessoaJuridica_End_Endereco_End_EnderecoId",
                table: "PeJ_PessoaJuridica",
                column: "End_EnderecoId",
                principalTable: "End_Endereco",
                principalColumn: "End_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeF_PessoaFisica_End_Endereco_End_EnderecoId",
                table: "PeF_PessoaFisica");

            migrationBuilder.DropForeignKey(
                name: "FK_PeJ_PessoaJuridica_End_Endereco_End_EnderecoId",
                table: "PeJ_PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PeJ_PessoaJuridica_End_EnderecoId",
                table: "PeJ_PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PeF_PessoaFisica_End_EnderecoId",
                table: "PeF_PessoaFisica");

            migrationBuilder.DropColumn(
                name: "End_EnderecoId",
                table: "PeJ_PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "End_EnderecoId",
                table: "PeF_PessoaFisica");

            migrationBuilder.AddColumn<DateTime>(
                name: "Pes_CriadoEm",
                table: "End_Endereco",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaFisicaId",
                table: "End_Endereco",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaJuridicaId",
                table: "End_Endereco",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PeF_PessoaFisica_End_Endereco_Pes_Id",
                table: "PeF_PessoaFisica",
                column: "Pes_Id",
                principalTable: "End_Endereco",
                principalColumn: "End_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeJ_PessoaJuridica_End_Endereco_Pes_Id",
                table: "PeJ_PessoaJuridica",
                column: "Pes_Id",
                principalTable: "End_Endereco",
                principalColumn: "End_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
