using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovolarLocadorFront.Controllers
{
    public class ImovelController : Controller
    {
        IImovelService _imovelService { get; set; }
        // GET: ImovelController

        public ImovelController(IImovelService imovelService)
        {
                _imovelService = imovelService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult<List<Imovel>> List()
        {
            var imoveis = _imovelService.FindAllSync();
            return View(imoveis);
        }

        // GET: ImovelController/Details/5
        public ActionResult<Imovel> Details(int id)
        {
            var imovel = _imovelService.FindImovel(id);
            return View(imovel);
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
