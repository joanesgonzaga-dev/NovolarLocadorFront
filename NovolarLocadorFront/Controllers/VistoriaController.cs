using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Services;
using System.Collections.Generic;

namespace NovolarLocadorFront.Controllers
{
    public class VistoriaController : Controller
    {
        IImovelService _imovelService;

        public VistoriaController(IImovelService imovelService)
        {
                _imovelService = imovelService;
        }
        // GET: VistoriaController
        public ActionResult<List<Vistoria>> List(int id)
        {
            var vistorias = _imovelService.FindImovel(id).VISTORIAS;
            return View(vistorias);
        }

        // GET: VistoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VistoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VistoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VistoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
