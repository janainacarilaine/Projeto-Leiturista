using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapeamentos
{
    public class LeituristaMapeamento : IEntityTypeConfiguration<Leiturista>
    {
        public void Configure(EntityTypeBuilder<Leiturista> builder)
        {
            builder.ToTable("tbl_leituristas");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Matricula)
                .IsRequired()
                .HasColumnName("matricula");

            builder.Property(l => l.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nome");

            builder.Property(l => l.Ativo)
                .IsRequired()
                .HasColumnName("ativo");

            builder.HasMany(l => l.Leituras)
                .WithOne(l => l.Leiturista)
                .HasForeignKey(l => l.LeituristaId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
