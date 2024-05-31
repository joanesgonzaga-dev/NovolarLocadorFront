using System;

namespace NovolarLocadorFront.Models
{
    public class Vistoria
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string OBS { get; set; }
        public Imovel Imovel { get; set; }

    }
}
