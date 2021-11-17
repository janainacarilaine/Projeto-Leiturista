using Business.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositorios
{
    public interface ILeituristaRepositorio : IBaseRepositorio<Leiturista>
    {
        Task<IEnumerable<Leiturista>> BuscarPorNome(string nome);

        Task<Leiturista> BuscarPorMatricula(long matricula);

        Task<IEnumerable<Leiturista>> BuscarPorStatus(bool status);        
    }
}
