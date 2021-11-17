using Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Task<IEnumerable<Usuario>> BuscarPorFuncao(string funcao);

        Task<IEnumerable<Usuario>> BuscarPorNome(string nome);

        Task<Usuario> BuscarPorEmailSenha(string email, string senha);
    }
}
