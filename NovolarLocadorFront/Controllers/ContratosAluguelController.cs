using Microsoft.AspNetCore.Mvc;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.ContratosAluguel;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Utils;
using System.Drawing;
using System.Globalization;

namespace NovolarLocadorFront.Controllers
{
    [Route("contratosaluguel")]
    public class ContratosAluguelController : Controller
    {
        IContratoAluguelService _contratoAluguelService;
        ApplicationGlobals _applicationGlobals;

        public ContratosAluguelController(ContratoAluguelService contratoAluguelService)
        {
            _contratoAluguelService = contratoAluguelService;
            _applicationGlobals = ServiceLocator._applicationGlobals;
        }

        [HttpGet]
        [Route("consultar/{idImovel}")]
        public async Task<ActionResult> ContratosPorImovel([FromRoute] int idImovel)
        {
            List<ContratoAluguelDto> contratosAluguelDto = new List<ContratoAluguelDto>();
            var contratos = await _contratoAluguelService.RetornaContratosPorImovelId(idImovel);

            foreach (var contrato in contratos)
            {
                contratosAluguelDto.Add(
                new ContratoAluguelDto
                {
                    Id = int.Parse(contrato.id_contrato_con),
                    DataInicio = DateTime.ParseExact(contrato.dt_inicio_con, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                    DataFim = DateTime.ParseExact(contrato.dt_fim_con, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                    ValorAluguel = decimal.Parse(contrato.vl_aluguel_con, CultureInfo.InvariantCulture),
                    Reajustes = _applicationGlobals._mapper.Map<List<ReajusteDto>>(contrato.contratos_reajustes)
                });
            }

            #region contratosMock
            /*
            ContratoAluguelDto contratoDto1 = new ContratoAluguelDto();
            contratoDto1.Id = 100;
            contratoDto1.DataInicio = new DateTime(2019, 01, 01);
            contratoDto1.DataFim = new DateTime(2019, 07, 31);
            contratoDto1.ValorAluguel = 1500M;
            contratoDto1.Reajustes = new List<ReajusteDto>();


            ContratoAluguelDto contratoDto2 = new ContratoAluguelDto();
            contratoDto2.Id = 200;
            contratoDto2.DataInicio = new DateTime(2019, 09, 05);
            contratoDto2.DataFim = new DateTime(2019, 12, 31);
            contratoDto2.ValorAluguel = 1550M;
            contratoDto2.Reajustes = new List<ReajusteDto>();

            ContratoAluguelDto contratoDto3 = new ContratoAluguelDto();
            contratoDto3.Id = 300;
            contratoDto3.DataInicio = new DateTime(2020, 01, 15);
            contratoDto3.DataFim = new DateTime(2020, 12, 31);
            contratoDto3.ValorAluguel = 2600M;
            contratoDto3.Reajustes = new List<ReajusteDto>();
            ReajusteDto reajuste301 = new ReajusteDto();
            reajuste301.Id = 301;
            reajuste301.ValorAntigo = 1550M;
            reajuste301.ValorNovo = 2000M;
            reajuste301.DataReajuste = new DateTime(2020, 01, 15);
            ReajusteDto reajuste302 = new ReajusteDto();
            reajuste302.Id = 302;
            reajuste302.ValorAntigo = 2000M;
            reajuste302.ValorNovo = 2600M;
            reajuste302.DataReajuste = new DateTime(2020, 07, 20);
            contratoDto3.Reajustes.Add(reajuste301);
            contratoDto3.Reajustes.Add(reajuste302);


            ContratoAluguelDto contratoDto4 = new ContratoAluguelDto();
            contratoDto4.Id = 400;
            contratoDto4.DataInicio = new DateTime(2020, 01, 15);
            contratoDto4.DataFim = new DateTime(2020, 12, 31);
            contratoDto4.ValorAluguel = 2700M;
            contratoDto4.Reajustes = new List<ReajusteDto>();
            ReajusteDto reajuste401 = new ReajusteDto();
            reajuste401.Id = 401;
            reajuste401.ValorAntigo = 2600M;
            reajuste401.ValorNovo = 2650.50M;
            reajuste401.DataReajuste = new DateTime(2020, 01, 15);
            ReajusteDto reajuste402 = new ReajusteDto();
            reajuste402.Id = 402;
            reajuste402.ValorAntigo = 2650.50M;
            reajuste402.ValorNovo = 2700.80M;
            reajuste402.DataReajuste = new DateTime(2020, 07, 20);
            contratoDto4.Reajustes.Add(reajuste401);
            contratoDto4.Reajustes.Add(reajuste402);

            contratosAluguelDto.Add(contratoDto1);
            contratosAluguelDto.Add(contratoDto2);
            contratosAluguelDto.Add(contratoDto3);
            contratosAluguelDto.Add(contratoDto4);
            */
            #endregion

            contratosAluguelDto = contratosAluguelDto.OrderBy(x => x.DataInicio).ToList();
            List<int> anosReajuste = new List<int>();
           
            foreach (var contrato in contratosAluguelDto)
            {
                if (contrato.Reajustes is null || contrato.Reajustes.Count <= 0)
                {
                    anosReajuste.Add(contrato.DataInicio.Year);
                    contrato.Reajustes.Add(
                        new ReajusteDto
                        {
                            DataReajuste = contrato.DataInicio,
                            ValorNovo = contrato.ValorAluguel,
                        });
                }
                else
                {
                    foreach (var reajuste in contrato.Reajustes)
                    {
                        anosReajuste.Add(reajuste.DataReajuste.Year);
                    }
                }
            }
            anosReajuste.Sort();
            
            List<LineChartDataSet> dataSets = new List<LineChartDataSet>();
            List<decimal> valoresVariacoes = new List<decimal>();

            foreach (var contrato in contratosAluguelDto)
            {
                LineChartDataSet dataSet = new LineChartDataSet();
                dataSet.label = $"Contrato {contrato.Id}";
                dataSet.borderColor = Color.Red;
                dataSet.backgroundColor = Color.Red;
                dataSet.tension = 0.5f;
                dataSet.fill = true;
                //dataSet.yAxisID = "y";
                //dataSet.xAxisID = "x";

                decimal[] valoresContrato = new decimal[contrato.Reajustes.Count];
                

                for (int i = 0; i < contrato.Reajustes.Count; i++)
                {
                    valoresContrato[i] = contrato.Reajustes.ElementAt(i).ValorNovo;
                }

                dataSet.data = new object[valoresVariacoes.Count + contrato.Reajustes.Count];

                //for (int i = 0; i < valoresVariacoes.Count; i++)
                //{
                //    dataSet.data[i] = null;
                //}

                Array.Copy(valoresVariacoes.ToArray(), 0, dataSet.data, 0,valoresVariacoes.Count);
                Array.Copy(valoresContrato, 0,dataSet.data, valoresVariacoes.Count,valoresContrato.Length);

                foreach (var item in valoresContrato)
                {
                    valoresVariacoes.Add(item);
                }

                dataSets.Add(dataSet);
            }
            int[] arrayAnosComReajustes = anosReajuste.ToArray();

            VariacoesAlugueisData data = new VariacoesAlugueisData();
            data.AnosComReajustes = arrayAnosComReajustes;
            data.DataSets = dataSets;
            
            return Ok(data);
        }
    }

    public class LineChartDataSet
    {
        public string label { get; set; }
        public object[] data { get; set; }
        public Color borderColor { get; set; }
        public Color backgroundColor { get; set; }
        //public string yAxisID { get; set; }
        //public string xAxisID { get; set; }
        public float tension { get; set; }
        public bool fill { get; set; }
    }

    public class VariacoesAlugueisData
    {
        public int[] AnosComReajustes { get; set; }
        public List<LineChartDataSet> DataSets { get; set; } = new List<LineChartDataSet>();
    }
}
