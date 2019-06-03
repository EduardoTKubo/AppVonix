namespace TesteCRM.Forms
{
    partial class frmRelat2
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblParametro = new System.Windows.Forms.Label();
            this.cboParametro = new System.Windows.Forms.ComboBox();
            this.btXls = new System.Windows.Forms.Button();
            this.dtPicker2 = new System.Windows.Forms.DateTimePicker();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblParametro);
            this.groupBox2.Controls.Add(this.cboParametro);
            this.groupBox2.Controls.Add(this.btXls);
            this.groupBox2.Controls.Add(this.dtPicker2);
            this.groupBox2.Controls.Add(this.dtPicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnListar);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // lblParametro
            // 
            this.lblParametro.AutoSize = true;
            this.lblParametro.Location = new System.Drawing.Point(261, 20);
            this.lblParametro.Name = "lblParametro";
            this.lblParametro.Size = new System.Drawing.Size(54, 13);
            this.lblParametro.TabIndex = 10;
            this.lblParametro.Text = "parametro";
            // 
            // cboParametro
            // 
            this.cboParametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParametro.FormattingEnabled = true;
            this.cboParametro.Location = new System.Drawing.Point(321, 20);
            this.cboParametro.Name = "cboParametro";
            this.cboParametro.Size = new System.Drawing.Size(240, 21);
            this.cboParametro.TabIndex = 9;
            this.cboParametro.SelectedIndexChanged += new System.EventHandler(this.cboParametro_SelectedIndexChanged);
            // 
            // btXls
            // 
            this.btXls.Location = new System.Drawing.Point(644, 18);
            this.btXls.Name = "btXls";
            this.btXls.Size = new System.Drawing.Size(43, 23);
            this.btXls.TabIndex = 8;
            this.btXls.Text = "XLS";
            this.btXls.UseVisualStyleBackColor = true;
            this.btXls.Click += new System.EventHandler(this.btXls_Click);
            // 
            // dtPicker2
            // 
            this.dtPicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker2.Location = new System.Drawing.Point(161, 20);
            this.dtPicker2.Name = "dtPicker2";
            this.dtPicker2.Size = new System.Drawing.Size(87, 20);
            this.dtPicker2.TabIndex = 2;
            this.dtPicker2.ValueChanged += new System.EventHandler(this.dtPicker2_ValueChanged);
            // 
            // dtPicker1
            // 
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker1.Location = new System.Drawing.Point(36, 19);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.Size = new System.Drawing.Size(87, 20);
            this.dtPicker1.TabIndex = 1;
            this.dtPicker1.ValueChanged += new System.EventHandler(this.dtPicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "de                                    até";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(567, 19);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(71, 23);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(706, 316);
            this.dataGridView1.TabIndex = 4;
            // 
            // frmRelat2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(734, 400);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRelat2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtPicker2;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btXls;
        private System.Windows.Forms.ComboBox cboParametro;
        private System.Windows.Forms.Label lblParametro;
    }
}