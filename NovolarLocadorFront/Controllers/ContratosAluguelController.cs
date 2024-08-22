using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Models.ContratosAluguel;
using NovolarLocadorFront.Services;
using System.Globalization;

namespace NovolarLocadorFront.Controllers
{
    [Route("contratosaluguel")]
    public class ContratosAluguelController : Controller
    {
        IContratoAluguelService _contratoAluguelService;
        public ContratosAluguelController(ContratoAluguelService contratoAluguelService)
        {
            _contratoAluguelService = contratoAluguelService;
        }

        [HttpGet]
        [Route("consultar/{idImovel}")]
        public async Task<ActionResult> ContratosPorImovel([FromRoute] int idImovel)
        {
            List<ContratoAluguelDto> contratosAluguel = new List<ContratoAluguelDto>();
            var contratos = await _contratoAluguelService.RetornaContratosPorImovelId(idImovel);

            foreach (var contrato in contratos)
            {
                contratosAluguel.Add(
                new ContratoAluguelDto
                {
                    Id = int.Parse(contrato.id_contrato_con),
                    DataInicio = DateTime.ParseExact(contrato.dt_inicio_con, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                    DataFim = DateTime.ParseExact(contrato.dt_fim_con, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                    ValorAluguel = decimal.Parse(contrato.vl_aluguel_con, CultureInfo.InvariantCulture)
                });
            }

            contratosAluguel = contratosAluguel.OrderBy(x => x.DataInicio).ToList();

            //numero contrato + inicio + fim / valor

            string[] detalhesContratos = new string[contratosAluguel.Count];
            decimal[] valoresContratos = new decimal[contratosAluguel.Count];

            for (int i = 0; i < contratosAluguel.Count; i++)
            {
                var detalhe = contratosAluguel.ElementAt(i);
                detalhesContratos[i] = $"Contrato: {detalhe.Id}, De: {detalhe.DataInicio.ToShortDateString()}, Até: {detalhe.DataFim.ToShortDateString()}";
                valoresContratos[i] = detalhe.ValorAluguel;
            }

            VariacoesAluguel variacoes = new VariacoesAluguel();
            variacoes.detalhes = new string[detalhesContratos.Length];
            variacoes.valores = new decimal[valoresContratos.Length];

            Array.Copy(detalhesContratos, variacoes.detalhes, detalhesContratos.Length);
            Array.Copy(valoresContratos, variacoes.valores, valoresContratos.Length);

            return Ok(variacoes);
        }
    }

    public class VariacoesAluguel
    {
        public string[] detalhes { get; set; }
        public decimal[] valores { get; set; }
    }
}
