using Domain.Lancamento;

namespace UnitTestData
{
    [TestClass]
    public class TesteInsert
    {
        [TestMethod]
        public void InserirdadosFluxoCaixa()
        {
            //Arrange
            
            LancamentoDomain lancamento = new LancamentoDomain();
            lancamento.Tp_Movimentacao = 1;
            lancamento.Tp_Lancamento= 1;
            lancamento.Nm_Descricao = "Entrada de dados para testes";
            lancamento.Vl_Saldo_Inicial = 100;
            lancamento.Vl_Lancamento = 50;
            lancamento.dt_Lancamento = DateTime.Now;

            //Act
            
             var result = Services.Lancamentos.LancamentoServices.AddLancamento(lancamento);

            //Assert
            Assert.IsTrue(result[0].status);
        }
    }
}