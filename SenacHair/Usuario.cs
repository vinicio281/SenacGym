using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SenacHair
{
    public class Usuario
    {
        //Definimos as propriedades da classe
        public int id { get; set; }
        public string login { get; set; }
        public string nome { get; set; }
        public string password { get; set; }
        public bool ativo { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Usuario()
        {
            id = 0;
            login = string.Empty;
            nome = string.Empty;
            password = string.Empty;
            ativo = false;
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
                sql = "select id, login, nome, password, ativo \n";
                sql += "from tblUsuario \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    sql += "where id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (login != string.Empty)
                {
                    //caso o login esteja preenchido
                    //definimos a busca pelo login
                    sql += "where login = @login \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@login", login));
                }
                else if (nome != string.Empty)
                {
                    //Caso o nome esteja preenchido
                    //Definimos a consulta por aproximação através do nome
                    sql += "where nome like @nome \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@nome", "%" + nome + "%"));
                }
                //Ordenamos o retorno pelo nome do usuario
                sql += "order by nome";
                //Solicitamos ao objeto acesso a execução da consulta
                //E o resultado é armazenado no nosso DataTable (dt)
                dt = acesso.ConsultarSQL(sql, lista);

                if (dt.Rows.Count > 0 && (id != 0 || login != string.Empty))
                {
                    //Caso a pesquisa tenha sido feita pelo Id do usuário ou 
                    //pelo login, e tenha retornado o registro especificado
                    //Atribuímos os valores retornados a sua respectiva
                    //propriedade da classe
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    login = dt.Rows[0]["login"].ToString();
                    password = dt.Rows[0]["password"].ToString();
                    ativo = Convert.ToBoolean(dt.Rows[0]["ativo"]);
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
                    sql = "insert into tblUsuario \n";
                    sql += "(login, nome, password, ativo)\n";
                    sql += "values \n";
                    sql += "(@login, @nome, @password, @ativo)";
                }
                else
                {
                    //Caso seja um registro já existente
                    //Montamos o UPDATE
                    sql = "update tblUsuario\n";
                    sql += "set \n";
                    sql += "login     = @login, \n";
                    sql += "nome	  = @nome, \n";
                    sql += "password  = @password, \n";
                    sql += "ativo	  = @ativo\n";
                    sql += "where id  = @id \n";
                    //Adicionamos separadamente o Id 
                    lista.Add(new SqlParameter("@id", id));
                }
                //Adicionamos em conjunto o restante dos parâmetros SQL
                lista.Add(new SqlParameter("@login", login));
                lista.Add(new SqlParameter("@nome", nome));
                lista.Add(new SqlParameter("@password", password));
                lista.Add(new SqlParameter("@ativo", ativo));
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
