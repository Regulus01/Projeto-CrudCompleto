using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Maps;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("End_Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Bairro)
            .HasColumnName("End_Bairro");

        builder.Property(x => x.Cep)
            .HasColumnName("End_Cep")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.Uf)
            .HasColumnName("End_Uf")
            .HasMaxLength(2);

        builder.Property(x => x.Complemento)
            .HasColumnName("End_Complemento");

        builder.Property(x => x.Logradouro)
            .HasColumnName("End_Logradouro");
        
        builder.Property(x => x.CriadoEm)
            .HasColumnName("Pes_CriadoEm")
            .IsRequired();

        builder.ToTable("End_Endereco");
    }
}