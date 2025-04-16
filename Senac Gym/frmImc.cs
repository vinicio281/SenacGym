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
    public partial class frmImc : Form
    {
        public frmImc()
        {
            InitializeComponent();
        }

        private void calcularImc()
        {
            if (Global.isFloat(txtAltura.Text) && Global.isFloat(txtPeso.Text))
            {
                float peso = float.Parse(txtPeso.Text);
                float altura = float.Parse(txtAltura.Text);
                if (peso == 0 || altura == 0)
                {
                    txtImc.Clear();
                    txtStatus.Clear();
                    return;
                }
                float imc = peso / (altura * altura);
                txtImc.Text = imc.ToString();

                string status;
                if (imc > 30)
                {
                    status = "Obesidade";
                } else if (imc >= 25)
                {
                    status = "Sobrepeso";
                }
                else if (imc >= 18.5)
                {
                    status = "Saudável";
                } else
                {
                    status = "Abaixo do peso";
                }
                txtStatus.Text = status;
            } else
            {
                txtImc.Clear();
                txtStatus.Clear();
            }
        }

        private void CarregarGrid()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Preenchemos o Grid com o resultado da consulta dos usuários
                grdDados.DataSource = imc.Consultar();
                //Ocultar colunas
                grdDados.Columns[0].Visible = false; //Id
                grdDados.Columns[1].Visible = false; //Senha
                grdDados.Columns[5].Visible = false; //Data Nascimento
                //Cabeçalho das colunas
                grdDados.Columns[2].HeaderText = "Nome";
                grdDados.Columns[3].HeaderText = "Altura";
                grdDados.Columns[4].HeaderText = "Peso";
                grdDados.Columns[6].HeaderText = "Nascimento";
                //Largura das colunas
                grdDados.Columns[2].Width = 100;
                grdDados.Columns[3].Width = 100;
                grdDados.Columns[4].Width = 100;
                grdDados.Columns[6].Width = 100;

            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Imc imc = new Imc();
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //Resetamos o objeto       
            imc = new Imc();
            //Atribuímos o nome para pesquisa
            imc.nome = txtPesquisa.Text;
            //Chamamos o método para preencher o Grid com o resultado do filtro aplicado
            CarregarGrid();
        }

        private string ValidarPreenchimento()
        {
            string mensagemErro = "";
            if (!Global.isFloat(txtAltura.Text))
            {
                mensagemErro += "Altura deve ser um número!\n";
            }
            if (!Global.isFloat(txtIdade.Text))
            {
                mensagemErro += "Idade deve ser um número!\n";
            }
            if (!Global.isFloat(txtPeso.Text))
            {
                mensagemErro += "Peso deve ser um número!\n";
            }
            return mensagemErro;
        }

        private void PreencherClasse()
        {
            imc.nome = txtNome.Text;
            imc.altura = float.Parse(txtAltura.Text);
            imc.peso = float.Parse(txtPeso.Text);
            imc.data = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LimparCampos()
        {
            imc = new Imc();
            txtAltura.Clear();
            txtIdade.Clear();
            txtPeso.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
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
                imc.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Tipo de Cliente gravado com sucesso!",
                    "Cadastro de Tipos de Cliente",
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

        private void PreencherFormulario()
        {
            txtNome.Text = imc.nome;
            txtAltura.Text = imc.altura != 0 ? imc.altura.ToString() : "";
            txtPeso.Text = imc.peso != 0 ? imc.peso.ToString() : "";
            txtIdade.Text = imc.idade != 0 ? imc.idade.ToString() : "";
        }

        private void frmImc_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Resetamos o objeto  
                imc = new Imc();
                //Atribuímos o Id do dentista a propriedade
                imc.idAluno = Convert.ToInt32(grdDados.SelectedRows[0].Cells[1].Value);
                if (!(grdDados.SelectedRows[0].Cells[0].Value.GetType() == typeof(DBNull)))
                {
                    imc.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                }
                    
                //Efetuamos a consulta para obter os dados do dentista
                imc.Consultar();
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

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            calcularImc();
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            calcularImc();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            imc = new Imc();
            txtAltura.Clear();
            txtIdade.Clear();
            txtImc.Clear();
            txtNome.Clear();
            txtPeso.Clear();    
            txtPesquisa.Clear();
            txtPesquisa.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
