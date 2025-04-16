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
    public partial class frmAgendamento : Form
    {
        public frmAgendamento()
        {
            InitializeComponent();
        }
        //Instanciamos o objeto principal do formulário
        Agendamento agendamento = new Agendamento();
        //Criamos uma variável boolead para gerenciar o load do formulário
        bool load = false;

        private void PreencherCabeleireiro()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Instanciamos o objeto
                Cabeleireiro d = new Cabeleireiro();
                //Carregamos o ComboBox com o resultado da consulta dos dentistas (DataTable)
                cboCabeleireiro.DataSource = d.Consultar();
                //Definimos o valor a ser exibido para o usuário
                cboCabeleireiro.DisplayMember = "Nome";
                //Definimos o valor a ser armazenado após o usuário selecionar um item
                cboCabeleireiro.ValueMember = "Id";
                //Definimos que o ComboBox irá ser iniciado sem nenhuma opção escolhida
                cboCabeleireiro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAgendamento_Load(object sender, EventArgs e)
        {
            PreencherCabeleireiro();
            PreencherProcedimentos();
            PreencherSituacoes();
            ConfigurarGrid();
            //Copiamos as definições de exibição e atribuição de valores do ComboBox para o ListBox
            lstProcedimentos.DisplayMember = cboProcedimentos.DisplayMember;
            lstProcedimentos.ValueMember = cboProcedimentos.ValueMember;
            //definimos como true, para sinalizar que o load foi processado
            load = true;
        }

        private void PreencherSituacoes()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Instanciamos o objeto
                Situacao s = new Situacao();
                //Carregamos o ComboBox com o resultado da consulta das situações (DataTable)
                cboSituacoes.DataSource = s.Consultar();
                //Definimos o valor a ser exibido para o usuário
                cboSituacoes.DisplayMember = "Situacao";
                //Definimos o valor a ser armazenado após o usuário selecionar um item
                cboSituacoes.ValueMember = "Id";
                //Definimos que o ComboBox irá ser iniciado sem nenhuma opção escolhida
                cboSituacoes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherProcedimentos()
        {
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Instanciamos o objeto
                Procedimento p = new Procedimento();
                //Carregamos o ComboBox com o resultado da consulta dos procedimentos (DataTable)
                cboProcedimentos.DataSource = p.Consultar();
                //Definimos o valor a ser exibido para o usuário
                cboProcedimentos.DisplayMember = "Procedimento";
                //Definimos o valor a ser armazenado após o usuário selecionar um item
                cboProcedimentos.ValueMember = "Id";
                //Definimos que o ComboBox irá ser iniciado sem nenhuma opção escolhida
                cboProcedimentos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpAgendamento_ValueChanged(object sender, EventArgs e)
        {
            //Caso nenhum dentista foi selecionado, não consultamos os agendamentos
            if (cboCabeleireiro.SelectedValue == null) return;
            //consultamos os agendamentos caso o dentista esteja selecionado
            CarregarGrid();
        }
        private void ConfigurarGrid()
        {
            //Como o grid desta tela é um grid offline, ou seja, não está vinculado diretamente a uma consulta 
            //precisamos criar sua estrutura manualmente
            //Limpamos as linhas existentes de uma consulta anterior
            grdAgendamento.Rows.Clear();
            //Limpamos as colunas existentes de uma consulta anterior
            grdAgendamento.Columns.Clear();
            //Adicionamos as colunas 
            grdAgendamento.Columns.Add("id", "id");
            grdAgendamento.Columns.Add("hora", "Hora");
            grdAgendamento.Columns.Add("Situacao", "Situação");
            grdAgendamento.Columns.Add("idCliente", "idCliente");
            grdAgendamento.Columns.Add("cliente", "Cliente");
            grdAgendamento.Columns.Add("cpf", "CPF");
            grdAgendamento.Columns.Add("idCabeleireiro", "idCabeleireiro");
            grdAgendamento.Columns.Add("Cabeleireiro", "Cabeleireiro");
            grdAgendamento.Columns.Add("idSituacao", "idSituacao");

            //Ocultar colunas que não devem ser visíveis para o usuário
            grdAgendamento.Columns[0].Visible = false; //Id
            grdAgendamento.Columns[3].Visible = false; //IdCliente
            grdAgendamento.Columns[5].Visible = false; //CPF
            grdAgendamento.Columns[6].Visible = false; //IdDentista
            grdAgendamento.Columns[8].Visible = false; //IdSituacao

            //Definimos a largura das colunas
            grdAgendamento.Columns[1].Width = 50; //Hora
            grdAgendamento.Columns[2].Width = 79; //Situação
            grdAgendamento.Columns[4].Width = 245; //Cliente
            grdAgendamento.Columns[7].Width = 245; //Dentista

            //Alterando o alinhamento das colunas
            grdAgendamento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAgendamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Criamos um vetor com 9 posições para colocarmos todos os valores de cada linha do grid
            string[] linha = new string[9];
            for (int i = 0; i < 9; i++)
            {
                //Iniciando as colunas com uma string vazia
                linha[i] = string.Empty;
            }
            //Horários das 8:00 as 22:00h
            for (int i = 8; i < 23; i++)
            {
                //Preenchemos apenas o horário
                linha[1] = i.ToString("00") + ":00";
                //Adicionamos a linha no grid
                grdAgendamento.Rows.Add(linha);
            }
        }
        private void CarregarGrid()
        {
            //Para preencher o grid, primeiro fazemos a configuração dele
            ConfigurarGrid();
            //resetamos o objeto
            agendamento = new Agendamento();
            //Armazenamos a data selecionada no calendário
            agendamento.data = dtpAgendamento.Value;
            //Armazenamos o id do dentista a ser consultado
            agendamento.cabeleireiro.id = (int)cboCabeleireiro.SelectedValue;

            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Percorremos os horários retornados na consulta para colocar cada um no seu respectivo local
                foreach (DataRow dr in agendamento.Consultar().Rows)
                {
                    //Percorremos cada linha do grid para encontrar o horário
                    foreach (DataGridViewRow linha in grdAgendamento.Rows)
                    {
                        if (dr[1].ToString() == linha.Cells[1].Value.ToString())
                        {
                            //Com o horário identificado, colocamos cada informação no seu lugar, dentro da linha do grid posicionada
                            linha.Cells[0].Value = dr[0].ToString();
                            linha.Cells[2].Value = dr[2].ToString();
                            linha.Cells[3].Value = dr[3].ToString();
                            linha.Cells[4].Value = dr[4].ToString();
                            linha.Cells[5].Value = dr[5].ToString();
                            linha.Cells[6].Value = dr[6].ToString();
                            linha.Cells[7].Value = dr[7].ToString();
                            linha.Cells[8].Value = dr[8].ToString();
                            //Paramos de percorrer o grid e passamos para o próximo registro retornado na consulta
                            break;
                        }
                    }
                }
                //Limpamos os campos do agendamento
                LimparCampos();
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConsultarCliente()
        {
            try
            {
                //Instanciamos um objeto cliente para consultar o cliente pelo cpf digitado
                Cliente c = new Cliente();
                //Atribuímos o cpf digitado à propriedade correspondentes
                c.cpf = txtCPF.Text;
                //Fazemos a consulta do CPF
                c.Consultar();
                //Verificamos se o CPF foi localizado no banco de dados
                if (c.id == 0)
                {
                    //Caso não seja localizado, exibimos a mensagem ao usuário
                    MessageBox.Show("Cliente não localizado.", "Agendamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCPF.Focus();
                    //Encerramos o processamento do método
                    return;
                }
                //atribuímos o cliente encontrado ao cliente do objeto de agendamento
                agendamento.cliente = c;
                //Preenchemos a tela com os dados do cliente
                txtNome.Text = c.nome;
                txtCelular.Text = c.celular;   
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro fora do ambiente
                //Mostramos a mensagem de erro ao usuário
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            //Se o CPF não estiver preenchido, não consultamos o cliente
            if (string.IsNullOrEmpty(txtCPF.Text)) return;
            //Chamamos o método para consultar o cliente através do CPF
            ConsultarCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Fechamos o formulário
            Close();
        }

        private void LimparCampos()
        {
            //Resetamos o objeto
            agendamento = new Agendamento();
            //Limpamos os TextBox
            txtNome.Clear();
            txtCPF.Clear();
            txtCelular.Clear();
            //Limpamos o ListBox
            lstProcedimentos.Items.Clear();
            //Reposicionamos os ComboBox
            cboProcedimentos.SelectedIndex = -1;
            cboSituacoes.SelectedIndex = -1;
            //Desabilitamos o ComboBox
            cboSituacoes.Enabled = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Chamamos o método para limpar o formulário
            LimparCampos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Caso não tenhamos nenhuma especialidade selecionada, não executamos nenhuma ação
            if (cboProcedimentos.SelectedIndex == -1) return;

            if (lstProcedimentos.Items.IndexOf(cboProcedimentos.SelectedItem) != -1)
            {
                //Caso o procedimento já tenha sido adicionado anteriormente
                //Exibimos a mensagem ao usuário e não executamos nenhuma ação
                MessageBox.Show("Procedimento já selecionado.",
                    "Cadastro de Cabeleireiro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Adicionamos ao ListBox a especialidade selecionada no ComboBox
            lstProcedimentos.Items.Add(cboProcedimentos.SelectedItem);
            //Posicionamos o ComboBox na opção em branco
            cboProcedimentos.SelectedIndex = -1;
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            //Caso não tenhamos nenhuma especialidade adicionada, não executamos nenhuma ação
            if (lstProcedimentos.SelectedIndex == -1) return;

            //Exibimos a mensagem ao usuário, solicitando a confirmação da exclusão
            //do procedimento selecionada
            string item = lstProcedimentos.Text;
            if (MessageBox.Show($"Deseja remover o item {item}?",
                "Cadastro de Cabeleireiro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            //Caso o usuário confirma a intenção, removemos o procedimento selecionada
            lstProcedimentos.Items.Remove(lstProcedimentos.SelectedItem);
        }

        private void cboCabeleireiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verificamos se o dentista foi selecionado e o Load do formulário já tenha sido finalizado
            if (cboCabeleireiro.SelectedValue == null || !load) return;
            //Efetuamos a consulta para trazer os dados dos agendamentos do dentista selecionado
            CarregarGrid();
        }

        private void grdAgendamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verificamos se o horário está vago
            if (grdAgendamento.SelectedRows[0].Cells[0].Value.ToString() == string.Empty)
            {
                //Caso seja um horário vago, limpamos os campos referente ao agendamento
                LimparCampos();
                //Encerramos a execução do método
                return;
            }
            //Caso seja um horário preenchido, efetuamos a consulta do agendamento
            //definimos um bloco try/catch para garantir a execução
            //do fluxo fora do nosso ambiente
            try
            {
                //Resetamos o objeto  
                agendamento = new Agendamento();
                //Atribuímos o Id do agendamento a propriedade
                agendamento.id = Convert.ToInt32(grdAgendamento.SelectedRows[0].Cells[0].Value);
                //Efetuamos a consulta para obter os dados do agendamento
                agendamento.Consultar();
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

        private void PreencherFormulario()
        {
            //Preenchemos o CPF do cliente
            txtCPF.Text = agendamento.cliente.cpf;
            //chamamos o método para consultar o cliente e preencher o restante dos dados do cliente
            ConsultarCliente();
            //Limpamos a lista de procedimentos
            lstProcedimentos.Items.Clear();
            //Percorremos a lista de procedimentos do agendamento
            foreach (Procedimento p in agendamento.procedimentos)
            {
                //Posicionamos o comboBox no procedimento existente
                cboProcedimentos.SelectedValue = p.id;
                //Simulamos o click no botão adicionar
                btnAdd.PerformClick();
            }
            //habilitamos o combobox de situações
            cboSituacoes.Enabled = true;
            //Posicionamos o combobox na situação 
            cboSituacoes.SelectedValue = agendamento.situacao.id;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            //Fazemos a validação do preenchimento do formulário
            if (txtNome.Text == string.Empty)
            {
                msgErro = "Selecione o cliente.\n";
            }
            if (cboCabeleireiro.SelectedIndex == -1)
            {
                msgErro += "Selecione o cabeleireiro.\n";
            }
            if (lstProcedimentos.Items.Count == 0)
            {
                msgErro += "Selecione ao menos 1 procedimento.\n";
            }
            //Retornamos as mensagens de erro encontradas
            return msgErro;
        }

        private void PreencherClasse()
        {
            //Atribuímos às propriedades do objeto os respectivos valores informados no formulário
            agendamento.cabeleireiro.id = (int)cboCabeleireiro.SelectedValue;
            agendamento.data = Convert.ToDateTime(dtpAgendamento.Value.ToShortDateString()+" "+ grdAgendamento.SelectedRows[0].Cells[1].Value);
            agendamento.situacao.id = agendamento.id == 0 ? 1 : (int)cboSituacoes.SelectedValue;
            //Limpamos a lista de procedimentos
            agendamento.procedimentos.Clear();
            //Percorremos todas os procedimentos adicionados ao ListNox
            foreach (DataRowView item in lstProcedimentos.Items)
            {
                //Instanciamos um objeto de procedimento
                Procedimento p = new Procedimento();
                //Atribuímos os respectivos valores às propriedades do objeto
                p.id = Convert.ToInt32(item.Row.ItemArray[0]);
                p.procedimento = item.Row.ItemArray[1].ToString();
                //Adicionamos o objeto à lista de procedimentos do objeto principal
                agendamento.procedimentos.Add(p);
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
                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    //Caso seja encontrada algum conteúdo na mensagem de Erro
                    //Exibimos a mensagem ao usuário e encerramos o fluxo de gravação
                    MessageBox.Show(mensagem, "Agendamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Chamamos o método para preencher o objeto com os dados
                //Preenchidos no formulário
                PreencherClasse();
                //Chamamos o método para efetivar a gravação dos dados
                agendamento.Gravar();
                //Exibimos a mensagem de sucesso na gravação dos dados
                MessageBox.Show("Agendamento gravado com sucesso.", "Agendamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Resetamos apenas o cliente do agendamento, para mantermos o dentista selecionado e a data
                agendamento.cliente = new Cliente();
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

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verificamos se o caracter digitado é um número ou o BackSpace
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //Caso não seja um número ou o backSpace, ignoramos a tecla
                e.Handled = true;
            }
        }

        private void dtpAgendamento_ValueChanged_1(object sender, EventArgs e)
        {
            if (cboCabeleireiro.SelectedValue == null) return;
            CarregarGrid();
        }

    }
}
