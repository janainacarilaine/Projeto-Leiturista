using Business.Modelos;
using Business.ViewModels;
using Business.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Servicos
{
    public interface IUsuarioServico
    {
        Task<bool> Adicionar(UsuarioCadastroViewModel usuarioViewModel);

        Task<bool> Atualizar(UsuarioAtualizacaoViewModel usuarioViewModel);

        Task<UsuarioExibicaoViewModel> BuscarPorId(long id);

        Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarTodos();

        Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorFuncao(string funcao);

        Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorNome(string nome);

        Task<bool> Deletar(long id);

        Task<UsuarioLogadoViewModel> Logar(UsuarioLoginViewModel usuarioLogin);

    }
}
