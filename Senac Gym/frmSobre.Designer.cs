namespace Senac_Gym
{
    partial class frmSobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSobre));
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.pctCliente = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pctCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.Location = new System.Drawing.Point(12, 117);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(277, 82);
            this.lblTexto.TabIndex = 38;
            this.lblTexto.Text = resources.GetString("lblTexto.Text");
            // 
            // lblSistema
            // 
            this.lblSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSistema.Location = new System.Drawing.Point(12, 12);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(222, 93);
            this.lblSistema.TabIndex = 37;
            this.lblSistema.Text = "Senac Gym\r\nSistema de Gerenciamento de Academias\r\nVersão 3.14.15\r\n\r\n© 2025 Silico" +
    "n Solutions\r\nDistribuído sob a licença GPLv3.";
            // 
            // pctCliente
            // 
            this.pctCliente.Image = global::Senac_Gym.Properties.Resources.Captura_de_tela_2025_01_23_192832;
            this.pctCliente.Location = new System.Drawing.Point(295, 18);
            this.pctCliente.Name = "pctCliente";
            this.pctCliente.Size = new System.Drawing.Size(201, 198);
            this.pctCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCliente.TabIndex = 35;
            this.pctCliente.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 210);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(111, 13);
            this.linkLabel1.TabIndex = 39;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Repositório no GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 238);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.pctCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSobre";
            this.Text = "Senac Gym - Sobre";
            ((System.ComponentModel.ISupportInitialize)(this.pctCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.PictureBox pctCliente;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}