using HappySmile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senac_Gym
{
    public partial class frmAtividade : Form
    {
        private AlunoAtividade aluno;
        private Atividade atividade;
        bool consultarTreino = true;
        DataGridViewPrinter printer;
        public frmAtividade()
        {
            InitializeComponent();
            aluno = new AlunoAtividade();
            printer = new DataGridViewPrinter(grdAtividade);
            //atividade = new Atividade();
        }

        private void CarregarGridAluno()
        {
            try
            {
                grdAluno.DataSource = aluno.Consultar();
                // Ajuste das colunas conforme estrutura da classe Aluno
                grdAluno.Columns[0].Visible = false; // Id
                grdAluno.Columns[1].HeaderText = "Nome";
                grdAluno.Columns[2].HeaderText = "Telefone";
                grdAluno.Columns[3].HeaderText = "E-mail";


                // Ajuste de largura
                grdAluno.Columns[1].Width = 364;
                grdAluno.Columns[2].Width = 89;
                grdAluno.Columns[3].Width = 226;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarGridAtividade()
        {
            try
            {
                // Carrega os dados da atividade
                grdAtividade.DataSource = atividade.Consultar();

                // Oculta as colunas que não são relevantes para o usuário
                grdAtividade.Columns["atividadeId"].Visible = false;    // Oculta a coluna atividadeId
                grdAtividade.Columns["idMusculo"].Visible = false;      // Oculta a coluna idMusculo
                grdAtividade.Columns["idExercicio"].Visible = false;    // Oculta a coluna idExercicio
                grdAtividade.Columns["idAluno"].Visible = false;        // Oculta a coluna idAluno
                grdAtividade.Columns["alunoNome"].Visible = false;
                grdAtividade.Columns["treino"].Visible = false;

                // Ajusta os cabeçalhos das colunas para nomes mais amigáveis
                grdAtividade.Columns["MusculoNome"].HeaderText = "Músculo";
                grdAtividade.Columns["ExercicioNome"].HeaderText = "Exercício";
                grdAtividade.Columns["comentario"].HeaderText = "Comentário";
                grdAtividade.Columns["serie"].HeaderText = "Séries";
                grdAtividade.Columns["repeticao"].HeaderText = "Repetições";

                // Ajusta a largura das colunas para melhor visualização
                grdAtividade.Columns["MusculoNome"].Width = 54;
                grdAtividade.Columns["ExercicioNome"].Width = 119;
                grdAtividade.Columns["comentario"].Width = 406;
                grdAtividade.Columns["serie"].Width = 41;
                grdAtividade.Columns["repeticao"].Width = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            aluno = new AlunoAtividade();
            aluno.pesquisa = txtPesquisa.Text;
            CarregarGridAluno();
        }

        private void grdAluno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LimparAtividade();
                aluno = new AlunoAtividade();
                aluno.id = Convert.ToInt32(grdAluno.SelectedRows[0].Cells[0].Value);
                aluno.Consultar();
                txtNome.Text = aluno.nome;
                atividade = new Atividade();
                atividade.idAluno = aluno.id;
                carregarGridAtividade();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAtividade_Load(object sender, EventArgs e)
        {
            aluno = new AlunoAtividade();
            aluno.pesquisa = txtPesquisa.Text;
            CarregarGridAluno();
            cboMusculo.DataSource = Musculo.Consultar();
            cboMusculo.DisplayMember = "nome";
            cboMusculo.ValueMember = "id";
            cboMusculo.SelectedIndex = -1;

            cboExercicio.DataSource = Exercicio.Consultar();
            cboExercicio.DisplayMember = "nome";
            cboExercicio.ValueMember = "id";
            cboExercicio.SelectedIndex = -1;
        }

        private void preencherFormularioAtividade()
        {
            consultarTreino = false;
            cboTreino.Text = atividade.treino;
            cboExercicio.Text = atividade.exercicio;
            cboMusculo.Text = atividade.musculo;
            txtObservacao.Text = atividade.comentario;
            txtRepeticao.Text = atividade.repeticao.ToString();
            txtSerie.Text = atividade.serie.ToString();
            consultarTreino = true;


        }

        private void PreencherClasse()
        {
            atividade.idMusculo = (int)cboMusculo.SelectedValue;
            atividade.idExercicio = (int)cboExercicio.SelectedValue;
            atividade.idAluno = aluno.id;
            atividade.comentario = txtObservacao.Text;
            atividade.serie = int.Parse(txtSerie.Text);
            atividade.repeticao = int.Parse(txtRepeticao.Text);
            atividade.treino = cboTreino.Text;
        }

        private void grdAtividade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            atividade = new Atividade();

            atividade.id = Convert.ToInt32(grdAtividade.SelectedRows[0].Cells[0].Value);

            atividade.Consultar();
            preencherFormularioAtividade();
        }


        private void LimparCampos()
        {
            LimparAluno();
            LimparAtividade();
        }

        private void LimparAluno()
        {
            // Limpa os campos de texto relacionados ao aluno
            txtNome.Text = string.Empty;

            //// Limpa a seleção do grid de alunos
            //grdAluno.DataSource = null;
            //grdAluno.ClearSelection();
            //grdAluno.Rows.Clear();

            // Limpa a pesquisa
            txtPesquisa.Text = string.Empty;

            // Limpa a instância de aluno
            aluno = new AlunoAtividade();
            
        }
        private void LimparAtividade()
        {
            // Limpa os campos de texto relacionados à atividade
            txtObservacao.Text = string.Empty;
            txtRepeticao.Text = string.Empty;
            txtSerie.Text = string.Empty;

            // Limpa os comboboxes relacionados à atividade
            cboMusculo.SelectedIndex = -1;
            cboExercicio.SelectedIndex = -1;
            cboTreino.SelectedIndex = -1;

            // Limpa a seleção do grid de atividades
            grdAtividade.DataSource = null;
            grdAtividade.ClearSelection();
            grdAtividade.Rows.Clear();

            // Limpa a instância de atividade
            atividade = new Atividade();

        }

        private string ValidarPreenchimento()
        {
            string mensagemErro = string.Empty;
            if (cboMusculo.SelectedIndex == -1)
            {
                mensagemErro += "Selecione um músculo\n";
            }
            if (cboExercicio.SelectedIndex == -1)
            {
                mensagemErro += "Selecione um exercício\n";
            }
            if (cboTreino.SelectedIndex == -1)
            {
                mensagemErro += "Selecione um treino\n";
            }
            if (txtRepeticao.Text == "0")
            {
                mensagemErro += "Informe a quantidade de repetições\n";
            }
            if (txtSerie.Text == "0")
            {
                mensagemErro += "Informe a quantidade de séries\n";
            }
            return mensagemErro;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagemErro = ValidarPreenchimento();
                if (mensagemErro != string.Empty)
                {
                    MessageBox.Show(mensagemErro, "Erro de Preenchimento",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PreencherClasse();
                atividade.Gravar();
                atividade.id = 0;
                carregarGridAtividade();
                MessageBox.Show("Aluno gravado com sucesso!", "Cadastro de Alunos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void cboTreino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!consultarTreino)
            {
                return;
            }
            atividade = new Atividade();

            atividade.idAluno = aluno.id;
            atividade.treino = cboTreino.Text;
            grdAtividade.DataSource = atividade.Consultar();
            preencherFormularioAtividade();
        }

        private void grdAtividade_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            // Cast the sender to a DataGridView
            DataGridView dataGridView = sender as DataGridView;

            // Check if the cast was successful
            if (dataGridView != null)
            {
                // Iterate through each column in the DataGridView
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    // Print the column header and its width
                    Console.WriteLine($"Column '{column.HeaderText}' width: {column.Width}");
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            grdAtividade.ClearSelection();
            printer.Print();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (atividade == null || atividade.id == 0)
            {
                MessageBox.Show("Selecione uma atividade para excluir.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherClasse();
            atividade.ExcluirAtividade();
            atividade = new Atividade();
            atividade.idAluno = aluno.id;
            carregarGridAtividade();

            MessageBox.Show("Atividade excluída com sucesso!", "Exclusão de Atividade",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtRepeticao.Text = string.Empty;
            txtSerie.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            cboMusculo.SelectedIndex = -1;
            cboExercicio.SelectedIndex = -1;
            cboTreino.SelectedIndex = -1;

        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, txtSerie);
        }

        private void txtRepeticao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, txtRepeticao);
        }
    }
}
