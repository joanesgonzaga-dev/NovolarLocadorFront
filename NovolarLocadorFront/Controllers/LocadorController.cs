using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Controllers
{
    public class LocadorController : Controller
    {
        private ILocadorService _locadorService;
        public LocadorController(ILocadorService locadorService)
        {
                _locadorService = locadorService;
        }
        // GET: LocadorController
        public ActionResult<IEnumerable<Locador>> Index()
        {
            var locadores = _locadorService.GetAllAsync();
            return View(locadores);
        }

        // GET: LocadorController/Details/5
        public ActionResult Details(int id)
        {
            var locadores = _locadorService.GetAllAsync();

            
            return View(locadores.Find(l => l.ID_PESSOA_PE == id));
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
