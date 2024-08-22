namespace NovolarLocadorFront.Models.ContratosAluguel
{
    public class ContratoAluguelDto
    {
        /// <summary>
        /// id_contrato_con
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// dt_inicio_con
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// dt_fim_con
        /// </summary>
        public DateTime DataFim { get; set; }

        /// <summary>
        /// vl_aluguel_con
        /// </summary>
        public decimal ValorAluguel { get; set; }

        /// <summary>
        /// fl_ativo_con
        /// </summary>
        public bool isAtivo { get; set; }


    }
}
