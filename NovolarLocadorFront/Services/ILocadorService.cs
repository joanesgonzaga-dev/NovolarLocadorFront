using NovolarLocadorFront.Models.DeadEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public interface ILocadorService
    {
        public List<Locador> GetAllAsync();
    }
}
