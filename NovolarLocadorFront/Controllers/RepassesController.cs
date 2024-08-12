using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Services;

namespace NovolarLocadorFront.Controllers
{
    public class RepassesController : Controller
    {
        IRepasseService _repasseService;

        public RepassesController(IRepasseService repasseService)
        {
            _repasseService = repasseService;
        }

        [HttpGet]
        [Route("/repasses/{ano}/{id}")]
        public async Task<ActionResult> RepassesPorFavorecido([FromRoute] int ano, int id)
        {
            var repasses = await _repasseService.GetRepassesPorFavorecidoAsync(ano, id);
            return View(repasses); 
        }
    }
}
