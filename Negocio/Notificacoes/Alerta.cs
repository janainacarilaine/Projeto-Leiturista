using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Notificacoes
{
    public class Alerta
    {
        public string Mensagem { get; set; }

        public Alerta(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
