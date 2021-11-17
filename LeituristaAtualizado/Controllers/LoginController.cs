using Business.Interfaces;
using Business.Interfaces.Servicos;
using Business.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("login")]
    public class LoginController : NotificadorController
    {
        private readonly IUsuarioServico _usuarioServico;

        public LoginController(IUsuarioServico usuarioServico, INotificador notificador) : base(notificador)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticar(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            var usuarioLogado = await _usuarioServico.Logar(usuarioLogin);

            return RespostaCustomizada(usuarioLogado);
        }


    }
}
