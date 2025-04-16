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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }
        //Instanciamos o objeto principal do formulário
        Usuario usuario = new Usuario();

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

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //Resetamos o objeto       
            usuario = new Usuario();
            //Atribuímos o nome para pesquisa
            usuario.nome = txtPesquisa.Text;
            //Chamamos o método para preencher o Grid com o resultado do filtro aplicado
            CarregarGrid();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            //Chamamos o método para preencher o Grid com os Usuários cadastrados
            CarregarGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Resetamos o objeto  
                usuario = new Usuario();
                //Atribuímos o Id do Usuário a propriedade
                usuario.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                //Efetuamos a consulta para obter os dados dos usuários
                usuario.Consultar();
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
                usuario.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Usuário gravado com sucesso!",
                    "Cadastro de Usuários",
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
            usuario = new Usuario();
            //Limpamos todos os TextBox
            txtPesquisa.Clear();
            txtUsuario.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            txtConfirmacao.Clear();
            //Deixamos marcado o status ATIVO
            rdbAtivo.Checked = true;
            //e INATIVO fica desmarcado
            rdbInativo.Checked = false;
            //colocamos o cursor no TextBox de Pesquisa
            txtPesquisa.Focus();
        }

        private void CarregarGrid()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Preenchemos o Grid com o resultado da consulta dos usuários
                grdDados.DataSource = usuario.Consultar();
                //Ocultar colunas
                grdDados.Columns[0].Visible = false; //Id
                grdDados.Columns[3].Visible = false; //Senha
                grdDados.Columns[4].Visible = false; //Status
                //Cabeçalho das colunas
                grdDados.Columns[1].HeaderText = "Usuário";
                grdDados.Columns[2].HeaderText = "Nome";
                //Largura das colunas
                grdDados.Columns[1].Width = 100;
                grdDados.Columns[2].Width = 250;
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
            txtUsuario.Text = usuario.login;
            txtNome.Text = usuario.nome;
            txtSenha.Text = usuario.password;
            txtConfirmacao.Text = usuario.password;
            rdbAtivo.Checked = usuario.ativo;
            //Definimos o status INATIVO como OPOSTO do status ATIVO
            rdbInativo.Checked = !usuario.ativo;
        }
        private void PreencherClasse()
        {
            //Atribuímos às propriedades do objeto os respectivos valores informados no formulário
            usuario.login = txtUsuario.Text;
            usuario.nome = txtNome.Text;
            if (usuario.password != txtSenha.Text)
            {
                //Caso tenha existido alteração da senha
                //Atribuímos a nova senha criptografada
                usuario.password = Global.EncriptPassword(txtSenha.Text);
            }
            //Atribuímos o status ativo como o bool do rdbAtivo
            usuario.ativo = rdbAtivo.Checked;
        }

        private string ValidarPreenchimento()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Fazemos a validação do preenchimento do formulário
                string msgErro = string.Empty;
                if (txtUsuario.Text == string.Empty)
                {
                    msgErro = "Preencha o USUÁRIO.\n";
                }
                else
                {
                    //Instanciamos um objeto auxiliar
                    Usuario u = new Usuario();
                    //Atribuímos o usuário para busca
                    u.login = txtUsuario.Text;
                    //Efetuamos a consulta do usuário existente no TextBox
                    u.Consultar();

                    if (usuario.id == 0 && u.id != 0 || //Caso estejamos efetuando o cadastro de um novo usuário, e este usuário já exista no banco de dados
                        usuario.id != 0 && u.id != 0 && usuario.id != u.id) //Ou caso estejamos efetuando a alteração do usuário e este novo usuário já exista no banco de dados
                    {
                        //definimos a mensagem de erro
                        msgErro += "Usuário já existente.\n";
                    }
                }
                if (txtNome.Text == string.Empty)
                {
                    msgErro += "Preencha o NOME.\n";
                }
                if (txtSenha.Text == string.Empty)
                {
                    msgErro += "Preencha a SENHA.\n";
                }
                else if (txtSenha.Text != txtConfirmacao.Text)
                {
                    msgErro += "Confirmação da senha não confere.\n";
                }
                //Retornamos as mensagens de erros definidas
                return msgErro;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Enviamos o erro para quem chamou o método
                throw new Exception(ex.Message);
            }
        }
    }
}
