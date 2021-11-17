using Business.ViewModels.Leiturista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Servicos
{
    public interface ILeituristaServico
    {
        Task<bool> Adicionar(LeituristaCadastroViewModel leituristaViewModel);

        Task<bool> Atualizar(LeituristaCadastroViewModel leituristaViewModel);

        Task<bool> Deletar(long id);

        Task<IEnumerable<LeituristaViewModel>> BuscarPorNome(string nome);

        Task<IEnumerable<LeituristaViewModel>> BuscarTodos();

        Task<LeituristaViewModel> BuscarPorMatricula(long matricula);
        
        //Task<LeituristaViewModel> BuscarPorId(long id);
       
        Task<IEnumerable<LeituristaViewModel>> BuscarPorStatus(bool status);

    }
}
