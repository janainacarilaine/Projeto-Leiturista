using Business.Interfaces;
using Business.Modelos;
using Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Servicos
{
    public abstract class NotificacaoServico
    {
        private readonly INotificador _notificador;

        protected NotificacaoServico(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<V,E>(V validacao, E entidade) where V : AbstractValidator<E> where E : Base
        {
            var validador = validacao.Validate(entidade);
            
            if (validador.IsValid) return true;

            Notificar(validador);

            return false;
        }
    }
}
