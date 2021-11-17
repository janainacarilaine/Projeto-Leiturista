using Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;
        private readonly List<Alerta> _alertas;
        

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
            _alertas = new List<Alerta>();
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
           _notificacoes.Add(notificacao);
        }

         public void AdicionarAlerta(Alerta alerta)
        {
           _alertas.Add(alerta);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public List<Alerta> ObterAlertas()
        {
            return _alertas;
        }

        public bool TemNotificacao()
        {
           return _notificacoes.Any();
        }

        public bool TemAlerta()
        {
           return _alertas.Any();
        }


              
    }
}
