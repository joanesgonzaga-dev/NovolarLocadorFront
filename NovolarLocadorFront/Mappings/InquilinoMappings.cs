using AutoMapper;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Locatario;

namespace NovolarLocadorFront.Mappings
{
    public class InquilinoMappings : Profile
    {
        public InquilinoMappings()
        {
            try
            {
                CreateMap<Inquilino, InquilinoDTO>()
                .ForMember<int>(e => e.Id, options => options.MapFrom(input => input.id_pessoa_pes))
                .ForMember<int>(e => e.isPrincipal, options => options.MapFrom(input => input.fl_principal_inq))
                .ForMember<string>(e => e.Nome, options => options.MapFrom(input => input.st_nome_pes))
                .ForMember<int>(e => e.Sexo, options => options.MapFrom(input => input.st_sexo_pes))
                .ForMember<string>(e => e.NomeFantasia, options => options.MapFrom(input => input.st_fantasia_pes))
                .ForMember<string>(e => e.Cnpj, options => options.MapFrom(input => input.st_cnpj_pes))
                .ForMember<string>(e => e.Rg, options => options.MapFrom(input => input.st_rg_pes))
                .ForMember<string>(e => e.OrgaoEmissor, options => options.MapFrom(input => input.st_orgao_pes))
                .ForMember<string>(e => e.Ie, options => options.MapFrom(input => input.st_ie_pes))
                .ForMember<string>(e => e.Logradouro, options => options.MapFrom(input => input.st_endereco_pes))
                .ForMember<string>(e => e.Numero, options => options.MapFrom(input => input.st_numero_pes))
                .ForMember<string>(e => e.Complemento, options => options.MapFrom(input => input.st_complemento_pes))
                .ForMember<string>(e => e.Cidade, options => options.MapFrom(input => input.st_cidade_pes))
                .ForMember<string>(e => e.Bairro, options => options.MapFrom(input => input.st_bairro_pes))
                .ForMember<string>(e => e.Estado, options => options.MapFrom(input => input.st_estado_pes))
                .ForMember<string>(e => e.Cep, options => options.MapFrom(input => input.st_cep_pes))
                .ForMember<string>(e => e.Telefone, options => options.MapFrom(input => input.st_telefone_pes))
                .ForMember<string>(e => e.Celular, options => options.MapFrom(input => input.st_celular_pes))
                .ForMember<string>(e => e.Email, options => options.MapFrom(input => input.st_email_pes))
                .ForMember<int>(e => e.IdContrato, options => options.MapFrom(input => input.id_contrato_con))
                ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
