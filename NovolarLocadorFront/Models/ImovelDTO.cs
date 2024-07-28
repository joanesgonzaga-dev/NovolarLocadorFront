using NovolarLocadorFront.Models.Proprietario;

namespace NovolarLocadorFront.Models
{
    public class ImovelDTO
    {
        public int Id { get; set; } = -1; //ID_IMOVEL_IMO

        public int ProprietarioId { get; set; }
        public decimal ValorAluguel { get; set; } = 0.0M; //VL_ALUGUEL_IMO
        public decimal ValorCondominio { get; set; } = 0.0M; //VL_CONDOMINIO_IMO
        public decimal ValorParcelaIptu { get; set; } = 0.0M;//"vl_parcelaiptu_imo"
        public int TipoImovel { get; set; } = -1; //ST_TIPO_IMO CRIAR ENUM
        public string CodigoIptu { get; set; } = string.Empty; // "st_codigoiptu_imo"
        public int NumeroParcelasIptu { get; set; } = 0;// "nm_parcelasiptu_imo"
        public int ResponsavelCondominio { get; set; } = -1;// "fl_responsavelcondominio_imo": "1" //Criar Enum
        public string Logradouro { get; set; } = string.Empty; //"st_endereco_imo": "Rua Antônio Everdosa",
        public string Numero { get; set; } = string.Empty;// "st_numero_imo": "1744"
        public string Complemento { get; set; } = string.Empty;//"st_complemento_imo": "Casa 01",
        public string Bairro { get; set; } = string.Empty;//"st_bairro_imo": "Pedreira"
        public string Cidade { get; set; } = string.Empty;//"st_cidade_imo": "Belém"
        public string Estado { get; set; } = string.Empty;//"st_estado_imo": "PA"
        public string Cep { get; set; } = string.Empty;//"st_cep_imo": "66085-756"
        public string CodigoAgua { get; set; } = string.Empty; //"st_codagua_imo": "3368530",
        public string CodigoEnergia { get; set; } = string.Empty;//"st_codenergia_imo": "3017659935",
        public string OBS { get; set; } = string.Empty; //"st_observacao_imo": "Casa com sala, 02 quartos, banheiro social, copa, cozinha, área de serviço, piso em lajota e gradeada."
        public decimal TaxaAdministracao { get; set; } = 0.0M; //"tx_adm_imo": "10.00"
        public int isLocado { get; set; } = 0; // "situacao_imovel" : "1" //Esta propriedade não existe em Proprietario => Imovel. tem que consultar Endpoint de Imoveis

        public string ImageUri { get; set; }
        public List<InquilinoDTO> Inquilinos { get; set; } = new List<InquilinoDTO>();
        public List<Contrato> Contratos { get; set; } = new List<Contrato>(); //Pendencia: Criar e trabalhar com o DTO

        public string Detalhes { get; set; } = string.Empty;

    }
}
