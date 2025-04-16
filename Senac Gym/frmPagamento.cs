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
    public partial class frmPagamento : Form
    {
        private Pagamento pagamento;
        private Aluno aluno;
        private Plano plano;
        private bool consultandoAluno = false;
        public frmPagamento()
        {
            InitializeComponent();
            pagamento = new Pagamento();
            aluno = new Aluno();
            plano = new Plano();
            cboPlano.ValueMember = "id";
            cboPlano.DisplayMember = "nome";
            cboPlano.SelectedIndex = -1;
            
            carregarPlano();
            CarregarGridAluno();
            
        }

        private void carregarPlano()
        {
            try
            {
                //Instanciamos o objeto
                plano = new Plano();
                //Carregamos o ComboBox com o resultado da consulta dos Tipos de Cliente (DataTable)
                cboPlano.DataSource = plano.Consultar();
                //Definimos o valor a ser exibido para o usuário
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }

        private void CarregarGridAluno()
        {
            try
            {
                grdAluno.DataSource = aluno.Consultar();
                configurarGridAluno();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            aluno = new Aluno();
            aluno.nome = txtPesquisa.Text;
            CarregarGridAluno();
        }

        private void configurarGridPagamento()
        {
            // Esconde as colunas que não são necessárias
            grdPagamento.Columns["idPagamento"].Visible = false;
            grdPagamento.Columns["idAluno"].Visible = false;
            grdPagamento.Columns["idPlano"].Visible = false;
            grdPagamento.Columns["nome"].Visible = false;
            grdPagamento.Columns["valorPagamento"].Visible = false;

            // Ajusta os cabeçalhos das colunas para nomes mais amigáveis
            grdPagamento.Columns["descricao"].HeaderText = "Descrição";
            grdPagamento.Columns["valor"].HeaderText = "Valor";
            grdPagamento.Columns["duracao"].HeaderText = "Duração";
            grdPagamento.Columns["dataPagamento"].HeaderText = "Data de Pagamento";

            // Ajusta a largura das colunas para melhor visualização
            grdPagamento.Columns["descricao"].Width = 403;
            grdPagamento.Columns["valor"].Width = 100;
            grdPagamento.Columns["duracao"].Width = 80;
            grdPagamento.Columns["dataPagamento"].Width = 126;
        }

        private void configurarGridAluno()
        {
            // Ajuste das colunas conforme estrutura da classe Aluno
            grdAluno.Columns[0].Visible = false; // Id
            grdAluno.Columns[4].Visible = false; // Id
            grdAluno.Columns[1].HeaderText = "Nome";
            grdAluno.Columns[2].HeaderText = "Telefone";
            grdAluno.Columns[3].HeaderText = "E-mail";


            // Ajuste de largura
            grdAluno.Columns[1].Width = 364;
            grdAluno.Columns[2].Width = 102;
            grdAluno.Columns[3].Width = 226;
        }

        private void carregarAluno() {

            aluno = new Aluno();
            pagamento = new Pagamento();
            aluno.id = Convert.ToInt32(grdAluno.SelectedRows[0].Cells[0].Value);
            aluno.Consultar();
            txtNome.Text = aluno.nome;
            pagamento.idAluno = aluno.id;
            DataTable pagamentos = pagamento.Consultar();
            grdPagamento.DataSource = pagamentos;
            DateTime dataPagamento = new DateTime(1, 1, 1);
            int duracao = 0;
            List<int> duracaoList = pagamentos.AsEnumerable().Select(row => row.Field<int>("duracao")).ToList();
            List<DateTime> dataList = pagamentos.AsEnumerable().Select(row => row.Field<DateTime>("dataPagamento")).ToList();
            for (int i = 0; i < duracaoList.Count; i++)
            {
                if (dataList[i].AddDays(duracaoList[i]) > dataPagamento.AddDays(duracao))
                {
                    dataPagamento = dataList[i];
                    duracao = duracaoList[i];
                }
            }
            DateTime ativoAte = dataPagamento.AddDays(duracao);
            if (ativoAte > DateTime.Now)
            {
                txtStatus.Text = "Ativo até " + ativoAte.ToString("dd/MM/yyyy");
            }
            else
            {
                txtStatus.Text = "Inativo";
            }
        }

        private void grdAluno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                consultandoAluno = true;   
                cboPlano.SelectedIndex = -1;
                txtDescricao.Text = "";
                txtDias.Text = "";
                txtValor.Text = "";
                
                

                carregarAluno();

                configurarGridPagamento();
                consultandoAluno = false;
                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdPagamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            aluno = new Aluno();
            pagamento = new Pagamento();
            aluno.id = Convert.ToInt32(grdAluno.SelectedRows[0].Cells[0].Value);
            aluno.Consultar();
            txtNome.Text = aluno.nome;
            pagamento.idAluno = aluno.id;
            pagamento.id = Convert.ToInt32(grdPagamento.SelectedRows[0].Cells[0].Value);
            pagamento.Consultar();

            txtDias.Text = pagamento.duracao.ToString();
            txtValor.Text = pagamento.valorPagamento.ToString();
            cboPlano.Text = pagamento.plano;
            txtDescricao.Text = pagamento.descricao;
        }

        private void cboPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlano.SelectedIndex == -1)
            {
                return;
            }
            if (!consultandoAluno)
            {
                plano = new Plano();
                plano.id = (int)(cboPlano.SelectedValue);
                plano.Consultar();
                txtValor.Text = plano.valor.ToString();
                txtDescricao.Text = plano.descricao;
                txtDias.Text = plano.duracao.ToString();
            }
            

        }

        private void preencherClasse()
        {
            pagamento = new Pagamento();
            pagamento.idAluno = aluno.id;
            pagamento.idPlano = (int)(cboPlano.SelectedValue);
            pagamento.descricao = txtDescricao.Text;
            pagamento.duracao = Convert.ToInt32(txtDias.Text);
            pagamento.valorPagamento = Convert.ToDecimal(txtValor.Text);
            pagamento.dataPagamento = DateTime.Now.ToString();
            
        }

        private string ValidarPreenchimento()
        {
            string mensagemErro = string.Empty;
            if (txtNome.Text == string.Empty)
            {
                mensagemErro += "Selecione um aluno\n";
            }
            if (cboPlano.SelectedIndex == -1)
            {
                mensagemErro += "Selecione um plano\n";
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

                preencherClasse();
                pagamento.Gravar();
                grdPagamento.DataSource = pagamento.Consultar();
                configurarGridPagamento();
                carregarAluno();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpa os campos do formulário
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtDias.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtPesquisa.Text = string.Empty;
            cboPlano.SelectedIndex = -1;

            // Limpa os grids
            grdPagamento.DataSource = null;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
