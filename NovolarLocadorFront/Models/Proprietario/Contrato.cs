﻿using NovolarLocadorFront.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Models.Proprietario
{
    /// <summary>
    /// Dados referentes ao contrato de administração junto à imobiliária
    /// </summary>
    public class Contrato
    {
        public string id_contrato_con { get; set; }
        public string id_tipo_con { get; set; }
        /// <summary>
        /// Inicio do contrato entre Proprietário e Imobiliária
        /// </summary>
        public string dt_inicio_con { get; set; }
        public string dt_fim_con { get; set; }
        public string tx_adm_con { get; set; }
        public string vl_aluguel_con { get; set; }
        public string nm_diavencimento_con { get; set; }
        public string id_indicereajuste_con { get; set; }
        public string nm_txjuros_con { get; set; }
        public string nm_txmulta_con { get; set; }
        public string nm_txdesconto_con { get; set; }
        public string tx_locacao_con { get; set; }
        public string id_imovel_imo { get; set; }
        public string id_corretor_con { get; set; }
        public string fl_garantia_con { get; set; }
        public string fl_tipocaucaogarantia_con { get; set; }
        public string st_descricaogarantia_con { get; set; }
        public string st_identificadorgarantia_con { get; set; }
        public string st_observacaogarantia_con { get; set; }
        public string vl_valorgarantia_con { get; set; }
        public string nm_diarepasse_con { get; set; }
        public string nm_mesreajuste_con { get; set; }
        public string dt_rescisao_con { get; set; }
        public string fl_ativo_con { get; set; }
        public string dt_garantiainicio_con { get; set; }
        public string dt_garantiafim_con { get; set; }
        public string fl_garantiaresponsavel_con { get; set; }
        public string nm_garantiaparcelas_con { get; set; }
        public string vl_garantiaparcela_con { get; set; }
        public string dt_seguroincendioinicio_con { get; set; }
        public string dt_seguroincendiofim_con { get; set; }
        public string vl_seguroincendio_con { get; set; }
        public string st_seguroincendiodescricao_con { get; set; }
        public string st_seguroincendioidentificador_con { get; set; }
        public string st_seguroincendioobservacao_con { get; set; }
        public string fl_seguroincendio_con { get; set; }
        public string nm_locacoesimovel_con { get; set; }
        public string id_mensalidade_mens { get; set; }
        public string fl_endcobranca_con { get; set; }
        public string st_cep_con { get; set; }
        public string st_endereco_con { get; set; }
        public string st_numero_con { get; set; }
        public string st_complemento_con { get; set; }
        public string st_bairro_con { get; set; }
        public string st_cidade_con { get; set; }
        public string dt_ultimoreajuste_con { get; set; }
        public string st_estado_con { get; set; }
        public string fl_txadmvalorfixo_con { get; set; }
        public string fl_txlocacaovalorfixo_con { get; set; }
        public string nm_parcelastxlocacao_con { get; set; }
        public string nm_repassegarantido_con { get; set; }
        public string fl_cobrarnosegundoaluguel_con { get; set; }
        public string id_primeiraparcela_con { get; set; }
        public string fl_reterir_con { get; set; }
        public string st_label_mens { get; set; }
        public string fl_emitirnotafiscal_con { get; set; }
        public string id_contabanco_cb { get; set; }
        public string fl_mesvencido_con { get; set; }
        public string fl_diafixorepasse_con { get; set; }
        public string st_clausulas_con { get; set; }
        public string dt_faturamento_con { get; set; }
        public string tx_multacontratual_con { get; set; }
        public string vl_tarifabancariarepasse_con { get; set; }
        public string fl_tarifabancariarepasse_con { get; set; }
        public string id_txbancaria_mens { get; set; }
        public string fl_cobrartxbancaria_con { get; set; }
        public string id_endereco_sen { get; set; }
        public string fl_status_con { get; set; }
        public string fl_tipoentrega_con { get; set; }
        public string fl_suspenso_con { get; set; }
        public string fl_dimob_con { get; set; }
        public string dt_desocupacao_con { get; set; }
        public string st_atividadecomercial_con { get; set; }
        public string fl_txlocacao_con { get; set; }
        public string dt_renovacao_con { get; set; }
        public string fl_irdeduzirtxadm_con { get; set; }
        public string nm_carencia_con { get; set; }
        public string id_seguro_seg { get; set; }
        public string fl_mesfechado_con { get; set; }
        public string dt_cadastro_con { get; set; }
        public string id_filial_fil { get; set; }
        public string fl_split_con { get; set; }
        public string fl_contratodigital_con { get; set; }
        public string id_arquivo_arq { get; set; }
        public string st_observacaorecisao_con { get; set; }
        public string st_observacao_con { get; set; }
        public string vl_importanciaseguradaincendio_con { get; set; }
        public string vl_premioseguroincendio_con { get; set; }
        public string id_seguradora_seg { get; set; }
        public string st_motivopausa_con { get; set; }
        public string dt_ultimapausa_con { get; set; }
        public string nm_parcelasseguroincendio_con { get; set; }
        public string id_seguradorafianca_con { get; set; }
        public string id_forma_pag { get; set; }
        public string fl_locacaodigital_con { get; set; }
        public string dt_previsaodesocupacao_con { get; set; }
        public string dt_sincronizacaofaturamento_con { get; set; }
        public string st_linkpropostaexterna_con { get; set; }
        public string st_propostaexterna_con { get; set; }
        public string nm_mesesisencaomulta_con { get; set; }
        public string dt_ocupacao_con { get; set; }
        public string id_agentecomercial_con { get; set; }
        public string fl_tiporepassegarantido_con { get; set; }
        public string id_contarepasse_con { get; set; }
        public string dt_atualizacao_con { get; set; }
        public string fl_tipoatividade_con { get; set; }
        public string dt_entregachaves_con { get; set; }
        public string fl_responsavelcontrato_con { get; set; }
        public string st_seguroincendioplanocontrato_con { get; set; }
        public string id_gerente_con { get; set; }
        public string fl_motivorescisao_con { get; set; }
        public string id_garantia_grt { get; set; }
        public string st_cotacao_grt { get; set; }
        public string fl_reterjurosemulta_con { get; set; }
        public string fl_multisplit_con { get; set; }
        public string st_outromotivo_con { get; set; }
        public string fl_seguroincendiostatus_con { get; set; }
        public string id_identificadorimportacao_con { get; set; }
        public string fl_irporcentagemlocatario_con { get; set; }
        public string fl_cobrarseguroaluguel_con { get; set; }
        public string dt_notificacaoocupacao_con { get; set; }
        public string dt_notificacaodesocupacao_con { get; set; }
        public string fl_renovacaoautomatica_con { get; set; }
        public string dt_notificacaocarencia_con { get; set; }
        public string dt_previstasolicitacaodesocupacao_con { get; set; }
        public string fl_carencia_con { get; set; }
        public string dt_previsaodesocupacaocarencia_con { get; set; }
        public string fl_tipovalorgarantia_con { get; set; }
        public string nm_parcelastxadm_con { get; set; }
        public string fl_fisicocobrancaproprietario_con { get; set; }
        public string nm_vistoria_con { get; set; }
        public string st_tiporesponsavelvistoria_con { get; set; }
        public string fl_enderecofaturamentodigital_con { get; set; }
        public string fl_renovacaodigital_con { get; set; }
        public string fl_envionfe_con { get; set; }
        public string id_imobiliaria_con { get; set; }
        public string dt_previsaovistoriaentrada_con { get; set; }
        public string st_tipovistoriaentrada_con { get; set; }
        public string dt_notificacaoaluguel_con { get; set; }
        public string st_observacaofinanceira_con { get; set; }
        public string fl_autorizacobraancapagamento_con { get; set; }
        public string id_despesalocador_con { get; set; }
        public string fl_pisporcentagemlocatario_con { get; set; }
        public string fl_cofinslocatario_con { get; set; }
        public string fl_cslporcentagemlocatario_con { get; set; }
        public string id_banco_con { get; set; }
        public string fl_divergencia_valor_con { get; set; }
        public string st_cep_locador_con { get; set; }
        public string st_endereco_locador_con { get; set; }
        public string st_numero_locador_con { get; set; }
        public string st_complemento_locador_con { get; set; }
        public string st_bairro_locador_con { get; set; }
        public string st_cidade_locador_con { get; set; }
        public string st_estado_locador_con { get; set; }
        //public EnumFormasDeCobranca FL_MESVENCIDO_CON { get; set; } //0
    }
}
