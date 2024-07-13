using NovolarLocadorFront.Models;
using NovolarLocadorFront.Utils;

namespace NovolarLocadorFront.ViewModel
{
    public class DetalhesImovelViewModel
    {
        public string EnderecoCompleto { get; set; }
        public string SituacaoContrato { get; set; }
        public string SituacaoAluguel { get; set; }
        public DateTime UltimaVistoria { get; set; }
        public decimal ValorAluguel { get; set; }
        public int TotalImoveisAlugados { get; set; }

        public InquilinoDTO InquilinoPrincipal { get; set; }

        public ImovelDTO ImovelDTO { get; set; }

        public List<InquilinoDTO> Inquilinos { get; set; }

        ApplicationGlobals _applicationGlobals;
        public DetalhesImovelViewModel(ApplicationGlobals applicationGlobals, ImovelDTO imovelDTO)
        {
            _applicationGlobals = applicationGlobals;
            this.ImovelDTO = imovelDTO;
            Inquilinos = imovelDTO.Inquilinos;
            MontaEnderecoCompleto();
            DefineInquilinoPrincipal();
            DefineSituacaoAluguel();
            this.ValorAluguel = ImovelDTO.ValorAluguel;
        }

        private void MontaEnderecoCompleto()
        {
            EnderecoCompleto = $"{ImovelDTO.Logradouro}, {ImovelDTO.Numero} {ImovelDTO.Complemento}. {ImovelDTO.Bairro} - {ImovelDTO.Estado}";
        }

        private void DefineInquilinoPrincipal()
        {
            if (Inquilinos.Count > 0)
            {
                foreach (var inquilino in Inquilinos)
                {
                    foreach (var contrato in ImovelDTO.Contratos)
                    {
                        if (contrato.id_imovel_imo.Equals(ImovelDTO.Id.ToString()) && contrato.id_contrato_con.Equals(inquilino.IdContrato.ToString()))
                        {
                            SituacaoContrato = contrato.fl_ativo_con.Equals("1") ? "Ativo" : "Inativo";
                        }
                    }
                    if (inquilino.isPrincipal == 1)
                    {
                        InquilinoPrincipal = inquilino;
                    }
                }
            }

            else
            {
                InquilinoPrincipal = new InquilinoDTO();
            }

            
        }

        private void DefineSituacaoAluguel()
        {
            SituacaoAluguel = ImovelDTO.isLocado == 1 ? "Alugado" : "Desalugado";
        }
    }
}
