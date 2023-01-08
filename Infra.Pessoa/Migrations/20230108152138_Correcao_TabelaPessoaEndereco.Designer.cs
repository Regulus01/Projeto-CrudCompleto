﻿// <auto-generated />
using System;
using Infra.Pessoa.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Pessoa.Migrations
{
    [DbContext(typeof(PessoaContext))]
    [Migration("20230108152138_Correcao_TabelaPessoaEndereco")]
    partial class CorrecaoTabelaPessoaEndereco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pessoa.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("End_Id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("End_Bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("End_Cep");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("End_Complemento");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("End_Logradouro");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("End_Uf");

                    b.HasKey("Id");

                    b.ToTable("End_Endereco", (string)null);
                });

            modelBuilder.Entity("Pessoa.Domain.Entities.PessoaFisica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Pes_Id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("PeF_Cpf");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Pes_CriadoEm");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Email");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uuid")
                        .HasColumnName("End_EnderecoId");

                    b.Property<string>("Idade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PeF_Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Telefone");

                    b.Property<byte>("Tipo")
                        .HasColumnType("smallint")
                        .HasColumnName("Pes_Tipo");

                    b.HasKey("Id");

                    b.ToTable("PeF_PessoaFisica", (string)null);
                });

            modelBuilder.Entity("Pessoa.Domain.Entities.PessoaJuridica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Pes_Id");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("PeJ_Cnpj");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Pes_CriadoEm");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Email");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uuid")
                        .HasColumnName("End_EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pes_Telefone");

                    b.Property<byte>("Tipo")
                        .HasColumnType("smallint")
                        .HasColumnName("Pes_Tipo");

                    b.HasKey("Id");

                    b.ToTable("PeJ_PessoaJuridica", (string)null);
                });

            modelBuilder.Entity("Pessoa.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("Pessoa.Domain.Entities.PessoaFisica", "PessoaFisica")
                        .WithOne("Endereco")
                        .HasForeignKey("Pessoa.Domain.Entities.Endereco", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pessoa.Domain.Entities.PessoaJuridica", "PessoaJuridica")
                        .WithOne("Endereco")
                        .HasForeignKey("Pessoa.Domain.Entities.Endereco", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");

                    b.Navigation("PessoaJuridica");
                });

            modelBuilder.Entity("Pessoa.Domain.Entities.PessoaFisica", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("Pessoa.Domain.Entities.PessoaJuridica", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}