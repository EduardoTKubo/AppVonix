using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Forms
{
    public partial class frmAgendas : Form
    {
        public frmAgendas()
        {
            InitializeComponent();
            Limpar();
            PreencherGridAg();

        }

        private void Limpar()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
        }
        
        private void PreencherGridAg()
        {
            clsVariaveis.GstrSQL = "select id_ag ,data ,hora ,contato ,ddd ,fone ,obs from Agenda where Ativo = 1 and Operador = '" +
                                   clsUsuarioLogado.Usu_cpf + "' order by data ,hora";
            dataGridView1.DataSource = clsBanco.Consulta(clsVariaveis.GstrSQL);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "id_ag")
                    column.Visible = false;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void PreecherTela(string _idag)
        {
            clsVariaveis.GstrSQL = ("select * from Agenda where Id_ag = @id_ag ").Replace("@id_ag", _idag);

            DataTable dtAg = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtAg.Rows.Count > 0)
            {
                lblId_AG.Text = _idag;

                dtpData.Text = dtAg.Rows[0]["data"].ToString();
                dtpHora.Text = dtAg.Rows[0]["hora"].ToString();
                txtContato.Text = dtAg.Rows[0]["contato"].ToString();
                txtObs.Text = dtAg.Rows[0]["obs"].ToString();
            }
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (lblId_AG.Text != "")
            {
                int iComp = DateTime.Compare(Convert.ToDateTime(dtpData.Value).Date, DateTime.Now.Date);

                if (iComp >= 0)
                {
                    if (MessageBox.Show("Confirma ?", "Alterar Agendamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        clsVariaveis.GstrSQL = "UPDATE AGENDA SET " + clsFuncoes.MontaUpdate("CONTATO", txtContato.Text, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaUpdate("DATA", dtpData.Value.ToString("yyyy-MM-dd"), "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaUpdate("HORA", dtpHora.Value.ToString("HH:mm:ss"), "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaUpdate("OBS", txtObs.Text, "TEXT");
                        clsVariaveis.GstrSQL += " WHERE ID_AG = " + lblId_AG.Text;
                        if (clsBanco.ExecuteQuery(clsVariaveis.GstrSQL))
                        {
                            MessageBox.Show("Alterado com sucesso", "Agendamento", MessageBoxButtons.OK);
                            Limpar();
                            PreencherGridAg();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data inválida", "Agendamento", MessageBoxButtons.OK);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string sID = Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            PreecherTela(sID);
        }
    }
}
