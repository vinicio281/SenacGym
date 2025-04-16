using SenacHair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenacHair
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
