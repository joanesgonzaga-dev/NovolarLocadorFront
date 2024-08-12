using NovolarLocadorFront.Models.Despesa;

namespace NovolarLocadorFront.Services
{
    public interface IRepasseService
    {
        Task<List<RepasseDTO>> GetRepassesPorFavorecidoAsync(int ano, int idBeneficiario);
    }
}