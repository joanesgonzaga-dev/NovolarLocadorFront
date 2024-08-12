namespace NovolarLocadorFront.Models.Despesa
{
    public class Root
    {
        public string status { get; set; }
        public string session { get; set; }
        public string msg { get; set; }
        public List<DespesaImovel> data { get; set; }
        public string executiontime { get; set; }
    }
}
