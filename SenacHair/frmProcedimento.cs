using SenacHair;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenacHair
{
    public partial class frmProcedimento : Form
    {
        public frmProcedimento()
        {
            InitializeComponent();
        }
        //Instanciamos o objeto principal do formulário
        Procedimento procedimento = new Procedimento();

        private void frmProcedimento_Load(object sender, EventArgs e)
        {
            //Chamamos o método para preencher o Grid com os procedimentos cadastrados
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Preenchemos o Grid com o resultado da consulta dos procedimentos
                grdDados.DataSource = procedimento.Consultar();
                //Ocultar colunas
                grdDados.Columns[0].Visible = false; //Id
                //Cabeçalho das colunas
                grdDados.Columns[1].HeaderText = "Procedimentos";
                //Largura das colunas
                grdDados.Columns[1].Width = 350;

            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherFormulario()
        {
            //Preenchemos os controle do formulário com suas
            //respectivas informações contidas no objeto
            txtProcedimento.Text = procedimento.procedimento;
        }
        private void PreencherClasse()
        {
            //Atribuímos às propriedades do objeto os respectivos valores informados no formulário
            procedimento.procedimento = txtProcedimento.Text;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Efetuamos a validação do preenchimento do formulário
                //e armazenamos as mensagens de erro retornadas pelo método
                string mensagemErro = ValidarPreenchimento();
                if (mensagemErro != string.Empty)
                {
                    //Caso seja encontrada algum conteúdo na mensagem de Erro
                    //Exibimos a mensagem ao usuário e encerramos o fluxo de gravação
                    MessageBox.Show(mensagemErro, "Erro de Preenchimento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Chamamos o método para preencher o objeto com os dados
                //Preenchidos no formulário
                PreencherClasse();
                //Chamamos o método para efetivar a gravação dos dados
                procedimento.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Procedimento gravada com sucesso!",
                    "Cadastro de Procedimentos",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                //chamamos o método para limpar o formulário
                LimparCampos();
                //Atualizamos o grid com os dados gravados no banco de dados
                CarregarGrid();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            //Resetamos o objeto 
            procedimento = new Procedimento();
            //Limpamos todos os TextBox
            txtPesquisa.Clear();
            txtProcedimento.Clear();
            //colocamos o cursor no TextBox de Pesquisa
            txtPesquisa.Focus();
        }
        private string ValidarPreenchimento()
        {
            //Fazemos a validação do preenchimento do formulário
            string mensagemErro = string.Empty;
            if (txtProcedimento.Text == string.Empty)
            {
                mensagemErro = "Preencha o PROCEDIMENTO.";
            }
            //Retornamos as mensagens de erro encontradas
            return mensagemErro;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Chamamos o método para limpar o formulário
            LimparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Fechamos o formulário
            Close();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Resetamos o objeto  
                procedimento = new Procedimento();
                //Atribuímos o Id do procedimento a propriedade
                procedimento.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                //Efetuamos a consulta para obter os dados do procedimento
                procedimento.Consultar();
                //Chamamos o método para preencher os dados do formulário
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
