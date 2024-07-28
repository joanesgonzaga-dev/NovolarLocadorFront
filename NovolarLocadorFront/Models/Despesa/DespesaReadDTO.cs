using NovolarLocadorFront.Models.Enums;

namespace NovolarLocadorFront.Models.Despesa
{
    public class DespesaReadDTO
    {
        public EnumTipoDeDespesa IdTipoDespesa { get; set; } //id_produto_prd
        public string Referencia { get; set; } //dt_referencia_imod
        //public DateTime Competencia { get; set; } //dt_competencia_imod
        public decimal Valor { get; set; } //vl_valor_imod
        public string Vencimento { get; set; } //dt_vencimento_recb
        public string DataPagamento { get; set; } //dt_liquidacao_recb

    }
}
