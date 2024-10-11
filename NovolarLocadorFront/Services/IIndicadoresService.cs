using NovolarLocadorFront.Models;

namespace NovolarLocadorFront.Services
{
    public interface IIndicadoresService
    {
        public Task<CaixaMeses> GetCaixaMesesDoAnoPorFavorecido(int partitionKey, int rowKey);
    }
}
