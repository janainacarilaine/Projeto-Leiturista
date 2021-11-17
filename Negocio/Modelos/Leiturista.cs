using System.Collections.Generic;

namespace Business.Modelos
{
    public class Leiturista : Base
    {
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Leitura> Leituras { get; set; }
    }
}