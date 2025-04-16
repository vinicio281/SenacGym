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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        Cliente cliente = new Cliente();

        private void frmCliente_Load(object sender, EventArgs e)
        {
            //Preenchemos o grid com os clientes existentes no banco de dados
            CarregarGrid();
            //Alteramos a flag informando que o LOAD do formulário foi finalizado
        }
        private void CarregarGrid()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Preenchemos o Grid com o resultado da consulta dos dentistas
                grdDados.DataSource = cliente.Consultar();
                //Ocultar colunas
                grdDados.Columns[0].Visible = false; //Id
                //Cabeçalho das colunas
                grdDados.Columns[1].HeaderText = "Nome";
                grdDados.Columns[2].HeaderText = "CPF";
                grdDados.Columns[3].HeaderText = "Celular";
                //Largura das colunas
                grdDados.Columns[1].Width = 200;
                grdDados.Columns[2].Width = 75;
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
            cliente = new Cliente();
            //Atribuímos o nome para pesquisa
            cliente.nome = txtPesquisa.Text;
            //Chamamos o método para preencher o Grid com o resultado do filtro aplicado
            CarregarGrid();
        }

        private void PreencherFormulario()
        {
            //Preenchemos os controle do formulário com suas
            //respectivas informações contidas no objeto
            txtNome.Text = cliente.nome;
            txtCPF.Text = cliente.cpf;
            txtCelular.Text = cliente.celular;
        }

        private void PreencherClasse()
        {
            //Atribuímos às propriedades do objeto os respectivos valores informados no formulário
            cliente.nome = txtNome.Text;
            cliente.cpf = txtCPF.Text;
            cliente.celular = txtCelular.Text;
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
                cliente.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Cliente gravado com sucesso!",
                    "Cadastro de Clientes",
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

        private string ValidarPreenchimento()
        {
            //Fazemos a validação do preenchimento do formulário
            string msgErro = string.Empty;
            if (txtNome.Text == string.Empty)
            {
                msgErro = "Preencha o NOME.\n";
            }
            if (txtCPF.Text == string.Empty)
            {
                msgErro += "Preencha o CPF.\n";
            }
            else
            {
                //Instanciamos um objeto auxiliar
                Cliente c = new Cliente();
                //Atribuímos o CPF para busca
                c.cpf = txtCPF.Text;
                //Efetuamos a consulta do cpf existente no TextBox
                c.Consultar();

                if (cliente.id == 0 && c.id != 0 || //Caso estejamos efetuando o cadastro de um novo cliente, e este cpf já exista no banco de dados
                    cliente.id != 0 && c.id != 0 && cliente.id != c.id) //Ou caso estejamos efetuando a alteração do cliente e este novo cpf já exista no banco de dados
                {
                    //definimos a mensagem de erro
                    msgErro += "CPF já existente.\n";
                }
            }
            if (txtCelular.Text == string.Empty)
            {
                msgErro += "Preencha o CELULAR.\n";
            }
           
            
            //Retornamos as mensagens de erro encontradas
            return msgErro;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Chamamos o método para limpar o formulário
            LimparCampos();
        }

        private void LimparCampos()
        {
            //Resetamos o objeto 
            cliente = new Cliente();
            //Limpamos todos os TextBox
            txtPesquisa.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtCelular.Clear();
            //colocamos o cursor no TextBox de Pesquisa
            txtPesquisa.Focus();
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
                cliente = new Cliente();
                //Atribuímos o Id do dentista a propriedade
                cliente.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                //Efetuamos a consulta para obter os dados do dentista
                cliente.Consultar();
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

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chamamos o método para validar se a tecla pressionada é um número
            e.Handled = Global.SomenteNumeros(e.KeyChar, txtCPF);
        }


    }
}
