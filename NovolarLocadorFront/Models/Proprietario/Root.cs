using System.Collections.Generic;

namespace NovolarLocadorFront.Models.Proprietario
{
    public class Root
    {
        public string status { get; set; }
        public string session { get; set; }
        public string msg { get; set; }
        public List<ProprietarioDTO> data { get; set; }
        public string executiontime { get; set; }
    }
}
