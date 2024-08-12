using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Utils;

namespace NovolarLocadorFront.Services
{
    public class RepasseService : IRepasseService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://novolarbackendapi.azurewebsites.net/repasses";
        //public string BasePath = "https://localhost:7288/repasses";
        ApplicationGlobals _applicationGlobals;

        public RepasseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _applicationGlobals = ServiceLocator._applicationGlobals;
        }

        public async Task<List<RepasseDTO>> GetRepassesPorFavorecidoAsync(int ano, int idFavorecido)
        {
            try
            {
                Uri url = new Uri(BasePath + $"/{ano}/{idFavorecido}");
                var response = await _httpClient.GetAsync(url);
                var despesas = await response.ReadContentAs<List<DespesaImobiliaria>>();
                List<RepasseDTO> repasses = new List<RepasseDTO>();
                foreach (var despesa in despesas)
                {
                    repasses.Add(_applicationGlobals._mapper.Map<RepasseDTO>(despesa));
                }

                return repasses;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
