using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modelos
{
    public class Ocorrencia : Base
    {
        public string Descricao { get; set; }
        public bool PermiteLeitura { get; set; }
        public decimal Valor { get; set; }

        public IEnumerable<Leitura> Leituras { get; set; }
    }
}
