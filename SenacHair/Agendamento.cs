using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Transactions;

namespace SenacHair
{
    public class Agendamento
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        private DateTime dataOriginal { get; set; }
        public Situacao situacao { get; set; }
        public Cliente cliente { get; set; }
        public Cabeleireiro cabeleireiro{ get; set; }
        public List<Procedimento> procedimentos { get; set; }
        public List<Pagamento> pagamentos { get; set; }

        public int idSituacao { get; set; }
        public Agendamento()
        {
            id = 0;
            idSituacao = 0;
            data = DateTime.Now;
            dataOriginal = data;
            situacao = new Situacao();
            cliente = new Cliente();
            cabeleireiro = new Cabeleireiro();
            procedimentos = new List<Procedimento>();
        }
        //Instanciamos os objetos necessários para
        //a comunicação entre o objeto criado e o banco de dados
        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> lista = new List<SqlParameter>();
        string sql = string.Empty;

        public DataTable ConsultarPagamentos()
        {
            try
            {
                // Limpamos a lista de parâmetros
                lista.Clear();

                // Definimos o comando SQL (SELECT) com filtro por data e status (se necessário)
                sql = "SELECT age.id, FORMAT(age.data, 'HH:mm') AS Hora, sit.Situacao, cli.id AS idCliente, \n";
                sql += "cli.nome AS Cliente, cli.CPF, ca.id AS idCabeleireiro, ca.nome AS Cabeleireiro, age.idSituacao \n";
                sql += "FROM tblAgendamento age \n";
                sql += "INNER JOIN tblSituacao sit ON age.idSituacao = sit.id \n";
                sql += "INNER JOIN tblCliente cli ON age.idCliente = cli.id \n";
                sql += "INNER JOIN tblCabeleireiro ca ON age.idCabeleireiro = ca.id \n";
                sql += "WHERE CAST(age.data AS DATE) = CAST(@data AS DATE) \n"; // Filtra pela data
                sql += "AND sit.Situacao = 'Efetivada' \n"; // Filtra por status (exemplo: agendamentos pendentes)
                sql += "ORDER BY age.data"; // Ordena pela data do agendamento

                // Adicionamos o parâmetro da data à lista de parâmetros
                lista.Add(new SqlParameter("@data", data.Date));

                // Executamos a consulta e retornamos o DataTable
                dt = acesso.ConsultarSQL(sql, lista);
                return dt;
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro, lançamos uma exceção
                throw new Exception("Erro ao consultar agendamentos para pagamento: " + ex.Message);
            }
        }

