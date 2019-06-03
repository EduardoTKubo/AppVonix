namespace TesteCRM.Forms
{
    partial class frmUsuario
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCadastro = new System.Windows.Forms.TabPage();
            this.grbAcesso = new System.Windows.Forms.GroupBox();
            this.mnuVisuCarga = new System.Windows.Forms.CheckBox();
            this.mnuReceptivo = new System.Windows.Forms.CheckBox();
            this.mnuVisualizaVda = new System.Windows.Forms.CheckBox();
            this.mnuEstorno = new System.Windows.Forms.CheckBox();
            this.mnuStandby = new System.Windows.Forms.CheckBox();
            this.mnuBOffice2 = new System.Windows.Forms.CheckBox();
            this.mnuAtivo = new System.Windows.Forms.CheckBox();
            this.mnuBases = new System.Windows.Forms.CheckBox();
            this.mnuManutencao = new System.Windows.Forms.CheckBox();
            this.mnuCadUsuario = new System.Windows.Forms.CheckBox();
            this.mnuSistema = new System.Windows.Forms.CheckBox();
            this.mnuRelatorios = new System.Windows.Forms.CheckBox();
            this.mnuBOffice = new System.Windows.Forms.CheckBox();
            this.mnuOperacao = new System.Windows.Forms.CheckBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.listBoxEquipe = new System.Windows.Forms.ListBox();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.cboEquipe = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.tabPageLista = new System.Windows.Forms.TabPage();
            this.dgvOperadores = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btXls = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageCadastro.SuspendLayout();
            this.grbAcesso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCadastro);
            this.tabControl1.Controls.Add(this.tabPageLista);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 391);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageCadastro
            // 
            this.tabPageCadastro.BackColor = System.Drawing.Color.Silver;
            this.tabPageCadastro.Controls.Add(this.grbAcesso);
            this.tabPageCadastro.Controls.Add(this.lblCod);
            this.tabPageCadastro.Controls.Add(this.listBoxEquipe);
            this.tabPageCadastro.Controls.Add(this.listBoxStatus);
            this.tabPageCadastro.Controls.Add(this.groupBox1);
            this.tabPageCadastro.Controls.Add(this.label6);
            this.tabPageCadastro.Controls.Add(this.label5);
            this.tabPageCadastro.Controls.Add(this.label4);
            this.tabPageCadastro.Controls.Add(this.label3);
            this.tabPageCadastro.Controls.Add(this.label2);
            this.tabPageCadastro.Controls.Add(this.label1);
            this.tabPageCadastro.Controls.Add(this.checkBox1);
            this.tabPageCadastro.Controls.Add(this.txtSenha);
            this.tabPageCadastro.Controls.Add(this.cboStatus);
            this.tabPageCadastro.Controls.Add(this.txtMatricula);
            this.tabPageCadastro.Controls.Add(this.cboEquipe);
            this.tabPageCadastro.Controls.Add(this.txtNome);
            this.tabPageCadastro.Controls.Add(this.txtCPF);
            this.tabPageCadastro.Location = new System.Drawing.Point(4, 22);
            this.tabPageCadastro.Name = "tabPageCadastro";
            this.tabPageCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCadastro.Size = new System.Drawing.Size(768, 365);
            this.tabPageCadastro.TabIndex = 0;
            this.tabPageCadastro.Text = "Cadastro";
            // 
            // grbAcesso
            // 
            this.grbAcesso.Controls.Add(this.mnuVisuCarga);
            this.grbAcesso.Controls.Add(this.mnuReceptivo);
            this.grbAcesso.Controls.Add(this.mnuVisualizaVda);
            this.grbAcesso.Controls.Add(this.mnuEstorno);
            this.grbAcesso.Controls.Add(this.mnuStandby);
            this.grbAcesso.Controls.Add(this.mnuBOffice2);
            this.grbAcesso.Controls.Add(this.mnuAtivo);
            this.grbAcesso.Controls.Add(this.mnuBases);
            this.grbAcesso.Controls.Add(this.mnuManutencao);
            this.grbAcesso.Controls.Add(this.mnuCadUsuario);
            this.grbAcesso.Controls.Add(this.mnuSistema);
            this.grbAcesso.Controls.Add(this.mnuRelatorios);
            this.grbAcesso.Controls.Add(this.mnuBOffice);
            this.grbAcesso.Controls.Add(this.mnuOperacao);
            this.grbAcesso.Location = new System.Drawing.Point(390, 6);
            this.grbAcesso.Name = "grbAcesso";
            this.grbAcesso.Size = new System.Drawing.Size(358, 341);
            this.grbAcesso.TabIndex = 18;
            this.grbAcesso.TabStop = false;
            // 
            // mnuVisuCarga
            // 
            this.mnuVisuCarga.Location = new System.Drawing.Point(52, 223);
            this.mnuVisuCarga.Name = "mnuVisuCarga";
            this.mnuVisuCarga.Size = new System.Drawing.Size(145, 22);
            this.mnuVisuCarga.TabIndex = 34;
            this.mnuVisuCarga.Text = "Visualiza Carga";
            this.mnuVisuCarga.UseVisualStyleBackColor = true;
            // 
            // mnuReceptivo
            // 
            this.mnuReceptivo.Location = new System.Drawing.Point(52, 56);
            this.mnuReceptivo.Name = "mnuReceptivo";
            this.mnuReceptivo.Size = new System.Drawing.Size(145, 22);
            this.mnuReceptivo.TabIndex = 33;
            this.mnuReceptivo.Text = "Receptivo";
            this.mnuReceptivo.UseVisualStyleBackColor = true;
            // 
            // mnuVisualizaVda
            // 
            this.mnuVisualizaVda.Location = new System.Drawing.Point(52, 158);
            this.mnuVisualizaVda.Name = "mnuVisualizaVda";
            this.mnuVisualizaVda.Size = new System.Drawing.Size(145, 22);
            this.mnuVisualizaVda.TabIndex = 32;
            this.mnuVisualizaVda.Text = "Visualiza Venda";
            this.mnuVisualizaVda.UseVisualStyleBackColor = true;
            // 
            // mnuEstorno
            // 
            this.mnuEstorno.Location = new System.Drawing.Point(52, 122);
            this.mnuEstorno.Name = "mnuEstorno";
            this.mnuEstorno.Size = new System.Drawing.Size(145, 22);
            this.mnuEstorno.TabIndex = 31;
            this.mnuEstorno.Text = "Estorno";
            this.mnuEstorno.UseVisualStyleBackColor = true;
            // 
            // mnuStandby
            // 
            this.mnuStandby.Location = new System.Drawing.Point(52, 140);
            this.mnuStandby.Name = "mnuStandby";
            this.mnuStandby.Size = new System.Drawing.Size(145, 22);
            this.mnuStandby.TabIndex = 30;
            this.mnuStandby.Text = "Stand_by";
            this.mnuStandby.UseVisualStyleBackColor = true;
            // 
            // mnuBOffice2
            // 
            this.mnuBOffice2.Location = new System.Drawing.Point(52, 104);
            this.mnuBOffice2.Name = "mnuBOffice2";
            this.mnuBOffice2.Size = new System.Drawing.Size(145, 22);
            this.mnuBOffice2.TabIndex = 29;
            this.mnuBOffice2.Text = "Back Office";
            this.mnuBOffice2.UseVisualStyleBackColor = true;
            // 
            // mnuAtivo
            // 
            this.mnuAtivo.Location = new System.Drawing.Point(52, 38);
            this.mnuAtivo.Name = "mnuAtivo";
            this.mnuAtivo.Size = new System.Drawing.Size(145, 22);
            this.mnuAtivo.TabIndex = 28;
            this.mnuAtivo.Text = "Ativo";
            this.mnuAtivo.UseVisualStyleBackColor = true;
            // 
            // mnuBases
            // 
            this.mnuBases.Location = new System.Drawing.Point(52, 205);
            this.mnuBases.Name = "mnuBases";
            this.mnuBases.Size = new System.Drawing.Size(145, 22);
            this.mnuBases.TabIndex = 27;
            this.mnuBases.Text = "Distrib. Bases";
            this.mnuBases.UseVisualStyleBackColor = true;
            // 
            // mnuManutencao
            // 
            this.mnuManutencao.BackColor = System.Drawing.Color.Gray;
            this.mnuManutencao.Location = new System.Drawing.Point(27, 186);
            this.mnuManutencao.Name = "mnuManutencao";
            this.mnuManutencao.Size = new System.Drawing.Size(170, 17);
            this.mnuManutencao.TabIndex = 26;
            this.mnuManutencao.Text = "Manutenção";
            this.mnuManutencao.UseVisualStyleBackColor = false;
            // 
            // mnuCadUsuario
            // 
            this.mnuCadUsuario.Location = new System.Drawing.Point(52, 309);
            this.mnuCadUsuario.Name = "mnuCadUsuario";
            this.mnuCadUsuario.Size = new System.Drawing.Size(145, 22);
            this.mnuCadUsuario.TabIndex = 25;
            this.mnuCadUsuario.Text = "Cadastro de Usuários";
            this.mnuCadUsuario.UseVisualStyleBackColor = true;
            // 
            // mnuSistema
            // 
            this.mnuSistema.BackColor = System.Drawing.Color.Gray;
            this.mnuSistema.Location = new System.Drawing.Point(27, 292);
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(170, 17);
            this.mnuSistema.TabIndex = 24;
            this.mnuSistema.Text = "Sistema";
            this.mnuSistema.UseVisualStyleBackColor = false;
            // 
            // mnuRelatorios
            // 
            this.mnuRelatorios.BackColor = System.Drawing.Color.Gray;
            this.mnuRelatorios.Location = new System.Drawing.Point(27, 254);
            this.mnuRelatorios.Name = "mnuRelatorios";
            this.mnuRelatorios.Size = new System.Drawing.Size(170, 17);
            this.mnuRelatorios.TabIndex = 23;
            this.mnuRelatorios.Text = "Relatório";
            this.mnuRelatorios.UseVisualStyleBackColor = false;
            // 
            // mnuBOffice
            // 
            this.mnuBOffice.BackColor = System.Drawing.Color.Gray;
            this.mnuBOffice.Location = new System.Drawing.Point(27, 84);
            this.mnuBOffice.Name = "mnuBOffice";
            this.mnuBOffice.Size = new System.Drawing.Size(170, 17);
            this.mnuBOffice.TabIndex = 22;
            this.mnuBOffice.Text = "Back Office";
            this.mnuBOffice.UseVisualStyleBackColor = false;
            // 
            // mnuOperacao
            // 
            this.mnuOperacao.BackColor = System.Drawing.Color.Gray;
            this.mnuOperacao.Location = new System.Drawing.Point(27, 19);
            this.mnuOperacao.Name = "mnuOperacao";
            this.mnuOperacao.Size = new System.Drawing.Size(170, 17);
            this.mnuOperacao.TabIndex = 21;
            this.mnuOperacao.Text = "Operação";
            this.mnuOperacao.UseVisualStyleBackColor = false;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(347, 18);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(13, 13);
            this.lblCod.TabIndex = 17;
            this.lblCod.Text = "0";
            // 
            // listBoxEquipe
            // 
            this.listBoxEquipe.FormattingEnabled = true;
            this.listBoxEquipe.Location = new System.Drawing.Point(246, 97);
            this.listBoxEquipe.Name = "listBoxEquipe";
            this.listBoxEquipe.Size = new System.Drawing.Size(120, 30);
            this.listBoxEquipe.TabIndex = 16;
            this.listBoxEquipe.Visible = false;
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.Location = new System.Drawing.Point(246, 70);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(120, 30);
            this.listBoxStatus.TabIndex = 15;
            this.listBoxStatus.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.btnAlterar);
            this.groupBox1.Controls.Add(this.btnIncluir);
            this.groupBox1.Location = new System.Drawing.Point(15, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 51);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Limpar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(178, 11);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(81, 34);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(92, 11);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(81, 34);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(6, 11);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(81, 34);
            this.btnIncluir.TabIndex = 3;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Senha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Matrícula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Equipe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CPF";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(84, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(194, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Solicitar esta senha ao acessar app";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(84, 150);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(282, 20);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteLetrasMaiusculas);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(84, 70);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(282, 21);
            this.cboStatus.TabIndex = 2;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(84, 124);
            this.txtMatricula.MaxLength = 5;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(108, 20);
            this.txtMatricula.TabIndex = 4;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // cboEquipe
            // 
            this.cboEquipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipe.FormattingEnabled = true;
            this.cboEquipe.Location = new System.Drawing.Point(84, 97);
            this.cboEquipe.Name = "cboEquipe";
            this.cboEquipe.Size = new System.Drawing.Size(282, 21);
            this.cboEquipe.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(84, 44);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(282, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteLetrasMaiusculas);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(84, 18);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(131, 20);
            this.txtCPF.TabIndex = 0;
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // tabPageLista
            // 
            this.tabPageLista.BackColor = System.Drawing.Color.Silver;
            this.tabPageLista.Controls.Add(this.dgvOperadores);
            this.tabPageLista.Location = new System.Drawing.Point(4, 22);
            this.tabPageLista.Name = "tabPageLista";
            this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLista.Size = new System.Drawing.Size(768, 365);
            this.tabPageLista.TabIndex = 1;
            this.tabPageLista.Text = "Operadores";
            // 
            // dgvOperadores
            // 
            this.dgvOperadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOperadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperadores.Location = new System.Drawing.Point(51, 20);
            this.dgvOperadores.Name = "dgvOperadores";
            this.dgvOperadores.Size = new System.Drawing.Size(680, 324);
            this.dgvOperadores.TabIndex = 0;
            this.dgvOperadores.DoubleClick += new System.EventHandler(this.dgvOperadores_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.btXls);
            this.tabPage1.Controls.Add(this.dgvUsuarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 365);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Usuarios";
            // 
            // btXls
            // 
            this.btXls.Location = new System.Drawing.Point(6, 321);
            this.btXls.Name = "btXls";
            this.btXls.Size = new System.Drawing.Size(43, 23);
            this.btXls.TabIndex = 7;
            this.btXls.Text = "XLS";
            this.btXls.UseVisualStyleBackColor = true;
            this.btXls.Click += new System.EventHandler(this.btXls_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvUsuarios.Location = new System.Drawing.Point(51, 20);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(683, 324);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.DoubleClick += new System.EventHandler(this.dgvUsuarios_DoubleClick);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 413);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuarios";
            this.tabControl1.ResumeLayout(false);
            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
            this.grbAcesso.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCadastro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.ComboBox cboEquipe;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.DataGridView dgvOperadores;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.ListBox listBoxEquipe;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grbAcesso;
        private System.Windows.Forms.CheckBox mnuOperacao;
        private System.Windows.Forms.CheckBox mnuBOffice;
        private System.Windows.Forms.CheckBox mnuCadUsuario;
        private System.Windows.Forms.CheckBox mnuSistema;
        private System.Windows.Forms.CheckBox mnuRelatorios;
        private System.Windows.Forms.CheckBox mnuBases;
        private System.Windows.Forms.CheckBox mnuManutencao;
        private System.Windows.Forms.Button btXls;
        private System.Windows.Forms.CheckBox mnuAtivo;
        private System.Windows.Forms.CheckBox mnuBOffice2;
        private System.Windows.Forms.CheckBox mnuStandby;
        private System.Windows.Forms.CheckBox mnuEstorno;
        private System.Windows.Forms.CheckBox mnuVisualizaVda;
        private System.Windows.Forms.CheckBox mnuReceptivo;
        private System.Windows.Forms.CheckBox mnuVisuCarga;
    }
}