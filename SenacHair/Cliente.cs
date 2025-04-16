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
    public class Cliente
    {
        //Definimos as propriedades da classe
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        //Criamos o método construtor para definirmos valores
        //padrão para as propriedades no momento da instância do objeto
        public Cliente()
        {
            id = 0;
            nome = string.Empty;
            cpf = string.Empty;
            celular = string.Empty;
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
                sql = "select id, nome, cpf, celular \n";
                sql += "from tblCliente \n";
                if (id != 0)
                {
                    //Caso o ID esteja preenchido
                    //Definimos a consulta pela chave primária
                    sql += "where id = @id \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (cpf != string.Empty)
                {
                    //caso o cpf esteja preenchido
                    //definimos a busca pelo cpf
                    sql += "where cpf = @cpf \n";
                    //adicionamos o parâmetro à lista de parâmetros
                    lista.Add(new SqlParameter("@cpf", cpf));
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

                if (dt.Rows.Count > 0 && (id != 0 || cpf != string.Empty))
                {
                    //Caso a pesquisa tenha sido feita pelo Id do cliente ou 
                    //pelo cpf, e tenha retornado o registro especificado
                    //Atribuímos os valores retornados a sua respectiva
                    //propriedade da classe
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    cpf = dt.Rows[0]["cpf"].ToString();
                    celular = dt.Rows[0]["celular"].ToString();
                    //Consultamos o convenio caso seja do tipo convenio
                }
                //Retornamos o DataTable com os clientes retornados na consulta
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
                        sql = "insert into tblCliente \n";
                        sql += "(nome, cpf, celular)\n";
                        sql += "values \n";
                        sql += "(@nome, @cpf, @celular);";
                        sql += "select @@identity";
                    }
                    else
                    {
                        //Caso seja um registro já existente
                        //Montamos o UPDATE
                        sql = "update tblCliente\n";
                        sql += "set \n";
                        sql += "nome = @nome, \n";
                        sql += "cpf = @cpf, \n";
                        sql += "celular = @celular \n";
                        sql += "where id  = @id \n";
                        //Adicionamos separadamente o Id do dentista
                        lista.Add(new SqlParameter("@id", id));
                    }
                    //Adicionamos em conjunto o restante dos parâmetros SQL
                    lista.Add(new SqlParameter("@nome", nome));
                    lista.Add(new SqlParameter("@cpf", cpf));
                    lista.Add(new SqlParameter("@celular", celular));

                    if (id == 0)
                    {
                        //Caso seja um novo registro, solicitamos ao acesso
                        //a execução do comando INSERT, juntamente com o comando
                        //select @@identity para buscarmos o novo id gerado
                        id = Convert.ToInt32(acesso.ExecutarSQL(lista, sql));
                        //Atribuímos o novo id gerado do cliente para gravação do convênio
                    }
                    else
                    {
                        //Caso seja um registro já existente,
                        //apenas efetuamos o UPDATE
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
