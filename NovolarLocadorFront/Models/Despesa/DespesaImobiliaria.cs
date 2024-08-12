using Newtonsoft.Json;

namespace NovolarLocadorFront.Models.Despesa
{
    public class DespesaImobiliaria
    {
        public string destino { get; set; }
        public string dt_emissao_doc { get; set; }
        public string dt_liquidacao_mov { get; set; }
        public string dt_ordenacao { get; set; }
        public string dt_previsaocredito_mov { get; set; }
        public string dt_vencimentooriginal_mov { get; set; }
        public string dt_vencimento_mov { get; set; }
        public string fl_adiantamento_mov { get; set; }
        public string fl_possuiarquivo { get; set; }
        public string fl_recorrente_mov { get; set; }
        public string fl_remessastatus_mov { get; set; }
        public string fl_statusexterno_mov { get; set; }
        public string fl_status_mov { get; set; }
        public string fl_status_reti { get; set; }
        public string fl_tipotributo_mov { get; set; }
        public string fl_transferencia_trans { get; set; }
        public string fl_virtual_mov { get; set; }
        public string id_cheque_mov { get; set; }
        public string id_contabanco_mov { get; set; }
        public string id_conta_cb { get; set; }
        public string id_favorecido_fav { get; set; }
        public string id_forma_pag { get; set; }
        public string id_origemvirtual_mov { get; set; }
        public string id_original_mov { get; set; }
        public string id_pj_mov { get; set; }
        public string id_retornoitemduplicado_reti { get; set; }
        public string id_ret_cod_imp { get; set; }
        public string id_ret_origem_mov { get; set; }
        public string id_tipocontabanco_cb { get; set; }
        public string isrecebimento { get; set; }
        public string nm_numero_ch { get; set; }
        public string origem { get; set; }
        public string saldo { get; set; }
        public string st_agenciabanco_fav { get; set; }
        public string st_agenciabanco_mov { get; set; }
        public string st_arqret_mov { get; set; }
        public string st_banco_mov { get; set; }
        public string st_conta_fav { get; set; }
        public string st_conta_mov { get; set; }
        public string st_cpnjrecebedor_fav { get; set; }
        public string st_descricao_cb { get; set; }
        public string st_documento_mov { get; set; }
        public string st_fantasia_fav { get; set; }
        public string st_fitid_mov { get; set; }
        public string st_forma_pag { get; set; }
        public string st_historico_mov { get; set; }
        public string st_label_mov { get; set; }
        public string st_msgretorno_mov { get; set; }
        public string st_nomerecebedor_fav { get; set; }
        public string st_nomerecebedor_mov { get; set; }
        public string st_nome_fav { get; set; }
        public string st_nome_sac { get; set; }
        public string st_observacoes_mov { get; set; }
        public string st_sincro_mov { get; set; }
        public string vl_ret_maodeobra_mov { get; set; }
        public string vl_ret_material_mov { get; set; }
        public string vl_ret_subempreitada_mov { get; set; }
        public string vl_ret_valorretido_mov { get; set; }
        public string vl_valor_mov { get; set; }
        public string fornecedor_formatado { get; set; }
        
        [JsonIgnore]
        public List<object> Arquivos { get; set; }
    }
}
