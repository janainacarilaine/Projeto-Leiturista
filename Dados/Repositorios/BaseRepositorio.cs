using Business.Interfaces.Repositorios;
using Business.Modelos;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : Base
    {
        protected readonly ContextoDb _db;
        protected readonly DbSet<T> _dbSet;

        public BaseRepositorio(ContextoDb db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task Adicionar(T entidade)
        {
            _dbSet.Add(entidade);
            await _db.SaveChangesAsync();
        }

        public async Task Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado)
        {
            return await _dbSet.AsNoTracking().Where(predicado).ToListAsync();
        }

        public async Task Deletar(long id)
        {
            _dbSet.Remove(await BuscarPorId(id));
            await _db.SaveChangesAsync();
        }

        public virtual async Task<T> BuscarPorId(long id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<IEnumerable<T>> BuscarTodos()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
    }
}
