using NovolarLocadorFront.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public class ImovelService : IImovelService
    {
        List<Imovel> _imoveis;
        public ImovelService()
        {
            _imoveis = new List<Imovel>();
            var imovel1 = new Imovel()
            {
                ID_IMOVEL_IMO = 200,
                ST_TIPO_IMO = Models.Enums.EnumTipoImovel.CasaEmCondominio,
                ST_CEP_IMO = "66000000",
                ST_ENDERECO_IMO = "AV. Gentil Bitencourt",
                ST_NUMERO_IMO = "8527",
                ST_BAIRRO_IMO = "São Brás",
                IMG_URL = "\\img\\saobras_belem.jpg",
                IS_ALUGADO = true
            };

            imovel1.VISTORIAS = new List<Vistoria>();

            Vistoria v1 = new Vistoria();
            v1.Id = 100;
            v1.Data = new System.DateTime(2024, 01, 15);
            v1.Imovel = imovel1;
            v1.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            
            Vistoria v2 = new Vistoria();
            v2.Id = 200;
            v2.Data = new System.DateTime(2024, 02, 23);
            v2.Imovel = imovel1;
            v2.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            
            Vistoria v3 = new Vistoria();
            v3.Id = 300;
            v3.Data = new System.DateTime(2024, 02, 15);
            v3.Imovel = imovel1;
            v3.OBS = "FOI DETECTADA A NECESSIDADE DE REPAROS NOS ARMARIOS EMBUTIDOS COZINHA";

            imovel1.VISTORIAS.Add(v1);
            imovel1.VISTORIAS.Add(v2);
            imovel1.VISTORIAS.Add(v3);

            //---------------------------------------------------------------------
            var imovel2 = new Imovel()
            {
                ID_IMOVEL_IMO = 300,
                ST_TIPO_IMO = Models.Enums.EnumTipoImovel.Casa,
                ST_CEP_IMO = "67000000",
                ST_ENDERECO_IMO = "TV. WE 65",
                ST_NUMERO_IMO = "558",
                ST_BAIRRO_IMO = "CIDADE NOVA",
                IMG_URL = "\\img\\cidadevelha_belem.jpg",
                IS_ALUGADO = true
            };

            imovel2.VISTORIAS = new List<Vistoria>();

            Vistoria v4 = new Vistoria();
            v4.Id = 400;
            v4.Data = new System.DateTime(2024, 01, 15);
            v4.Imovel = imovel2;
            v4.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";

            Vistoria v5 = new Vistoria();
            v5.Id = 500;
            v5.Data = new System.DateTime(2024, 02, 23);
            v5.Imovel = imovel2;
            v5.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";

            Vistoria v6 = new Vistoria();
            v6.Id = 600;
            v6.Data = new System.DateTime(2024, 02, 15);
            v6.Imovel = imovel2;
            v6.OBS = "NENHUMA OBSERVAÇÃO";

            imovel2.VISTORIAS.Add(v4);
            imovel2.VISTORIAS.Add(v5);
            imovel2.VISTORIAS.Add(v6);

            //---------------------------------------------------------------------
            var imovel3 = new Imovel()
            {
                ID_IMOVEL_IMO = 400,
                ST_TIPO_IMO = Models.Enums.EnumTipoImovel.Apartamento,
                ST_CEP_IMO = "65000000",
                ST_ENDERECO_IMO = "RUA NOVA",
                ST_NUMERO_IMO = "5050",
                ST_BAIRRO_IMO = "UMARIZAL",
                IMG_URL = "\\img\\marambaia_belem.jpg",
                IS_ALUGADO = false
            };

            imovel3.VISTORIAS = new List<Vistoria>();

            Vistoria v7 = new Vistoria();
            v7.Id = 700;
            v7.Data = new System.DateTime(2024, 01, 15);
            v7.Imovel = imovel3;
            v7.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";

            Vistoria v8 = new Vistoria();
            v8.Id = 800;
            v8.Data = new System.DateTime(2024, 02, 23);
            v8.Imovel = imovel3;
            v8.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";

            Vistoria v9 = new Vistoria();
            v9.Id = 900;
            v9.Data = new System.DateTime(2024, 02, 15);
            v9.Imovel = imovel3;
            v9.OBS = "FOI DETECTADA A NECESSIDADE DE REPAROS NOS ARMARIOS EMBUTIDOS COZINHA";

            imovel3.VISTORIAS.Add(v7);
            imovel3.VISTORIAS.Add(v8);
            imovel3.VISTORIAS.Add(v9);

            _imoveis.Add(imovel1);
            _imoveis.Add(imovel2);
            _imoveis.Add(imovel3);
        }
        public List<Imovel> FindAllSync()
        {
            return _imoveis;
        }

        public Imovel FindImovel(int id) {
            return _imoveis.Find(i => i.ID_IMOVEL_IMO == id);
        }
    }
}
