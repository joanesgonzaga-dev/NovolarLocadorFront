using AutoMapper;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Imovel;
using NovolarLocadorFront.Models.Proprietario;
using System.Globalization;
namespace NovolarLocadorFront.Mappings
{
    public class ImovelMapping : Profile
    {
        public ImovelMapping()
        {
            try
            {
                CreateMap<Imovel, ImovelDTO>()
            .ForMember<int>(e => e.Id, options => options.MapFrom(input => string.IsNullOrEmpty(input.id_imovel_imo) ? -1 : int.Parse(input.id_imovel_imo)))
            .ForMember<decimal>(e => e.ValorAluguel, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_aluguel_imo) ? 0.0M : decimal.Parse(input.vl_aluguel_imo, CultureInfo.InvariantCulture)))
            .ForMember<decimal>(e => e.ValorCondominio, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_condominio_imo) ? 0.0M : decimal.Parse(input.vl_condominio_imo, CultureInfo.InvariantCulture)))
            .ForMember<decimal>(e => e.ValorParcelaIptu, options => options.MapFrom(input => string.IsNullOrEmpty(input.vl_parcelaiptu_imo) ? 0.0M : decimal.Parse(input.vl_parcelaiptu_imo, CultureInfo.InvariantCulture)))
            //.ForMember<decimal>(e => e.ValorAluguel, options => options.MapFrom(input => input.vl_aluguel_imo))
            .ForMember<int>(e => e.TipoImovel, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_tipo_imo) ? -1 : int.Parse(input.st_tipo_imo)))
            .ForMember<string>(e => e.CodigoIptu, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_codigoiptu_imo) ? -1 : int.Parse(input.st_codigoiptu_imo)))
            .ForMember<int>(e => e.NumeroParcelasIptu, options => options.MapFrom(input => string.IsNullOrEmpty(input.nm_parcelasiptu_imo) ? "0" : input.nm_parcelasiptu_imo))
            .ForMember<int>(e => e.ResponsavelCondominio, options => options.MapFrom(input => string.IsNullOrEmpty(input.fl_responsavelcondominio_imo) ? -1 : int.Parse(input.fl_responsavelcondominio_imo)))
            .ForMember<string>(e => e.Logradouro, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_endereco_imo) ? string.Empty : input.st_endereco_imo))
            .ForMember<string>(e => e.Numero, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_numero_imo) ? string.Empty : input.st_numero_imo))
            .ForMember<string>(e => e.Complemento, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_complemento_imo) ? string.Empty : input.st_complemento_imo))
            .ForMember<string>(e => e.Bairro, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_bairro_imo) ? string.Empty : input.st_bairro_imo))
            .ForMember<string>(e => e.Cidade, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_cidade_imo) ? string.Empty : input.st_cidade_imo))
            .ForMember<string>(e => e.Estado, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_estado_imo) ? string.Empty : input.st_estado_imo))
            .ForMember<string>(e => e.Cep, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_cep_imo) ? string.Empty : input.st_cep_imo))
            .ForMember<string>(e => e.CodigoAgua, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_codagua_imo) ? string.Empty : input.st_codagua_imo))
            .ForMember<string>(e => e.CodigoEnergia, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_codenergia_imo) ? string.Empty : input.st_codenergia_imo))
            .ForMember<string>(e => e.OBS, options => options.MapFrom(input => string.IsNullOrEmpty(input.st_observacao_imo) ? string.Empty : input.st_observacao_imo))
            .ForMember<decimal>(e => e.TaxaAdministracao, options => options.MapFrom(input => string.IsNullOrEmpty(input.fl_txadmvalorfixo_imo) ? 0.0M : decimal.Parse(input.fl_txadmvalorfixo_imo)))
            .ForMember<int>(e => e.isLocado, options => options.MapFrom(input => string.IsNullOrEmpty(input.situacao_imovel) ? -1 : int.Parse(input.situacao_imovel)))
            .ForMember<List<InquilinoDTO>>(e => e.Inquilinos, options => options.MapFrom(input => input.inquilinos))
            .ForMember<List<Contrato>>(e => e.Contratos, options => options.MapFrom(input => input.contratos))
            ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
