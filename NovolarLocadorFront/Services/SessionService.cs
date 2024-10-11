using Microsoft.Extensions.Caching.Memory;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Proprietario;

namespace NovolarLocadorFront.Services
{
    public class SessionService
    {
        private readonly IMemoryCache _cache;
        IImovelService _imovelService;
        IProprietarioService _proprietarioService;

        public SessionService(IMemoryCache cache, IImovelService movelService, IProprietarioService proprietarioService)
        {
            _cache = cache;
            _imovelService = movelService;
            _proprietarioService = proprietarioService;
        }

        public async Task<UserSession> GetOrSetUserSession(int proprietarioId)
        {
            if (!_cache.TryGetValue(proprietarioId, out UserSession userSession))
            {

                userSession = new UserSession();
                userSession._imovelService = _imovelService;
                userSession.Proprietario = await _proprietarioService.GetProprietarioById(proprietarioId).ConfigureAwait(false);
                userSession.CarregaImoveis();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(15));
                _cache.Set(proprietarioId, userSession, cacheEntryOptions);
            }

            return userSession;
        }
    }
}
