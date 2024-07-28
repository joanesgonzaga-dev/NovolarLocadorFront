using AutoMapper;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using System.Security.Policy;
using System;
using System.Threading.Tasks;
using NovolarLocadorFront.Mappings;

namespace NovolarLocadorFront.Globals
{
    public class ApplicationGlobals
    {
        public IDictionary<string, string> Bancos { get; set; }
        public IMapper _mapper { get; set; }
        public ApplicationGlobals()
        {
            InicializaDictionaryBancos();

            ConfiguraMapeamentos();
        }
        private void InicializaDictionaryBancos()
        {
            Bancos = new Dictionary<string, string>();

            Bancos.Add("000", "Selecionar");
            Bancos.Add("001", "Banco do Brasil S.A");
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

        private void ConfiguraMapeamentos()
        {

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<ImovelMapping>();
                cfg.AddProfile<InquilinoMappings>();
                cfg.AddProfile<DespesaAluguelMapping>();
            });
            //_imovelService = new ImovelService(new HttpClient());
            _mapper = new Mapper(mapConfig);
        }

    }
}
