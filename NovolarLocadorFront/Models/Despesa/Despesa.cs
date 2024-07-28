using Newtonsoft.Json;

namespace NovolarLocadorFront.Models.Despesa
{
    public class Despesa
    {
        public string st_identificador_imo { get; set; }
        public string st_tipo_imo { get; set; }
        public string st_endereco_imo { get; set; }
        public string st_numero_imo { get; set; }
        public string st_bairro_imo { get; set; }
        public string st_cep_imo { get; set; }
        public string st_complemento_imo { get; set; }
        public string st_conta_cont { get; set; }
        public string st_descricao_prd { get; set; }
        public string id_produto_prd { get; set; }
        public string nome_proprietariodebito { get; set; }
        public string nome_proprietariocredito { get; set; }
        public string fl_repassar_mop { get; set; }
        public string id_lancamento_imod { get; set; }
        public string dt_lancamento_imod { get; set; }
        public string st_complemento_imod { get; set; }
        public string id_imovel_imo { get; set; }
        public string fl_status_imod { get; set; }
        public string vl_valor_imod { get; set; }
        public string id_md5parcelamento_imod { get; set; }
        public string id_contrato_con { get; set; }
        public string id_proprietariodebito_imod { get; set; }
        public string fl_cobrartxadm_imod { get; set; }
        public string fl_pagtoantecipado_imod { get; set; }
        public string dt_referencia_imod { get; set; }
        public string id_debito_imod { get; set; }
        public string id_credito_imod { get; set; }
        public string id_lancamentodebito_imod { get; set; }
        public string id_lancamentocredito_imod { get; set; }
        public string id_proprietariocredito_imod { get; set; }
        public string id_terceiro_fav { get; set; }
        public string id_faturamento_comp { get; set; }
        public string id_repasse_rep { get; set; }
        public string id_faturamento_facs { get; set; }
        public string fl_especialfin_imod { get; set; }
        public string fl_especial_imod { get; set; }
        public string id_recebimento_recb { get; set; }
        public string fl_retencao_imod { get; set; }
        public string dt_competencia_imod { get; set; }
        public string st_codigobarras_mov { get; set; }
        public string st_label_imod { get; set; }
        public string id_acordo_aco { get; set; }
        public string id_lancamento_imodm { get; set; }
        public string dt_liquidacao_mov { get; set; }
        public string fl_status_mov { get; set; }
        public string id_pagtoindevido_imod { get; set; }
        public string vl_pagtoindevido_imod { get; set; }
        public string id_despesaorigem_imod { get; set; }
        public string id_formapagamento_imod { get; set; }
        public string id_contabanco_cb { get; set; }
        public string fl_repassar_imod { get; set; }
        public string dt_liquidacao_imom { get; set; }
        public string fl_conciliado_imod { get; set; }
        public string fl_alterouvalor_imod { get; set; }
        public string id_seguro_seg { get; set; }
        public string id_iptulancamento_iil { get; set; }
        public string st_split_imod { get; set; }
        public string id_orcamento_morc { get; set; }
        public string fl_statusdebito_imod { get; set; }
        public string id_previsao_prt { get; set; }
        public string id_despesa_desp { get; set; }
        public string id_despesareembolso_imod { get; set; }
        public string fl_exibir_imod { get; set; }
        public string st_cpfcnpjpagadororiginal_imod { get; set; }
        public string dt_atualizacao_imod { get; set; }
        public string fl_garantida_imod { get; set; }
        public string st_label_recb { get; set; }
        public string st_hashdespesa_imod { get; set; }
        public string fl_tipo_imod { get; set; }
        public string id_propdiferenca_imod { get; set; }
        public string fl_despesaalterada_imod { get; set; }
        public string fl_despesaproporcional_imod { get; set; }
        public string nm_tagcriacao_imod { get; set; }
        public string nm_tagliquidacao_imod { get; set; }
        public string fl_calcularproporcionalrescisao_imod { get; set; }
        public string dt_recebimento_recb { get; set; }
        public string dt_liquidacao_recb { get; set; }
        public string fl_status_recb { get; set; }
        public string st_label3_recb { get; set; }
        public string dt_vencimento_recb { get; set; }

        [JsonIgnore]
        public List<Repasse> repasses { get; set; }
        public string dt_repasse_rep { get; set; }
        public string imovel_formatado { get; set; }
        public string detalhes_contrato { get; set; }
        public string dt_competencia_aux { get; set; }
    }
}
