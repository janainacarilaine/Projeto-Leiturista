using Business.Interfaces;
using Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    public abstract class NotificadorController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected NotificadorController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool ValidarOperacao()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult RespostaCustomizada(object resultado = null)
        {
            if (ValidarOperacao())
            {
                if (_notificador.TemAlerta())
                {
                    return Ok(new
                    {
                        sucesso = true,
                        alertas = _notificador.ObterAlertas().Select(a => a.Mensagem),
                        dados = resultado
                    });

                }

                return Ok(new
                {
                    sucesso = true,
                    dados = resultado
                });

            }

            return BadRequest(new
            {
                sucesso = false,
                erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult RespostaCustomizada(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return RespostaCustomizada();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var mensagemErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(mensagemErro);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }
    }
}
