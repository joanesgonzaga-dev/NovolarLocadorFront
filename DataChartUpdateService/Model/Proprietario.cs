﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataChartUpdateService.Model
{
    public class Proprietario
    {
        [JsonIgnore]
        public List<Object> proprietarios_beneficiarios { get; set; }
        public string id_pessoa_pes { get; set; }
        public string st_nome_pes { get; set; }
        public string st_cnpj_pes { get; set; }
        public string st_fantasia_pes { get; set; }
        public string st_rg_pes { get; set; }
        public string st_orgao_pes { get; set; }
        public string st_ie_pes { get; set; }
        public string st_inscmunicipal_pes { get; set; }
        public string st_endereco_pes { get; set; }
        public string st_complemento_pes { get; set; }
        public string st_numero_pes { get; set; }
        public string st_cidade_pes { get; set; }
        public string st_estado_pes { get; set; }
        public string st_cep_pes { get; set; }
        public string st_bairro_pes { get; set; }
        public string st_telefone_pes { get; set; }
        public string st_celular_pes { get; set; }
        public string st_email_pes { get; set; }
        public string st_observacao_pes { get; set; }
        public string st_nacionalidade_pes { get; set; }
        public string st_sexo_pes { get; set; }
        public string dt_nascimento_pes { get; set; }
        public string st_estadocivil_pes { get; set; }
        public string st_profissao_pes { get; set; }
        public string st_ramoatividade_pes { get; set; }
        public string st_trabalhocep_pes { get; set; }
        public string st_trabalhoendereco_pes { get; set; }
        public string st_trabalhonumero_pes { get; set; }
        public string st_trabalhocomplemento_pes { get; set; }
        public string st_trabalhobairro_pes { get; set; }
        public string st_trabalhocidade_pes { get; set; }
        public string st_trabalhoestado_pes { get; set; }
        public string st_banco_pes { get; set; }
        public string id_forma_pag { get; set; }
        public string st_agenciabanco_pes { get; set; }
        public string st_conta_pes { get; set; }
        public string id_sacado_sac { get; set; }
        public string id_favorecido_fav { get; set; }
        public string fl_proprietariobeneficiario_pes { get; set; }
        public string fl_locatario_pes { get; set; }
        public string fl_corretor_pes { get; set; }
        public string fl_fiador_pes { get; set; }
        public string st_nomerecebedor_pes { get; set; }
        public string st_cnpjrecebedor_pes { get; set; }
        public string id_formarecebimento_pes { get; set; }
        public string st_identificadorprop_pes { get; set; }
        public string st_identificadorloc_pes { get; set; }
        public string vl_rendamensal_pes { get; set; }
        public string st_nome_coj { get; set; }
        public string st_cpf_coj { get; set; }
        public string st_rg_coj { get; set; }
        public string st_nacionalidade_coj { get; set; }
        public string st_sexo_coj { get; set; }
        public string st_profissao_coj { get; set; }
        public string st_celular_coj { get; set; }
        public string st_email_coj { get; set; }
        public string st_observacao_coj { get; set; }
        public string st_telefone_coj { get; set; }
        public string fl_status_pes { get; set; }
        public string nm_dependentes_pes { get; set; }
        public string st_tipoconta_pes { get; set; }
        public string id_unidade_uni { get; set; }
        public string st_nomeresp_pes { get; set; }
        public string st_cpfresp_pes { get; set; }
        public string st_telefoneresp_pes { get; set; }
        public string st_respcep_pes { get; set; }
        public string st_respendereco_pes { get; set; }
        public string st_respnumero_pes { get; set; }
        public string st_respcomplemento_pes { get; set; }
        public string st_respbairro_pes { get; set; }
        public string st_respcidade_pes { get; set; }
        public string st_respestado_pes { get; set; }
        public string st_respemail_pes { get; set; }
        public string st_rgresp_pes { get; set; }
        public string st_identificadorfiador_pes { get; set; }
        public string st_orgao_coj { get; set; }
        public string dt_expedicaorg_pes { get; set; }
        public string st_operacao_pes { get; set; }
        public string fl_reterissqn_pes { get; set; }
        public string fl_reterinss_pes { get; set; }
        public string fl_reterirrf_pes { get; set; }
        public string fl_reterpis_pes { get; set; }
        public string fl_retercofins_pes { get; set; }
        public string fl_retercontribuicaosocial_pes { get; set; }
        public string st_razaoempresa_pes { get; set; }
        public string st_telefoneempresa_pes { get; set; }
        public string dt_admissaoempresa_pes { get; set; }
        public string fl_naodomiciliado_pes { get; set; }
        public string fl_comprador_pes { get; set; }
        public string fl_vistoriador_pes { get; set; }
        public string st_identificadorcorretor_pes { get; set; }
        public string id_foto_pes { get; set; }
        public string st_creci_pes { get; set; }
        public string vl_txissqn_pes { get; set; }
        public string st_identidadeblockchain_pes { get; set; }
        public string st_fotourl_pes { get; set; }
        public string fl_naonotificar_pes { get; set; }
        public string st_nomemae_pes { get; set; }
        public string st_nomepai_pes { get; set; }
        public string st_naturalidade_pes { get; set; }
        public string fl_statusconvitecartao_pes { get; set; }
        public string vl_tarifabancaria_pes { get; set; }
        public string dt_diarepasse_pes { get; set; }
        public string dt_atualizacao_pes { get; set; }
        public string fl_testemunha_pes { get; set; }
        public string fl_contapessoa_pes { get; set; }
        public string st_pais_pes { get; set; }
        public string fl_gerente_pes { get; set; }
        public string fl_reembolsoiss_pes { get; set; }
        public string fl_recolhimentodarf_pes { get; set; }
        public string id_gestor_ges { get; set; }
        public string vl_saldobloqueado_pes { get; set; }
        public string fl_reembolsarirrf_pes { get; set; }
        public string fl_reembolsarpiscofins_pes { get; set; }
        public string st_chavepix_pes { get; set; }
        public string fl_tipochavepix_pes { get; set; }
        public string fl_descontosimplificadoir_pes { get; set; }
        public string st_codigocontabil_pes { get; set; }
        public string fl_semrenda_pes { get; set; }
        public string fl_vinculoemprego_pes { get; set; }
        public string st_beneficio_pes { get; set; }
        public string vl_outrosrendimentos_pes { get; set; }
        public string st_cnpjempresa_pes { get; set; }
        public string dt_admissaoemprego_pes { get; set; }
        public string nome_formatado { get; set; }
    }
}
