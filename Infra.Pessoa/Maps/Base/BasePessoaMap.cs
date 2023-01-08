using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PessoaDomain = global::Pessoa.Domain.Entities.Pessoa;

namespace Infra.Pessoa.Maps.Base;

public class BasePessoaMap<TDomain> : IEntityTypeConfiguration<TDomain> 
    where TDomain : global::Pessoa.Domain.Entities.Pessoa
{
    private readonly string _tableName;
    
    public BasePessoaMap(string tableName = "")
    {
        _tableName = tableName;
    }

    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        if (!string.IsNullOrEmpty(_tableName))
            builder.ToTable(_tableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Pes_Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("Pes_Nome")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("Pes_Email")
            .IsRequired();

        builder.Property(x => x.Telefone)
            .HasColumnName("Pes_Telefone")
            .IsRequired();

        builder.Property(x => x.Tipo)
            .HasColumnName("Pes_Tipo")
            .IsRequired();

        builder.Property(x => x.CriadoEm)
            .HasColumnName("Pes_CriadoEm")
            .IsRequired();
        
        builder.Property(x => x.EnderecoId)
            .HasColumnName("End_EnderecoId")
            .IsRequired();
    }
}