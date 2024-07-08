using Services.Lancamentos;
using System.Windows.Controls;

namespace UIFluxoCaixa.Views
{
    /// <summary>
    /// Interação lógica para UlFluxoDiario.xam
    /// </summary>
    public partial class UlFluxoDiario : UserControl
    {
        #region Variaveis
        public int Pagenumber { get; set; }
        public int PageMax { get; set; }
        public DateTime DataDia { get; set; }


        #endregion Variaveis

        #region Metodos
        internal void Contador(int _pageNumber, int _pageMax)
        {
            txtcontador.Text = $"{_pageNumber} de {_pageMax}";
        }
        #endregion Metodos

        #region Eventos
        public UlFluxoDiario()
        {
            InitializeComponent();
        }
        private void UserControl_Initialized(object sender, EventArgs e)
        {
            DataDia = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Pagenumber = 1;
            var GetLancamento = LancamentoServices.GetLancamentos(DataDia, Pagenumber, 10);
            dtgMovimentacao.ItemsSource = GetLancamento;
            if (GetLancamento.Count > 0)
            {
                PageMax = GetLancamento[0].totalPage;
                Contador(Pagenumber, PageMax);
            }
        }
        #endregion Eventos

        private void bntprimeiro_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Pagenumber = 1;
            var GetLancamento = LancamentoServices.GetLancamentos(DataDia, Pagenumber, 10);
            dtgMovimentacao.ItemsSource = GetLancamento;
            PageMax = GetLancamento[0].totalPage;
            Contador(Pagenumber, PageMax);
        }

        private void bntultimo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var GetLancamento = LancamentoServices.GetLancamentos(DataDia, Pagenumber, 10);
            dtgMovimentacao.ItemsSource = GetLancamento;
            PageMax = GetLancamento[0].totalPage;
            Contador(PageMax, PageMax);
        }

        private void bntproximo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Pagenumber < PageMax)
            {
                var proximaPagina = Pagenumber = Pagenumber + 1;
                var GetLancamento = LancamentoServices.GetLancamentos(DataDia, Pagenumber, 10);
                dtgMovimentacao.ItemsSource = GetLancamento;
                PageMax = GetLancamento[0].totalPage;
                Contador(proximaPagina, PageMax);
            }
        }

        private void bntvoltar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Pagenumber > 1)
            {
                var paginaAnterior = Pagenumber = Pagenumber - 1;
                var GetLancamento = LancamentoServices.GetLancamentos(DataDia, Pagenumber, 10);
                dtgMovimentacao.ItemsSource = GetLancamento;
                PageMax = GetLancamento[0].totalPage;
                Contador(paginaAnterior, PageMax);
            }
        }
    }
}
