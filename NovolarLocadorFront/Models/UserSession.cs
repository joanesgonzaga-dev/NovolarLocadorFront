using AutoMapper;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Mappings;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Utils;

namespace NovolarLocadorFront.Models
{
    public class UserSession
    {
        public Proprietario.Proprietario Proprietario { get; set; }
        public List<ImovelDTO> Imoveis { get; set; }
        public IImovelService _imovelService { get; set; } = null;
        IMapper _mapper { get; set; }
        ApplicationGlobals _applicationGlobals { get; set; }
        public UserSession(){
            _applicationGlobals = ServiceLocator._applicationGlobals;
        }
        private ImovelDTO RetornaImovelDTO(ProprietariosBeneficiarios beneficiario)
        {
            try
            {
                ImovelDTO imovelDTO = new ImovelDTO();
                Imovel.Imovel imovel = _imovelService.FindImovelByIdAsync(int.Parse(beneficiario.id_imovel_imo)).Result;

                if (imovel != null)
                {
                    imovelDTO =  _applicationGlobals._mapper.Map<ImovelDTO>(imovel);
                    DefineIconeImovel(int.Parse(imovel.st_tipo_imo), ref imovelDTO);
                }
                return imovelDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DefineIconeImovel(int numeroTipo, ref ImovelDTO imovelDto)
        {
            switch (numeroTipo)
            {
                case 1:
                    imovelDto.ImageUri = "/img/house.png";
                    break;
                case 4:
                    imovelDto.ImageUri = "/img/apartamento.jpg";
                    break;
                case 11:
                    imovelDto.ImageUri = "/img/salacomercial.png";
                    break;
                case 12:
                    imovelDto.ImageUri = "/img/loja.jpg";
                    break;
                default:
                    break;
            }
        }

        public void CarregaImoveis()
        {
            Imoveis = new List<ImovelDTO>();

            foreach (var beneficiario in Proprietario.proprietarios_beneficiarios)
            {
                if (string.IsNullOrEmpty(beneficiario.id_imovel_imo))
                {
                    continue;
                }
                Imoveis.Add(RetornaImovelDTO(beneficiario));
            }
        }

        
    }
}
