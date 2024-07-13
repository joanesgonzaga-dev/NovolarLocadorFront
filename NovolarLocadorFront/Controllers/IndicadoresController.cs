using Microsoft.AspNetCore.Mvc;

namespace NovolarLocadorFront.Controllers
{
    public class IndicadoresController : Controller
    {
        public IActionResult Charts()
        {
            return View(nameof(Charts));
        }
    }
}
