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
    public class Aluno
    {
        // Propriedades da classe
        public int id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }

        // Construtor com valores padrão
        public Aluno()
        {
            id = 0;
            nome = string.Empty;
            celular = string.Empty;
            email = string.Empty;
            dataNascimento = DateTime.Now;
        }

        // Objetos para acesso ao banco
        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> lista = new List<SqlParameter>();
        string sql = string.Empty;

        public DataTable Consultar()
        {
            try
            {
                lista.Clear();
                sql = "SELECT id, nome, telefone, email, dataNascimento \n";
                sql += "FROM tblAluno \n";

                if (id != 0)
                {
                    sql += "WHERE id = @id \n";
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (nome != string.Empty)
                {
                    sql += "WHERE nome LIKE @nome \n";
                    lista.Add(new SqlParameter("@nome", "%" + nome + "%"));
                }

                sql += "ORDER BY nome";
                dt = acesso.ConsultarSQL(sql, lista);

                // Preenche propriedades se encontrar registro único
                if (dt.Rows.Count > 0 && id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    celular = dt.Rows[0]["telefone"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    dataNascimento = Convert.ToDateTime(dt.Rows[0]["dataNascimento"]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Gravar()
        {
            try
            {
                lista.Clear();
                if (id == 0)
                {
                    sql = "INSERT INTO tblAluno \n";
                    sql += "(nome, telefone, email, dataNascimento) \n";
                    sql += "VALUES \n";
                    sql += "(@nome, @telefone, @email, @dataNascimento)";
                }
                else
                {
                    sql = "UPDATE tblAluno \n";
                    sql += "SET \n";
                    sql += "nome = @nome, \n";
                    sql += "telefone = @telefone, \n";
                    sql += "email = @email, \n";
                    sql += "dataNascimento = @dataNascimento \n";
                    sql += "WHERE id = @id";
                    lista.Add(new SqlParameter("@id", id));
                }

                // Parâmetros comuns
                lista.Add(new SqlParameter("@nome", nome));
                lista.Add(new SqlParameter("@telefone", celular));
                lista.Add(new SqlParameter("@email", email));
                lista.Add(new SqlParameter("@dataNascimento", dataNascimento));

                acesso.ExecutarSQL(sql, lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
