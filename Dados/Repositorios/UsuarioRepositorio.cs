using Business.Interfaces.Repositorios;
using Business.Modelos;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoDb db) : base(db)
        {
        }

        public async Task<IEnumerable<Usuario>> BuscarPorFuncao(string funcao)
        {
            return await Buscar(u => u.Funcao.Equals(funcao));
        }

        public async Task<IEnumerable<Usuario>> BuscarPorNome(string nome)
        {
            return await Buscar(u => u.Nome.StartsWith(nome));
        }

        public async Task<Usuario> BuscarPorEmailSenha(string email, string senha)
        {
            return await _db.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
