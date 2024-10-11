using NovolarLocadorFront.Models;
using NovolarLocadorFront.Utils;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace NovolarLocadorFront.Services
{
    public class IndicadoresService : IIndicadoresService
    {
        private HttpClient _httpClient;
        //private readonly string _url = "https://localhost:7288/caixaanual";
        private readonly string _url = "https://locadormanager-api.azurewebsites.net/caixaanual";
        public IndicadoresService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<CaixaMeses> GetCaixaMesesDoAnoPorFavorecido(int partitionKey, int rowKey)
        {
            Uri uri = new Uri($"{_url}/{partitionKey.ToString()}/{rowKey.ToString()}");

            var response = await _httpClient.GetAsync(uri);

            CaixaMesesAzureTable caixaMesesTable = await response.ReadContentAs<CaixaMesesAzureTable>();
            
            CaixaMeses caixaMeses = new CaixaMeses();
            caixaMeses.Meses = caixaMesesTable.meses.Limpar<string>();
            caixaMeses.ValoresRepasses = caixaMesesTable.repasses.Limpar<decimal>();
            caixaMeses.ValoresDespesas = caixaMesesTable.despesas.Limpar<decimal>();

            return caixaMeses;
        }
    }
}
