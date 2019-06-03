namespace TesteCRM
{
    partial class frmMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuOperacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReceptivo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBOffice2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstorno = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStandby = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisualizaVda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManutencao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBases = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisuCarga = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOperacao,
            this.toolStripMenuItem1,
            this.mnuBOffice,
            this.toolStripMenuItem2,
            this.mnuManutencao,
            this.toolStripMenuItem3,
            this.mnuRelatorios,
            this.toolStripMenuItem4,
            this.mnuSistema,
            this.toolStripMenuItem5,
            this.mnuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Pos Venda";
            // 
            // mnuOperacao
            // 
            this.mnuOperacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAtivo,
            this.mnuReceptivo});
            this.mnuOperacao.Enabled = false;
            this.mnuOperacao.Name = "mnuOperacao";
            this.mnuOperacao.Size = new System.Drawing.Size(70, 20);
            this.mnuOperacao.Text = "Operação";
            // 
            // mnuAtivo
            // 
            this.mnuAtivo.Enabled = false;
            this.mnuAtivo.Name = "mnuAtivo";
            this.mnuAtivo.Size = new System.Drawing.Size(126, 22);
            this.mnuAtivo.Text = "Ativo";
            this.mnuAtivo.Click += new System.EventHandler(this.mnuAtivo_Click);
            // 
            // mnuReceptivo
            // 
            this.mnuReceptivo.Enabled = false;
            this.mnuReceptivo.Name = "mnuReceptivo";
            this.mnuReceptivo.Size = new System.Drawing.Size(126, 22);
            this.mnuReceptivo.Text = "Receptivo";
            this.mnuReceptivo.Click += new System.EventHandler(this.mnuReceptivo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(10, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // mnuBOffice
            // 
            this.mnuBOffice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBOffice2,
            this.mnuEstorno,
            this.mnuStandby,
            this.mnuVisualizaVda});
            this.mnuBOffice.Enabled = false;
            this.mnuBOffice.Name = "mnuBOffice";
            this.mnuBOffice.Size = new System.Drawing.Size(79, 20);
            this.mnuBOffice.Text = "Back Office";
            // 
            // mnuBOffice2
            // 
            this.mnuBOffice2.Enabled = false;
            this.mnuBOffice2.Name = "mnuBOffice2";
            this.mnuBOffice2.Size = new System.Drawing.Size(155, 22);
            this.mnuBOffice2.Text = "Back Office";
            this.mnuBOffice2.Click += new System.EventHandler(this.mnuBOffice2_Click);
            // 
            // mnuEstorno
            // 
            this.mnuEstorno.Enabled = false;
            this.mnuEstorno.Name = "mnuEstorno";
            this.mnuEstorno.Size = new System.Drawing.Size(155, 22);
            this.mnuEstorno.Text = "Estorno";
            this.mnuEstorno.Click += new System.EventHandler(this.mnuEstorno_Click);
            // 
            // mnuStandby
            // 
            this.mnuStandby.Enabled = false;
            this.mnuStandby.Name = "mnuStandby";
            this.mnuStandby.Size = new System.Drawing.Size(155, 22);
            this.mnuStandby.Text = "Stand-by";
            this.mnuStandby.Click += new System.EventHandler(this.mnuStandby_Click);
            // 
            // mnuVisualizaVda
            // 
            this.mnuVisualizaVda.Enabled = false;
            this.mnuVisualizaVda.Name = "mnuVisualizaVda";
            this.mnuVisualizaVda.Size = new System.Drawing.Size(155, 22);
            this.mnuVisualizaVda.Text = "Visualiza Venda";
            this.mnuVisualizaVda.Click += new System.EventHandler(this.mnuVisualizaVda_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AutoSize = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(10, 20);
            this.toolStripMenuItem2.Text = "|";
            // 
            // mnuManutencao
            // 
            this.mnuManutencao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBases,
            this.mnuVisuCarga});
            this.mnuManutencao.Enabled = false;
            this.mnuManutencao.Name = "mnuManutencao";
            this.mnuManutencao.Size = new System.Drawing.Size(86, 20);
            this.mnuManutencao.Text = "Manutenção";
            // 
            // mnuBases
            // 
            this.mnuBases.Enabled = false;
            this.mnuBases.Name = "mnuBases";
            this.mnuBases.Size = new System.Drawing.Size(153, 22);
            this.mnuBases.Text = "Distrib. Bases";
            this.mnuBases.Click += new System.EventHandler(this.mnuBases_Click);
            // 
            // mnuVisuCarga
            // 
            this.mnuVisuCarga.Enabled = false;
            this.mnuVisuCarga.Name = "mnuVisuCarga";
            this.mnuVisuCarga.Size = new System.Drawing.Size(153, 22);
            this.mnuVisuCarga.Text = "Visualiza Carga";
            this.mnuVisuCarga.Click += new System.EventHandler(this.mnuVisuCarga_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AutoSize = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(10, 20);
            this.toolStripMenuItem3.Text = "|";
            // 
            // mnuRelatorios
            // 
            this.mnuRelatorios.Enabled = false;
            this.mnuRelatorios.Name = "mnuRelatorios";
            this.mnuRelatorios.Size = new System.Drawing.Size(71, 20);
            this.mnuRelatorios.Text = "Relatórios";
            this.mnuRelatorios.Click += new System.EventHandler(this.mnuRelatorios_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.AutoSize = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(10, 20);
            this.toolStripMenuItem4.Text = "|";
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadUsuario});
            this.mnuSistema.Enabled = false;
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(60, 20);
            this.mnuSistema.Text = "Sistema";
            // 
            // mnuCadUsuario
            // 
            this.mnuCadUsuario.Enabled = false;
            this.mnuCadUsuario.Name = "mnuCadUsuario";
            this.mnuCadUsuario.Size = new System.Drawing.Size(143, 22);
            this.mnuCadUsuario.Text = "Cad Usuários";
            this.mnuCadUsuario.Click += new System.EventHandler(this.mnuCadUsuario_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.AutoSize = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(10, 20);
            this.toolStripMenuItem5.Text = "|";
            // 
            // mnuSair
            // 
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(38, 20);
            this.mnuSair.Text = "&Sair";
            this.mnuSair.Click += new System.EventHandler(this.mnuSair_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslabel1,
            this.tsslabel2,
            this.tsslabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslabel1
            // 
            this.tsslabel1.AutoSize = false;
            this.tsslabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslabel1.Name = "tsslabel1";
            this.tsslabel1.Size = new System.Drawing.Size(100, 17);
            this.tsslabel1.Text = "1";
            // 
            // tsslabel2
            // 
            this.tsslabel2.AutoSize = false;
            this.tsslabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslabel2.Name = "tsslabel2";
            this.tsslabel2.Size = new System.Drawing.Size(320, 17);
            this.tsslabel2.Text = "2";
            // 
            // tsslabel3
            // 
            this.tsslabel3.AutoSize = false;
            this.tsslabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslabel3.Name = "tsslabel3";
            this.tsslabel3.Size = new System.Drawing.Size(100, 17);
            this.tsslabel3.Text = "3";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(536, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuOperacao;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem mnuCadUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuBOffice;
        private System.Windows.Forms.ToolStripMenuItem mnuManutencao;
        private System.Windows.Forms.ToolStripMenuItem mnuBases;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel3;
        private System.Windows.Forms.ToolStripMenuItem mnuAtivo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuBOffice2;
        private System.Windows.Forms.ToolStripMenuItem mnuStandby;
        private System.Windows.Forms.ToolStripMenuItem mnuEstorno;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualizaVda;
        private System.Windows.Forms.ToolStripMenuItem mnuReceptivo;
        private System.Windows.Forms.ToolStripMenuItem mnuVisuCarga;
    }
}