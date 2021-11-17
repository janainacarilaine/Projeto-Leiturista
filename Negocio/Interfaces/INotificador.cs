using Business.Notificacoes;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        bool TemAlerta();

        List<Notificacao> ObterNotificacoes();

        List<Alerta> ObterAlertas();

        void AdicionarNotificacao(Notificacao notificacao);

        void AdicionarAlerta(Alerta alerta);
    }
}
