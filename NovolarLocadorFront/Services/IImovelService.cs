using NovolarLocadorFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public interface IImovelService
    {
        public List<Imovel> FindAllSync();
        public Imovel FindImovel(int id);
    }
}
