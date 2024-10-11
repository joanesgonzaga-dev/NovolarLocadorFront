using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovolarLocadorFront.Models;
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
        SessionService _sessionService;
        UserSession userSession { get; set; }

        public AccountController(IProprietarioService proprietarioService, SessionService sessionService)
        {
            _proprietarioService = proprietarioService;
            _sessionService = sessionService;
        }
        public async Task<IActionResult> Login()
        {
            List<Proprietario> proprietarios = await _proprietarioService.GetAllProprietariosAsync();
            
            return View(proprietarios);
        }

        public async Task<IActionResult> Access(int id)
        {
            var userSession = await _sessionService.GetOrSetUserSession(id);
            var userSessionDataJson = JsonConvert.SerializeObject(userSession);
            HttpContext.Session.SetString("userSessionDataJson", userSessionDataJson);
            var url = Url.Action("List", "Imovel", new {id = id});
            return Redirect(url);
        }
    }
}
