using Infra.Pessoa.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Maps;

public class PessoaJuridicaMap : BasePessoaMap<PessoaJuridica>
{
    public PessoaJuridicaMap() : base("PeJ_PessoaJuridica")
    {
    }

    public override void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Cnpj)
            .HasColumnName("PeJ_Cnpj")
            .HasMaxLength(14)
            .IsRequired();
        
        builder.Property(x => x.EnderecoId)
            .HasColumnName("End_EnderecoId");
    }
}