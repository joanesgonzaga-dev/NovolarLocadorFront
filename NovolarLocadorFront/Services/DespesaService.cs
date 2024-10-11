using Newtonsoft.Json;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Utils;
using System.Net.Http.Headers;
using System.Globalization;
using System.Text;

namespace NovolarLocadorFront.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://locadormanager-api.azurewebsites.net/imovel";
        //public string BasePath = "https://localhost:7288/imovel";
        
        //ApplicationGlobals _applicationGlobals;

        #region Variaveis antigo backend
        HttpRequestMessage request;
        string _app_token = string.Empty;
        string _access_token = string.Empty;
        IConfiguration _configuration;
        #endregion
        public DespesaService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            //_applicationGlobals = ServiceLocator._applicationGlobals;
            _configuration = configuration;
        }
        public async Task<List<DespesaReadDTO>> GetDespesasPorIdImovel(int id, EnumTipoDeDespesa enumTipoDeDespesa, int? ano)
        {
            try
            {
                Uri uri = new Uri($"{BasePath}/{id}/{enumTipoDeDespesa}/{ano}" );
                var response = await _httpClient.GetAsync(uri);
                return await response.ReadContentAs<List<DespesaReadDTO>>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
