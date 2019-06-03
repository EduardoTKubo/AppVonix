namespace TesteCRM.Forms
{
    partial class frmVisuCarga
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
            this.listOrigem = new System.Windows.Forms.ListBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.dtPicker2 = new System.Windows.Forms.DateTimePicker();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrigem = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listOrigem);
            this.groupBox1.Controls.Add(this.btnListar);
            this.groupBox1.Controls.Add(this.dtPicker2);
            this.groupBox1.Controls.Add(this.dtPicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboOrigem);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // listOrigem
            // 
            this.listOrigem.FormattingEnabled = true;
            this.listOrigem.Location = new System.Drawing.Point(128, 18);
            this.listOrigem.Name = "listOrigem";
            this.listOrigem.Size = new System.Drawing.Size(120, 30);
            this.listOrigem.TabIndex = 7;
            this.listOrigem.Visible = false;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(534, 19);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 6;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dtPicker2
            // 
            this.dtPicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker2.Location = new System.Drawing.Point(437, 18);
            this.dtPicker2.Name = "dtPicker2";
            this.dtPicker2.Size = new System.Drawing.Size(81, 20);
            this.dtPicker2.TabIndex = 4;
            this.dtPicker2.ValueChanged += new System.EventHandler(this.dtPicker2_ValueChanged);
            // 
            // dtPicker1
            // 
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker1.Location = new System.Drawing.Point(321, 18);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.Size = new System.Drawing.Size(81, 20);
            this.dtPicker1.TabIndex = 3;
            this.dtPicker1.ValueChanged += new System.EventHandler(this.dtPicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "de                                 até";
            // 
            // cboOrigem
            // 
            this.cboOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigem.FormattingEnabled = true;
            this.cboOrigem.Location = new System.Drawing.Point(18, 19);
            this.cboOrigem.Name = "cboOrigem";
            this.cboOrigem.Size = new System.Drawing.Size(271, 21);
            this.cboOrigem.TabIndex = 1;
            this.cboOrigem.Click += new System.EventHandler(this.cboOrigem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(13, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(624, 285);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 352);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0";
            // 
            // frmVisuCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(647, 372);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVisuCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisuCarga";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboOrigem;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DateTimePicker dtPicker2;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListBox listOrigem;
    }
}