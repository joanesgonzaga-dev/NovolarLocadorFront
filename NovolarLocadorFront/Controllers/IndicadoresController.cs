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
        IRepasseService _repasseService;
        public IndicadoresController(SessionService sessionService, IRepasseService repasseService)
        {
            _sessionService = sessionService;
            _repasseService = repasseService;
        }
        public IActionResult Charts(int id)
        {
            var userSession = _sessionService.GetOrSetUserSession(id);
            ChartsViewModel chartsViewModel = new ChartsViewModel(userSession);

            List<string> anos = new List<string>();
            anos.Add("2019");
            anos.Add("2020");
            anos.Add("2021");
            anos.Add("2022");
            anos.Add("2023");
            anos.Add("2024");

            ViewData["anoRepassesComboBox"] = new SelectList(anos, DateTime.Now.Year);
            
            return View(chartsViewModel);
        }

        private EnumMesesIndexados[] RetornaMesesDoAno(int anoDaConsulta)
        {
            EnumMesesIndexados[] meses;
            int anoAtual = DateTime.Now.Year;
            int totalMeses = anoDaConsulta == anoAtual ? DateTime.Now.Month : 12;

            meses = new EnumMesesIndexados[totalMeses];

            for (int i = 0; i < meses.Length; i++)
            {
                meses[i] = (EnumMesesIndexados)ServiceLocator._applicationGlobals.MesesDoAno.ElementAt(i).Key;
            }

            return meses;
        }

        [HttpGet]
        [Route("RetornaCaixas/{anoConsulta}/{idFavorecido}")]
        public async Task<ActionResult> RetornaCaixaMesesDoAno([FromRoute] int anoConsulta, int idFavorecido)
        {
            List<RepasseDTO> repasses = await _repasseService.GetRepassesPorFavorecidoAsync(anoConsulta, idFavorecido);
            EnumMesesIndexados[] meses = RetornaMesesDoAno(anoConsulta);
            CaixaMeses caixaMeses = new CaixaMeses();
            caixaMeses.Meses = new List<string>();
            caixaMeses.ValoresRepasses = new List<decimal>();
            caixaMeses.ValoresDespesas = new List<decimal>();

            for (int i = 0; i < meses.Length; i++)
            {
                CaixaMes caixa = new CaixaMes();
                caixa.Repasses = new List<RepasseDTO>();
                caixa.Mes = meses[i];
                caixa.Ano = anoConsulta;
                foreach (var repasse in repasses)
                {
                    DateTime dataRecebimento = DateTime.ParseExact(repasse.DataRecebimento, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                    if ((dataRecebimento.Month - 1) == i)
                    {
                        caixa.Repasses.Add(repasse);
                        caixa.TotalRepasses += repasse.ValorRepasse;
                    }
                }

                caixaMeses.Meses.Add(Enum.GetName(typeof(EnumMesesIndexados), caixa.Mes));
                caixaMeses.ValoresRepasses.Add(caixa.TotalRepasses);
            }


            return Json(caixaMeses);
        }

    }
}
