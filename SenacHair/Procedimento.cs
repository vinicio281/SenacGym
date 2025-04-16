using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacHair
{
    public class Procedimento
    {
        //Definimos as propriedades da classe
        public int id { get; set; }
        public string procedimento { get; set; }
        public double valor { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Procedimento()
        {
            id = 0;
            procedimento = string.Empty;
            valor = 0;
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
                sql = "select id, procedimento, valor \n";
                sql += "from tblProcedimento \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    sql += "where id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (procedimento != string.Empty)
                {
                    //Caso a procedimento esteja preenchido
                    //Definimos a consulta por aproximação através da procedimento
                    sql += "where procedimento like @procedimento \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@procedimento", "%" + procedimento + "%"));
                }
                //Ordenamos o retorno pela procedimento
                sql += "order by procedimento";
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
                    valor = Convert.ToDouble(dt.Rows[0]["valor"]);
                    procedimento = dt.Rows[0]["procedimento"].ToString();
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
                    sql = "insert into tblProcedimento \n";
                    sql += "(procedimento)\n";
                    sql += "values \n";
                    sql += "(@procedimento)";
                }
                else
                {
                    //Caso seja um registro já existente
                    //Montamos o UPDATE
                    sql = "update tblProcedimento\n";
                    sql += "set \n";
                    sql += "procedimento = @procedimento \n";
                    sql += "where id  = @id \n";
                    //Adicionamos separadamente o Id 
                    lista.Add(new SqlParameter("@id", id));
                }
                //Adicionamos em conjunto o restante dos parâmetros SQL
                lista.Add(new SqlParameter("@procedimento", procedimento));
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
