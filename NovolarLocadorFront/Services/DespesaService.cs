using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Utils;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace NovolarLocadorFront.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://novolarbackendapi.azurewebsites.net/imovel";
        //public string BasePath = "https://localhost:7288/imovel";
        private List<DespesaReadDTO> _despesasFiltradas;
        ApplicationGlobals _applicationGlobals;

        #region Variaveis antigo backend
        HttpRequestMessage request;
        string _app_token = string.Empty;
        string _access_token = string.Empty;
        IConfiguration _configuration;
        #endregion
        public DespesaService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _applicationGlobals = ServiceLocator._applicationGlobals;
            _configuration = configuration;
        }

        public async Task<List<DespesaReadDTO>> GetDespesasPorIdImovel(int id, EnumTipoDeDespesa enumTipoDeDespesa, int? ano)
        {
            try
            {
                //Uri url = new Uri(BasePath + $"/{id}/{ano}");
                //var response = await _httpClient.GetAsync(url);
                //List<DespesaImovel> despesas = await response.ReadContentAs<List<DespesaImovel>>();

                List<DespesaImovel> despesas = await GetDespesasImovelAnoAtualAsync(id, ano);

                foreach (var item in despesas)
                {
                    Console.WriteLine($"Despesa de código {item.id_produto_prd} do imóvel {item.id_imovel_imo} no valor de {item.vl_valor_imod} com vencimnto em {item.dt_vencimento_recb}");
                }

                var alugueis = _applicationGlobals._mapper.Map<List<DespesaReadDTO>>(despesas);
                return FiltraDespesas(alugueis, enumTipoDeDespesa, ano);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<DespesaReadDTO> FiltraDespesas(List<DespesaReadDTO> despesasDTO, EnumTipoDeDespesa enumTipoDeDespesa, int? ano)
        {
            try
            {
                _despesasFiltradas = new List<DespesaReadDTO>();

                if (ano is not null)
                {
                    if (enumTipoDeDespesa == EnumTipoDeDespesa.Indefinido)
                    {
                        foreach (var despesa in despesasDTO)
                        {
                            int anoDespesa = DateTime.ParseExact(despesa.Referencia, "MM/dd/yyyy", CultureInfo.InvariantCulture).Year;
                            if (ano is not null && anoDespesa == ano)
                            {
                                _despesasFiltradas.Add(despesa);
                            }   
                        }
                    }
                    else
                    {
                        foreach (var despesa in despesasDTO)
                        {
                            if (despesa.IdTipoDespesa == enumTipoDeDespesa)
                            {
                                int anoDespesa = DateTime.ParseExact(despesa.Referencia, "MM/dd/yyyy", CultureInfo.InvariantCulture).Year;
                                if (ano is not null && anoDespesa == ano)
                                {
                                    _despesasFiltradas.Add(despesa);
                                }
                            }
                        }
                    }
                }

                else
                {
                    if (enumTipoDeDespesa == EnumTipoDeDespesa.Indefinido)
                    {
                        foreach (var despesa in despesasDTO)
                        {
                            _despesasFiltradas.Add(despesa);
                        }
                    }
                    else {
                        foreach (var despesa in despesasDTO)
                        {
                            if (despesa.IdTipoDespesa == enumTipoDeDespesa)
                            {
                                _despesasFiltradas.Add(despesa);
                            }
                        }
                    }
                }
                return _despesasFiltradas;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //O método abaixo foi transferido da api LocadorManager-Api para cá por questão de desempenho
        public async Task<List<DespesaImovel>> GetDespesasImovelAnoAtualAsync(int idImovel, int? anoConsulta)
        {
            int counter = 1;
            HttpResponseMessage response;
            List<DespesaImovel> despesas = new List<DespesaImovel>();

            while (true)
            {
                try
                {
                    var parametros = new
                    {
                        ID_IMOVEL_IMO = $"{idImovel}",
                        dtInicio = $"01/01/{anoConsulta}",
                        dtFim = $"12/31/{anoConsulta}"
                    };
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parametros);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    string azurePath = "http://apps.superlogica.net/imobiliaria/api/imoveisdespesa";
                    request = new HttpRequestMessage(HttpMethod.Get, azurePath);
                    _app_token = _configuration.GetValue<string>("IntegrationTokens:app_token");
                    _access_token = _configuration.GetValue<string>("IntegrationTokens:access_token");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Content = content;

                    request.RequestUri = new Uri(azurePath + "?pagina=" + counter);
                    request.Headers.Add("app_token", _app_token);
                    request.Headers.Add("access_token", _access_token);

                    response = await _httpClient.SendAsync(request);
                    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Models.Despesa.Root myDeserializedRootClass = JsonConvert.DeserializeObject<Models.Despesa.Root>(dataAsString);

                    if (response.IsSuccessStatusCode)
                    {
                        if (myDeserializedRootClass.data is null || myDeserializedRootClass.data.Count <= 0)
                        {
                            break;
                        }

                        foreach (var item in myDeserializedRootClass.data)
                        {
                            despesas.Add(item);
                        }

                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return despesas;
        }
    }
}
