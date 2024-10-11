using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.DeadEntities;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.ViewModel;

namespace NovolarLocadorFront.Controllers
{
    public class LocadorController : Controller
    {
        private ILocadorService _locadorService;
        ApplicationGlobals _applicationGlobals;
        SessionService _sessionService;
        UserSession userSession;
        public LocadorController(ILocadorService locadorService, ApplicationGlobals applicationGlobals, SessionService sessionService)
        {
                _locadorService = locadorService;
            _applicationGlobals = applicationGlobals;
            _sessionService = sessionService;
        }
        // GET: LocadorController
        public ActionResult<IEnumerable<Locador>> Index()
        {
            var locadores = _locadorService.GetAllAsync();
            return View(locadores);
        }

        // GET: LocadorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var locadores = _locadorService.GetAllAsync();
            userSession = await _sessionService.GetOrSetUserSession(id);
            ProprietarioViewModel viewModel = new ProprietarioViewModel(userSession);
            
            return View(viewModel);
        }

        // GET: LocadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocadorController/Create
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

        // GET: LocadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocadorController/Edit/5
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

        // GET: LocadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocadorController/Delete/5
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
