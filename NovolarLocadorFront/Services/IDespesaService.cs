using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;

namespace NovolarLocadorFront.Services
{
    public interface IDespesaService
    {
        public Task<List<DespesaReadDTO>> GetDespesasPorIdImovel(int idImovel, EnumTipoDeDespesa enumTipoDeDespesa, int? ano);
    }
}
