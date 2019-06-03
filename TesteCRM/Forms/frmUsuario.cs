using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Forms
{
    public partial class frmUsuario : Form
    {
        private string strAcao = "";
        clsUsuario Usuario = new clsUsuario();

        public frmUsuario()
        {
            InitializeComponent();
            //LimpaCampos();
            //this.Icon = TesteCRM.Properties.Resources.punisher2;

            cboEquipe.Items.Clear();
            listBoxEquipe.Items.Clear();

            foreach (DataRow item in Classes.clsBanco.Consulta("select descricao ,descricao2 from tab_geral where titulo = 'equipe' and ativo = 1 order by descricao").Rows)
            {
                cboEquipe.Items.Add(item[0].ToString());
                listBoxEquipe.Items.Add(item[1].ToString());
            }

            cboStatus.Items.Clear();
            listBoxStatus.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select descricao ,descricao2 from tab_geral where titulo = 'rank' and ativo = 1 order by descricao").Rows)
            {
                cboStatus.Items.Add(item[0].ToString());
                listBoxStatus.Items.Add(item[1].ToString());
            }

            ListarUsuarios();
            strAcao = "INCLUSAO";
            TrataBotoes(strAcao);
        }


        private void CarregarDadosDaTela()
        {
            ///clsUsuario.usu_cod = Convert.ToInt32(dt.Rows[0][0].ToString());
            Usuario.Usu_cod = lblCod.Text.ToString();
            Usuario.Usu_cpf = txtCPF.Text.ToString();
            Usuario.Usu_nome = txtNome.Text.ToString();

            Usuario.Usu_status = cboStatus.Text.ToString();
            listBoxStatus.SelectedIndex = cboStatus.FindStringExact(cboStatus.Text, listBoxStatus.SelectedIndex);
            Usuario.Usu_rank = listBoxStatus.Text.ToString();

            Usuario.Usu_equipe = cboEquipe.Text.ToString();
            listBoxEquipe.SelectedIndex = cboEquipe.FindStringExact(cboEquipe.Text, listBoxEquipe.SelectedIndex);
            Usuario.Usu_fila = listBoxEquipe.Text.ToString();

            Usuario.Usu_matricula = txtMatricula.Text.ToString();
            Usuario.Usu_senha = txtSenha.Text.ToString();
            Usuario.Usu_pwd2 = checkBox1.Checked.ToString();
        }

        private void ListarUsuarios()
        {
            try
            {
                clsVariaveis.GstrSQL = "[cod] AS 'ID' , [turno] AS 'EQUIPE', [nomecompleto] AS 'NOME', [cpf] AS 'CPF', [matricula] AS 'MATR'";
                dgvOperadores.DataSource = clsFuncoes.CarregarListaUsuarios(clsVariaveis.GstrSQL, "USUARIO", Classes.GetSet.clsUsuarioLogado.Usu_rank, " TURNO,NOMECOMPLETO")[0];

                foreach (DataGridViewColumn column in dgvOperadores.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Visible = false;
                    else
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        // largura automatica da coluna
                        //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }


                clsVariaveis.GstrSQL = "[cod] AS 'ID' , [status] AS 'STATUS', [nomecompleto] AS 'NOME' ";
                dgvUsuarios.DataSource = clsFuncoes.CarregarListaUsuarios(clsVariaveis.GstrSQL, "USUARIO", Classes.GetSet.clsUsuarioLogado.Usu_rank, " STATUS,NOMECOMPLETO")[1];

                foreach (DataGridViewColumn column in dgvUsuarios.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Visible = false;
                    else
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        // largura automatica da coluna
                        //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Listar Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Limpar()
        {
            lblCod.Text = "0";
            txtCPF.PasswordChar = '\0';
            txtCPF.Enabled = true;

            clsFuncoes.LimpaCampos(this, tabPageCadastro);
            clsFuncoes.LimpaCampos(this, grbAcesso);
        }


        private void Preenche_Tela(string tipo, string idcod)
        {
            try
            {
                Limpar();
                txtCPF.PasswordChar = Convert.ToChar("*");

                clsVariaveis.GstrSQL = string.Empty;
                if (tipo == "CPF")
                {
                    clsVariaveis.GstrSQL = ("select * from Usuario where Ativo = 1 and cpf = '@cpf' ").Replace("@cpf", idcod);
                }
                else if (tipo == "COD")
                {
                    clsVariaveis.GstrSQL = ("select * from Usuario where Ativo = 1 and cod = @idcod ").Replace("@idcod", idcod);
                }
                DataTable dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtUsu.Rows.Count > 0)
                {
                    lblCod.Text = dtUsu.Rows[0]["cod"].ToString();
                    txtCPF.Text = dtUsu.Rows[0]["cpf"].ToString();
                    txtNome.Text = dtUsu.Rows[0]["nomecompleto"].ToString();

                    cboStatus.Text = dtUsu.Rows[0]["status"].ToString();
                    listBoxStatus.SelectedIndex = cboStatus.FindStringExact(cboStatus.Text, listBoxStatus.SelectedIndex);
                    cboStatus.SelectedIndex = listBoxStatus.SelectedIndex;

                    cboEquipe.Text = dtUsu.Rows[0]["turno"].ToString();
                    listBoxEquipe.SelectedIndex = cboEquipe.FindStringExact(cboEquipe.Text, listBoxEquipe.SelectedIndex);
                    cboEquipe.SelectedIndex = listBoxEquipe.SelectedIndex;

                    txtMatricula.Text = dtUsu.Rows[0]["matricula"].ToString();
                    txtSenha.Text = dtUsu.Rows[0]["senha"].ToString();
                    if (Convert.ToBoolean(dtUsu.Rows[0]["pwd2"].ToString()) == true)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }


                    // preenchendo Acesso
                    foreach (DataRow Acesso in clsBanco.Consulta("SELECT ACESSO FROM USUARIO_ACESSO_MENU WHERE COD = " + lblCod.Text + "").Rows)
                    {
                        foreach (Control c in this.grbAcesso.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox chk = c as CheckBox;
                                if (chk.Name == Acesso["ACESSO"].ToString())
                                {
                                    chk.Checked = true;
                                }
                            }
                        }
                    }
                    TrataBotoes("ALTERACAO");
                }
                else
                {
                    TrataBotoes("INCLUSAO");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SomenteLetrasMaiusculas(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }


        private void TrataBotoes(string acao)
        {
            tabControl1.SelectedIndex = 0;
            switch (acao)
            {
                case "INCLUSAO":
                    btnIncluir.Enabled = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    break;
                case "ALTERACAO":
                    btnIncluir.Enabled = false;
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txtCPF.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string resp = clsFuncoes.ValidarDoc(this, txtCPF);
            if (resp != "")
            {
                MessageBox.Show("CPF inválido!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCPF.Focus();
            }
            else
            {
                Preenche_Tela("CPF", txtCPF.Text);
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja incluir ?", "Inclusão de Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CarregarDadosDaTela();

                    try
                    {
                        // incluindo em Usuario
                        DataTable dt = clsBanco.ExecuteQueryRetorno(clsInsert.ComandoInsertUsuario(Usuario));

                        // INCLUINDO EM USUARIO_ACESSO_MENU
                        clsVariaveis.GstrSQL = "select top 1 cod from usuario where cpf = '" + txtCPF.Text + "' where ativo = 1 order by cod desc";
                        DataTable dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                        if (dtUsu.Rows.Count > 0)
                        {
                            lblCod.Text = dtUsu.Rows[0]["cod"].ToString();
                            
                            foreach (Control c in this.grbAcesso.Controls)
                            {
                                if (c is CheckBox)
                                {
                                    CheckBox chk = c as CheckBox;
                                    if (chk.Checked == true)
                                    {
                                        clsVariaveis.GstrSQL = ("INSERT INTO USUARIO_ACESSO_MENU ( COD,ACESSO ) VALUES ( @idcod ,'@acesso' )").Replace("@idcod", lblCod.Text).Replace("@acesso", chk.Name.ToString());
                                        bool booIncl = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Incluído com sucesso", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        TrataBotoes("INCLUSAO");
                        ListarUsuarios();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja alterar ?", "Alteração / Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CarregarDadosDaTela();

                    try
                    {
                        // alteracao em Usuario
                        DataTable dt = clsBanco.ExecuteQueryRetorno(clsUpdate.ComandoUpdateUsuario(Usuario));


                        // alteracao em Usuario_Acesso_Menu
                        clsVariaveis.GstrSQL = ("DELETE FROM USUARIO_ACESSO_MENU WHERE COD = @idcod").Replace("@idcod", lblCod.Text);
                        bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                        if (booDel)
                        {
                            // INCLUINDO EM USUARIO_ACESSO_MENU
                            foreach (Control c in this.grbAcesso.Controls)
                            {
                                if (c is CheckBox)
                                {
                                    CheckBox chk = c as CheckBox;
                                    if (chk.Checked == true)
                                    {
                                        clsVariaveis.GstrSQL = ("INSERT INTO USUARIO_ACESSO_MENU ( COD,ACESSO ) VALUES ( @idcod ,'@acesso' )").Replace("@idcod", lblCod.Text).Replace("@acesso", chk.Name.ToString());
                                        bool booIncl = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                                    }
                                }
                            }

                            MessageBox.Show("Alterado com sucesso", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            TrataBotoes("INCLUSAO");
                            ListarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpar();
            TrataBotoes("INCLUSAO");
        }

        private void dgvOperadores_DoubleClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvOperadores[0, dgvOperadores.CurrentRow.Index].Value);
            Preenche_Tela("COD", ID.ToString());
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvUsuarios[0, dgvUsuarios.CurrentRow.Index].Value);
            Preenche_Tela("COD", ID.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lblCod.Text != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o usuário ?", "Excluir / Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    clsVariaveis.GstrSQL = ("UPDATE USUARIO SET ATIVO = 0 WHERE COD = @idcod").Replace("@idcod", lblCod.Text);
                    bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                    if (booDel)
                    {
                        MessageBox.Show("Excluído com sucesso", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        TrataBotoes("INCLUSAO");
                        ListarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btXls_Click(object sender, EventArgs e)
        {
            //pgStatus.Style = ProgressBarStyle.Marquee;
            btXls.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            clsFuncoes.ExportarXLS(dgvUsuarios);
            btXls.Enabled = true;
            this.Cursor = Cursors.Default;
            //pgStatus.Style = ProgressBarStyle.Blocks;
        }
    }
}
