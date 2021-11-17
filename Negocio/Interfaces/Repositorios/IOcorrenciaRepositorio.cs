using Business.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositorios
{
    public interface IOcorrenciaRepositorio : IBaseRepositorio<Ocorrencia>
    {
        Task<Ocorrencia> BuscarOcorrenciaPorDescricao(string descricao);
        Task<IEnumerable<Ocorrencia>> BuscarListaOcorrenciasPorDescricao(string descricao);

        
    }
}
