using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Forms
{
    public partial class frmVisuCarga : Form
    {
        public frmVisuCarga()
        {
            InitializeComponent();

            cboOrigem.Items.Clear();
            listOrigem.Items.Clear();

            foreach (DataRow item in Classes.clsBanco.Consulta("select descricao ,descricao2 from tab_geral where titulo = 'VISUCARGA' and ativo = 1 order by descricao").Rows)
            {
                dtPicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1));
                dtPicker2.Value = DateTime.Today;
                dataGridView1.DataSource = "";

                cboOrigem.Items.Add(item[0].ToString());
                listOrigem.Items.Add(item[1].ToString());
            }
        }

        private void dtPicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }
        }

        private void dtPicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }
        }

        private void cboOrigem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }

            if (cboOrigem.Text != "")
            {
                lblTotal.Text = "0";

                try
                {
                    listOrigem.SelectedIndex = cboOrigem.FindStringExact(cboOrigem.Text, listOrigem.SelectedIndex);
                    switch (listOrigem.Text.ToString())
                    {
                        case "TAB_AUX_FORMULARIO":
                            clsVariaveis.GstrSQL = "select ( convert(nvarchar,data,103) + ' ' + hora ) as data ,( convert(nvarchar,dtincl,103) + ' ' + left(hrincl,5) ) as dtInclusao , nome ,ddd1 ,fone1 " +
                                                   "from TAB_AUX_FORMULARIO where Origem = '" +
                                                   cboOrigem.Text + "' and dtIncl between '" +
                                                   dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" +
                                                   dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by dtIncl ,hrIncl ,id_orig";
                            dataGridView1.DataSource = clsBanco.Consulta(clsVariaveis.GstrSQL);

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                            lblTotal.Text = Convert.ToString(dataGridView1.Rows.Count);
                            break;

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Visualiza carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
