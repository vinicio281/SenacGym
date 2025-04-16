using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappySmile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Senac_Gym
{
    internal class Atividade
    {
        public int id { get; set; }
        public int idMusculo { get; set; }
        public int idExercicio { get; set; }
        public int idAluno { get; set; }
        public string musculo { get; set; }
        public string exercicio { get; set; }
        public string aluno { get; set; }
        public string comentario { get; set; }
        public int serie { get; set; }
        public int repeticao { get; set; }
        public string treino { get; set; }

        public Atividade()
        {
            id = 0;
            idMusculo = 0;
            idExercicio = 0;
            idAluno = 0;
            musculo = string.Empty;
            exercicio = string.Empty;
            aluno = string.Empty;
            comentario = string.Empty;
            serie = 0;
            repeticao = 0;
            treino = string.Empty;
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
                sql = "SELECT ati.id atividadeId, idMusculo, idExercicio, idAluno, mus.nome MusculoNome, exe.nome ExercicioNome, alu.nome alunoNome, comentario, serie, repeticao, treino \n";
                sql += "FROM tblAtividade ati \n";
                sql += "inner join tblMusculo mus on mus.id = ati.idMusculo \n";
                sql += "inner join tblExercicio exe on exe.id = ati.idExercicio \n";
                sql += "inner join tblAluno alu on alu.id = ati.idAluno \n";



                sql += "where 1=1 \n";
                if (id != 0)
                {
                    sql += "and ati.id = @id \n";
                    lista.Add(new SqlParameter("@id", id));
                }
                if (idAluno != 0)
                {
                    sql += "and idAluno = @idAluno \n";
                    lista.Add(new SqlParameter("@idAluno", idAluno));
                }
                if (treino != "")
                {
                    sql += "and treino = @treino \n";
                    lista.Add(new SqlParameter("@treino", treino));
                }


                sql += "ORDER BY treino";
                dt = acesso.ConsultarSQL(sql, lista);

                // Preenche propriedades se encontrar registro único
                if (dt.Rows.Count > 0 && id != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["atividadeId"]);
                    idMusculo = Convert.ToInt32(dt.Rows[0]["idMusculo"]);
                    idExercicio = Convert.ToInt32(dt.Rows[0]["idExercicio"]);
                    idAluno = Convert.ToInt32(dt.Rows[0]["idAluno"]);
                    musculo = dt.Rows[0]["MusculoNome"].ToString();
                    exercicio = dt.Rows[0]["ExercicioNome"].ToString();
                    aluno = dt.Rows[0]["alunoNome"].ToString();
                    comentario = dt.Rows[0]["comentario"].ToString();
                    serie = Convert.ToInt32(dt.Rows[0]["serie"]);
                    repeticao = Convert.ToInt32(dt.Rows[0]["repeticao"]);
                    treino = dt.Rows[0]["treino"].ToString();
                    //nome = dt.Rows[0]["nome"].ToString();
                    //celular = dt.Rows[0]["telefone"].ToString();
                    //email = dt.Rows[0]["email"].ToString();
                    //dataNascimento = Convert.ToDateTime(dt.Rows[0]["dataNascimento"]);
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
                    sql = "INSERT INTO tblAtividade \n";
                    sql += "(idExercicio, idMusculo, idAluno, comentario, serie, repeticao, treino) \n";
                    sql += "VALUES \n";
                    sql += "(@idExercicio, @idMusculo, @idAluno, @comentario, @serie, @repeticao, @treino)";
                }
                else
                {
                    sql = "UPDATE tblAtividade \n";
                    sql += "SET \n";
                    sql += "idExercicio = @idExercicio, \n";
                    sql += "idMusculo = @idMusculo, \n";
                    sql += "idAluno = @idAluno, \n";
                    sql += "comentario = @comentario, \n";
                    sql += "serie = @serie, \n";
                    sql += "repeticao = @repeticao, \n";
                    sql += "treino = @treino \n";
                    sql += "WHERE id = @id";
                    lista.Add(new SqlParameter("@id", id));
                }

                // Parâmetros comuns
                lista.Add(new SqlParameter("@idExercicio", idExercicio));
                lista.Add(new SqlParameter("@idMusculo", idMusculo));
                lista.Add(new SqlParameter("@idAluno", idAluno));
                lista.Add(new SqlParameter("@comentario", comentario));
                lista.Add(new SqlParameter("@serie", serie));
                lista.Add(new SqlParameter("@repeticao", repeticao));
                lista.Add(new SqlParameter("@treino", treino));

                acesso.ExecutarSQL(sql, lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExcluirAtividade()
        {
            try
            {
                if (id != 0)
                {
                    lista.Clear();
                    sql = "DELETE FROM tblAtividade WHERE id = @id";
                    lista.Add(new SqlParameter("@id", id));

                    acesso.ExecutarSQL(sql, lista);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
