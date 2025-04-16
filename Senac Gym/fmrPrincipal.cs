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

namespace Senac_Gym
{
    public partial class frmPrincipal : Form
    {
        //Instanciamos uma variável para armazenar o momento do login
        DateTime login;
        private void AbrirForm(Form form)
        {
            if (Application.OpenForms[form.Name] != null)
            {
                Application.OpenForms[form.Name].Activate();
            }
            else
            {
                form.Show();
            }
        }
        public frmPrincipal()
        {
            InitializeComponent();
        }



        private void btnConsultaIMC_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmImc());
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            //No click do menu, chamamos o método para abrir o formulário
            AbrirForm(new frmUsuario());
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmAluno());
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTreino_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmAtividade());
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Preenchemos o label com os dados do usuário logado
            //Ex: Usuário: Administrador (adm.admin)
            lblUsuario.Text = string.Format("Usuario: {0} ({1})",
                Global.nome, Global.usuario);
            //Preenchemos o label com os dados do banco de dados
            //Ex: Servidor: TIT686856\SQLEXPRESS | Banco: HappySmile
            lblConexao.Text = string.Format("Servidor: {0} | Banco: {1}",
                Global.servidor, Global.banco);

            //Atribuímos o momento do login
            login = DateTime.Now;
            //Definimos a posição do formulário
            Left = 0;
            Top = 0;
            //Definimos o tamanho do formulário
            //Com o tamanho da área útil do monitor
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void tmrPrincipal_Tick(object sender, EventArgs e)
        {
            //Instanciamos um objeto TimeSpam para calcular o tempo de logado do usuário
            //Com base na data de login e no momento atual do ciclo do timer (1 seg)
            TimeSpan ts = DateTime.Now - login;

            //Preenchemos o label com o tempo que o usúário está logado
            lblTempo.Text = string.Format("Tempo: {0}:{1}:{2}",
                ts.Hours.ToString("00"),
                ts.Minutes.ToString("00"),
                ts.Seconds.ToString("00"));
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmPagamento());
        }

        private void mnuSobre_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmSobre());
        }
    }
}
