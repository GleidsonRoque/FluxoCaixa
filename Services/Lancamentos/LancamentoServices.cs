using Dapper;
using Domain.DTO;
using Domain.Lancamento;
using Domain.Movimentacao;
using Infrastructure.DataBase;
using System.Text;

namespace Services.Lancamentos
{
    public class LancamentoServices : DbContext
    {
        public static List<VerificacaoDomain> AddLancamento(LancamentoDomain lancamento)
        {
            List<VerificacaoDomain> resultadoTransacao = new List<VerificacaoDomain>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Insert into Tb_Lancamento");
            sb.AppendLine("(Tp_Lancamento,Tp_Movimentacao,Nm_Descricao,Vl_Saldo_Inicial,Vl_Lancamento,dt_Lancamento)");
            sb.AppendLine("Values");
            sb.AppendLine($"({lancamento.Tp_Lancamento},{lancamento.Tp_Movimentacao},'{lancamento.Nm_Descricao}',");
            sb.AppendLine($"{lancamento.Vl_Saldo_Inicial},replace('{lancamento.Vl_Lancamento}',',','.'),'{lancamento.dt_Lancamento}')");
            try
            {
                GetConnection().Execute(sb.ToString());
                resultadoTransacao.Add(new VerificacaoDomain { status = true });
            }
            catch (Exception ex)
            {
                resultadoTransacao.Add(new VerificacaoDomain { status = false, errMotivo = ex.Message });
            }
            return resultadoTransacao;
        }
        public static int MaxPagina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*)/10 from TB_Lancamento");
            return GetConnection().Query<int>(sb.ToString()).First();
        }

        public static List<DtoLancamento> GetLancamentos(DateTime Data, int? pageNumber = null, int? pagesize = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"execute SP_ConsultaFluxo @pageNumber = {pageNumber},@pagesize={pagesize},@date='{Data}'");
            try
            {
                return GetConnection().Query<DtoLancamento>(sb.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DtoLancamento> GetEntradaConsolidado(DateTime Data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Execute SP_EntradaConsolidada @date = '{Data}'");
            try
            {
                return GetConnection().Query<DtoLancamento>(sb.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DtoLancamento> GetSaidaConsolidado(DateTime Data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Execute SP_SaidaConsolidada @date = '{Data}'");
            
            try
            {
                return GetConnection().Query<DtoLancamento>(sb.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DtoConsolidado>GetConsolidadoDiaria(DateTime Data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Execute SP_ConsolidadoDiario @data = '{Data}'");
            try
            {
                return GetConnection().Query<DtoConsolidado>(sb.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public enum TipoLancamento
        {
            Entrada = 1,
            Saída = 2
        }
        public enum TipoMovimentacao
        {
            Crédito = 1,
            Débito = 2,
        }
    }
}
