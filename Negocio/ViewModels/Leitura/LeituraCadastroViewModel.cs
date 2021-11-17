namespace Business.ViewModels.Leitura
{
    public class LeituraCadastroViewModel
    {
        public long CodCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long? LeituraAtual { get; set; }
        public long LeituristaId { get; set; }
        public long OcorrenciaId { get; set; } = 1;
        public long Latitude { get; set; }
        public long Longitude { get; set; }       
    }
}
