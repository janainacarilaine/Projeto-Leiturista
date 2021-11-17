using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Data.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tbl_usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnName("senha")
                .HasColumnType("VARCHAR(32)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.Funcao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("funcao")
                .HasColumnType("VARCHAR(50)");
  
        }
    }
}
