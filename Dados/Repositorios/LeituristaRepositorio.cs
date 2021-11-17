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
    public class LeituristaRepositorio : BaseRepositorio<Leiturista>, ILeituristaRepositorio
    {
        public LeituristaRepositorio(ContextoDb db) : base(db)
        {
        }

        public async Task<Leiturista> BuscarPorMatricula(long matricula)
        {
            return await _dbSet.AsNoTracking().Where(l => l.Matricula.Equals(matricula)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Leiturista>> BuscarPorNome(string nome)
        {
            return await Buscar(l=> l.Nome.Contains(nome));
        }

        public async Task<IEnumerable<Leiturista>> BuscarPorStatus(bool status)
        {
           return await Buscar(l => l.Ativo.Equals(status));
        }
    }
}
