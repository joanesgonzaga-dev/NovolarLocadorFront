using Newtonsoft.Json;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Models.Proprietario;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace NovolarLocadorFront.ViewModel
{
    public class ChartsViewModel
    {
        public string[,] anos = new string[3,4]{{"2019", "Imovel1", "Imovel2", "null" } ,{"2020", "Imovel1", "Imovel2", "Imovel3" }, { "2021", "Imovel1", "Imovel2", "null" } };
        public string[] meses;


        public Proprietario Proprietario { get; set; }

        public UserSession UserSession { get; set; }

        public ChartsViewModel(UserSession userSession)
        {
            UserSession = userSession;
            Proprietario = UserSession.Proprietario;
            RetornaMesesDoAno(DateTime.Now.Year);
        }
        public void RetornaMesesDoAno(int anoDaConsulta)
        {
            int anoAtual = DateTime.Now.Year;
            int totalMeses = anoDaConsulta == anoAtual ? DateTime.Now.Month : 12; 

            meses = new string[totalMeses];
            for (int i = 0; i < totalMeses; i++)
            {
                meses[i] = Enum.GetName(typeof(EnumMesesIndexados), i+1);
            }
        }



    }
}
