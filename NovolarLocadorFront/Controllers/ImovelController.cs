using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.DeadEntities;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Utils;
using NovolarLocadorFront.ViewModel;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

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

        public ActionResult<List<Imovel>> List(int id)
        {
            userSession = _sessionService.GetOrSetUserSession(id);

            ProprietarioViewModel viewModel = new ProprietarioViewModel(userSession);
            return View(viewModel);
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
