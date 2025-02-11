namespace sistemaGestaoPizzaria.services
{
    public class ResultDto
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public int? TempoPreparo { get; set; }
    }
}