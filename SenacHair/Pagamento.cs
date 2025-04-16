using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;

namespace SenacHair
{
    public class Pagamento
    {
        public int id { get; set; }
        public decimal valor { get; set; }
        public int agendamentoID { get; set; }
        public int formaPagamentoId { get; set; }
        public DateTime data;

        private readonly AcessoBD acesso = new AcessoBD();
        private List<SqlParameter> parametros = new List<SqlParameter>();
        private string sql = string.Empty;

        public Pagamento()
        {
            agendamentoID = 0;
            formaPagamentoId = 0;
        }

        public void CarregarProcedimentos()
        {
            try
            {
                if (agendamentoID == 0) return;

                parametros.Clear();
                sql = @"SELECT p.valor 
                        FROM tblAgendamentoProcedimento ap
                        INNER JOIN tblProcedimento p ON ap.idProcedimento = p.id
                        WHERE ap.idAgendamento = @idAgendamento";

                parametros.Add(new SqlParameter("@idAgendamento", agendamentoID));

                var dt = acesso.ConsultarSQL(sql, parametros);
                valor = 0;

                foreach (DataRow row in dt.Rows)
                {
                    valor += Convert.ToDecimal(row["valor"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao calcular valor total: {ex.Message}");
            }
        }

        public void Gravar()
        {
            using (var transacao = new TransactionScope())
            {
                try
                {
                    parametros.Clear();
                    sql = @"INSERT INTO tblPagamento 
                            (valor, idAgendamento, idFormaPagamento)
                            VALUES
                            (@valor, @idAgendamento, @idFormaPagamento) 
                            ";

                    parametros.Add(new SqlParameter("@valor", valor));
                    parametros.Add(new SqlParameter("@idAgendamento", agendamentoID));
                    parametros.Add(new SqlParameter("@idFormaPagamento", formaPagamentoId));

                    sql += @"UPDATE tblAgendamento 
                            SET idSituacao = 2 
                            WHERE id = @idAgendamento";

                    acesso.ExecutarSQL(sql, parametros);

                    transacao.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao registrar pagamento: {ex.Message}");
                }
            }
        }
    }

}