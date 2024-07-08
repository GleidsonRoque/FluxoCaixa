using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIFluxoCaixa.Views
{
    /// <summary>
    /// Interação lógica para UlConsolidado.xam
    /// </summary>
    public partial class UlConsolidado : UserControl
    {
        #region Variaveis        
        public DateTime DataDia { get; set; }

        #endregion Variaveis

        #region Eventos
        public UlConsolidado()
        {
            InitializeComponent();
        }

        private void bntFechar_Click(object sender, RoutedEventArgs e)
        {
            Fechar();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataDia = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            CarregarRelatorioEntrada(DataDia);
            CarregaRelatorioSaida(DataDia);
            CarregaConsolidado(DataDia);
        }
        private void dataEntrada_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {           
            DataDia = Convert.ToDateTime(sender.ToString());
            CarregarRelatorioEntrada(DataDia);
            CarregaRelatorioSaida(DataDia);
            CarregaConsolidado(DataDia);
        }
        #endregion Eventos

        #region Metodos
        internal void Fechar()
        {
            (this.Parent as Grid).Children.Remove(this);
        }
        internal void CarregarRelatorioEntrada(DateTime date)
        {
            dtgMovimentacaoEntrada.ItemsSource = Services.Lancamentos.LancamentoServices.GetEntradaConsolidado(date);
        }

        internal void CarregaRelatorioSaida(DateTime date)
        {
            dtgMovimentacaoSaida.ItemsSource = Services.Lancamentos.LancamentoServices.GetSaidaConsolidado(date);
        }
        internal void CarregaConsolidado(DateTime date)
        {
            var consolidado = Services.Lancamentos.LancamentoServices.GetConsolidadoDiaria(date);
            lblEntrada.Content = string.Format("{0:C}", consolidado[0].Entrada);
            lblsaida.Content = string.Format("{0:C}", consolidado[0].Saida);
            lblSaldo.Content = string.Format("{0:C}", consolidado[0].Saldo);
        }

        #endregion Metodos

        
    }
}
