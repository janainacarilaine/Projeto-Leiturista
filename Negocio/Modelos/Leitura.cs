using System;

namespace Business.Modelos
{
    public class Leitura : Base
    {
        public long CodCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long? LeituraAtual { get; set; }
        public long LeituristaId{ get; set; }
        public long OcorrenciaId { get; set; }        
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public DateTime DataLeitura { get; set; }
        public Leiturista Leiturista { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
    }
}