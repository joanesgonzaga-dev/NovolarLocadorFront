using NovolarLocadorFront.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Models
{
    public class Contrato
    {
        public int ID_IMOVEL_IMO { get; set; }
        public int ID_TIPO_CON { get; set; }
        public int DT_INICIO_CON { get; set; }
        public int DT_FIM_CON { get; set; }
        public string VL_ALUGUEL_CON { get; set; }
        public string TX_ADM_CON { get; set; }
        public int FL_TXADMVALORFIXO_CON { get; set; } //"0"
        public int NM_DIAVENCIMENTO_CON { get; set; } //"25"
        public List<Inquilino> Inquilinos { get; set; }
        public string TX_LOCACAO_CON { get; set; } //"0"
        public int ID_INDICEREAJUSTE_CON { get; set; } //1
        public int NM_MESREAJUSTE_CON { get; set; } //6
        public int DT_ULTIMOREAJUSTE_CON { get; set; } //"06/01/2019"
        public int FL_MESFECHADO_CON { get; set; } //0
        public int ID_CONTABANCO_CB { get; set; } //1
        public int FL_DIAFIXOREPASSE_CON { get; set; } //0
        public int NM_DIAREPASSE_CON { get; set; } //5
        public EnumFormasDeCobranca FL_MESVENCIDO_CON { get; set; } //0
        public int FL_DIMOB_CON { get; set; } //0
        public int ID_FILIAL_FIL { get; set; } //0
        public string ST_OBSERVACAO_CON { get; set; } //"Contrato cadastrado via API"
        public int NM_REPASSEGARANTIDO_CON { get; set; } //-1, 0, 1, 2, 3...
        public int FL_GARANTIA_CON { get; set; } //0 : Não possui garantia
        public int FL_SEGUROINCENDIO_CON { get; set; } //0 : Não possui seguro
        public int FL_ENDCOBRANCA_CON { get; set; } //0
    }
}
