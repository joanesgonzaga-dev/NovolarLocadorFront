using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.DeadEntities;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.ViewModel;
using System.Collections.Generic;

namespace NovolarLocadorFront.Controllers
{
    [Route("Vistoria")]
    public class VistoriaController : Controller
    {
        SessionService _sessionService;
        UserSession userSession { get; set; }
        public VistoriaController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(int id)
        {
            userSession = await _sessionService.GetOrSetUserSession(id);
            ProprietarioViewModel proprietarioViewModel = new ProprietarioViewModel(userSession);
            ViewData["imovelComboBox"] = new SelectList(userSession.Imoveis, "Id", "Detalhes");

            return View(proprietarioViewModel);
        }
    }
}
