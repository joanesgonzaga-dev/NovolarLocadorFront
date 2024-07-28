using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.ViewModel;

namespace NovolarLocadorFront.Controllers
{
    public class IndicadoresController : Controller
    {
        SessionService _sessionService;
        public IndicadoresController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public IActionResult Charts(int id)
        {
            var userSession = _sessionService.GetOrSetUserSession(id);
            ChartsViewModel chartsViewModel = new ChartsViewModel(userSession);
            
            return View(chartsViewModel);
        }
    }
}
