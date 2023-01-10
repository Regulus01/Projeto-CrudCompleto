using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuarioDomain = Domain.Authentication.Domain.Usuario;

namespace Infra.Usuario.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Domain.Authentication.Domain.Usuario>
{
    public void Configure(EntityTypeBuilder<UsuarioDomain> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Usu_Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Username)
            .HasColumnName("Usu_UserName");
        
        builder.Property(x => x.Password)
            .HasColumnName("Usu_Password");
        
        builder.Property(x => x.Role)
            .HasColumnName("Usu_Role");

        builder.ToTable("Usu_Usuario", "Usuario");
    }
}