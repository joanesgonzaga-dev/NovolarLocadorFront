using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Services;

namespace NovolarLocadorFront.Controllers
{
    [ApiController]
    public class DespesasController : Controller
    {
        IDespesaService _despesaService;

        public DespesasController(DespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        //[HttpGet("id")]
        //public async Task<ActionResult<List<DespesaReadDTO>>> List([FromQuery] int id)
        //{
        //    Console.WriteLine($"A requisição ocorreu e buscou pelo Id: {id}");
        //    var alugueis = await _despesaService.GetDespesasPorIdImovel(id);
            
        //    return View(nameof(List), alugueis);
        //}

        [HttpGet]
        [Route("/despesas/{id}/{tipoDeDespesa}/{ano?}")]
        public async Task<ActionResult> GetDespesasPorTipoPorImovelId([FromRoute] int id, EnumTipoDeDespesa tipoDeDespesa, int? ano)
        {
            var despesas = await _despesaService.GetDespesasPorIdImovel(id, tipoDeDespesa, ano);
            return Ok(despesas);
        }
    }
}
