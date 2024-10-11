using DataChartUpdateService.Model;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.Extensions.Logging;


namespace DataChartUpdateService
{
    public class Updater : IHostedService
    {
        private Timer? _timer;
        private readonly HttpClient _httpClient = new HttpClient();
        public string BasePath = "https://localhost:7288/proprietarios";
        private readonly ILogger<Updater> _logger;
        
        public Updater(ILogger<Updater> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
           _logger.LogInformation("Serviço iniciou");
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
            _timer = new Timer(ExecuteDoWork, null, TimeSpan.Zero, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }
        private async void ExecuteDoWork(object? state)
        {
            try
            {
                await DoWork();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex}");
            }    
        }
        private async Task DoWork()
        {
            try
            {
                _logger.LogInformation($"Executei em uma consulta a proprietário às {DateTime.Now}");
                var props = await ConsultarProprietarios();
                foreach (var item in props)
                {
                    _logger.LogInformation($"Nome do proprietário: {item.st_nome_pes}");
                    //TODO: CONSULTAR E PRINTAR OS DADOS DE CHARTBAR DE CADA CLIENTE: FEITO
                }
                foreach (var proprietario in props)
                {
                    string path = $"https://localhost:5001/indicadores/RetornaCaixas/{proprietario.id_pessoa_pes}/{2024}/{proprietario.id_favorecido_fav}";
                    _logger.LogInformation($"Consultando dados do Proprietario:{proprietario.st_nome_pes}");
                    var response = await _httpClient.GetAsync(path);
                    string conteudo = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    _logger.LogInformation($"Dados do Proprietario:{proprietario.st_nome_pes}; Status: {proprietario.fl_status_pes}");
                    _logger.LogInformation($"Conteúdo:\n{conteudo}");
                    _logger.LogInformation($"---------------------------------------------------------------------");
                    await Task.Delay(3000);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao consultarReceitas/Despesas {ex.Message} \n {ex.StackTrace}");
                //throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogError("Serviço encerrou");
            return Task.CompletedTask;
        }

        private async Task<List<Proprietario>> ConsultarProprietarios()
        {
            try
            {
                var response = await _httpClient.GetAsync(BasePath);

                if (response.IsSuccessStatusCode)
                {
                    var proprietarios = await response.ReadContentAs<List<Proprietario>>();
                    return proprietarios;
                }
                else
                {
                    // Aqui, lançar uma exceção personalizada ou logar a resposta
                    _logger.LogError($"Erro ao consultar proprietários: {response.StatusCode}");
                    throw new HttpRequestException($"Erro ao consultar proprietários: {response.StatusCode}");
                }       
            }
            catch (HttpRequestException ex)
            {
                // Logar a exceção ou tratar de forma mais adequada
                _logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // Log para outras exceções
                _logger.LogError(ex, $"Erro inesperado: {ex.Message}");
                throw;
            }
        }
    }
}
