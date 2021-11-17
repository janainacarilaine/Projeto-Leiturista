using Business.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class LeituraMapeamento : IEntityTypeConfiguration<Leitura>
    {
        public void Configure(EntityTypeBuilder<Leitura> builder)
        {
            builder.ToTable("tbl_leituras");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.LeituraAnterior)
                .IsRequired()
                .HasColumnName("leitura_anterior");

            builder.Property(l => l.LeituraAtual)
                .HasColumnName("leitura_atual");

            builder.Property(l => l.DataLeitura)
                .HasColumnName("data_leitura")
                .HasColumnType("datetime(0)");

            builder.Property(l => l.Latitude)
                .IsRequired()
                .HasColumnType("decimal(20,0)")
                .HasColumnName("latitude");

            builder.Property(l => l.Longitude)
               .IsRequired()
               .HasColumnType("decimal(20,0)")
               .HasColumnName("longitude");

            builder.Property(l => l.LeituristaId)
                .IsRequired()
                .HasColumnName("id_ leiturista");

            builder.Property(l => l.OcorrenciaId)
                .IsRequired()
                .HasColumnName("id_ocorrencia");

            builder.Property(l => l.CodCliente)
                .IsRequired()
                .HasColumnName("codigo_cliente");
    
        }
    }
}
