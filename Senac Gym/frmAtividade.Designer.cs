namespace Senac_Gym
{
    partial class frmAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtividade));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRepeticao = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblTreino = new System.Windows.Forms.Label();
            this.txtRepeticao = new System.Windows.Forms.TextBox();
            this.cboTreino = new System.Windows.Forms.ComboBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.grdAtividade = new System.Windows.Forms.DataGridView();
            this.lblExercicio = new System.Windows.Forms.Label();
            this.cboExercicio = new System.Windows.Forms.ComboBox();
            this.lblMusculo = new System.Windows.Forms.Label();
            this.cboMusculo = new System.Windows.Forms.ComboBox();
            this.grpLista = new System.Windows.Forms.GroupBox();
            this.grdAluno = new System.Windows.Forms.DataGridView();
            this.grpPesquisa = new System.Windows.Forms.GroupBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpAluno = new System.Windows.Forms.GroupBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtividade)).BeginInit();
            this.grpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAluno)).BeginInit();
            this.grpPesquisa.SuspendLayout();
            this.grpAluno.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSerie);
            this.groupBox1.Controls.Add(this.lblRepeticao);
            this.groupBox1.Controls.Add(this.lblObservacao);
            this.groupBox1.Controls.Add(this.lblTreino);
            this.groupBox1.Controls.Add(this.txtRepeticao);
            this.groupBox1.Controls.Add(this.cboTreino);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.grdAtividade);
            this.groupBox1.Controls.Add(this.lblExercicio);
            this.groupBox1.Controls.Add(this.cboExercicio);
            this.groupBox1.Controls.Add(this.lblMusculo);
            this.groupBox1.Controls.Add(this.cboMusculo);
            this.groupBox1.Location = new System.Drawing.Point(6, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 331);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Atividades";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(557, 24);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(36, 13);
            this.lblSerie.TabIndex = 9;
            this.lblSerie.Text = "Séries";
            // 
            // lblRepeticao
            // 
            this.lblRepeticao.AutoSize = true;
            this.lblRepeticao.Location = new System.Drawing.Point(633, 24);
            this.lblRepeticao.Name = "lblRepeticao";
            this.lblRepeticao.Size = new System.Drawing.Size(61, 13);
            this.lblRepeticao.TabIndex = 8;
            this.lblRepeticao.Text = "Repetições";
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(9, 70);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(60, 13);
            this.lblObservacao.TabIndex = 7;
            this.lblObservacao.Text = "Comentário";
            // 
            // lblTreino
            // 
            this.lblTreino.AutoSize = true;
            this.lblTreino.Location = new System.Drawing.Point(9, 21);
            this.lblTreino.Name = "lblTreino";
            this.lblTreino.Size = new System.Drawing.Size(37, 13);
            this.lblTreino.TabIndex = 6;
            this.lblTreino.Text = "Treino";
            // 
            // txtRepeticao
            // 
            this.txtRepeticao.Location = new System.Drawing.Point(636, 41);
            this.txtRepeticao.Name = "txtRepeticao";
            this.txtRepeticao.Size = new System.Drawing.Size(51, 20);
            this.txtRepeticao.TabIndex = 5;
            this.txtRepeticao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepeticao_KeyPress);
            // 
            // cboTreino
            // 
            this.cboTreino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTreino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTreino.FormattingEnabled = true;
            this.cboTreino.Items.AddRange(new object[] {
            "Treino A",
            "Treino B",
            "Treino C",
            "Treino D",
            "Treino E",
            "Treino F",
            "Treino G"});
            this.cboTreino.Location = new System.Drawing.Point(9, 39);
            this.cboTreino.Name = "cboTreino";
            this.cboTreino.Size = new System.Drawing.Size(71, 21);
            this.cboTreino.TabIndex = 6;
            this.cboTreino.SelectedIndexChanged += new System.EventHandler(this.cboTreino_SelectedIndexChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(556, 43);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(51, 20);
            this.txtSerie.TabIndex = 4;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 87);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(686, 20);
            this.txtObservacao.TabIndex = 1;
            // 
            // grdAtividade
            // 
            this.grdAtividade.AllowUserToAddRows = false;
            this.grdAtividade.AllowUserToDeleteRows = false;
            this.grdAtividade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAtividade.Location = new System.Drawing.Point(6, 121);
            this.grdAtividade.MultiSelect = false;
            this.grdAtividade.Name = "grdAtividade";
            this.grdAtividade.ReadOnly = true;
            this.grdAtividade.RowHeadersVisible = false;
            this.grdAtividade.RowHeadersWidth = 62;
            this.grdAtividade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdAtividade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAtividade.Size = new System.Drawing.Size(692, 203);
            this.grdAtividade.TabIndex = 1;
            this.grdAtividade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAtividade_CellClick);
            this.grdAtividade.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grdAtividade_ColumnWidthChanged);
            // 
            // lblExercicio
            // 
            this.lblExercicio.AutoSize = true;
            this.lblExercicio.Location = new System.Drawing.Point(336, 25);
            this.lblExercicio.Name = "lblExercicio";
            this.lblExercicio.Size = new System.Drawing.Size(50, 13);
            this.lblExercicio.TabIndex = 3;
            this.lblExercicio.Text = "Exercicio";
            // 
            // cboExercicio
            // 
            this.cboExercicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboExercicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboExercicio.FormattingEnabled = true;
            this.cboExercicio.Location = new System.Drawing.Point(339, 41);
            this.cboExercicio.Name = "cboExercicio";
            this.cboExercicio.Size = new System.Drawing.Size(190, 21);
            this.cboExercicio.TabIndex = 2;
            // 
            // lblMusculo
            // 
            this.lblMusculo.AutoSize = true;
            this.lblMusculo.Location = new System.Drawing.Point(109, 26);
            this.lblMusculo.Name = "lblMusculo";
            this.lblMusculo.Size = new System.Drawing.Size(47, 13);
            this.lblMusculo.TabIndex = 1;
            this.lblMusculo.Text = "Musculo";
            // 
            // cboMusculo
            // 
            this.cboMusculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMusculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMusculo.FormattingEnabled = true;
            this.cboMusculo.Location = new System.Drawing.Point(112, 41);
            this.cboMusculo.Name = "cboMusculo";
            this.cboMusculo.Size = new System.Drawing.Size(190, 21);
            this.cboMusculo.TabIndex = 0;
            // 
            // grpLista
            // 
            this.grpLista.Controls.Add(this.grdAluno);
            this.grpLista.Location = new System.Drawing.Point(9, 68);
            this.grpLista.Name = "grpLista";
            this.grpLista.Size = new System.Drawing.Size(708, 106);
            this.grpLista.TabIndex = 37;
            this.grpLista.TabStop = false;
            this.grpLista.Text = "Alunos Cadastrados";
            // 
            // grdAluno
            // 
            this.grdAluno.AllowUserToAddRows = false;
            this.grdAluno.AllowUserToDeleteRows = false;
            this.grdAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAluno.Location = new System.Drawing.Point(6, 19);
            this.grdAluno.MultiSelect = false;
            this.grdAluno.Name = "grdAluno";
            this.grdAluno.ReadOnly = true;
            this.grdAluno.RowHeadersVisible = false;
            this.grdAluno.RowHeadersWidth = 62;
            this.grdAluno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdAluno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAluno.Size = new System.Drawing.Size(689, 77);
            this.grdAluno.TabIndex = 0;
            this.grdAluno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAluno_CellClick);
            // 
            // grpPesquisa
            // 
            this.grpPesquisa.Controls.Add(this.txtPesquisa);
            this.grpPesquisa.Location = new System.Drawing.Point(9, 9);
            this.grpPesquisa.Name = "grpPesquisa";
            this.grpPesquisa.Size = new System.Drawing.Size(334, 53);
            this.grpPesquisa.TabIndex = 36;
            this.grpPesquisa.TabStop = false;
            this.grpPesquisa.Text = "Pesquisa";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(9, 22);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(319, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // btnGravar
            // 
            this.btnGravar.Image = global::Senac_Gym.Properties.Resources.FloppyDisks;
            this.btnGravar.Location = new System.Drawing.Point(345, 519);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(115, 41);
            this.btnGravar.TabIndex = 40;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Senac_Gym.Properties.Resources.exit;
            this.btnCancelar.Location = new System.Drawing.Point(589, 519);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 41);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpAluno
            // 
            this.grpAluno.Controls.Add(this.lblNome);
            this.grpAluno.Controls.Add(this.txtNome);
            this.grpAluno.Location = new System.Drawing.Point(360, 9);
            this.grpAluno.Name = "grpAluno";
            this.grpAluno.Size = new System.Drawing.Size(357, 53);
            this.grpAluno.TabIndex = 39;
            this.grpAluno.TabStop = false;
            this.grpAluno.Text = "Aluno Selecionado";
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
            this.txtNome.Size = new System.Drawing.Size(289, 20);
            this.txtNome.TabIndex = 0;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::Senac_Gym.Properties.Resources.eraser;
            this.btnLimpar.Location = new System.Drawing.Point(466, 519);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(115, 41);
            this.btnLimpar.TabIndex = 41;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Senac_Gym.Properties.Resources.Minus_16;
            this.btnExcluir.Location = new System.Drawing.Point(214, 519);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(125, 41);
            this.btnExcluir.TabIndex = 43;
            this.btnExcluir.Text = "Exluir Atividade";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Senac_Gym.Properties.Resources.check;
            this.btnImprimir.Location = new System.Drawing.Point(83, 519);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(125, 41);
            this.btnImprimir.TabIndex = 44;
            this.btnImprimir.Text = "Imprimir Treino";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 572);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpLista);
            this.Controls.Add(this.grpPesquisa);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpAluno);
            this.Controls.Add(this.btnLimpar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAtividade";
            this.Text = "Senac Gym -Treinos";
            this.Load += new System.EventHandler(this.frmAtividade_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtividade)).EndInit();
            this.grpLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAluno)).EndInit();
            this.grpPesquisa.ResumeLayout(false);
            this.grpPesquisa.PerformLayout();
            this.grpAluno.ResumeLayout(false);
            this.grpAluno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExercicio;
        private System.Windows.Forms.ComboBox cboExercicio;
        private System.Windows.Forms.Label lblMusculo;
        private System.Windows.Forms.ComboBox cboMusculo;
        private System.Windows.Forms.GroupBox grpLista;
        private System.Windows.Forms.DataGridView grdAluno;
        private System.Windows.Forms.GroupBox grpPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpAluno;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cboTreino;
        private System.Windows.Forms.TextBox txtRepeticao;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.DataGridView grdAtividade;
        private System.Windows.Forms.Label lblTreino;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRepeticao;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnImprimir;
    }
}