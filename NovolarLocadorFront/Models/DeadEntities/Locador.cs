using NovolarLocadorFront.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Models.DeadEntities
{
    public class Locador
    {
        public int ID_PESSOA_PE { get; set; } //Id do Proprietário
        public string ST_NOME_PES { get; set; } //required. Nome ou razão social.

        public EnumTipoPessoa TIPO_PESSOA { get; set; }
        public string ST_CNPJ_PES { get; set; } //string CNPJ ou CPF.

        public string ST_FANTASIA_PES { get; set; } //string Nome fantasia.

        public string ST_CELULAR_PES { get; set; } //string Celular.

        public string ST_TELEFONE_PES { get; set; } //string Telefone.

        public string ST_EMAIL_PES { get; set; } //string E-mail.

        public EnumFormasDePagamento ID_FORMA_PAG { get; set; } //number
        //1 => Depósito em cheque, 2 => Depósito em dinheiro, 3 => Retirar cheque no local, 4 => Retirar dinheiro no local, 5 => Transf.bancária 6 => Doc/Ted

        public string ST_RG_PES { get; set; } //string RG.

        public string ST_ORGÃO_PES { get; set; } //string Orgão exp.

        public EnumSexo ST_SEXO_PES { get; set; } //number 1 => Masculino, 2 => Feminino

        public DateTime DT_NASCIMENTO_PES { get; set; } //number Data de Nascimento.

        public string ST_NACIONALIDADE_PES { get; set; } //string Nacionalidade.

        public bool FL_NAODOMICILIADO_PES { get; set; } //number Não domiciliado no Brasil (Boolean 0 ou 1)

        public string ST_CEP_PES { get; set; } //string CEP.

        public string ST_ENDERECO_PES { get; set; } //string Endereço.

        public string ST_NUMERO_PES { get; set; } //string Número.

        public string ST_COMPLEMENTO_PES { get; set; } //string Complemento.

        public string ST_BAIRRO_PES { get; set; } //string Bairro.

        public string ST_CIDADE_PES { get; set; } //string Cidade.

        public string ST_ESTADO_PES { get; set; } // string Estado.

        public bool FL_RETERISSQN_PES { get; set; } //number Reter ISSQN. (Boolean 0 ou 1)

        public string ST_OBSERVACAO_PES { get; set; } //string Observação.

        public bool FL_PROPRIETARIOBENEFICIARIO_PES { get; set; } //required Flag do proprietário = 1. (Boolean 0 ou 1)

        public override bool Equals(object obj)
        {
            return obj is Locador locador &&
                   ID_PESSOA_PE == locador.ID_PESSOA_PE &&
                   ST_CNPJ_PES == locador.ST_CNPJ_PES;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID_PESSOA_PE, ST_CNPJ_PES);
        }
    }
}
