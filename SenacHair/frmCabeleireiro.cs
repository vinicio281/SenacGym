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
    public partial class frmCabeleireiro : Form
    {
        public frmCabeleireiro()
        {
            InitializeComponent();
        }
        bool load = false;
        //Instanciamos o objeto principal do formulário
        Cabeleireiro cabeleireiro = new Cabeleireiro();
        //Criamos o método para preencher o ComboBox com as especialidades disponíveis no banco de dados

        private void frmCabeleireiro_Load(object sender, EventArgs e)
        {
            //Preenchemos o grid com os clientes existentes no banco de dados
            CarregarGrid();
            //Alteramos a flag informando que o LOAD do formulário foi finalizado
            load = true;
        }

        private void CarregarGrid()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Preenchemos o Grid com o resultado da consulta dos dentistas
                grdDados.DataSource = cabeleireiro.Consultar();
                //Ocultar colunas
                grdDados.Columns[0].Visible = false; //Id
                //Cabeçalho das colunas
                grdDados.Columns[1].HeaderText = "Nome";
                grdDados.Columns[2].HeaderText = "Email";
                grdDados.Columns[3].HeaderText = "Telefone";
                //Largura das colunas
                grdDados.Columns[1].Width = 180;
                grdDados.Columns[2].Width = 83;
                grdDados.Columns[3].Width = 75;


            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //Resetamos o objeto             
            cabeleireiro = new Cabeleireiro();
            //Atribuímos o nome para pesquisa
            cabeleireiro.nome = txtPesquisa.Text;
            //Chamamos o método para preencher o Grid com o resultado do filtro aplicado
            CarregarGrid();
        }

        private void PreencherFormulario()
        {
            //Preenchemos os controle do formulário com suas
            //respectivas informações contidas no objeto
            txtNome.Text = cabeleireiro.nome;
            txtEmail.Text = cabeleireiro.email;
            txtTelefone.Text = cabeleireiro.telefone;
        
        }
        private void PreencherClasse()
        {
            //Atribuímos às propriedades do objeto os respectivos valores informados no formulário
            cabeleireiro.nome = txtNome.Text;
            cabeleireiro.email = txtEmail.Text;
            cabeleireiro.telefone = txtTelefone.Text;
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Resetamos o objeto  
                cabeleireiro = new Cabeleireiro();
                //Atribuímos o Id do dentista a propriedade
                cabeleireiro.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                //Efetuamos a consulta para obter os dados do dentista
                cabeleireiro.Consultar();
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
                cabeleireiro.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Profissional gravado com sucesso!",
                    "Cadastro de Profissional",
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Fechamos o formulário
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Chamamos o método para limpar o formulário
            LimparCampos();
        }

        private void LimparCampos()
        {
            //Resetamos o objeto 
            cabeleireiro = new Cabeleireiro();
            //Limpamos todos os TextBox
            txtPesquisa.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtPesquisa.Focus();
        }
        private string ValidarPreenchimento()
        {
            //Fazemos a validação do preenchimento do formulário
            string msgErro = string.Empty;
            if (txtNome.Text == string.Empty)
            {
                msgErro = "Preencha o NOME.\n";
            }
            if (txtEmail.Text == string.Empty)
            {
                msgErro += "Preencha o EMAIL.\n";
            }
            if (txtTelefone.Text == string.Empty)
            {
                msgErro += "Preencha o Telefone.\n";
            }
            //Retornamos as mensagens de erro encontradas
            return msgErro;
        }


    }
}
