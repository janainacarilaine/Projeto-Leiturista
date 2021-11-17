using Business.ViewModels.Leiturista;
using Business.ViewModels.Ocorrencia;
using System;

namespace Business.ViewModels.Leitura
{
    public class LeituraViewModel
    {
        public long Id { get; set; }
        public long CodCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long? LeituraAtual { get; set; }
        public LeituristaViewModel LeituristaViewModel { get; set; }
        public OcorrenciaViewModel OcorrenciaViewModel { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public DateTime DataLeitura { get; set; }

    }
}
