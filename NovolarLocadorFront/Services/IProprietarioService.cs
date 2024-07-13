using NovolarLocadorFront.Models.Proprietario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Services
{
    public interface IProprietarioService
    {
        public Task<List<Proprietario>> GetAllProprietariosAsync();

        public Task<Proprietario> GetProprietarioById(int id);


    }
}
