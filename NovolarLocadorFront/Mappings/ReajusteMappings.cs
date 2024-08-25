using AutoMapper;
using NovolarLocadorFront.Models.ContratosAluguel;
using System.Globalization;

namespace NovolarLocadorFront.Mappings
{
    public class ReajusteMappings : Profile
    {
        public ReajusteMappings()
        {
			try
			{
				CreateMap<Reajuste, ReajusteDto>()
					.ForMember<int>(e => e.Id, options => options.MapFrom(input => string.IsNullOrEmpty(input.id_reajuste_conre) ? 0 : int.Parse(input.id_reajuste_conre)))
					.ForMember<DateTime>(e => e.DataReajuste, options => options.MapFrom(input => string.IsNullOrEmpty(input.dt_reajuste_conre) ? new DateTime(1900, 01, 01) : DateTime.ParseExact(input.dt_reajuste_conre, "MM/dd/yyyy" ,CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal)))
					.ForMember<decimal>(e => e.ValorAntigo, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_antigo_conre) ? 0M : decimal.Parse(input.vl_antigo_conre, CultureInfo.InvariantCulture)))
					.ForMember<decimal>(e => e.ValorNovo, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_novo_conre) ? 0M : decimal.Parse(input.vl_novo_conre, CultureInfo.InvariantCulture)));

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
