namespace SenacHair
{
    partial class frmPagamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamento));
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.grpAgendamento = new System.Windows.Forms.GroupBox();
            this.grdAgendamento = new System.Windows.Forms.DataGridView();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.gpoProcedimento = new System.Windows.Forms.GroupBox();
            this.grdProcedimento = new System.Windows.Forms.DataGridView();
            this.lblSItuacao = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpAgendamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgendamento)).BeginInit();
            this.grpCliente.SuspendLayout();
            this.gpoProcedimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimento)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(45, 19);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(96, 20);
            this.dtpData.TabIndex = 8;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(9, 20);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Data";
            // 
            // grpAgendamento
            // 
            this.grpAgendamento.Controls.Add(this.grdAgendamento);
            this.grpAgendamento.Location = new System.Drawing.Point(12, 52);
            this.grpAgendamento.Name = "grpAgendamento";
            this.grpAgendamento.Size = new System.Drawing.Size(623, 166);
            this.grpAgendamento.TabIndex = 9;
            this.grpAgendamento.TabStop = false;
            this.grpAgendamento.Text = "Agendamentos";
            // 
            // grdAgendamento
            // 
            this.grdAgendamento.AllowUserToAddRows = false;
            this.grdAgendamento.AllowUserToDeleteRows = false;
            this.grdAgendamento.AllowUserToResizeColumns = false;
            this.grdAgendamento.AllowUserToResizeRows = false;
            this.grdAgendamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAgendamento.Location = new System.Drawing.Point(6, 19);
            this.grdAgendamento.MultiSelect = false;
            this.grdAgendamento.Name = "grdAgendamento";
            this.grdAgendamento.ReadOnly = true;
            this.grdAgendamento.RowHeadersVisible = false;
            this.grdAgendamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAgendamento.Size = new System.Drawing.Size(611, 131);
            this.grdAgendamento.TabIndex = 0;
            this.grdAgendamento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgendamento_CellClick);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(15, 423);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(58, 13);
            this.lblValor.TabIndex = 26;
            this.lblValor.Text = "Valor Total";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(395, 420);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(108, 13);
            this.lblFormaPagamento.TabIndex = 36;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Location = new System.Drawing.Point(509, 415);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(120, 21);
            this.cboFormaPagamento.TabIndex = 35;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(79, 419);
            this.txtValor.MaxLength = 100;
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(109, 20);
            this.txtValor.TabIndex = 26;
            this.txtValor.TabStop = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::SenacHair.Properties.Resources.eraser;
            this.btnLimpar.Location = new System.Drawing.Point(391, 457);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(115, 41);
            this.btnLimpar.TabIndex = 38;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Image = global::SenacHair.Properties.Resources.check;
            this.btnGravar.Location = new System.Drawing.Point(230, 457);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(155, 41);
            this.btnGravar.TabIndex = 37;
            this.btnGravar.Text = "Confirmar Pagamento";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SenacHair.Properties.Resources.exit;
            this.btnCancelar.Location = new System.Drawing.Point(514, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 41);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(47, 12);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(435, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TabStop = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 15);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 20;
            this.lblNome.Text = "Nome";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblNome);
            this.grpCliente.Controls.Add(this.txtNome);
            this.grpCliente.Location = new System.Drawing.Point(147, 4);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(488, 42);
            this.grpCliente.TabIndex = 11;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // gpoProcedimento
            // 
            this.gpoProcedimento.Controls.Add(this.grdProcedimento);
            this.gpoProcedimento.Location = new System.Drawing.Point(12, 224);
            this.gpoProcedimento.Name = "gpoProcedimento";
            this.gpoProcedimento.Size = new System.Drawing.Size(623, 179);
            this.gpoProcedimento.TabIndex = 10;
            this.gpoProcedimento.TabStop = false;
            this.gpoProcedimento.Text = "Procedimentos";
            // 
            // grdProcedimento
            // 
            this.grdProcedimento.AllowUserToAddRows = false;
            this.grdProcedimento.AllowUserToDeleteRows = false;
            this.grdProcedimento.AllowUserToResizeColumns = false;
            this.grdProcedimento.AllowUserToResizeRows = false;
            this.grdProcedimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcedimento.Location = new System.Drawing.Point(6, 19);
            this.grdProcedimento.MultiSelect = false;
            this.grdProcedimento.Name = "grdProcedimento";
            this.grdProcedimento.ReadOnly = true;
            this.grdProcedimento.RowHeadersVisible = false;
            this.grdProcedimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProcedimento.Size = new System.Drawing.Size(611, 144);
            this.grdProcedimento.TabIndex = 0;
            // 
            // lblSItuacao
            // 
            this.lblSItuacao.AutoSize = true;
            this.lblSItuacao.Location = new System.Drawing.Point(194, 421);
            this.lblSItuacao.Name = "lblSItuacao";
            this.lblSItuacao.Size = new System.Drawing.Size(49, 13);
            this.lblSItuacao.TabIndex = 40;
            this.lblSItuacao.Text = "Situação";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 418);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 41;
            this.textBox1.TabStop = false;
            // 
            // frmPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 514);
            this.Controls.Add(this.lblSItuacao);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gpoProcedimento);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cboFormaPagamento);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.grpAgendamento);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamentos";
            this.Load += new System.EventHandler(this.frmPagamento_Load);
            this.grpAgendamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgendamento)).EndInit();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.gpoProcedimento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.GroupBox grpAgendamento;
        private System.Windows.Forms.DataGridView grdAgendamento;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cboFormaPagamento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.GroupBox gpoProcedimento;
        private System.Windows.Forms.DataGridView grdProcedimento;
        private System.Windows.Forms.Label lblSItuacao;
        private System.Windows.Forms.TextBox textBox1;
    }
}