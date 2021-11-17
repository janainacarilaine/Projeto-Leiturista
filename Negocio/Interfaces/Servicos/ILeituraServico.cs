using Business.ViewModels.Leitura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Servicos
{
    public interface ILeituraServico
    {
        Task<IEnumerable<LeituraViewModel>> BuscarTodas();

        Task<LeituraViewModel> BuscarPorId(long id);

        Task<IEnumerable<LeituraViewModel>> BuscarPorLeiturista(long matricula);

        Task<IEnumerable<LeituraViewModel>> BuscarPorOcorrencia(string descricao);

        Task<IEnumerable<LeituraViewModel>> BuscarPorMesAno(int mes, int ano);

        Task Adicionar(LeituraCadastroViewModel leituraViewModel);

        Task Atualizar(LeituraAtualizacaoViewModel leituraViewModel);

        Task<bool> Deletar(long id);
    }
}
