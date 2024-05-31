using NovolarLocadorFront.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public class LocadorService : ILocadorService
    {
        public async Task<List<Locador>> GetAllAsync()
        {
            List<Locador> locadores = new List<Locador>();

            Locador locador1 = new Locador();
            locador1.ID_PESSOA_PE = 100;
            locador1.ST_NOME_PES = "MARIA DAS GRAÇAS";
            locador1.TIPO_PESSOA = Models.Enums.EnumTipoPessoa.PF;
            locador1.ST_CNPJ_PES = "99999999999";
            locador1.ST_FANTASIA_PES = string.Empty;
            locador1.ST_CELULAR_PES = "(91)980808080";
            locador1.ST_TELEFONE_PES = string.Empty;
            locador1.ST_EMAIL_PES = "mariadasgracas@meudominio.com";
            locador1.ID_FORMA_PAG = Models.Enums.EnumFormasDePagamento.TransferenciaBancaria;
            locador1.ST_RG_PES = "546892167";
            locador1.ST_ORGÃO_PES = "SEGUP-PA";
            locador1.ST_SEXO_PES = Models.Enums.EnumSexo.Feminino;
            locador1.DT_NASCIMENTO_PES = new System.DateTime(1952, 08, 22);
            locador1.ST_NACIONALIDADE_PES = "Brasileira";
            locador1.FL_NAODOMICILIADO_PES = false;
            locador1.ST_CEP_PES = "66000000";
            locador1.ST_ENDERECO_PES = "Travessa da Paz";
            locador1.ST_NUMERO_PES = "777A";
            locador1.ST_BAIRRO_PES = "Bom Jesus";
            locador1.ST_CIDADE_PES = "Santo Amaro";
            locador1.ST_ESTADO_PES = "PA";
            locador1.FL_RETERISSQN_PES = false;
            locador1.ST_OBSERVACAO_PES = "Cliente VIP";
            locador1.FL_PROPRIETARIOBENEFICIARIO_PES = false;

            locadores.Add(locador1);



            return locadores;
        }
    }
}
