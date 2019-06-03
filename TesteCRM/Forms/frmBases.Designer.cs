namespace TesteCRM.Forms
{
    partial class frmBases
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOrigem = new System.Windows.Forms.ComboBox();
            this.listBoxOrigem = new System.Windows.Forms.ListBox();
            this.dtgOrigem = new System.Windows.Forms.DataGridView();
            this.clmMailing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLivre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRepasse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPower = new System.Windows.Forms.Button();
            this.chkPower = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPreditiva = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOper = new System.Windows.Forms.TabPage();
            this.dtgOper = new System.Windows.Forms.DataGridView();
            this.chkCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPageUsu = new System.Windows.Forms.TabPage();
            this.dtgUsu = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrigem)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOper)).BeginInit();
            this.tabPageUsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOrigem);
            this.groupBox1.Controls.Add(this.listBoxOrigem);
            this.groupBox1.Controls.Add(this.dtgOrigem);
            this.groupBox1.Controls.Add(this.btnPower);
            this.groupBox1.Controls.Add(this.chkPower);
            this.groupBox1.Location = new System.Drawing.Point(659, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 237);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual / Power";
            // 
            // cboOrigem
            // 
            this.cboOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigem.FormattingEnabled = true;
            this.cboOrigem.Location = new System.Drawing.Point(18, 33);
            this.cboOrigem.Name = "cboOrigem";
            this.cboOrigem.Size = new System.Drawing.Size(426, 21);
            this.cboOrigem.TabIndex = 0;
            this.cboOrigem.SelectedIndexChanged += new System.EventHandler(this.cboOrigem_SelectedIndexChanged);
            // 
            // listBoxOrigem
            // 
            this.listBoxOrigem.FormattingEnabled = true;
            this.listBoxOrigem.Location = new System.Drawing.Point(203, 24);
            this.listBoxOrigem.Name = "listBoxOrigem";
            this.listBoxOrigem.Size = new System.Drawing.Size(120, 30);
            this.listBoxOrigem.TabIndex = 16;
            this.listBoxOrigem.Visible = false;
            // 
            // dtgOrigem
            // 
            this.dtgOrigem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOrigem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMailing,
            this.clmTotal,
            this.clmLivre,
            this.clmRepasse});
            this.dtgOrigem.Location = new System.Drawing.Point(18, 60);
            this.dtgOrigem.Name = "dtgOrigem";
            this.dtgOrigem.RowHeadersVisible = false;
            this.dtgOrigem.Size = new System.Drawing.Size(428, 99);
            this.dtgOrigem.TabIndex = 3;
            // 
            // clmMailing
            // 
            this.clmMailing.HeaderText = "Mailing";
            this.clmMailing.Name = "clmMailing";
            this.clmMailing.Width = 200;
            // 
            // clmTotal
            // 
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.Width = 60;
            // 
            // clmLivre
            // 
            this.clmLivre.HeaderText = "Livre";
            this.clmLivre.Name = "clmLivre";
            this.clmLivre.Width = 60;
            // 
            // clmRepasse
            // 
            this.clmRepasse.HeaderText = "Repasse";
            this.clmRepasse.Name = "clmRepasse";
            this.clmRepasse.Width = 60;
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(163, 192);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(135, 30);
            this.btnPower.TabIndex = 2;
            this.btnPower.Text = "Manual / Power";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // chkPower
            // 
            this.chkPower.AutoSize = true;
            this.chkPower.Location = new System.Drawing.Point(203, 169);
            this.chkPower.Name = "chkPower";
            this.chkPower.Size = new System.Drawing.Size(56, 17);
            this.chkPower.TabIndex = 1;
            this.chkPower.Text = "Power";
            this.chkPower.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPreditiva);
            this.groupBox2.Location = new System.Drawing.Point(659, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preditivo ";
            // 
            // btnPreditiva
            // 
            this.btnPreditiva.Location = new System.Drawing.Point(163, 31);
            this.btnPreditiva.Name = "btnPreditiva";
            this.btnPreditiva.Size = new System.Drawing.Size(135, 34);
            this.btnPreditiva.TabIndex = 3;
            this.btnPreditiva.Text = "Preditiva";
            this.btnPreditiva.UseVisualStyleBackColor = true;
            this.btnPreditiva.Click += new System.EventHandler(this.btnPreditiva_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOper);
            this.tabControl1.Controls.Add(this.tabPageUsu);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 394);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageOper
            // 
            this.tabPageOper.Controls.Add(this.dtgOper);
            this.tabPageOper.Location = new System.Drawing.Point(4, 22);
            this.tabPageOper.Name = "tabPageOper";
            this.tabPageOper.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOper.Size = new System.Drawing.Size(627, 368);
            this.tabPageOper.TabIndex = 0;
            this.tabPageOper.Text = "Operadores";
            this.tabPageOper.UseVisualStyleBackColor = true;
            // 
            // dtgOper
            // 
            this.dtgOper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOper.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkCol});
            this.dtgOper.Location = new System.Drawing.Point(6, 6);
            this.dtgOper.Name = "dtgOper";
            this.dtgOper.RowHeadersVisible = false;
            this.dtgOper.Size = new System.Drawing.Size(615, 356);
            this.dtgOper.TabIndex = 1;
            // 
            // chkCol
            // 
            this.chkCol.HeaderText = "";
            this.chkCol.Name = "chkCol";
            this.chkCol.Width = 30;
            // 
            // tabPageUsu
            // 
            this.tabPageUsu.Controls.Add(this.dtgUsu);
            this.tabPageUsu.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsu.Name = "tabPageUsu";
            this.tabPageUsu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsu.Size = new System.Drawing.Size(627, 368);
            this.tabPageUsu.TabIndex = 1;
            this.tabPageUsu.Text = "Outros Usuários";
            this.tabPageUsu.UseVisualStyleBackColor = true;
            // 
            // dtgUsu
            // 
            this.dtgUsu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.dtgUsu.Location = new System.Drawing.Point(5, 6);
            this.dtgUsu.Name = "dtgUsu";
            this.dtgUsu.RowHeadersVisible = false;
            this.dtgUsu.Size = new System.Drawing.Size(616, 356);
            this.dtgUsu.TabIndex = 2;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // frmBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1129, 414);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribuição de Base";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrigem)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOper)).EndInit();
            this.tabPageUsu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboOrigem;
        private System.Windows.Forms.DataGridView dtgOrigem;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.CheckBox chkPower;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreditiva;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOper;
        private System.Windows.Forms.TabPage tabPageUsu;
        private System.Windows.Forms.DataGridView dtgUsu;
        private System.Windows.Forms.ListBox listBoxOrigem;
        private System.Windows.Forms.DataGridView dtgOper;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMailing;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLivre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRepasse;
    }
}