namespace NovolarLocadorFront.Models.ContratosAluguel
{
    public class ReajusteDto
    {
        public int Id { get; set; }
        public DateTime DataReajuste { get; set; }
        public decimal ValorAntigo { get; set; }
        public decimal ValorNovo { get; set; }

    }
}
