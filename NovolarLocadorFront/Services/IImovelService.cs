using NovolarLocadorFront.Models.DeadEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public interface IImovelService
    {
        public List<Imovel> FindAllSync();
        public Task<Models.Imovel.Imovel> FindImovelByIdAsync(int id);
    }
}
