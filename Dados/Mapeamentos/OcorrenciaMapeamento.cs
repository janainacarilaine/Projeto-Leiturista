using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapeamentos
{
    public class OcorrenciaMapeamento : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("tbl_ocorrencias");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("descricao");

            builder.Property(o => o.PermiteLeitura)
                .IsRequired()
                .HasColumnName("permite_leitura");

            builder.Property(o => o.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,3)")
                .HasColumnName("valor");

             builder.HasMany(l => l.Leituras)
                .WithOne(l => l.Ocorrencia)
                .HasForeignKey(l => l.OcorrenciaId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
