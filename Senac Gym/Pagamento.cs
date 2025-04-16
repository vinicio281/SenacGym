using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappySmile;

namespace Senac_Gym
{
    internal class Pagamento
    {
        //Definimos as propriedades da classe
        

        public int id { get; set; }
        public int idAluno { get; set; }
        public int idPlano { get; set; }
        public decimal valorPagamento { get; set; }
        //public DateTime dataPagamento { get; set; }
        public string dataPagamento { get; set; }
        public int duracao { get; set; }
        public string plano { get; set; }
        public string descricao { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Pagamento()
        {
            id = 0;
            idAluno = 0;
            idPlano = 0;
            valorPagamento = 0;
            dataPagamento = "";
        }
        //Instanciamos os objetos necessários para
        //a comunicação entre o objeto criado e o banco de dados
        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> lista = new List<SqlParameter>();
        string sql = string.Empty;

        public DataTable Consultar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //id	idAluno	idPlano	valorPagamento	dataPagamento
                //Limpamos a lista de parâmetros
                lista.Clear();
                //Definimos o comando SQL (SELECT)
                sql = "SELECT pag.id AS idPagamento, pag.idAluno, pag.idPlano, nome, descricao, duracao, valor, pag.valorPagamento, pag.dataPagamento \n";
                sql += "FROM tblPagamento pag INNER JOIN tblPlano plano ON plano.id = pag.idPlano \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    //sql += "where tblImc.id = @id \n";
                    sql += "where pag.id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (idAluno != 0)
                {
                    sql += "where idAluno = @idAluno \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@idAluno", idAluno));
                }
                
                //Ordenamos o retorno pelo nome do usuario
                sql += "order by dataPagamento";
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);

                if (dt.Rows.Count > 0 && (id != 0 || idAluno != 0))
                {
                    //id	idAluno	idPlano	valorPagamento	dataPagamento

                    id = Convert.ToInt32(dt.Rows[0]["idPagamento"]);
                    idAluno = Convert.ToInt32(dt.Rows[0]["idAluno"]);
                    idPlano = Convert.ToInt32(dt.Rows[0]["idPlano"]);
                    valorPagamento = Convert.ToDecimal(dt.Rows[0]["valorPagamento"]);
                    //dataPagamento = DateTime.ParseExact(dt.Rows[0]["dataNascimento"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dataPagamento = dt.Rows[0]["dataPagamento"].ToString();
                    duracao = Convert.ToInt32(dt.Rows[0]["duracao"]);
                    plano = dt.Rows[0]["nome"].ToString();
                    descricao = dt.Rows[0]["descricao"].ToString();

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
        public void Gravar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Limpamos a lista de parâmetros
                lista.Clear();
                if (id == 0)
                {
                    //id	idAluno	idPlano	valorPagamento	dataPagamento

                    //Caso seja um registro novo
                    //Montamos o INSERT
                    sql = "insert into tblPagamento \n";
                    sql += "(idAluno, idPlano, valorPagamento, dataPagamento)\n";
                    sql += "values \n";
                    sql += "(@idAluno, @idPlano, @valorPagamento, @dataPagamento)";
                }
                else
                {
                    //Caso seja um registro já existente
                    //Montamos o UPDATE
                    sql = "update tblPagamento\n";
                    sql += "set \n";
                    sql += "idAluno     = @idAluno, \n";
                    sql += "idPlano     = @peso, \n";
                    sql += "valorPagamento     = @altura, \n";
                    sql += "dataPagamento     = @data \n";
                    sql += "where id  = @id \n";

                    //Adicionamos separadamente o Id 
                    lista.Add(new SqlParameter("@id", id));
                }
                //Adicionamos em conjunto o restante dos parâmetros SQL
                lista.Add(new SqlParameter("@idAluno", idAluno));
                lista.Add(new SqlParameter("@idPlano", idPlano));
                lista.Add(new SqlParameter("@valorPagamento", valorPagamento));
                lista.Add(new SqlParameter("@dataPagamento", dataPagamento));
                //id	idAluno	idPlano	valorPagamento	dataPagamento
                //Solicitamos ao acesso para executar o INSERT/UPDATE junto ao banco de dados
                acesso.ExecutarSQL(sql, lista);
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
