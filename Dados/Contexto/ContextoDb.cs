using Business.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions options): base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Leitura> Leituras { get; set; }
        public DbSet<Leiturista> Leituristas { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoDb).Assembly);
        }
    }

}
