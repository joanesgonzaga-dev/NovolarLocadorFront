using NovolarLocadorFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public interface ILocadorService
    {
        public Task<List<Locador>> GetAllAsync();
    }
}
