using System.Runtime.ConstrainedExecution;
using System;
using NovolarLocadorFront.Models.Enums;
using System.Collections.Generic;

namespace NovolarLocadorFront.Models
{
    /// <summary>
    /// Representa o objeto de um contrato imobiliário
    /// </summary>
    public class Imovel
    {

        ///<value>required number Id do imóvel.</value>
        public int ID_IMOVEL_IMO { get; set; }

        ///<value>required string Tipo de imóvel como por exemplo: 1: Casa, 2: Casa em condomínio, 3: Casa comercial, 4: Apartamento, 5: Cobertura, 6: Flat..</value>
        public EnumTipoImovel ST_TIPO_IMO { get; set; }

        /// <value>
        /// required string CEP.
        /// </value>
        public string ST_CEP_IMO { get; set; }
        public string ST_ENDERECO_IMO { get; set; } //required string Endereço.

        public string ST_NUMERO_IMO { get; set; } //string Número.

        public string ST_COMPLEMENTO_IMO { get; set; } //string Comlemento.

        public string ST_BAIRRO_IMO { get; set; } //required string Bairro.

        public string ST_CIDADE_IMO { get; set; } //required string Cidade.

        public string ST_ESTADO_IMO { get; set; } //string Estado.
        public Locador PROPRIETARIOS_BENEFICIARIOS { get; set; }
        //[0][ID_PESSOA_PES] //required number Id gerado no cadastro do proprietário.
        //[0][FL_PROPRIETARIO_PRB] number Caso o imóvel tenha mais de 1 proprietário esse campo é OBRIGATÓRIO.Serve para identificar o proprietário principal do imóvel e os beneficiarios: -1: Proprietário principal, 1: Proprietário e 2: Beneficiário.
        //[0][NM_FRACAO_PRB] string Caso o imóvel tenha mais de 1 proprietário esse campo é OBRIGATÓRIO.Serve para identificar o percentual de repasse dos proprietários.A soma do percentual de todos os proprietários deve ser 100.

        public string ST_IDENTIFICADOR_IMO { get; set; } //string Identificador do imóvel em outro sistema.

        public string VL_ALUGUEL_IMO { get; set; } //string Valor do aluguel.

        public string VL_VENDA_IMO { get; set; } //string Valor de venda.

        public string VL_VENAL_IMO { get; set; } //string Valor venal.

        public string TX_ADM_IMO { get; set; } //string Taxa de administração mensal (%).

        public string FL_TXADMVALORFIXO_IMO { get; set; } //number (Boolean 0 ou 1)

        public string IMG_URL {  get; set; }
        public override bool Equals(object obj)
        {
            return obj is Imovel imovel &&
                   ID_IMOVEL_IMO == imovel.ID_IMOVEL_IMO;
        }

        public bool IS_ALUGADO { get; set; }

        public List<Vistoria> VISTORIAS { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID_IMOVEL_IMO);
        }
    }
}
