namespace NovolarLocadorFront.Services
{
    public interface IContratoAluguelService
    {
        public Task<List<Models.ContratosAluguel.ContratoAluguel>> RetornaContratosPorImovelId(int idImovel);
    }
}
