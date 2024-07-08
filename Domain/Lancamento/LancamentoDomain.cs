namespace Domain.Lancamento
{
    public class LancamentoDomain
    {
        public int Id { get; set; }
        public int Tp_Lancamento { get; set; }
        public int Tp_Movimentacao { get; set; }
        public string Nm_Descricao { get; set; }
        public decimal Vl_Saldo_Inicial { get; set; }
        public decimal Vl_Lancamento { get; set; }
        public DateTime dt_Lancamento { get; set; }
    }
}
