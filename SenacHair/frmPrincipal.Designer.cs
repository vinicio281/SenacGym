namespace SenacHair
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormasPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDominios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcedimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSituacaoAgendamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroCabeleireiro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCabeleireiros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPagamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrPrincipal = new System.Windows.Forms.Timer(this.components);
            this.lblTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuSair
            // 
            this.mnuSair.Image = global::SenacHair.Properties.Resources.door2_open;
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(62, 28);
            this.mnuSair.Text = "Sai&r";
            this.mnuSair.Click += new System.EventHandler(this.mnuSair_Click);
            // 
            // mnuFormasPagamento
            // 
            this.mnuFormasPagamento.Image = global::SenacHair.Properties.Resources.credit_cards;
            this.mnuFormasPagamento.Name = "mnuFormasPagamento";
            this.mnuFormasPagamento.Size = new System.Drawing.Size(219, 22);
            this.mnuFormasPagamento.Text = "&Formas de Pagamento";
            this.mnuFormasPagamento.Click += new System.EventHandler(this.mnuFormasPagamento_Click);
            // 
            // mnuDominios
            // 
            this.mnuDominios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormasPagamento,
            this.mnuProcedimentos,
            this.mnuSituacaoAgendamento});
            this.mnuDominios.Image = global::SenacHair.Properties.Resources.address_book;
            this.mnuDominios.Name = "mnuDominios";
            this.mnuDominios.Size = new System.Drawing.Size(94, 28);
            this.mnuDominios.Text = "Do&mínios";
            // 
            // mnuProcedimentos
            // 
            this.mnuProcedimentos.Image = global::SenacHair.Properties.Resources.notebook;
            this.mnuProcedimentos.Name = "mnuProcedimentos";
            this.mnuProcedimentos.Size = new System.Drawing.Size(219, 22);
            this.mnuProcedimentos.Text = "&Procedimentos";
            this.mnuProcedimentos.Click += new System.EventHandler(this.mnuProcedimentos_Click);
            // 
            // mnuSituacaoAgendamento
            // 
            this.mnuSituacaoAgendamento.Image = global::SenacHair.Properties.Resources.calendar_1;
            this.mnuSituacaoAgendamento.Name = "mnuSituacaoAgendamento";
            this.mnuSituacaoAgendamento.Size = new System.Drawing.Size(219, 22);
            this.mnuSituacaoAgendamento.Text = "&Situações de Agendamento";
            this.mnuSituacaoAgendamento.Click += new System.EventHandler(this.mnuSituacaoAgendamento_Click);
            // 
            // mnuAgendamentos
            // 
            this.mnuAgendamentos.Image = global::SenacHair.Properties.Resources.calendar_1;
            this.mnuAgendamentos.Name = "mnuAgendamentos";
            this.mnuAgendamentos.Size = new System.Drawing.Size(124, 28);
            this.mnuAgendamentos.Text = "&Agendamentos";
            this.mnuAgendamentos.Click += new System.EventHandler(this.mnuAgendamentos_Click);
            // 
            // mnuCadastroCabeleireiro
            // 
            this.mnuCadastroCabeleireiro.Image = global::SenacHair.Properties.Resources.Dentistas;
            this.mnuCadastroCabeleireiro.Name = "mnuCadastroCabeleireiro";
            this.mnuCadastroCabeleireiro.Size = new System.Drawing.Size(208, 22);
            this.mnuCadastroCabeleireiro.Text = "Cadastro de Cabeleireiros";
            this.mnuCadastroCabeleireiro.Click += new System.EventHandler(this.mnuCadastroCabeleireiro_Click);
            // 
            // mnuCabeleireiros
            // 
            this.mnuCabeleireiros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastroCabeleireiro});
            this.mnuCabeleireiros.Image = global::SenacHair.Properties.Resources.stockbroker2;
            this.mnuCabeleireiros.Name = "mnuCabeleireiros";
            this.mnuCabeleireiros.Size = new System.Drawing.Size(111, 28);
            this.mnuCabeleireiros.Text = "Cabeleireiros";
            // 
            // mnuCadastroClientes
            // 
            this.mnuCadastroClientes.Image = global::SenacHair.Properties.Resources.Pacientes;
            this.mnuCadastroClientes.Name = "mnuCadastroClientes";
            this.mnuCadastroClientes.Size = new System.Drawing.Size(182, 22);
            this.mnuCadastroClientes.Text = "Cadastro de Clientes";
            this.mnuCadastroClientes.Click += new System.EventHandler(this.mnuCadastroClientes_Click);
            // 
            // mnuPacientes
            // 
            this.mnuPacientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastroClientes});
            this.mnuPacientes.Image = global::SenacHair.Properties.Resources.businesspeople;
            this.mnuPacientes.Name = "mnuPacientes";
            this.mnuPacientes.Size = new System.Drawing.Size(85, 28);
            this.mnuPacientes.Text = "Clientes";
            // 
            // mnuCadastroUsuario
            // 
            this.mnuCadastroUsuario.Image = global::SenacHair.Properties.Resources.businessman_add;
            this.mnuCadastroUsuario.Name = "mnuCadastroUsuario";
            this.mnuCadastroUsuario.Size = new System.Drawing.Size(164, 22);
            this.mnuCadastroUsuario.Text = "&Cadastro Usuário";
            this.mnuCadastroUsuario.Click += new System.EventHandler(this.mnuCadastroUsuario_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastroUsuario});
            this.mnuUsuarios.Image = global::SenacHair.Properties.Resources.businessman;
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(88, 28);
            this.mnuUsuarios.Text = "&Usuários";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios,
            this.mnuPacientes,
            this.mnuCabeleireiros,
            this.mnuAgendamentos,
            this.mnuPagamentos,
            this.mnuDominios,
            this.mnuSobre,
            this.mnuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 32);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPagamentos
            // 
            this.mnuPagamentos.Image = global::SenacHair.Properties.Resources.symbol_dollar;
            this.mnuPagamentos.Name = "mnuPagamentos";
            this.mnuPagamentos.Size = new System.Drawing.Size(109, 28);
            this.mnuPagamentos.Text = "Pagamentos";
            this.mnuPagamentos.Click += new System.EventHandler(this.mnuPagamentos_Click);
            // 
            // mnuSobre
            // 
            this.mnuSobre.Image = global::SenacHair.Properties.Resources.about;
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(73, 28);
            this.mnuSobre.Text = "&Sobre";
            this.mnuSobre.Click += new System.EventHandler(this.mnuSobre_Click);
            // 
            // tmrPrincipal
            // 
            this.tmrPrincipal.Enabled = true;
            this.tmrPrincipal.Interval = 1000;
            this.tmrPrincipal.Tick += new System.EventHandler(this.tmrPrincipal_Tick);
            // 
            // lblTempo
            // 
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(261, 17);
            this.lblTempo.Spring = true;
            this.lblTempo.Text = "Tempo: 00:00:00";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConexao
            // 
            this.lblConexao.Name = "lblConexao";
            this.lblConexao.Size = new System.Drawing.Size(261, 17);
            this.lblConexao.Spring = true;
            this.lblConexao.Text = "Servidor: 192.168.10.15 | Banco: Cliente";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(261, 17);
            this.lblUsuario.Spring = true;
            this.lblUsuario.Text = "Usuario: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblConexao,
            this.lblTempo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(148)))), ((int)(((byte)(129)))));
            this.BackgroundImage = global::SenacHair.Properties.Resources.Senac_Hair_Formatado1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 555);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuFormasPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnuDominios;
        private System.Windows.Forms.ToolStripMenuItem mnuAgendamentos;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroCabeleireiro;
        private System.Windows.Forms.ToolStripMenuItem mnuCabeleireiros;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuPacientes;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        private System.Windows.Forms.Timer tmrPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel lblTempo;
        private System.Windows.Forms.ToolStripStatusLabel lblConexao;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuProcedimentos;
        private System.Windows.Forms.ToolStripMenuItem mnuSituacaoAgendamento;
        private System.Windows.Forms.ToolStripMenuItem mnuPagamentos;
    }
}