using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace HappySmile
{
    public class AcessoBD
    {
        //Definimos uma conexão SQL
        SqlConnection conn;
             
        private void Conectar()
        {         
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Instânciamos a nova conexão para o servidor e banco de dados
                //definidos no arquivo de configuração app.config
                conn = new SqlConnection(Global.conexao);
                //Abrimos a conexão
                conn.Open();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
        private void Desconectar()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Verificamos se o estado da conexão é ABERTA
                if (conn.State == ConnectionState.Open)
                {
                    //Fechamos a conexão
                    conn.Close();
                    //Removemos o objeto da memória
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarSQL(string sql, List<SqlParameter> parametros)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //abrimos a conexão com o banco de dados
                Conectar();
                //Criamos um Comando SQL para ser executado no banco de dados
                SqlCommand command = new SqlCommand(sql, conn);
                //Percorremos todos os parâmetros SQL adicionados à lista
                //de parâmetros recebidos na chamada do método
                foreach (SqlParameter p in parametros)
                {
                    //Adicionamos cada parâmetro individualmente
                    //ao comando SQL para a execução no banco de dados
                    command.Parameters.Add(p);
                }
                //Criamos um Adaptador de Dados SQL, adicionando
                //o comando SQL
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //Criamos um DataTable para receber o resultado 
                //da consulta (SELECT) a ser efetuada no banco de dados
                DataTable dt = new DataTable();
                //Fazemos o preenchimentos dos dados no dataTable
                adapter.Fill(dt);
                //Retornamos o DataTable com o resultado da consulta (SELECT)
                return dt;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
            //Instrução finnaly sempre é executada ao final do bloco try/catch
            //Seja uma execução com sucesso ou uma execução com erro
            finally
            {
                //Fechamos a conexão com o banco de dados
                Desconectar();
            }
        }
        public void ExecutarSQL(string sql, List<SqlParameter> parametros)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //abrimos a conexão com o banco de dados
                Conectar();
                //Criamos um Comando SQL para ser executado no banco de dados
                SqlCommand command = new SqlCommand(sql, conn);
                //Percorremos todos os parâmetros SQL adicionados à lista
                //de parâmetros recebidos na chamada do método
                foreach (SqlParameter p in parametros)
                {
                    //Adicionamos cada parâmetro individualmente
                    //ao comando SQL para a execução no banco de dados
                    command.Parameters.Add(p);
                }
                //Executamos o comando SQL (Insert/Update/Delete)
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
            //Instrução finnaly sempre é executada ao final do bloco try/catch
            //Seja uma execução com sucesso ou uma execução com erro
            finally
            {
                //Fechamos a conexão com o banco de dados
                Desconectar();
            }
        }
        public string ExecutarSQL(List<SqlParameter> parametros, string sql)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //abrimos a conexão com o banco de dados
                Conectar();
                //Criamos um Comando SQL para ser executado no banco de dados
                SqlCommand command = new SqlCommand(sql, conn);
                //Percorremos todos os parâmetros SQL adicionados à lista
                //de parâmetros recebidos na chamada do método
                foreach (SqlParameter p in parametros)
                {
                    //Adicionamos cada parâmetro individualmente
                    //ao comando SQL para a execução no banco de dados
                    command.Parameters.Add(p);
                }
                //Executamos o comando SQL (Insert + select @@Identity)
                //Retornando a nova PK criada no banco de dados
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
            //Instrução finnaly sempre é executada ao final do bloco try/catch
            //Seja uma execução com sucesso ou uma execução com erro
            finally
            {
                //Fechamos a conexão com o banco de dados
                Desconectar();
            }
        }
    }
}
