using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SenacHair
{
    public static class Global
    {
        public static string conexao = string.Empty;
        public static string servidor = string.Empty;
        public static string banco = string.Empty;

        public static string usuario = string.Empty;
        public static string nome = string.Empty;
        public static int idUsuario = 0;

        //Método para criptografar uma string no formado MD5
        public static string EncriptPassword(string senha)
        {
            Byte[] original;
            Byte[] criptografado;
            MD5 md5 = new MD5CryptoServiceProvider();
            original = ASCIIEncoding.Default.GetBytes(senha);
            criptografado = md5.ComputeHash(original);

            return Regex.Replace(BitConverter.ToString(criptografado), "-", "").ToLower();
        }
        public static void MontarStringConexao()
        {
            //Lemos as informações do arquivo de configuração para
            //carregarmos o servidor e o banco do dados
            servidor = ConfigurationManager.AppSettings["server"];
            banco = ConfigurationManager.AppSettings["database"];
            //Montamos a string de conexão para utilizarmos na classe AcessoBD
            conexao = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true;",
                servidor, banco);
        }
        public static bool SomenteNumeros(char caracter, TextBox textBox)
        {
            bool retorno = true;

            if (char.IsDigit(caracter)              //é numero
                || caracter == (char)Keys.Back)      //BackSpace    
            {
                retorno = false;
            }
            return retorno;
        }
    }
}
