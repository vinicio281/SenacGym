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
    public partial class frmAluno : Form
    {
        public frmAluno()
        {
            InitializeComponent();
        }

        // Instância do objeto Aluno
        Aluno aluno = new Aluno();

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            aluno = new Aluno();
            aluno.nome = txtPesquisa.Text;
            CarregarGrid();
        }

        private void frmAluno_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                aluno = new Aluno();
                aluno.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                aluno.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                aluno.Gravar();
                MessageBox.Show("Aluno gravado com sucesso!", "Cadastro de Alunos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            aluno = new Aluno();
            txtPesquisa.Clear();
            txtNome.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            dateTimePickerNascimento.Value = DateTime.Now;
            txtPesquisa.Focus();
        }

        private void CarregarGrid()
        {
            try
            {
                grdDados.DataSource = aluno.Consultar();
                // Ajuste das colunas conforme estrutura da classe Aluno
                grdDados.Columns[0].Visible = false; // Id
                grdDados.Columns[1].HeaderText = "Nome";
                grdDados.Columns[2].HeaderText = "Celular";
                grdDados.Columns[3].HeaderText = "E-mail";
                grdDados.Columns[4].HeaderText = "Nascimento";

                // Ajuste de largura
                grdDados.Columns[1].Width = 200;
                grdDados.Columns[2].Width = 120;
                grdDados.Columns[3].Width = 250;
                grdDados.Columns[4].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtNome.Text = aluno.nome;
            txtCelular.Text = aluno.celular;
            txtEmail.Text = aluno.email;
            dateTimePickerNascimento.Value = aluno.dataNascimento;
        }

        private void PreencherClasse()
        {
            aluno.nome = txtNome.Text;
            aluno.celular = txtCelular.Text;
            aluno.email = txtEmail.Text;
            aluno.dataNascimento = dateTimePickerNascimento.Value;
        }

        private string ValidarPreenchimento()
        {
            try
            {
                string msgErro = string.Empty;

                if (txtNome.Text == string.Empty)
                {
                    msgErro += "Preencha o NOME.\n";
                }

                if (txtCelular.Text == string.Empty)
                {
                    msgErro += "Preencha o CELULAR.\n";
                } else if (txtCelular.Text.Length < 11)
                {
                    msgErro += "Celular deve ter 11 dígitos.\n";
                }

                if (txtEmail.Text == string.Empty)
                {
                    msgErro += "Preencha o E-MAIL.\n";
                }
                else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    msgErro += "E-mail inválido.\n";
                }

                if (dateTimePickerNascimento.Value > DateTime.Now)
                {
                    msgErro += "Data de nascimento inválida.\n";
                }

                return msgErro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, txtCelular);
        }
    }

}
