namespace NovolarLocadorFront.Models.Despesa
{
    /// <summary>
    /// Classe que representa o repasse de valores Imobiliária => Locador.
    /// </summary>
    public class RepasseDTO
    {
        private decimal _valorRepasse;

        /// <summary>
        /// id_favorecido_fav
        /// </summary>
        public int CodigoFavorecido { get; set; }

        public bool isRecebimento { get; set; }

        /// <summary>
        /// dt_vencimentooriginal_mov
        /// </summary>
        public string Vencimento { get; set; }
        /// <summary>
        /// dt_liquidacao_mov
        /// </summary>
        public string DataRecebimento { get; set; }

        /// <summary>
        /// fl_status_mov: 0 = Não repassado, 1 = Repassado
        /// </summary>
        public int StatusRepasse { get; set; }

        /// <summary>
        /// vl_valor_mov
        /// </summary>
        public decimal ValorRepasse
        {
            get => _valorRepasse;
            set
            {
                if (!isRecebimento)
                {
                    _valorRepasse = Math.Abs(value);
                }
            } 
        }
    }
}
