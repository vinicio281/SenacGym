namespace SenacHair
{
    partial class frmAgendamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendamento));
            this.grpAgendamento = new System.Windows.Forms.GroupBox();
            this.grdAgendamento = new System.Windows.Forms.DataGridView();
            this.dtpAgendamento = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.cboCabeleireiro = new System.Windows.Forms.ComboBox();
            this.lblCabeleireiro = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.grpProcedimento = new System.Windows.Forms.GroupBox();
            this.btnRem = new System.Windows.Forms.Button();
            this.lstProcedimentos = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboProcedimentos = new System.Windows.Forms.ComboBox();
            this.lblProcedimento = new System.Windows.Forms.Label();
            this.cboSituacoes = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpAgendamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgendamento)).BeginInit();
            this.grpCliente.SuspendLayout();
            this.grpProcedimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAgendamento
            // 
            this.grpAgendamento.Controls.Add(this.grdAgendamento);
            this.grpAgendamento.Location = new System.Drawing.Point(12, 40);
            this.grpAgendamento.Name = "grpAgendamento";
            this.grpAgendamento.Size = new System.Drawing.Size(634, 379);
            this.grpAgendamento.TabIndex = 7;
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
            this.grdAgendamento.Size = new System.Drawing.Size(622, 353);
            this.grdAgendamento.TabIndex = 0;
            this.grdAgendamento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgendamento_CellClick);
            // 
            // dtpAgendamento
            // 
            this.dtpAgendamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAgendamento.Location = new System.Drawing.Point(358, 10);
            this.dtpAgendamento.Name = "dtpAgendamento";
            this.dtpAgendamento.Size = new System.Drawing.Size(96, 20);
            this.dtpAgendamento.TabIndex = 6;
            this.dtpAgendamento.ValueChanged += new System.EventHandler(this.dtpAgendamento_ValueChanged_1);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(322, 12);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 5;
            this.lblData.Text = "Data";
            // 
            // cboCabeleireiro
            // 
            this.cboCabeleireiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabeleireiro.FormattingEnabled = true;
            this.cboCabeleireiro.Location = new System.Drawing.Point(80, 10);
            this.cboCabeleireiro.Name = "cboCabeleireiro";
            this.cboCabeleireiro.Size = new System.Drawing.Size(236, 21);
            this.cboCabeleireiro.TabIndex = 9;
            this.cboCabeleireiro.SelectedIndexChanged += new System.EventHandler(this.cboCabeleireiro_SelectedIndexChanged);
            // 
            // lblCabeleireiro
            // 
            this.lblCabeleireiro.AutoSize = true;
            this.lblCabeleireiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCabeleireiro.Location = new System.Drawing.Point(15, 12);
            this.lblCabeleireiro.Name = "lblCabeleireiro";
            this.lblCabeleireiro.Size = new System.Drawing.Size(62, 13);
            this.lblCabeleireiro.TabIndex = 8;
            this.lblCabeleireiro.Text = "Cabeleireiro";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblCelular);
            this.grpCliente.Controls.Add(this.txtCelular);
            this.grpCliente.Controls.Add(this.lblCPF);
            this.grpCliente.Controls.Add(this.txtCPF);
            this.grpCliente.Controls.Add(this.lblNome);
            this.grpCliente.Controls.Add(this.txtNome);
            this.grpCliente.Location = new System.Drawing.Point(650, 50);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(358, 84);
            this.grpCliente.TabIndex = 10;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(169, 49);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(39, 13);
            this.lblCelular.TabIndex = 25;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(214, 47);
            this.txtCelular.MaxLength = 100;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.ReadOnly = true;
            this.txtCelular.Size = new System.Drawing.Size(134, 20);
            this.txtCelular.TabIndex = 2;
            this.txtCelular.TabStop = false;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(10, 49);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(27, 13);
            this.lblCPF.TabIndex = 22;
            this.lblCPF.Text = "CPF";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(55, 47);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(113, 20);
            this.txtCPF.TabIndex = 0;
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(10, 23);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 20;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(55, 21);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(293, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TabStop = false;
            // 
            // grpProcedimento
            // 
            this.grpProcedimento.Controls.Add(this.btnRem);
            this.grpProcedimento.Controls.Add(this.lstProcedimentos);
            this.grpProcedimento.Controls.Add(this.btnAdd);
            this.grpProcedimento.Controls.Add(this.cboProcedimentos);
            this.grpProcedimento.Controls.Add(this.lblProcedimento);
            this.grpProcedimento.Location = new System.Drawing.Point(650, 192);
            this.grpProcedimento.Name = "grpProcedimento";
            this.grpProcedimento.Size = new System.Drawing.Size(360, 147);
            this.grpProcedimento.TabIndex = 28;
            this.grpProcedimento.TabStop = false;
            // 
            // btnRem
            // 
            this.btnRem.Image = global::SenacHair.Properties.Resources.Minus_16;
            this.btnRem.Location = new System.Drawing.Point(324, 46);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(25, 27);
            this.btnRem.TabIndex = 30;
            this.btnRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // lstProcedimentos
            // 
            this.lstProcedimentos.FormattingEnabled = true;
            this.lstProcedimentos.Location = new System.Drawing.Point(14, 44);
            this.lstProcedimentos.Name = "lstProcedimentos";
            this.lstProcedimentos.Size = new System.Drawing.Size(304, 95);
            this.lstProcedimentos.TabIndex = 29;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::SenacHair.Properties.Resources.add_16;
            this.btnAdd.Location = new System.Drawing.Point(324, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 27);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboProcedimentos
            // 
            this.cboProcedimentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcedimentos.FormattingEnabled = true;
            this.cboProcedimentos.Location = new System.Drawing.Point(95, 17);
            this.cboProcedimentos.Name = "cboProcedimentos";
            this.cboProcedimentos.Size = new System.Drawing.Size(223, 21);
            this.cboProcedimentos.TabIndex = 27;
            // 
            // lblProcedimento
            // 
            this.lblProcedimento.AutoSize = true;
            this.lblProcedimento.Location = new System.Drawing.Point(11, 20);
            this.lblProcedimento.Name = "lblProcedimento";
            this.lblProcedimento.Size = new System.Drawing.Size(77, 13);
            this.lblProcedimento.TabIndex = 26;
            this.lblProcedimento.Text = "Procedimentos";
            // 
            // cboSituacoes
            // 
            this.cboSituacoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacoes.FormattingEnabled = true;
            this.cboSituacoes.Location = new System.Drawing.Point(770, 345);
            this.cboSituacoes.Name = "cboSituacoes";
            this.cboSituacoes.Size = new System.Drawing.Size(238, 21);
            this.cboSituacoes.TabIndex = 33;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(647, 349);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(118, 13);
            this.lblSituacao.TabIndex = 34;
            this.lblSituacao.Text = "Situação Agendamento";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::SenacHair.Properties.Resources.eraser;
            this.btnLimpar.Location = new System.Drawing.Point(773, 374);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(115, 41);
            this.btnLimpar.TabIndex = 31;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Image = global::SenacHair.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(652, 374);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(115, 41);
            this.btnGravar.TabIndex = 30;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SenacHair.Properties.Resources.exit;
            this.btnCancelar.Location = new System.Drawing.Point(896, 374);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 41);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 426);
            this.Controls.Add(this.cboSituacoes);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpProcedimento);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.grpAgendamento);
            this.Controls.Add(this.dtpAgendamento);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cboCabeleireiro);
            this.Controls.Add(this.lblCabeleireiro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgendamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendamentos";
            this.Load += new System.EventHandler(this.frmAgendamento_Load);
            this.grpAgendamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgendamento)).EndInit();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpProcedimento.ResumeLayout(false);
            this.grpProcedimento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAgendamento;
        private System.Windows.Forms.DataGridView grdAgendamento;
        private System.Windows.Forms.DateTimePicker dtpAgendamento;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ComboBox cboCabeleireiro;
        private System.Windows.Forms.Label lblCabeleireiro;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox grpProcedimento;
        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.ListBox lstProcedimentos;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboProcedimentos;
        private System.Windows.Forms.Label lblProcedimento;
        private System.Windows.Forms.ComboBox cboSituacoes;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
    }
}