        public void GravarPagamentos()
        {

        }
        public DataTable Consultar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Limpamos a lista de parâmetros
                lista.Clear();
                //Definimos o comando SQL (SELECT)
                sql =  "select age.id, format(age.data, 'HH:mm') Hora, Situacao, ca.id idCliente, \n";
                sql += "cli.nome Cliente, CPF, ca.id idCabeleireiro, ca.nome Cabeleireiro, age.idSituacao \n";
                sql += "from tblAgendamento age \n";
                sql += "inner join tblSituacao sit on age.idSituacao = sit.id \n";
                sql += "inner join tblCliente cli on age.idCliente = cli.id \n";
                sql += "inner join tblCabeleireiro ca on age.idCabeleireiro = ca.id \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    sql += "where age.id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (cliente.id != 0)
                {
                    //Caso o cliente esteja preenchido
                    //Definimos a consulta pelo id do cliente
                    sql += "where cli.id = @idCliente \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@idCliente", cliente.id));
                }
                else if (cabeleireiro.id != 0)
                {
                    sql += "where ca.id = @idCabeleireiro \n";
                    sql += "and cast(data as date) = cast(@data as date) \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@idCabeleireiro", cabeleireiro.id));
                    lista.Add(new SqlParameter("@data", data));
                }
                else if (data != dataOriginal)
                {
                    sql += "where cast(data as date) = cast(@data as date) \n";
                    lista.Add(new SqlParameter("@data", data));
                    if (idSituacao != 0)
                    {
                        sql += "and age.idSituacao = @idSituacao \n";
                        lista.Add(new SqlParameter("@idSituacao", idSituacao));
                    }
                }

                //Ordenamos o retorno pela data do agendamento
                sql += "order by age.data";
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);

                if (id != 0)
                {
                    //Caso a pesquisa tenha sido efetuada pelo Id 
                    //o retorno será de apenas 1 registro
                    //Atribuímos os valores retornados a sua respectiva
                    //propriedade da classe
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    //data = Convert.ToDateTime(dt.Rows[0]["data"]);
                    idSituacao = Convert.ToInt32(dt.Rows[0]["idSituacao"]);
                    cliente.id = Convert.ToInt32(dt.Rows[0]["idCliente"]);
                    cabeleireiro.id = Convert.ToInt32(dt.Rows[0]["idCabeleireiro"]);
                    situacao.Consultar();
                    cliente.Consultar();
                    cabeleireiro.Consultar();
                    CarregarProcedimentos();
                }
                //Retornamos o DataTable com os dentistas retornados na consulta
                return dt;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
        public DataTable CarregarProcedimentos()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Limpamos a lista de parâmetros
                lista.Clear();
                //Definimos o comando SQL (SELECT)
                sql = "select pro.id, pro.procedimento, valor \n";
                sql += "from tblAgendamentoProcedimento ap \n";
                sql += "inner join tblProcedimento pro  \n";
                sql += "on ap.idProcedimento = pro.id \n";
                //Fazemos s busca pelo Id do agendamento
                sql += "where idAgendamento = @idAgendamento";
                //adicionamos o parâmetro à lista de parâmetros
                lista.Add(new SqlParameter("@idAgendamento", id));
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);
                //Limpamos a lista de especialidades
                procedimentos.Clear();
                //Percorremos cada linha do DataTable
                foreach (DataRow linha in dt.Rows)
                {
                    //Instanciamos um objeto para armazenarmos
                    //os dados da especialidade
                    Procedimento p = new Procedimento();
                    p.id = Convert.ToInt32(linha["id"]);
                    p.procedimento = linha["procedimento"].ToString();
                    p.valor = Convert.ToDouble(linha["valor"]);
                    //Adicionamos este objeto à lista de especialidades
                    procedimentos.Add(p);
                }
                return dt;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
        public void Gravar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Criamos uma transação para controlar a atuação do banco de dados
                //em mais de 1 entidade
                using (TransactionScope transacao = new TransactionScope())
                {

                    //Limpamos a lista de parâmetros
                    lista.Clear();

                    if (id == 0)
                    {
                        //Caso seja um registro novo
                        //Montamos o INSERT
                        sql = "insert into tblAgendamento \n";
                        sql += "(data, idSituacao, idCliente, idCabeleireiro)\n";
                        sql += "values \n";
                        sql += "(@data, @idSituacao, @idCliente, @idCabeleireiro);";
                        sql += "select @@identity";
                        //Adicionamos em conjunto o restante dos parâmetros SQL
                        lista.Add(new SqlParameter("@data", data));
                        lista.Add(new SqlParameter("@idSituacao", situacao.id));
                        lista.Add(new SqlParameter("@idCliente", cliente.id));
                        lista.Add(new SqlParameter("@idCabeleireiro", cabeleireiro.id));
                    }
                    else
                    {
                        //Caso seja um registro já existente
                        //Montamos o UPDATE
                        sql = "update tblAgendamento\n";
                        sql += "set \n";
                        sql += "idSituacao = @idSituacao \n";
                        sql += "where id  = @id \n";
                        //Adicionamos separadamente o Id do dentista
                        lista.Add(new SqlParameter("@id", id));
                        lista.Add(new SqlParameter("@idSituacao", situacao.id));
                    }
                    

                    if (id == 0)
                    {
                        //Caso seja um novo registro, solicitamos ao acesso
                        //a execução do comando INSERT, juntamente com o comando
                        //select @@identity para buscarmos o novo id gerado
                        id = Convert.ToInt32(acesso.ExecutarSQL(lista, sql));
                    }
                    else
                    {
                        //Caso seja um registro já existente,
                        //apenas efetuamos o UPDATE
                        acesso.ExecutarSQL(sql, lista);
                        //limpamos a lista de parâmetros
                        lista.Clear();
                        //Montamos o comando SQL para remover os procedimentos
                        //Definidos anteriormente
                        sql = "delete from tblAgendamentoProcedimento \n";
                        sql += "where idAgendamento = @idAgendamento";
                        //Adicionamos o id do dentista como parâmetro
                        lista.Add(new SqlParameter("@idAgendamento", id));
                        //Solicitamos ao acesso para executar o comando junto ao banco de dados
                        acesso.ExecutarSQL(sql, lista);
                    }
                    //Percorremos todos os procedimentos adicionados
                    //individualmente para serem inseridas no banco de dados
                    foreach (Procedimento p in procedimentos)
                    {
                        //Limpamos a lista de parâmetros
                        lista.Clear();
                        //Montamos o comando SQL
                        sql = "insert into tblAgendamentoProcedimento \n";
                        sql += "(idAgendamento, idProcedimento) \n";
                        sql += "values \n";
                        sql += "(@idAgendamento, @idProcedimento)";
                        //Adicionamos à lista de parâmetros o id do agendamento
                        //e o procedimento agendado
                        lista.Add(new SqlParameter("@idAgendamento", id));
                        lista.Add(new SqlParameter("@idProcedimento", p.id));
                        //Solicitamos ao acesso para executar o INSERT junto ao banco de dados
                        acesso.ExecutarSQL(sql, lista);
                    }
                    //confirmamos a execução dos comandos e efetivamos 
                    //as alterações no banco de dados
                    transacao.Complete();
                }
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
    }
}
