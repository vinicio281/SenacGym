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
    public class AlunoAtividade
    {
        // Propriedades da classe
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }


        public string pesquisa;

        // Construtor com valores padrão
        public AlunoAtividade()
        {
            id = 0;
            nome = string.Empty;
            telefone = string.Empty;
            email = string.Empty;
            pesquisa = string.Empty;
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
                sql = "SELECT id, nome, telefone, email \n";
                sql += "FROM tblAluno \n";

                if (id != 0)
                {
                    sql += "WHERE id = @id \n";
                    lista.Add(new SqlParameter("@id", id));
                }
                else if (pesquisa != "")
                {
                    sql += "where nome like @pesquisa or telefone like @pesquisa or email like @pesquisa \n";
                    lista.Add(new SqlParameter("@pesquisa", "%" + pesquisa + "%"));
                }

                sql += "ORDER BY nome";
                dt = acesso.ConsultarSQL(sql, lista);

                // Preenche propriedades se encontrar registro único
                if (dt.Rows.Count > 0 && id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"]);
                    nome = dt.Rows[0]["nome"].ToString();
                    telefone = dt.Rows[0]["telefone"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
