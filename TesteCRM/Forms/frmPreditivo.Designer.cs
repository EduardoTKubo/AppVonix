namespace TesteCRM.Forms
{
    partial class frmPreditivo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInforme = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblFone1 = new System.Windows.Forms.Label();
            this.lblDDD1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rbLN = new System.Windows.Forms.RadioButton();
            this.rbLT = new System.Windows.Forms.RadioButton();
            this.rbLD = new System.Windows.Forms.RadioButton();
            this.rbAG = new System.Windows.Forms.RadioButton();
            this.rbEC1 = new System.Windows.Forms.RadioButton();
            this.rbCP = new System.Windows.Forms.RadioButton();
            this.rbMudo = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtStatusVonix = new System.Windows.Forms.TextBox();
            this.txtStatusLigacao = new System.Windows.Forms.TextBox();
            this.btnLocaliza = new System.Windows.Forms.Button();
            this.btnEstorno = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.txtDDD = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbVenda = new System.Windows.Forms.RadioButton();
            this.rbNegativa = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgAg = new System.Windows.Forms.DataGridView();
            this.timerLogando = new System.Windows.Forms.Timer(this.components);
            this.vonix1 = new System.Pabx.Vonix();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAg)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInforme);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.lblCPF);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.lblFone1);
            this.groupBox1.Controls.Add(this.lblDDD1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 231);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtInforme
            // 
            this.txtInforme.AllowDrop = true;
            this.txtInforme.Location = new System.Drawing.Point(82, 119);
            this.txtInforme.MaxLength = 255;
            this.txtInforme.Multiline = true;
            this.txtInforme.Name = "txtInforme";
            this.txtInforme.Size = new System.Drawing.Size(271, 97);
            this.txtInforme.TabIndex = 18;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(18, 204);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(13, 13);
            this.lblCodigo.TabIndex = 17;
            this.lblCodigo.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "FONE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "INFORM.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "EMAIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "DOC.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOME";
            // 
            // lblEmail
            // 
            this.lblEmail.AllowDrop = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(82, 92);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(271, 15);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCPF
            // 
            this.lblCPF.AllowDrop = true;
            this.lblCPF.BackColor = System.Drawing.Color.White;
            this.lblCPF.Location = new System.Drawing.Point(82, 68);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(271, 15);
            this.lblCPF.TabIndex = 10;
            this.lblCPF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            this.lblNome.AllowDrop = true;
            this.lblNome.BackColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(82, 44);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(271, 15);
            this.lblNome.TabIndex = 9;
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFone1
            // 
            this.lblFone1.AllowDrop = true;
            this.lblFone1.BackColor = System.Drawing.Color.White;
            this.lblFone1.Location = new System.Drawing.Point(107, 16);
            this.lblFone1.Name = "lblFone1";
            this.lblFone1.Size = new System.Drawing.Size(69, 15);
            this.lblFone1.TabIndex = 2;
            this.lblFone1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDDD1
            // 
            this.lblDDD1.AllowDrop = true;
            this.lblDDD1.BackColor = System.Drawing.Color.White;
            this.lblDDD1.Location = new System.Drawing.Point(82, 16);
            this.lblDDD1.Name = "lblDDD1";
            this.lblDDD1.Size = new System.Drawing.Size(23, 15);
            this.lblDDD1.TabIndex = 1;
            this.lblDDD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbLN
            // 
            this.rbLN.AutoSize = true;
            this.rbLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLN.Location = new System.Drawing.Point(180, 45);
            this.rbLN.Name = "rbLN";
            this.rbLN.Size = new System.Drawing.Size(41, 17);
            this.rbLN.TabIndex = 9;
            this.rbLN.TabStop = true;
            this.rbLN.Text = "LN";
            this.toolTip1.SetToolTip(this.rbLN, "Ligar a noite");
            this.rbLN.UseVisualStyleBackColor = true;
            this.rbLN.Click += new System.EventHandler(this.rbLN_Click);
            // 
            // rbLT
            // 
            this.rbLT.AutoSize = true;
            this.rbLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLT.Location = new System.Drawing.Point(108, 45);
            this.rbLT.Name = "rbLT";
            this.rbLT.Size = new System.Drawing.Size(40, 17);
            this.rbLT.TabIndex = 8;
            this.rbLT.TabStop = true;
            this.rbLT.Text = "LT";
            this.toolTip1.SetToolTip(this.rbLT, "Ligar a tarde");
            this.rbLT.UseVisualStyleBackColor = true;
            this.rbLT.Click += new System.EventHandler(this.rbLT_Click);
            // 
            // rbLD
            // 
            this.rbLD.AutoSize = true;
            this.rbLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLD.Location = new System.Drawing.Point(35, 45);
            this.rbLD.Name = "rbLD";
            this.rbLD.Size = new System.Drawing.Size(41, 17);
            this.rbLD.TabIndex = 7;
            this.rbLD.TabStop = true;
            this.rbLD.Text = "LD";
            this.toolTip1.SetToolTip(this.rbLD, "Ligar de manhã");
            this.rbLD.UseVisualStyleBackColor = true;
            this.rbLD.Click += new System.EventHandler(this.rbLD_Click);
            // 
            // rbAG
            // 
            this.rbAG.AutoSize = true;
            this.rbAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAG.Location = new System.Drawing.Point(34, 19);
            this.rbAG.Name = "rbAG";
            this.rbAG.Size = new System.Drawing.Size(42, 17);
            this.rbAG.TabIndex = 3;
            this.rbAG.TabStop = true;
            this.rbAG.Text = "AG";
            this.toolTip1.SetToolTip(this.rbAG, "Agendamento");
            this.rbAG.UseVisualStyleBackColor = true;
            this.rbAG.Click += new System.EventHandler(this.rbAG_Click);
            // 
            // rbEC1
            // 
            this.rbEC1.AutoSize = true;
            this.rbEC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEC1.Location = new System.Drawing.Point(180, 19);
            this.rbEC1.Name = "rbEC1";
            this.rbEC1.Size = new System.Drawing.Size(48, 17);
            this.rbEC1.TabIndex = 5;
            this.rbEC1.TabStop = true;
            this.rbEC1.Text = "EC1";
            this.toolTip1.SetToolTip(this.rbEC1, "Erro de Cadastro");
            this.rbEC1.UseVisualStyleBackColor = true;
            this.rbEC1.Click += new System.EventHandler(this.rbEC1_Click);
            // 
            // rbCP
            // 
            this.rbCP.AutoSize = true;
            this.rbCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCP.Location = new System.Drawing.Point(108, 19);
            this.rbCP.Name = "rbCP";
            this.rbCP.Size = new System.Drawing.Size(41, 17);
            this.rbCP.TabIndex = 4;
            this.rbCP.TabStop = true;
            this.rbCP.Tag = "";
            this.rbCP.Text = "CP";
            this.toolTip1.SetToolTip(this.rbCP, "Caixa Postal");
            this.rbCP.UseVisualStyleBackColor = true;
            this.rbCP.Click += new System.EventHandler(this.rbCP_Click);
            // 
            // rbMudo
            // 
            this.rbMudo.AutoSize = true;
            this.rbMudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMudo.Location = new System.Drawing.Point(252, 19);
            this.rbMudo.Name = "rbMudo";
            this.rbMudo.Size = new System.Drawing.Size(42, 17);
            this.rbMudo.TabIndex = 6;
            this.rbMudo.TabStop = true;
            this.rbMudo.Text = "LM";
            this.toolTip1.SetToolTip(this.rbMudo, "Ligação Muda");
            this.rbMudo.UseVisualStyleBackColor = true;
            this.rbMudo.Click += new System.EventHandler(this.rbMudo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslabel1,
            this.tsslabel2,
            this.tsslabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(763, 22);
            this.statusStrip1.TabIndex = 3;
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
            this.tsslabel2.Size = new System.Drawing.Size(530, 17);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtStatusVonix);
            this.groupBox3.Controls.Add(this.txtStatusLigacao);
            this.groupBox3.Controls.Add(this.btnLocaliza);
            this.groupBox3.Controls.Add(this.btnEstorno);
            this.groupBox3.Controls.Add(this.btnVendas);
            this.groupBox3.Controls.Add(this.btnAgenda);
            this.groupBox3.Controls.Add(this.lblOrigem);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtFone);
            this.groupBox3.Controls.Add(this.txtDDD);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox3.Location = new System.Drawing.Point(389, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 252);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            // 
            // txtStatusVonix
            // 
            this.txtStatusVonix.Enabled = false;
            this.txtStatusVonix.Location = new System.Drawing.Point(18, 204);
            this.txtStatusVonix.Name = "txtStatusVonix";
            this.txtStatusVonix.Size = new System.Drawing.Size(331, 20);
            this.txtStatusVonix.TabIndex = 30;
            // 
            // txtStatusLigacao
            // 
            this.txtStatusLigacao.Enabled = false;
            this.txtStatusLigacao.Location = new System.Drawing.Point(18, 226);
            this.txtStatusLigacao.Name = "txtStatusLigacao";
            this.txtStatusLigacao.Size = new System.Drawing.Size(331, 20);
            this.txtStatusLigacao.TabIndex = 30;
            // 
            // btnLocaliza
            // 
            this.btnLocaliza.Location = new System.Drawing.Point(253, 19);
            this.btnLocaliza.Name = "btnLocaliza";
            this.btnLocaliza.Size = new System.Drawing.Size(98, 23);
            this.btnLocaliza.TabIndex = 2;
            this.btnLocaliza.Text = "Localizar Fone";
            this.btnLocaliza.UseVisualStyleBackColor = true;
            this.btnLocaliza.Click += new System.EventHandler(this.btnLocaliza_Click);
            // 
            // btnEstorno
            // 
            this.btnEstorno.Location = new System.Drawing.Point(191, 175);
            this.btnEstorno.Name = "btnEstorno";
            this.btnEstorno.Size = new System.Drawing.Size(62, 23);
            this.btnEstorno.TabIndex = 24;
            this.btnEstorno.Text = "Estorno";
            this.btnEstorno.UseVisualStyleBackColor = true;
            // 
            // btnVendas
            // 
            this.btnVendas.Location = new System.Drawing.Point(288, 175);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(62, 23);
            this.btnVendas.TabIndex = 23;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.Location = new System.Drawing.Point(87, 175);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(62, 23);
            this.btnAgenda.TabIndex = 22;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Location = new System.Drawing.Point(17, 185);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(13, 13);
            this.lblOrigem.TabIndex = 19;
            this.lblOrigem.Text = "0";
            this.lblOrigem.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "FONE ......";
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(126, 21);
            this.txtFone.MaxLength = 9;
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(99, 20);
            this.txtFone.TabIndex = 1;
            // 
            // txtDDD
            // 
            this.txtDDD.Location = new System.Drawing.Point(86, 21);
            this.txtDDD.MaxLength = 2;
            this.txtDDD.Name = "txtDDD";
            this.txtDDD.Size = new System.Drawing.Size(34, 20);
            this.txtDDD.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbMudo);
            this.groupBox5.Controls.Add(this.rbEC1);
            this.groupBox5.Controls.Add(this.rbCP);
            this.groupBox5.Controls.Add(this.rbLN);
            this.groupBox5.Controls.Add(this.rbLT);
            this.groupBox5.Controls.Add(this.rbLD);
            this.groupBox5.Controls.Add(this.rbAG);
            this.groupBox5.Location = new System.Drawing.Point(18, 49);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(331, 76);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbVenda);
            this.groupBox6.Controls.Add(this.rbNegativa);
            this.groupBox6.Location = new System.Drawing.Point(18, 117);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(331, 52);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            // 
            // rbVenda
            // 
            this.rbVenda.AutoSize = true;
            this.rbVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVenda.Location = new System.Drawing.Point(182, 19);
            this.rbVenda.Name = "rbVenda";
            this.rbVenda.Size = new System.Drawing.Size(67, 17);
            this.rbVenda.TabIndex = 11;
            this.rbVenda.TabStop = true;
            this.rbVenda.Text = "VENDA";
            this.rbVenda.UseVisualStyleBackColor = true;
            this.rbVenda.Click += new System.EventHandler(this.rbVenda_Click);
            // 
            // rbNegativa
            // 
            this.rbNegativa.AutoSize = true;
            this.rbNegativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNegativa.Location = new System.Drawing.Point(37, 19);
            this.rbNegativa.Name = "rbNegativa";
            this.rbNegativa.Size = new System.Drawing.Size(87, 17);
            this.rbNegativa.TabIndex = 10;
            this.rbNegativa.TabStop = true;
            this.rbNegativa.Text = "NEGATIVA";
            this.rbNegativa.UseVisualStyleBackColor = true;
            this.rbNegativa.Click += new System.EventHandler(this.rbNegativa_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtAgenda);
            this.groupBox8.Location = new System.Drawing.Point(389, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(366, 100);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " Obs. quando Agendamento";
            // 
            // txtAgenda
            // 
            this.txtAgenda.Enabled = false;
            this.txtAgenda.Location = new System.Drawing.Point(18, 19);
            this.txtAgenda.MaxLength = 255;
            this.txtAgenda.Multiline = true;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(331, 70);
            this.txtAgenda.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgAg);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 115);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seus Agendamentos";
            // 
            // dtgAg
            // 
            this.dtgAg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAg.Location = new System.Drawing.Point(13, 19);
            this.dtgAg.Name = "dtgAg";
            this.dtgAg.Size = new System.Drawing.Size(340, 87);
            this.dtgAg.TabIndex = 0;
            this.dtgAg.DoubleClick += new System.EventHandler(this.dtgAg_DoubleClick);
            // 
            // timerLogando
            // 
            this.timerLogando.Interval = 5000;
            this.timerLogando.Tick += new System.EventHandler(this.timerLogando_Tick_1);
            // 
            // vonix1
            // 
            this.vonix1.onConnectVx += new System.Pabx.Vonix.cbConnect(this.vonix1_onConnect);
            this.vonix1.onDialVx += new System.Pabx.Vonix.cbDial(this.vonix1_onDial);
            this.vonix1.onDialFailureVx += new System.Pabx.Vonix.cbDialFailure(this.vonix1_onDialFailure);
            this.vonix1.onDialAnswerVx += new System.Pabx.Vonix.cbDialAnswer(this.vonix1_onDialAnswer);
            this.vonix1.onHangUpVx += new System.Pabx.Vonix.cbHangUp(this.vonix1_onHangUp);
            this.vonix1.onReceiveVx += new System.Pabx.Vonix.cbReceive(this.vonix1_onReceive);
            this.vonix1.onReceiveAnswerVx += new System.Pabx.Vonix.cbReceiveAnswer(this.vonix1_onReceiveAnswer);
            this.vonix1.onReceiveFailureVx += new System.Pabx.Vonix.cbReceiveFailure(this.vonix1_onReceiveFailure);
            this.vonix1.onLoginVx += new System.Pabx.Vonix.cbLogin(this.vonix1_onLogin);
            this.vonix1.onLogoffVx += new System.Pabx.Vonix.cbLogoff(this.vonix1_onLogoff);
            this.vonix1.onPauseVx += new System.Pabx.Vonix.cbPause(this.vonix1_onPause);
            this.vonix1.onUnpauseVx += new System.Pabx.Vonix.cbUnpause(this.vonix1_onUnpause);
            this.vonix1.onStatusVx += new System.Pabx.Vonix.cbStatus(this.vonix1_onStatus);
            // 
            // frmPreditivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(763, 383);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPreditivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPreditivo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPreditivo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPreditivo_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInforme;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFone1;
        private System.Windows.Forms.Label lblDDD1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEstorno;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.TextBox txtDDD;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbLN;
        private System.Windows.Forms.RadioButton rbLT;
        private System.Windows.Forms.RadioButton rbLD;
        private System.Windows.Forms.RadioButton rbAG;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbVenda;
        private System.Windows.Forms.RadioButton rbNegativa;
        private System.Windows.Forms.Button btnLocaliza;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.RadioButton rbMudo;
        private System.Windows.Forms.RadioButton rbEC1;
        private System.Windows.Forms.RadioButton rbCP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgAg;
        private System.Windows.Forms.Timer timerLogando;
        private System.Pabx.Vonix vonix1;
        private System.Windows.Forms.TextBox txtStatusVonix;
        private System.Windows.Forms.TextBox txtStatusLigacao;
    }
}