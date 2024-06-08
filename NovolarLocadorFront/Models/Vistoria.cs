using NovolarLocadorFront.Models.Enums;
using System;

namespace NovolarLocadorFront.Models
{
    public class Vistoria
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string OBS { get; set; }
        public Imovel Imovel { get; set; }
        public EnumTipoVistoria TipoVistoria { get; set; }
        public EnumStatusVistoria Status { get; set; }
        public bool isVistoriaQuartos { get; set; }
        public bool isVistoriaQuartosAprovada { get; set; }
        public bool isVistoriaSalas { get; set; }
        public bool isVistoriaSalasAprovada { get; set; }
        public bool isVistoriaBanheiro { get; set; }
        public bool isVistoriaBanheiroAprovada { get; set; }
        public bool isVistoriaCozinha { get; set; }
        public bool isVistoriaCozinhaAprovada { get; set; }
        public bool isVistoriaAreaServico { get; set; }
        public bool isVistoriaAreaServicoAprovada { get; set; }
        public bool isVistoriaGaragem { get; set; }
        public bool isVistoriaGaragemAprovada { get; set; }
        public bool isVistoriaFachada { get; set; }
        public bool isVistoriaFachadaAprovada { get; set; }


    }
}
