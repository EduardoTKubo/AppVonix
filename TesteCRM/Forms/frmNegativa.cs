using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;

namespace TesteCRM.Forms
{
    public partial class frmNegativa : Form
    {
        public frmNegativa()
        {
            InitializeComponent();

            cboNegativa.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select descricao2 from tab_geral where titulo = 'TABULACAO' and descricao = 'NEGATIVA' and ativo = 1 order by descricao2").Rows)
            {
                cboNegativa.Items.Add(item[0].ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.clsVariaveis.GstrNegativa = "";
            Classes.clsVariaveis.SalvarInformacao = false;
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (cboNegativa.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Negativa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Classes.clsVariaveis.GstrNegativa = cboNegativa.Text;
                    Classes.clsVariaveis.SalvarInformacao = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Informe uma negativa", "Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
