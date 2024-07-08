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
using System.Windows.Shapes;
using System.Xaml;

namespace UIFluxoCaixa.Views
{
    /// <summary>
    /// Lógica interna para MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    { 
        #region Eventos
        public MainWindows()
        {
            InitializeComponent();
        }
       
        private void bntCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
            UlCadastro ulCadastro = new UlCadastro();
            AbrirModal(ulCadastro);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UlFluxoDiario ulFluxoDiario = new UlFluxoDiario();
            AbrirModal(ulFluxoDiario);
        }

        private void bntCaixa_Click(object sender, RoutedEventArgs e)
        {
            UlFluxoDiario ulFluxoDiario = new UlFluxoDiario();
            AbrirModal(ulFluxoDiario);
        }
        private void bntRelatorio_Click(object sender, RoutedEventArgs e)
        {
            UlConsolidado ulConsolidado = new UlConsolidado();
            AbrirModal(ulConsolidado);
        }
        #endregion eventos

        #region Metodos

        internal void AbrirModal(UserControl userControl)
        {
            GridInterface.Children.Clear();
            GridInterface.Children.Add(userControl);
        }

        #endregion Metodos
    }



}
