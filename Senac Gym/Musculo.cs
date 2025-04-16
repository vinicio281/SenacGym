using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappySmile;

namespace Senac_Gym
{
    internal static class Musculo
    {
        //Definimos as propriedades da classe
        public static int id { get; set; }
        public static string nome { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto

        //Instanciamos os objetos necessários para
        //a comunicação entre o objeto criado e o banco de dados
        static AcessoBD acesso = new AcessoBD();
        static DataTable dt = new DataTable();
        static List<SqlParameter> lista = new List<SqlParameter>();
        static string sql = string.Empty;

        static public DataTable Consultar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Limpamos a lista de parâmetros
                lista.Clear();
                //Definimos o comando SQL (SELECT)
                sql = "select id, nome \n";
                sql += "from tblMusculo \n";
                sql += "order by nome";
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);

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
    }
}
