using System;
using System.Data;
using System.Windows.Forms;

namespace SenacHair
{
    public partial class frmPagamento : Form
    {
        public frmPagamento()
        {
            InitializeComponent();
        }

        private Pagamento pagamento = new Pagamento();
        FormaPagamento formaPagamento;

        private void PreencherFormasPagamento()
        {
            try
            {
                formaPagamento = new FormaPagamento();
                cboFormaPagamento.DataSource = formaPagamento.Consultar();
                cboFormaPagamento.DisplayMember = "FormaPagamento";
                cboFormaPagamento.ValueMember = "id";
                cboFormaPagamento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridAgendamentos()
        {

            grdAgendamento.Columns["id"].Visible = false;
            grdAgendamento.Columns["idCliente"].Visible = false;
            grdAgendamento.Columns["idCabeleireiro"].Visible = false;
            grdAgendamento.Columns["idSituacao"].Visible = false;
            grdAgendamento.Columns["hora"].Width = 70;
            grdAgendamento.Columns["cliente"].Width = 200;
            grdAgendamento.Columns["cabeleireiro"].Width = 198;
            grdAgendamento.Columns["cpf"].Width = 75;
            grdAgendamento.Columns["situacao"].Width = 65;
        }

        private void ConfigurarGridProcedimentos()
        {

            grdProcedimento.Columns["id"].Visible = false;
            grdProcedimento.Columns["procedimento"].Width = 508;
            grdProcedimento.Columns["valor"].Width = 100;
        }

        private void CarregarAgendamentos()
        {
            try
            {
                Agendamento a = new Agendamento();
                a.data = dtpData.Value;
                a.idSituacao = 1;
                grdAgendamento.DataSource = a.Consultar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProcedimentos(int agendamentoId)
        {
            Agendamento a = new Agendamento();
            a.id = agendamentoId;
            double total = 0;
            grdProcedimento.DataSource = a.CarregarProcedimentos();
            foreach (var procedimento in a.procedimentos)
            {
                total += procedimento.valor;
            }
            txtValor.Text = total.ToString("c");
        }

        private void frmPagamento_Load(object sender, EventArgs e)
        {
            PreencherFormasPagamento();
            CarregarAgendamentos();
            ConfigurarGridAgendamentos();
            
            
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            CarregarAgendamentos();
        }

        private void grdAgendamento_CellClick(object sender, EventArgs e)
        {
            if (grdAgendamento.SelectedRows.Count > 0)
            {
                int agendamentoId = Convert.ToInt32(grdAgendamento.SelectedRows[0].Cells["id"].Value);
                CarregarProcedimentos(agendamentoId);
                txtNome.Text = grdAgendamento.SelectedRows[0].Cells["cliente"].Value.ToString();
                textBox1.Text = grdAgendamento.SelectedRows[0].Cells["situacao"].Value.ToString();
                ConfigurarGridProcedimentos();
            }
        }

        private string ValidarPagamento()
        {
            if (grdAgendamento.SelectedRows.Count == 0)
                return "Selecione um agendamento!";

            if (cboFormaPagamento.SelectedIndex == -1)
                return "Selecione a forma de pagamento!";

            if (Convert.ToDecimal(txtValor.Text.Replace("R$", "").Trim()) <= 0)
                return "Valor inválido!";

            return string.Empty;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                string validacao = ValidarPagamento();
                if (validacao != "")
                {
                    MessageBox.Show(validacao, "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                pagamento.data = dtpData.Value;
                pagamento.valor = Convert.ToDecimal(txtValor.Text.Replace("R$", "").Trim());
                pagamento.formaPagamentoId = (int)cboFormaPagamento.SelectedValue;
                pagamento.agendamentoID = Convert.ToInt32(grdAgendamento.SelectedRows[0].Cells["id"].Value);

                pagamento.Gravar();
                MessageBox.Show("Pagamento registrado com sucesso!", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            grdProcedimento.DataSource = null;
            txtNome.Clear();
            txtValor.Clear();
            textBox1.Clear();
            cboFormaPagamento.SelectedIndex = -1;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}