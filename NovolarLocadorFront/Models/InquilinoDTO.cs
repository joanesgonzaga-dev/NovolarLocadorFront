namespace NovolarLocadorFront.Models
{
    /// <summary>
    /// Classe amigável para Inquilino
    /// </summary>
    public class InquilinoDTO
    {
        /// <summary>
        /// id_pessoa_pes
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// fl_principal_inq
        /// </summary>
        public int isPrincipal { get; set; } = -1;

        /// <summary>
        /// st_nome_pes
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// st_sexo_pes
        /// </summary>
        public int Sexo { get; set; } = -1;

        /// <summary>
        /// st_fantasia_pes
        /// </summary>
        public string NomeFantasia { get; set; } = string.Empty;
        
        /// <summary>
        /// st_cnpj_pes ou cpf
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;
        /// <summary>
        /// st_rg_pes
        /// </summary>
        public string Rg { get; set; } = string.Empty;

        /// <summary>
        /// st_orgao_pes
        /// </summary>
        public string OrgaoEmissor { get; set; } = string.Empty;

        /// <summary>
        /// st_ie_pes
        /// </summary>
        public string Ie { get; set; } = string.Empty;

        /// <summary>
        /// st_endereco_pes
        /// </summary>
        public string Logradouro { get; set; } = string.Empty;

        /// <summary>
        /// st_numero_pes
        /// </summary>
        public string Numero { get; set; } = string.Empty;

        /// <summary>
        /// st_complemento_pes
        /// </summary>
        public string Complemento { get; set; } = string.Empty;

        /// <summary>
        /// st_cidade_pes
        /// </summary>
        public string Cidade { get; set; } = string.Empty;

        /// <summary>
        /// st_bairro_pes
        /// </summary>
        public string Bairro { get; set; } = string.Empty;

        /// <summary>
        /// st_estado_pes
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// st_cep_pes
        /// </summary>
        public string Cep { get; set; } = string.Empty;

        /// <summary>
        /// st_telefone_pes
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// st_celular_pes
        /// </summary>
        public string Celular { get; set; } = string.Empty;

        /// <summary>
        /// st_email_pes
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// id_contrato_con
        /// </summary>
        public int IdContrato { get; set; } = -1;


    }
}
