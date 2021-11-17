using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels.Usuario
{
    public class UsuarioLogadoViewModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Funcao { get; set; }

        public string Token { get; set; }
    }
}

