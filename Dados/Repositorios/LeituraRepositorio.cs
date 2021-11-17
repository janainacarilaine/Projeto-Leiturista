using Business.Interfaces.Repositorios;
using Business.Modelos;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class LeituraRepositorio : BaseRepositorio<Leitura>, ILeituraRepositorio
    {
        public LeituraRepositorio(ContextoDb db) : base(db)
        {
        }


        public async override Task<Leitura> BuscarPorId(long id)
        {
            return await _db.Leituras.AsNoTracking()
               .Include(l => l.Leiturista)
               .Include(l => l.Ocorrencia)
               .FirstOrDefaultAsync(l => l.Id.Equals(id));
        }

        public async override Task<IEnumerable<Leitura>> BuscarTodos()
        {
            return await _db.Leituras.AsNoTracking()
                .Include(l => l.Leiturista)
                .Include(l => l.Ocorrencia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Leitura>> BuscarPorMesAno(int mes, int ano)
        {
            var leituras = await _db.Leituras.AsNoTracking()
                .Where(l => l.DataLeitura.Date.Month.Equals(mes) && (l.DataLeitura.Year.Equals(ano)))
                .Include(l => l.Leiturista)
                .Include(l => l.Ocorrencia)
                .ToListAsync();

            return leituras;
        }

        public async Task<IEnumerable<Leitura>> BuscarPorLeiturista(long matricula)
        {
            var leituras = await _db.Leituras.AsNoTracking().Where(l => l.Leiturista.Matricula.Equals(matricula))
                  .Include(l => l.Leiturista)
                  .Include(l => l.Ocorrencia)
                  .ToListAsync();

            return leituras;
        }

        public async Task<IEnumerable<Leitura>> BuscarPorOcorrencia(string descricao)
        {
            var leituras = await _db.Leituras.AsNoTracking().Where(l => l.Ocorrencia.Descricao.Equals(descricao))
                 .Include(l => l.Leiturista)
                 .Include(l => l.Ocorrencia)
                 .ToListAsync();

            return leituras;
        }
    }
}
