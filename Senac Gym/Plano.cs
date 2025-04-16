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
    internal class Plano
    {
        //id	nome	descricao	valor	duracao
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        //public DateTime dataPagamento { get; set; }
        public int duracao { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Plano()
        {
            id = 0;
            nome = "";
            descricao = "";
            valor = 0;
            duracao = 0;
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
                //id	nome	descricao	valor	duracao
                sql = "select id, nome, descricao, valor, duracao \n";
                sql += "from tblPlano \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    //sql += "where tblImc.id = @id \n";
                    sql += "where id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }

                //Ordenamos o retorno pelo nome do usuario
                sql += "order by duracao";
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);

                if (dt.Rows.Count > 0 && id != 0)
                {
                    //id	nome	descricao	valor	duracao

                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    descricao = dt.Rows[0]["descricao"].ToString();
                    valor = Convert.ToDecimal(dt.Rows[0]["valor"]);
                    //dataPagamento = DateTime.ParseExact(dt.Rows[0]["dataNascimento"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    duracao = Convert.ToInt32(dt.Rows[0]["duracao"]);

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
                    //id	nome	descricao	valor	duracao

                    //Caso seja um registro novo
                    //Montamos o INSERT
                    sql = "insert into tblPlano \n";
                    sql += "(nome, descricao, valor, duracao)\n";
                    sql += "values \n";
                    sql += "(@nome, @descricao, @valor, @duracao)";
                }
                else
                {
                    //Caso seja um registro já existente
                    //Montamos o UPDATE
                    sql = "update tblPlano\n";
                    sql += "set \n";
                    sql += "nome     = @nome, \n";
                    sql += "descricao     = @descricao, \n";
                    sql += "valor     = @valor, \n";
                    sql += "duracao     = @duracao \n";
                    sql += "where id  = @id \n";

                    //Adicionamos separadamente o Id 
                    lista.Add(new SqlParameter("@id", id));
                }
                //id	nome	descricao	valor	duracao
                //Adicionamos em conjunto o restante dos parâmetros SQL
                lista.Add(new SqlParameter("@nome", nome));
                lista.Add(new SqlParameter("@descricao", descricao));
                lista.Add(new SqlParameter("@valor", valor));
                lista.Add(new SqlParameter("@duracao", duracao));
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
