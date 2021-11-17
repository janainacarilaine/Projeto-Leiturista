using Business.Interfaces.Repositorios;
using Business.Modelos;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class OcorrenciaRepositorio : BaseRepositorio<Ocorrencia>, IOcorrenciaRepositorio
    {
        public OcorrenciaRepositorio(ContextoDb db) : base(db)
        {
        }

        public async Task<IEnumerable<Ocorrencia>> BuscarListaOcorrenciasPorDescricao(string descricao)
        {
            return await Buscar(o => o.Descricao.Contains(descricao));
        }

        public async Task<Ocorrencia> BuscarOcorrenciaPorDescricao(string descricao)
        {
            return await _db.Ocorrencias.AsNoTracking().Where(o => o.Descricao.Equals(descricao)).FirstOrDefaultAsync();
        }

    }
}
