using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.ViewModel.Login
{
    public class LoginViewModel
    {
        public List<Proprietario> proprietarios;
        public IProprietarioService _proprietarioService;

        public LoginViewModel(){}

        public LoginViewModel(ProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
            CarregaProprietarios();
        }

        public async void CarregaProprietarios()
        {
            proprietarios = await _proprietarioService.GetAllProprietariosAsync();
        }
    }
}
