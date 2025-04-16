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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Instanciamos o objeto de usuário
                Usuario usuario = new Usuario();
                //Atribuímos o usário digitado
                usuario.login = txtUsuario.Text;
                //chamamos o método para consultar o usuário
                usuario.Consultar();
                //Criptografamos a senha digitada
                string senhaCriptografada = Global.EncriptPassword(txtSenha.Text);
                //Comparamos a senha criptografada com a senha retornada do banco de dados
                if (usuario.password == senhaCriptografada && usuario.password != "")
                {
                    //Caso a senha esteja correta, exibimos a mensagem de sucesso
                    MessageBox.Show("Bem vindo " + usuario.nome, "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Definimos o resultado de diálogo do formulário como OK
                    this.DialogResult = DialogResult.OK;
                    //Atribuimos às variáveis globais os dados do usuário logado
                    Global.idUsuario = usuario.id;
                    Global.usuario = usuario.login;
                    Global.nome = usuario.nome;
                    //Fechamos o formulário
                    this.Close();
                }
                else
                {
                    //Caso a senha esteja incorreta
                    //Exibimos a mensagem ao usuáro
                    MessageBox.Show("Usuário e/ou senha incorretos.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
