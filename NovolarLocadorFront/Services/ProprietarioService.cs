using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly HttpClient _httpClient;
        public string BasePath = "https://novolarbackendapi.azurewebsites.net/proprietarios";
        //public string BasePath = "https://localhost:7288/proprietarios";

        public ProprietarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Proprietario>> GetAllProprietariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BasePath);
                return await response.ReadContentAs<List<Proprietario>>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Proprietario> GetProprietarioById(int id)
        {
            try
            {
                Uri url = new Uri(BasePath+"/byid?id="+id);
                var response = await _httpClient.GetAsync(url);
                Proprietario prop = await response.ReadContentAs<Proprietario>();
                return prop;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
