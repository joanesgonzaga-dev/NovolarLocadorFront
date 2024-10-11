using NovolarLocadorFront.Models.ContratosAluguel;
using NovolarLocadorFront.Utils;

namespace NovolarLocadorFront.Services
{
    public class ContratoAluguelService : IContratoAluguelService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://locadormanager-api.azurewebsites.net/contratosaluguel";
        //public string BasePath = "https://localhost:7288/contratosaluguel";

        public ContratoAluguelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ContratoAluguel>> RetornaContratosPorImovelId(int idImovel)
        {
            try
            {
                Uri url = new Uri(BasePath + $"/{idImovel}");
                var response = await _httpClient.GetAsync(url);
                var contratos = await response.ReadContentAs<List<ContratoAluguel>>();
                return contratos.OrderBy(c => c.dt_inicio_con).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
