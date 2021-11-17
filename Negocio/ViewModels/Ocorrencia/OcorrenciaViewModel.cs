namespace Business.ViewModels.Ocorrencia
{
    public class OcorrenciaViewModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public bool PermiteLeitura { get; set; }
        public decimal Valor { get; set; }
    }
}
