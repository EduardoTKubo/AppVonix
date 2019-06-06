namespace TesteCRM.Forms
{
    partial class frmReceptivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceptivo));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdRecept = new System.Windows.Forms.Label();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbLigMuda = new System.Windows.Forms.RadioButton();
            this.rbLigErrado = new System.Windows.Forms.RadioButton();
            this.rbAgenda = new System.Windows.Forms.RadioButton();
            this.rbVenda = new System.Windows.Forms.RadioButton();
            this.rbNegativa = new System.Windows.Forms.RadioButton();
            this.label31 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFone1 = new System.Windows.Forms.TextBox();
            this.txtDDD1 = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrigem = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIdAg = new System.Windows.Forms.Label();
            this.txtObsAg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtStatusLigacao = new System.Windows.Forms.TextBox();
            this.txtStatusVonix = new System.Windows.Forms.TextBox();
            this.timerLogando = new System.Windows.Forms.Timer(this.components);
            this.vonix1 = new System.Pabx.Vonix();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslabel1,
            this.tsslabel2,
            this.tsslabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(750, 22);
            this.statusStrip1.TabIndex = 4;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblIdRecept);
            this.groupBox1.Controls.Add(this.btnVendas);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.txtObs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFone1);
            this.groupBox1.Controls.Add(this.txtDDD1);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboOrigem);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblIdRecept
            // 
            this.lblIdRecept.AllowDrop = true;
            this.lblIdRecept.Location = new System.Drawing.Point(267, 82);
            this.lblIdRecept.Name = "lblIdRecept";
            this.lblIdRecept.Size = new System.Drawing.Size(75, 13);
            this.lblIdRecept.TabIndex = 24;
            this.lblIdRecept.Text = "0";
            this.lblIdRecept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVendas
            // 
            this.btnVendas.Location = new System.Drawing.Point(267, 275);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(75, 30);
            this.btnVendas.TabIndex = 24;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(186, 275);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpar.TabIndex = 23;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Silver;
            this.groupBox4.Controls.Add(this.rbLigMuda);
            this.groupBox4.Controls.Add(this.rbLigErrado);
            this.groupBox4.Controls.Add(this.rbAgenda);
            this.groupBox4.Controls.Add(this.rbVenda);
            this.groupBox4.Controls.Add(this.rbNegativa);
            this.groupBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox4.Location = new System.Drawing.Point(6, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(349, 82);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // rbLigMuda
            // 
            this.rbLigMuda.AutoSize = true;
            this.rbLigMuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLigMuda.Location = new System.Drawing.Point(112, 19);
            this.rbLigMuda.Name = "rbLigMuda";
            this.rbLigMuda.Size = new System.Drawing.Size(105, 17);
            this.rbLigMuda.TabIndex = 14;
            this.rbLigMuda.TabStop = true;
            this.rbLigMuda.Text = "Ligação Muda";
            this.rbLigMuda.UseVisualStyleBackColor = true;
            this.rbLigMuda.Click += new System.EventHandler(this.rbLigMuda_Click);
            // 
            // rbLigErrado
            // 
            this.rbLigErrado.AutoSize = true;
            this.rbLigErrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLigErrado.Location = new System.Drawing.Point(112, 48);
            this.rbLigErrado.Name = "rbLigErrado";
            this.rbLigErrado.Size = new System.Drawing.Size(97, 17);
            this.rbLigErrado.TabIndex = 13;
            this.rbLigErrado.TabStop = true;
            this.rbLigErrado.Text = "Ligou Errado";
            this.rbLigErrado.UseVisualStyleBackColor = true;
            this.rbLigErrado.Click += new System.EventHandler(this.rbLigErrado_Click);
            // 
            // rbAgenda
            // 
            this.rbAgenda.AutoSize = true;
            this.rbAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAgenda.Location = new System.Drawing.Point(27, 19);
            this.rbAgenda.Name = "rbAgenda";
            this.rbAgenda.Size = new System.Drawing.Size(68, 17);
            this.rbAgenda.TabIndex = 12;
            this.rbAgenda.TabStop = true;
            this.rbAgenda.Text = "Agenda";
            this.rbAgenda.UseVisualStyleBackColor = true;
            this.rbAgenda.Click += new System.EventHandler(this.rbAgenda_Click);
            // 
            // rbVenda
            // 
            this.rbVenda.AutoSize = true;
            this.rbVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVenda.Location = new System.Drawing.Point(239, 48);
            this.rbVenda.Name = "rbVenda";
            this.rbVenda.Size = new System.Drawing.Size(61, 17);
            this.rbVenda.TabIndex = 11;
            this.rbVenda.TabStop = true;
            this.rbVenda.Text = "Venda";
            this.rbVenda.UseVisualStyleBackColor = true;
            this.rbVenda.Click += new System.EventHandler(this.rbVenda_Click);
            // 
            // rbNegativa
            // 
            this.rbNegativa.AutoSize = true;
            this.rbNegativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNegativa.Location = new System.Drawing.Point(239, 19);
            this.rbNegativa.Name = "rbNegativa";
            this.rbNegativa.Size = new System.Drawing.Size(76, 17);
            this.rbNegativa.TabIndex = 10;
            this.rbNegativa.TabStop = true;
            this.rbNegativa.Text = "Negativa";
            this.rbNegativa.UseVisualStyleBackColor = true;
            this.rbNegativa.Click += new System.EventHandler(this.rbNegativa_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 134);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 13);
            this.label31.TabIndex = 21;
            this.label31.Text = "Obs.";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(73, 131);
            this.txtObs.MaxLength = 1000;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(269, 52);
            this.txtObs.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(73, 105);
            this.txtEmail.MaxLength = 80;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Telefone";
            // 
            // txtFone1
            // 
            this.txtFone1.Location = new System.Drawing.Point(109, 79);
            this.txtFone1.MaxLength = 9;
            this.txtFone1.Name = "txtFone1";
            this.txtFone1.Size = new System.Drawing.Size(91, 20);
            this.txtFone1.TabIndex = 4;
            this.txtFone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFone1_KeyPress);
            // 
            // txtDDD1
            // 
            this.txtDDD1.Location = new System.Drawing.Point(73, 79);
            this.txtDDD1.MaxLength = 2;
            this.txtDDD1.Name = "txtDDD1";
            this.txtDDD1.Size = new System.Drawing.Size(30, 20);
            this.txtDDD1.TabIndex = 3;
            this.txtDDD1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDD1_KeyPress);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 53);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(269, 20);
            this.txtNome.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Origem";
            // 
            // cboOrigem
            // 
            this.cboOrigem.Enabled = false;
            this.cboOrigem.FormattingEnabled = true;
            this.cboOrigem.Location = new System.Drawing.Point(73, 26);
            this.cboOrigem.Name = "cboOrigem";
            this.cboOrigem.Size = new System.Drawing.Size(269, 21);
            this.cboOrigem.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIdAg);
            this.groupBox2.Controls.Add(this.txtObsAg);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(379, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 256);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lblIdAg
            // 
            this.lblIdAg.AllowDrop = true;
            this.lblIdAg.Location = new System.Drawing.Point(9, 172);
            this.lblIdAg.Name = "lblIdAg";
            this.lblIdAg.Size = new System.Drawing.Size(75, 13);
            this.lblIdAg.TabIndex = 25;
            this.lblIdAg.Text = "0";
            this.lblIdAg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObsAg
            // 
            this.txtObsAg.BackColor = System.Drawing.Color.Silver;
            this.txtObsAg.Location = new System.Drawing.Point(86, 173);
            this.txtObsAg.MaxLength = 1000;
            this.txtObsAg.Multiline = true;
            this.txtObsAg.Name = "txtObsAg";
            this.txtObsAg.Size = new System.Drawing.Size(269, 74);
            this.txtObsAg.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Agendamentos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(349, 137);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtStatusLigacao);
            this.groupBox3.Controls.Add(this.txtStatusVonix);
            this.groupBox3.Location = new System.Drawing.Point(379, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 58);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // txtStatusLigacao
            // 
            this.txtStatusLigacao.Enabled = false;
            this.txtStatusLigacao.Location = new System.Drawing.Point(6, 35);
            this.txtStatusLigacao.Name = "txtStatusLigacao";
            this.txtStatusLigacao.Size = new System.Drawing.Size(348, 20);
            this.txtStatusLigacao.TabIndex = 28;
            // 
            // txtStatusVonix
            // 
            this.txtStatusVonix.Enabled = false;
            this.txtStatusVonix.Location = new System.Drawing.Point(6, 9);
            this.txtStatusVonix.Name = "txtStatusVonix";
            this.txtStatusVonix.Size = new System.Drawing.Size(348, 20);
            this.txtStatusVonix.TabIndex = 27;
            // 
            // timerLogando
            // 
            this.timerLogando.Interval = 5000;
            this.timerLogando.Tick += new System.EventHandler(this.timerLogando_Tick);
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
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(206, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReceptivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(750, 347);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReceptivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReceptivo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReceptivo_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslabel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOrigem;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFone1;
        private System.Windows.Forms.TextBox txtDDD1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lblIdRecept;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbLigMuda;
        private System.Windows.Forms.RadioButton rbLigErrado;
        private System.Windows.Forms.RadioButton rbAgenda;
        private System.Windows.Forms.RadioButton rbVenda;
        private System.Windows.Forms.RadioButton rbNegativa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblIdAg;
        private System.Windows.Forms.TextBox txtObsAg;
        private System.Windows.Forms.Timer timerLogando;
        private System.Pabx.Vonix vonix1;
        private System.Windows.Forms.TextBox txtStatusLigacao;
        private System.Windows.Forms.TextBox txtStatusVonix;
        private System.Windows.Forms.Button button1;
    }
}