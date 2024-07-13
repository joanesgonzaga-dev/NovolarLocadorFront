using AutoMapper;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Utils
{
    public class ApplicationGlobals
    {  
        public IDictionary<string, string> Bancos {  get; set; }
        public IMapper Mapper;
        public IImovelService _imovelService;
        public ApplicationGlobals(IMapper mapper, IImovelService imovelService)
        {
            _imovelService = imovelService;
            Mapper = mapper;
            InicializaDictionaryBancos();
            //CarregaImoveis();
        }
        public Proprietario Proprietario { get; set; }

        public List<ImovelDTO> Imoveis { get; set; }

        private void InicializaDictionaryBancos()
        {
            Bancos = new Dictionary<string, string>();

            Bancos.Add("000", "Selecionar");
            Bancos.Add("001","Banco do Brasil S.A");
            Bancos.Add("033", "Banco Santander (Brasil) S.A.");
            Bancos.Add("104", "Caixa Econômica Federal");
            Bancos.Add("237", "Banco Bradesco S.A.");
            Bancos.Add("341", "Itaú Unibanco S.A.");
            Bancos.Add("260", "Nu Pagamentos S.A.");
            Bancos.Add("336", "Banco C6 S.A.");
            Bancos.Add("77", "Banco Inter S.A.");
            Bancos.Add("422", "Banco Safra S.A.");
            Bancos.Add("623", "Banco Pan S.A.");
            Bancos.Add("197", "Stone Pagamentos S.A");
        }

        public void CarregaImoveis()
        {
            Imoveis = new List<ImovelDTO>();

            foreach (var beneficiario in Proprietario.proprietarios_beneficiarios)
            {
                if (string.IsNullOrEmpty( beneficiario.id_imovel_imo))
                {
                    continue;    
                }

                Imoveis.Add(RetornaImovelDTO(beneficiario));    
            }
        }

        private ImovelDTO RetornaImovelDTO(ProprietariosBeneficiarios beneficiario)
        {
            //fazer chamada a GetImovelByIdAsync();
            try
            {
                ImovelDTO imovelDTO = new ImovelDTO();
                NovolarLocadorFront.Models.Imovel.Imovel imovel = _imovelService.FindImovelByIdAsync(int.Parse(beneficiario.id_imovel_imo)).Result;

                if (imovel != null)
                {
                    imovelDTO = Mapper.Map<ImovelDTO>(imovel);
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
                        imovelDto.ImageUri = "/img/apartamento.png";
                        break;
                    case 11:
                        imovelDto.ImageUri = "/img/salacomercial.png";
                        break;
                    case 12:
                    imovelDto.ImageUri = "/img/loja.png";
                    break;
                default:
                        break;
                }
        }
    }
}
