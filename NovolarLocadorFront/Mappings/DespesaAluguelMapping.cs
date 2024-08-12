using AutoMapper;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;
using System.Globalization;

namespace NovolarLocadorFront.Mappings
{
    public class DespesaAluguelMapping : Profile
    {
        public DespesaAluguelMapping()
        {
			try
			{
				CreateMap<DespesaImovel, DespesaReadDTO>()
					.ForMember<EnumTipoDeDespesa>(e => e.IdTipoDespesa, options => options.MapFrom(input => string.IsNullOrEmpty(input.id_produto_prd) ? EnumTipoDeDespesa.Indefinido : (EnumTipoDeDespesa)int.Parse(input.id_produto_prd)))
					.ForMember<string>(e => e.Referencia, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_referencia_imod) ? string.Empty : input.dt_referencia_imod))
					.ForMember<decimal>(e => e.Valor, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_valor_imod) ? 0.0M : decimal.Parse(input.vl_valor_imod, CultureInfo.InvariantCulture)))
					.ForMember<string>(e => e.Vencimento, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_vencimento_recb) ? string.Empty : input.dt_vencimento_recb))
					.ForMember<string>(e => e.DataPagamento, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_liquidacao_recb) ? string.Empty : input.dt_liquidacao_recb))
					;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
