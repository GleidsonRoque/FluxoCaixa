using System.ComponentModel;

namespace Domain.DTO
{
    public class DtoLancamento
    {
        public string Desc_TipoLancamento { get; set; }
        public string Nm_Movimentacao { get; set; }
        public string Nm_Descricao { get; set; }
        public float Vl_Lancamento { get; set; }
        public string Dt_Lancamento { get; set; }
        public int totalPage { get; set; }
    }
    public class DtoConsolidado
    {
        public decimal Entrada { get; set; }
        public decimal Saida { get; set; }
        public decimal Saldo { get; set; }
    }
}
