using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Utils;
using NovolarLocadorFront.ViewModel;

namespace NovolarLocadorFront.Controllers
{
    public class ImovelController : Controller
    {
        IImovelService _imovelService { get; set; }
        ProprietarioService _proprietarioService;
        SessionService _sessionService;
        ApplicationGlobals _applicationGlobals;
        UserSession userSession { get; set; }
        public ImovelController(IImovelService imovelService, ProprietarioService proprietarioService, SessionService sessionService)
        {
            _imovelService = imovelService;
            _proprietarioService = proprietarioService;
            _sessionService = sessionService;
            _applicationGlobals = ServiceLocator._applicationGlobals;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int id)
        {
            userSession = await _sessionService.GetOrSetUserSession(id);

            ProprietarioViewModel proprietarioViewModel = new ProprietarioViewModel(userSession);
            return View(proprietarioViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            Models.Imovel.Imovel imovel = await _imovelService.FindImovelByIdAsync(id);
            
            ImovelDTO imovelDTO = _applicationGlobals._mapper.Map<ImovelDTO>(imovel);
            
            DetalhesImovelViewModel viewModel = new DetalhesImovelViewModel(imovelDTO);
            return View(viewModel);
        }

    }
}
