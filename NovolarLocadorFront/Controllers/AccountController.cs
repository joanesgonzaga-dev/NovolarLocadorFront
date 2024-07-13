using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.ViewModel.Login;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Controllers
{
    public class AccountController : Controller
    {
        IProprietarioService _proprietarioService;
        
        public AccountController(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }
        public async Task<IActionResult> Login()
        {
            List<Proprietario> proprietarios = await _proprietarioService.GetAllProprietariosAsync();
            
            return View(proprietarios);
        }
    }
}
