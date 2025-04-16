using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacHair
{
    public class Situacao
    {
        //Definimos as propriedades da classe
        public int id { get; set; }
        public string situacao { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Situacao()
        {
            id = 0;
            situacao = string.Empty;
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
                //Limpamos a lista de parâmetros
                lista.Clear();
                //Definimos o comando SQL (SELECT)
                sql = "select id, situacao \n";
                sql += "from tblSituacao \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    sql += "where id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (situacao != string.Empty)
                {
                    //Caso a situacao esteja preenchido
                    //Definimos a consulta por aproximação através da situacao
                    sql += "where situacao like @situacao \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@situacao", "%" + situacao + "%"));
                }
                //Ordenamos o retorno pela situacao
                sql += "order by situacao";
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
                    situacao = dt.Rows[0]["situacao"].ToString();
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
                    //Caso seja um registro novo
                    //Montamos o INSERT
                    sql = "insert into tblSituacao \n";
                    sql += "(situacao)\n";
                    sql += "values \n";
                    sql += "(@situacao)";
                }
                else
                {
                    //Caso seja um registro já existente
                    //Montamos o UPDATE
                    sql = "update tblSituacao\n";
                    sql += "set \n";
                    sql += "situacao = @situacao \n";
                    sql += "where id  = @id \n";
                    //Adicionamos separadamente o Id 
                    lista.Add(new SqlParameter("@id", id));
                }
                //Adicionamos em conjunto o restante dos parâmetros SQL
                lista.Add(new SqlParameter("@situacao", situacao));
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
