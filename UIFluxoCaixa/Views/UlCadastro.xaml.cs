using Domain.Lancamento;
using Services.Lancamentos;
using System.Windows;
using System.Windows.Controls;

namespace UIFluxoCaixa.Views
{
    /// <summary>
    /// Interação lógica para UlCadastro.xam
    /// </summary>
    public partial class UlCadastro : UserControl
    {
        #region Eventos
        public UlCadastro()
        {
            InitializeComponent();            
        }
       
        private void bntCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Salvar();
        }

        private void bntFechar_Click(object sender, RoutedEventArgs e)
        {
            Fechar();
        }
        #endregion Eventos

        #region Metodos
        internal void Erro(string mensagem)
        {
            MessageBox.Show(mensagem,"Erro",MessageBoxButton.OK, MessageBoxImage.Error);
        }
        internal void Alert(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        internal void Salvar()
        { 
            LancamentoDomain lancamento = new LancamentoDomain();
            if (string.IsNullOrEmpty(cmbLancamento.Text))
            {   
                Alert("Informe o tipo de lançamento!"); 
                return;
            }
            if (string.IsNullOrEmpty(cmbMovimentacao.Text))
            {
                Alert("Informe o tipo de movimentação!");
                return;
            }
            if (string.IsNullOrEmpty(txtMovimentacao.Text))
            {
                Alert("Informe a descrição da movimentação!");
                return;
            }
            if (string.IsNullOrEmpty(txtvalorLancamento.Text))
            {
                Alert("Informe o valor do lançamento");
                return;
            }
            if (cmbLancamento.Text == "Entrada")
            {
                lancamento.Tp_Lancamento= 1;
            }
            else
            {
                lancamento.Tp_Lancamento= 2;
            }
            if (cmbMovimentacao.Text == "Crédito")
                {
                    lancamento.Tp_Movimentacao = 1;
                }
                else
                {
                    lancamento.Tp_Movimentacao = 2;
                }                
            lancamento.Nm_Descricao = txtMovimentacao.Text;
            lancamento.Vl_Lancamento = Convert.ToDecimal(txtvalorLancamento.Text.Replace("R$", "").Trim());
            lancamento.dt_Lancamento = DateTime.Now;
            try
            {
                var result = LancamentoServices.AddLancamento(lancamento);
                LimparCampos();
                if (result[0].status.Equals(false))
                {
                    throw new Exception(result[0].errMotivo);
                }
                
            }
            catch (Exception ex)
            {
                Erro($"Ocorreu o seguinte erro ao tentar efetuar o cadastro: {ex.Message}");                
            }
        }

        internal void Fechar()
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        internal void LimparCampos()
        {
            cmbLancamento.Text = string.Empty;
            cmbMovimentacao.Text = string.Empty;
            txtMovimentacao.Text = string.Empty;
            txtvalorLancamento.Text = string.Empty;
        }

        #endregion Metodos
    }
}
