using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;


namespace TesteCRM.Forms
{
    public partial class frmBases : Form
    {
        public frmBases()
        {
            InitializeComponent();

            tabControl1.SelectedIndex = 0;

            ListarUsuarios();

            cboOrigem.Items.Clear();
            listBoxOrigem.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Origem ,tp_origem from Tab_Origem where status = 1 and preditiva = 0 order by id").Rows)
            {
                cboOrigem.Items.Add(item[0].ToString());
                listBoxOrigem.Items.Add(item[1].ToString());
            }

        }


        private static bool AlterarBases(DataGridView _dgv, string _disc, string _origem, string _tpori)
        {
            try
            {
                int qtlin = Convert.ToInt32(_dgv.RowCount.ToString());
                string[] arrCodOper = new string[qtlin];
                int iopers = 0;

                foreach (DataGridViewRow dgv in _dgv.Rows)                        // percorrendo datagridview
                {
                    if (dgv.Cells[0].Value != null)
                    {
                        if (dgv.Cells[0].Value.ToString() == "True")              // se estiver ticado
                        {
                            iopers = iopers + 1;
                            arrCodOper[iopers] = dgv.Cells[1].Value.ToString();   // guarda id no array arrCodOper
                        }
                    }
                }

                if (iopers == 0)
                {
                    MessageBox.Show("Nenhum Usuario foi selecionado", "Alteração de discagem / Mailing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        //string msg = string.Empty;
                        for (int i = 0; i < qtlin; i++)                       // percorrendo o array arrCodOper
                        {
                            if (arrCodOper[i] != null)
                            {
                                //msg += arrCodOper[i].ToString() + " - ";
                                if (_disc == "PREDITIVA")
                                {
                                    clsVariaveis.GstrSQL = ("UPDATE USUARIO SET DISCADOR = 'PREDITIVA' ,ORIGEM = NULL ,TP_ORIGEM = 1 WHERE COD = @idcod").Replace("@idcod", arrCodOper[i].ToString());
                                    bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                                }
                                else
                                {
                                    clsVariaveis.GstrSQL = ("UPDATE USUARIO SET DISCADOR = '" + _disc + "' ,ORIGEM = '" + _origem + "' ,TP_ORIGEM = " + _tpori + " WHERE COD = @idcod").Replace("@idcod", arrCodOper[i].ToString());
                                    bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                                }
                            }
                        }
                        MessageBox.Show("Alterado com sucesso", "Discagem " + _disc, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao atualizar", "Discagem " + _disc, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Discagem Manual ou Power", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void CarregaDataGridOrigem(string _strOrigem)
        {
            dtgOrigem.DataSource = null;
            dtgOrigem.Rows.Clear();

            if (_strOrigem != "")
            {
                int itot = 0;
                int itrab = 0;
                int ireps = 0;

                // tot do mailing
                clsVariaveis.GstrSQL = "select count(*) as qtd from Cadastro where origem = '" + _strOrigem + "'";
                DataTable dtP1 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtP1.Rows.Count > 0)
                    itot = Convert.ToInt32(dtP1.Rows[0]["qtd"].ToString());

                // a trabalhar do mailing
                clsVariaveis.GstrSQL = "select count(*) as qtd from Cadastro where origem = '" + _strOrigem + "' and uso = 0";
                DataTable dtP2 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtP2.Rows.Count > 0)
                    itrab = Convert.ToInt32(dtP2.Rows[0]["qtd"].ToString());

                // repasses do mailing
                clsVariaveis.GstrSQL = "select count(*) as qtd from Cadastro where origem = '" + _strOrigem + "' and uso = 8";
                DataTable dtP3 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtP3.Rows.Count > 0)
                    ireps = Convert.ToInt32(dtP3.Rows[0]["qtd"].ToString());

                dtgOrigem.Rows.Add(_strOrigem, itot, itrab, ireps);
            }
        }

        private void ListarUsuarios()
        {
            try
            {
                // lista de operadores
                clsVariaveis.GstrSQL = "[cod] AS 'ID' , [turno] AS 'EQUIPE', [nomecompleto] AS 'NOME', [matricula] AS 'MATR', [discador] AS 'DISCAGEM', [origem] AS 'MAILING'";
                dtgOper.DataSource = clsFuncoes.CarregarListaUsuarios(clsVariaveis.GstrSQL, "USUARIO", Classes.GetSet.clsUsuarioLogado.Usu_rank, " TURNO,NOMECOMPLETO ")[0];

                foreach (DataGridViewColumn column in dtgOper.Columns)
                {
                    if (column.DataPropertyName == "")
                    { column.Width = 30; }
                    else if (column.DataPropertyName == "ID")
                    { column.Visible = false; }
                    else
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }

                // lista de usuarios
                clsVariaveis.GstrSQL = "[cod] AS 'ID' , [status] AS 'STATUS', [nomecompleto] AS 'NOME', [matricula] AS 'MATR', [discador] AS 'DISCAGEM', [origem] AS 'MAILING'";
                dtgUsu.DataSource = clsFuncoes.CarregarListaUsuarios(clsVariaveis.GstrSQL, "USUARIO", Classes.GetSet.clsUsuarioLogado.Usu_rank, " STATUS,NOMECOMPLETO ")[1];

                foreach (DataGridViewColumn column in dtgUsu.Columns)
                {
                    if (column.DataPropertyName == "")
                    { column.Width = 30; }
                    else if (column.DataPropertyName == "ID")
                    { column.Visible = false; }
                    else
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Listar Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaDataGridOrigem(cboOrigem.Text);
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (cboOrigem.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja alterar ?", "Discagem Manual ou Power", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    btnPower.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    listBoxOrigem.SelectedIndex = cboOrigem.FindStringExact(cboOrigem.Text, listBoxOrigem.SelectedIndex);

                    if (tabControl1.SelectedIndex == 0)
                    {
                        if (chkPower.Checked == true)
                        {
                            AlterarBases(dtgOper, "POWER", cboOrigem.Text, listBoxOrigem.Text.ToString());
                        }
                        else
                        {
                            AlterarBases(dtgOper, "MANUAL", cboOrigem.Text, listBoxOrigem.Text.ToString());
                        }
                    }
                    else
                    {
                        if (chkPower.Checked == true)
                        {
                            AlterarBases(dtgUsu, "POWER", cboOrigem.Text, listBoxOrigem.Text.ToString());
                        }
                        else
                        {
                            AlterarBases(dtgUsu, "MANUAL", cboOrigem.Text, listBoxOrigem.Text.ToString());
                        }
                    }
                    ListarUsuarios();
                    this.Cursor = Cursors.Default;
                    btnPower.Enabled = true;
                }
            }
        }

        private void btnPreditiva_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja alterar ?", "Discagem PREDITIVA", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnPreditiva.Enabled = false;
                if (tabControl1.SelectedIndex == 0)
                {
                    AlterarBases(dtgOper, "PREDITIVA", "", "");
                }
                else
                {
                    AlterarBases(dtgUsu, "PREDITIVA", "", "");
                }
                ListarUsuarios();
                btnPreditiva.Enabled = true;
            }
        }
    }
}
