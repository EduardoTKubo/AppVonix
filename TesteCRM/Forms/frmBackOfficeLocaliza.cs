using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Forms
{
    public partial class frmBackOfficeLocaliza : Form
    {
        public frmBackOfficeLocaliza()
        {
            InitializeComponent();

            this.Text = clsUsuarioLogado.Usu_BOffice;

            cboStatus.Items.Clear();
            cboStatus.Items.Add("");
            foreach (DataRow item in Classes.clsBanco.Consulta("select descricao from tab_geral where titulo = 'STATUS_VENDA' and ativo = 1 order by descricao").Rows)
            {
                cboStatus.Items.Add(item[0].ToString());
            }

            dtPicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1));
            dtPicker2.Value = DateTime.Today;

        }

        private void Preenche_Grid()
        {

            switch (clsUsuarioLogado.Usu_BOffice)
            {
                case "BACK-OFFICE":
                    clsVariaveis.GstrSQL = "select v.ID_Venda,  v.turno,  v.data,  v.hora, u.nomecompleto operador, v.nome , v.forma_pagto , v.status_venda from Vendas as v inner join usuario as u on u.cpf = v.operador ";
                    if (cboStatus.Text == "")
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda is null ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda = '" + cboStatus.Text + "' ";
                    }
                    clsVariaveis.GstrSQL += " and  v.estorno = 0 and  v.st_standby = 0 ";
                    clsVariaveis.GstrSQL += " and v.data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by v.data ,v.hora ";
                    break;

                case "ESTORNO":
                    clsVariaveis.GstrSQL = "select v.ID_Venda,  v.turno,  v.data,  v.hora, u.nomecompleto operador, v.nome , v.forma_pagto , v.status_venda from Vendas as v inner join usuario as u on u.cpf = v.operador ";
                    if (cboStatus.Text == "")
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda is null ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda = '" + cboStatus.Text + "' ";
                    }
                    clsVariaveis.GstrSQL += " and  v.estorno = 1 ";
                    clsVariaveis.GstrSQL += " and v.data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by v.data ,v.hora ";
                    break;

                case "STAND-BY":
                    clsVariaveis.GstrSQL = "select v.ID_Venda,  v.turno,  v.data,  v.hora, u.nomecompleto operador, v.nome , v.forma_pagto , v.status_venda from Vendas as v inner join usuario as u on u.cpf = v.operador ";
                    if (cboStatus.Text == "")
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda is null ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda = '" + cboStatus.Text + "' ";
                    }
                    clsVariaveis.GstrSQL += " and  v.st_standby = 1 ";
                    clsVariaveis.GstrSQL += " and v.data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by v.data ,v.hora ";
                    break;

                case "VISUALIZA-VENDA":
                    clsVariaveis.GstrSQL = "select v.ID_Venda,  v.turno,  v.data,  v.hora, u.nomecompleto operador, v.nome , v.forma_pagto , v.status_venda from Vendas as v inner join usuario as u on u.cpf = v.operador ";
                    if (cboStatus.Text == "")
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda is null ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " where  v.Status_Venda = '" + cboStatus.Text + "' ";
                    }
                    clsVariaveis.GstrSQL += " and v.data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by v.data ,v.hora ";
                    break;
            }

            dtGrid.DataSource = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtGrid.Rows.Count > 0)
            {
                foreach (DataGridViewColumn column in dtGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                lblTotal.Text = dtGrid.Rows.Count.ToString();
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Preenche_Grid();
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            int nLin = dtGrid.RowCount;
            if (nLin != 0)
            {
                clsVariaveis.GstrSQL = "select id_venda ,uso_office ,office from Vendas where id_venda = " + Convert.ToString(dtGrid[0, dtGrid.CurrentRow.Index].Value);
                DataTable dtVda = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtVda.Rows.Count != 0)
                {
                    if (dtVda.Rows[0]["uso_office"].ToString() == "13")
                    {
                        MessageBox.Show("Este registro esta sendo implantado" + "\r\n" + "Escolha outro registro", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        clsBackOffice.Bo_id_venda = dtVda.Rows[0]["id_venda"].ToString();
                        clsBackOffice.Bo_uso = dtVda.Rows[0]["uso_office"].ToString();
                        clsBackOffice.Bo_office = dtVda.Rows[0]["office"].ToString();

                        if (clsUsuarioLogado.Usu_BOffice != "CONSULTA")
                        {
                            clsVariaveis.GstrSQL = "update Vendas set Uso_Office = 13 where id_venda = " + clsBackOffice.Bo_id_venda;
                            bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                        }

                        this.Close();
                    }
                }



            }
        }
    }
}
