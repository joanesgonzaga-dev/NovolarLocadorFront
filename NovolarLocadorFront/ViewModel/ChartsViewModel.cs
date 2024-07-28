using Newtonsoft.Json;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Proprietario;
using System.Reflection.Emit;

namespace NovolarLocadorFront.ViewModel
{
    public class ChartsViewModel
    {
        public string[,] anos = new string[3,4]{{"2019", "Imovel1", "Imovel2", "null" } ,{"2020", "Imovel1", "Imovel2", "Imovel3" }, { "2021", "Imovel1", "Imovel2", "null" } };
       
        public Proprietario Proprietario { get; set; }

        public UserSession UserSession { get; set; }

        public ChartsViewModel(UserSession userSession)
        {
            UserSession = userSession;
            Proprietario = UserSession.Proprietario;
        }

       
    }
}
