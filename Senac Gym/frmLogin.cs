using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappySmile;

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
            try
            {
                Usuario usuario = new Usuario();
                usuario.login = txtUsuario.Text;
                usuario.Consultar();

                if (!usuario.ativo && usuario.password != "")
                {
                    MessageBox.Show("Usuário inativo.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string senhaCriptografada = Global.EncriptPassword(txtSenha.Text);
                if (usuario.password == senhaCriptografada)
                {
                    MessageBox.Show("Bem vindo " + usuario.nome, "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Global.idUsuario = usuario.id;
                    Global.usuario = usuario.login;
                    Global.nome = usuario.nome;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha incorretos.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
