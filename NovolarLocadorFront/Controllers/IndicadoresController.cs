using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.CaixaProprietario;
using NovolarLocadorFront.Models.Despesa;
using NovolarLocadorFront.Models.Enums;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Utils;
using NovolarLocadorFront.ViewModel;
using System.Globalization;

namespace NovolarLocadorFront.Controllers
{
    [Route("indicadores")]
    public class IndicadoresController : Controller
    {
        SessionService _sessionService;
        IIndicadoresService _indicadoresService;
        public IndicadoresController(SessionService sessionService, IIndicadoresService indicadoresService)
        {
            _sessionService = sessionService;
            _indicadoresService = indicadoresService;
        }
        public async Task<IActionResult> Charts(int id)
        {
            try
            {
                var userSession = await _sessionService.GetOrSetUserSession(id);
                ChartsViewModel chartsViewModel = new ChartsViewModel(userSession);

                List<string> anos = new List<string>();
                anos.Add("2019");
                anos.Add("2020");
                anos.Add("2021");
                anos.Add("2022");
                anos.Add("2023");
                anos.Add("2024");

                ViewData["anoRepassesComboBox"] = new SelectList(anos, DateTime.Now.Year.ToString());
                ViewData["anoVariacaoAluguelComboBox"] = new SelectList(anos, DateTime.Now.Year.ToString());
                ViewData["imovelVariacaoAluguelComboBox"] = new SelectList(userSession.Imoveis, "Id", "Detalhes");

                return View(chartsViewModel);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //private EnumMesesIndexados[] RetornaMesesDoAno(int anoDaConsulta)
        //{
        //    EnumMesesIndexados[] meses;
        //    int anoAtual = DateTime.Now.Year;
        //    int totalMeses = anoDaConsulta == anoAtual ? DateTime.Now.Month : 12;

        //    meses = new EnumMesesIndexados[totalMeses];

        //    for (int i = 0; i < meses.Length; i++)
        //    {
        //        meses[i] = (EnumMesesIndexados)ServiceLocator._applicationGlobals.MesesDoAno.ElementAt(i).Key;
        //    }
        //    return meses;
        //}

        [HttpGet]
        [Route("RetornaCaixas/{idProprietario}/{anoConsulta}")]
        public async Task<ActionResult> RetornaCaixaMesesDoAno([FromRoute] int idProprietario, int anoConsulta)
        {
            CaixaMeses caixaMeses = await _indicadoresService.GetCaixaMesesDoAnoPorFavorecido(idProprietario, anoConsulta);
            return Json(caixaMeses);
        }

    }
}
