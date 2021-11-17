using Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositorios
{
    public interface IBaseRepositorio<T> where T : Base
    {
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado);

        Task<IEnumerable<T>> BuscarTodos();

        Task<T> BuscarPorId(long id);

        Task Adicionar(T entidade);

        Task Atualizar(T entidade);

        Task Deletar(long id);
    }
}
