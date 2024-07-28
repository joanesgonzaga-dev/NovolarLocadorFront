using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using NovolarLocadorFront.Models.Imovel;

//using NovolarLocadorFront.Models.DeadEntities;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public class ImovelService : IImovelService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://novolarbackendapi.azurewebsites.net/Imoveis";
        //public string BasePath = "https://localhost:7288/Imoveis";
        public ImovelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Antigo Mock (Excluir)
        /*
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
                IS_ALUGADO = true,
                VL_VENAL_IMO = "R$ 580.000,00"

            };

            Locatario locatario1 = new Locatario
            {
                Nome = "MARIA DAS GRAÇAS DA SILVA",
                Email = "maria.gracas@gmail.com",
                Fone = "(91) 98888-0000",
                TipoPessoa = Models.Enums.TipoPessoa.PF,
                EstadoCivil = Models.Enums.EstadoCivil.Casado,
                CpfCnpj = "999.999.999-99",
                RgIe = "000000-0",
                IMG = "\\img\\clientes\\maga.jpg"
            };

            imovel1.Inquilino = locatario1;

            imovel1.VISTORIAS = new List<Vistoria>();

            Vistoria v1 = new Vistoria();
            v1.Id = 100;
            v1.Data = new System.DateTime(2024, 01, 15);
            v1.Imovel = imovel1;
            v1.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            v1.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v1.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v1.isVistoriaSalas = true;
            v1.isVistoriaSalasAprovada = true;
            v1.isVistoriaQuartos = true;
            v1.isVistoriaQuartosAprovada = true;
            v1.isVistoriaCozinha = true;
            v1.isVistoriaCozinhaAprovada = true;
            v1.isVistoriaBanheiro = true;
            v1.isVistoriaBanheiroAprovada = true;
            v1.isVistoriaAreaServico = true;
            v1.isVistoriaAreaServicoAprovada = true;
            v1.isVistoriaFachada = false;
            v1.isVistoriaFachadaAprovada = true;
            v1.isVistoriaGaragem = true;
            v1.isVistoriaGaragemAprovada = true;

            Vistoria v2 = new Vistoria();
            v2.Id = 200;
            v2.Data = new System.DateTime(2024, 02, 23);
            v2.Imovel = imovel1;
            v2.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            v2.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v2.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v2.isVistoriaSalas = true;
            v2.isVistoriaSalasAprovada = true;
            v2.isVistoriaQuartos = true;
            v2.isVistoriaQuartosAprovada = true;
            v2.isVistoriaCozinha = true;
            v2.isVistoriaCozinhaAprovada = true;
            v2.isVistoriaBanheiro = true;
            v2.isVistoriaBanheiroAprovada = true;
            v2.isVistoriaAreaServico = true;
            v2.isVistoriaAreaServicoAprovada = true;
            v2.isVistoriaFachada = false;
            v2.isVistoriaFachadaAprovada = true;
            v2.isVistoriaGaragem = true;
            v2.isVistoriaGaragemAprovada = true;

            Vistoria v3 = new Vistoria();
            v3.Id = 300;
            v3.Data = new System.DateTime(2024, 02, 15);
            v3.Imovel = imovel1;
            v3.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v3.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v3.OBS = "FOI DETECTADA A NECESSIDADE DE REPAROS NOS ARMARIOS EMBUTIDOS COZINHA";
            v3.isVistoriaSalas = true;
            v3.isVistoriaSalasAprovada = true;
            v3.isVistoriaQuartos = true;
            v3.isVistoriaQuartosAprovada = true;
            v3.isVistoriaCozinha = true;
            v3.isVistoriaCozinhaAprovada = true;
            v3.isVistoriaBanheiro = true;
            v3.isVistoriaBanheiroAprovada = true;
            v3.isVistoriaAreaServico = true;
            v3.isVistoriaAreaServicoAprovada = true;
            v3.isVistoriaFachada = false;
            v3.isVistoriaFachadaAprovada = true;
            v3.isVistoriaGaragem = true;
            v3.isVistoriaGaragemAprovada = true;


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
                IS_ALUGADO = true,
                VL_VENAL_IMO = "R$ 800.000,00"
            };

            Locatario locatario2 = new Locatario
            {
                Nome = "JOÃO FULANO DA COSTA",
                Email = "joao.fulano@gmail.com",
                Fone = "(91) 99999-1111",
                TipoPessoa = Models.Enums.TipoPessoa.PF,
                EstadoCivil = Models.Enums.EstadoCivil.Casado,
                CpfCnpj = "900.111.111-11",
                RgIe = "000001-0",
                IMG = "\\img\\clientes\\tio.png"
            };

            imovel2.Inquilino = locatario2;

            imovel2.VISTORIAS = new List<Vistoria>();

            Vistoria v4 = new Vistoria();
            v4.Id = 400;
            v4.Data = new System.DateTime(2024, 01, 15);
            v4.Imovel = imovel2;
            v4.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v4.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v4.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            v4.isVistoriaSalas = true;
            v4.isVistoriaSalasAprovada = true;
            v4.isVistoriaQuartos = true;
            v4.isVistoriaQuartosAprovada = true;
            v4.isVistoriaCozinha = true;
            v4.isVistoriaCozinhaAprovada = true;
            v4.isVistoriaBanheiro = true;
            v4.isVistoriaBanheiroAprovada = true;
            v4.isVistoriaAreaServico = true;
            v4.isVistoriaAreaServicoAprovada = true;
            v4.isVistoriaFachada = false;
            v4.isVistoriaFachadaAprovada = true;
            v4.isVistoriaGaragem = true;
            v4.isVistoriaGaragemAprovada = true;

            Vistoria v5 = new Vistoria();
            v5.Id = 500;
            v5.Data = new System.DateTime(2024, 02, 23);
            v5.Imovel = imovel2;
            v5.OBS = "GARAGEM APRESENTA DESGASTE NA PINTURA";
            v5.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v5.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v5.isVistoriaSalas = true;
            v5.isVistoriaSalasAprovada = true;
            v5.isVistoriaQuartos = true;
            v5.isVistoriaQuartosAprovada = true;
            v5.isVistoriaCozinha = true;
            v5.isVistoriaCozinhaAprovada = true;
            v5.isVistoriaBanheiro = true;
            v5.isVistoriaBanheiroAprovada = true;
            v5.isVistoriaAreaServico = true;
            v5.isVistoriaAreaServicoAprovada = true;
            v5.isVistoriaFachada = false;
            v5.isVistoriaFachadaAprovada = true;
            v5.isVistoriaGaragem = true;
            v5.isVistoriaGaragemAprovada = false;

            Vistoria v6 = new Vistoria();
            v6.Id = 600;
            v6.Data = new System.DateTime(2024, 07, 20);
            v6.TipoVistoria = Models.Enums.EnumTipoVistoria.Saida;
            v6.Status = Models.Enums.EnumStatusVistoria.Agendada;
            v6.Imovel = imovel2;
            v6.OBS = "VISTORIA AGENDADA COM A PRESENÇA DE CORRETOR";
            v6.isVistoriaSalas = false;
            v6.isVistoriaSalasAprovada = false;
            v6.isVistoriaQuartos = false;
            v6.isVistoriaQuartosAprovada = false;
            v6.isVistoriaCozinha = false;
            v6.isVistoriaCozinhaAprovada = false;
            v6.isVistoriaBanheiro = false;
            v6.isVistoriaBanheiroAprovada = false;
            v6.isVistoriaAreaServico = false;
            v6.isVistoriaAreaServicoAprovada = false;
            v6.isVistoriaFachada = false;
            v6.isVistoriaFachadaAprovada = false;
            v6.isVistoriaGaragem = false;
            v6.isVistoriaGaragemAprovada = false;


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
                IS_ALUGADO = false,
                VL_VENAL_IMO = "R$ 1.200.000,00"
            };

            Locatario locatario3 = new Locatario
            {
                Nome = "EMPRESA PRIVADA LTDA",
                Email = "empresa.privada@gmail.com",
                Fone = "(91) 91111-2222",
                TipoPessoa = Models.Enums.TipoPessoa.PJ,
                EstadoCivil = Models.Enums.EstadoCivil.Nenhum,
                CpfCnpj = "99.000.000/0001-00",
                RgIe = "155229875541",
                IMG = "\\img\\clientes\\ep.jpg"
            };

            imovel3.Inquilino = locatario3;

            imovel3.VISTORIAS = new List<Vistoria>();

            Vistoria v7 = new Vistoria();
            v7.Id = 700;
            v7.Data = new System.DateTime(2024, 01, 15);
            v7.Imovel = imovel3;
            v7.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v7.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v7.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            v7.isVistoriaSalas = true;
            v7.isVistoriaSalasAprovada = true;
            v7.isVistoriaQuartos = true;
            v7.isVistoriaQuartosAprovada = true;
            v7.isVistoriaCozinha = true;
            v7.isVistoriaCozinhaAprovada = true;
            v7.isVistoriaBanheiro = true;
            v7.isVistoriaBanheiroAprovada = true;
            v7.isVistoriaAreaServico = true;
            v7.isVistoriaAreaServicoAprovada = true;
            v7.isVistoriaFachada = false;
            v7.isVistoriaFachadaAprovada = true;
            v7.isVistoriaGaragem = true;
            v7.isVistoriaGaragemAprovada = true;

            Vistoria v8 = new Vistoria();
            v8.Id = 800;
            v8.Data = new System.DateTime(2024, 02, 23);
            v8.Imovel = imovel3;
            v8.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v8.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v8.OBS = "REALIZADO SEM NECESSIDADE DE REPAROS";
            v8.isVistoriaSalas = true;
            v8.isVistoriaSalasAprovada = true;
            v8.isVistoriaQuartos = true;
            v8.isVistoriaQuartosAprovada = true;
            v8.isVistoriaCozinha = true;
            v8.isVistoriaCozinhaAprovada = true;
            v8.isVistoriaBanheiro = true;
            v8.isVistoriaBanheiroAprovada = true;
            v8.isVistoriaAreaServico = true;
            v8.isVistoriaAreaServicoAprovada = true;
            v8.isVistoriaFachada = false;
            v8.isVistoriaFachadaAprovada = true;
            v8.isVistoriaGaragem = true;
            v8.isVistoriaGaragemAprovada = true;

            Vistoria v9 = new Vistoria();
            v9.Id = 900;
            v9.Data = new System.DateTime(2024, 02, 15);
            v9.Imovel = imovel3;
            v9.TipoVistoria = Models.Enums.EnumTipoVistoria.Entrada;
            v9.Status = Models.Enums.EnumStatusVistoria.Concluida;
            v9.OBS = "FOI DETECTADA A NECESSIDADE DE REPAROS NOS ARMARIOS EMBUTIDOS COZINHA";
            v9.isVistoriaSalas = true;
            v9.isVistoriaSalasAprovada = true;
            v9.isVistoriaQuartos = true;
            v9.isVistoriaQuartosAprovada = true;
            v9.isVistoriaCozinha = true;
            v9.isVistoriaCozinhaAprovada = true;
            v9.isVistoriaBanheiro = true;
            v9.isVistoriaBanheiroAprovada = true;
            v9.isVistoriaAreaServico = true;
            v9.isVistoriaAreaServicoAprovada = true;
            v9.isVistoriaFachada = false;
            v9.isVistoriaFachadaAprovada = true;
            v9.isVistoriaGaragem = true;
            v9.isVistoriaGaragemAprovada = true;

            imovel3.VISTORIAS.Add(v7);
            imovel3.VISTORIAS.Add(v8);
            imovel3.VISTORIAS.Add(v9);

            _imoveis.Add(imovel1);
            _imoveis.Add(imovel2);
            _imoveis.Add(imovel3);
        }
        */
        #endregion

        public List<Models.DeadEntities.Imovel> FindAllSync()
        {
            return null;
        }
        public async Task<Imovel> FindImovelByIdAsync(int id)
        {
            try
            {
                Uri url = new Uri(BasePath + "?id=" + id);
                var response = await _httpClient.GetAsync(url);
                var imov = await response.ReadContentAs<Imovel>();
                return imov;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
