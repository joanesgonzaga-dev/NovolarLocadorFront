using AutoMapper;
using NovolarLocadorFront.Models.Despesa;
using System.Globalization;

namespace NovolarLocadorFront.Mappings
{
    public class RepasseMapping : Profile
    {
        public RepasseMapping()
        {
			try
			{
				CreateMap<DespesaImobiliaria, RepasseDTO>()
					.ForMember<int>(e => e.CodigoFavorecido, options => options.MapFrom(input => string.IsNullOrEmpty(input.id_favorecido_fav) ? -1 : int.Parse(input.id_favorecido_fav)))
					.ForMember<bool>(e => e.isRecebimento, options => options.MapFrom(input => string.IsNullOrEmpty(input.isrecebimento) ? default(bool) : (input.isrecebimento.Equals("1") ? true : false) ))
					.ForMember<string>(e => e.Vencimento, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_vencimentooriginal_mov) ? string.Empty : input.dt_vencimentooriginal_mov))
                    .ForMember<string>(e => e.DataRecebimento, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_liquidacao_mov) ? string.Empty : input.dt_liquidacao_mov))
                    .ForMember<int>(e => e.StatusRepasse, options => options.MapFrom(input => string.IsNullOrEmpty(input.fl_status_mov) ? default(int) : int.Parse(input.fl_status_mov)))
                    .ForMember<decimal>(e => e.ValorRepasse, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_valor_mov) ? default(decimal) : decimal.Parse(input.vl_valor_mov, CultureInfo.InvariantCulture)))
                    ;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
