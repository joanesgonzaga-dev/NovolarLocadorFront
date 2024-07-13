using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        ApplicationGlobals _applicationGlobals;
        private readonly IMapper _mapper;
        //StateManager _stateManager;
        // GET: ImovelController

        public ImovelController(IImovelService imovelService, ProprietarioService proprietarioService, ApplicationGlobals applicationGlobals, IMapper mapper)
        {
            _imovelService = imovelService;
            _proprietarioService = proprietarioService;
            _applicationGlobals = applicationGlobals;
            _mapper = mapper;
            //_applicationGlobals = applicationGlobals;
            //_stateManager = stateManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<List<Imovel>>> List([FromQuery] int id)
        {
            if ( id > 0 && (_applicationGlobals.Proprietario is null || !(_applicationGlobals.Proprietario.id_pessoa_pes.Equals(id))))
            {
                _applicationGlobals.Proprietario = await _proprietarioService.GetProprietarioById(id);
                _applicationGlobals.CarregaImoveis();
            }


            ProprietarioViewModel viewModel = new ProprietarioViewModel(_applicationGlobals);
            return View(viewModel);
        }

        // GET: ImovelController/Details/5
        public async Task<ActionResult<Imovel>> Details(int id)
        {
            var imovel = await _imovelService.FindImovelByIdAsync(id);
            ImovelDTO imovelDTO = _mapper.Map<ImovelDTO>(imovel);
            DetalhesImovelViewModel viewModel = new DetalhesImovelViewModel(_applicationGlobals, imovelDTO);
            return View(viewModel);
        }

        // GET: ImovelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImovelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImovelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImovelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImovelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImovelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
