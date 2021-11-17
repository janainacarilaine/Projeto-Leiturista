using Business.ViewModels.Ocorrencia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Servicos
{
    public interface IOcorrenciaServico
    {
        Task<IEnumerable<OcorrenciaViewModel>> BuscarTodas();

        Task<OcorrenciaViewModel> BuscarPorId(long id);

        Task<bool> Adicionar(OcorrenciaCadastroViewModel ocorrencia);

        Task<bool> Atualizar(OcorrenciaViewModel ocorrencia);

        Task<bool> Deletar(long id);

        Task<OcorrenciaViewModel> BuscarPorDescricao(string descricao);

        Task<IEnumerable<OcorrenciaViewModel>> BuscarListaOcorrenciasPorDescricao(string descricao);
    }
}
 