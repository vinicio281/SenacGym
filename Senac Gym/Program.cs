using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappySmile;
using SenacHair;

namespace Senac_Gym
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Chamamos o método para ler as configurações do arquivo app.config
            //E montamos a string de conexão para acesso ao banco de dados
            Global.MontarStringConexao();
            //Instanciamos um objeto do formulario de login para autenticarmos o usuário
            frmLogin frm = new frmLogin();
            //Exibimos o formulário em modo proprietário
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                //Caso o formulário tenha retornado Ok como DialogResult, prosseguimos
                //com a execução da aplicação
                Application.Run(new frmPrincipal());
            }



        }
    }
}
