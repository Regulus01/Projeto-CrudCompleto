using Infra.Pessoa.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Maps;

public class PessoaFisicaMap : BasePessoaMap<PessoaFisica>
{
    public PessoaFisicaMap() : base("PeF_PessoaFisica")
    {
    }

    public override void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Cpf)
            .HasColumnName("PeF_Cpf")
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(x => x.Idade)
            .HasColumnName("PeF_Idade")
            .IsRequired();
    }
}