using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;

namespace NovolarLocadorFront.Models.CaixaProprietario
{
    public class CaixaMes
    {
        public int ProprietarioId { get; set; }
        public int Ano { get; set; }
        public EnumMesesIndexados Mes { get; set; }
        public List<RepasseDTO> Repasses { get; set; }
        public decimal TotalRepasses { get; set; }

        public List<DespesaReadDTO> Despesas { get; set; }
        public decimal TotalDespesas { get; set; }
    }
}
