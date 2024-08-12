using AutoMapper;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Utils;
using System.Diagnostics;
using System.Globalization;

namespace NovolarLocadorFront.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://novolarbackendapi.azurewebsites.net/imovel";
        //public string BasePath = "https://localhost:7288/imovel";
        private List<DespesaReadDTO> _despesasFiltradas;
        ApplicationGlobals _applicationGlobals;
        public DespesaService()
        {
            _httpClient = new HttpClient();
            _applicationGlobals = ServiceLocator._applicationGlobals;
        }

        public async Task<List<DespesaReadDTO>> GetDespesasPorIdImovel(int id, EnumTipoDeDespesa enumTipoDeDespesa, int? ano)
        {
            try
            {
                Uri url = new Uri(BasePath + $"/{id}/{ano}");
                var response = await _httpClient.GetAsync(url);
                List<DespesaImovel> despesas = await response.ReadContentAs<List<DespesaImovel>>();

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

                else
                {
                    foreach (var despesa in despesasDTO)
                    {
                        if (despesa.IdTipoDespesa == enumTipoDeDespesa)
                        {
                           _despesasFiltradas.Add(despesa); 
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
    }
}
