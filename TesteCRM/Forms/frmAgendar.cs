using System;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;

namespace TesteCRM.Forms
{
    public partial class frmAgendar : Form
    {
        public frmAgendar()
        {
            InitializeComponent();

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            int iComp = DateTime.Compare(Convert.ToDateTime(dtpData.Value).Date, DateTime.Now.Date);

            if (iComp >= 0)
            {
                if (MessageBox.Show("Confirma ?", "GravarAgendamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (clsVariaveis.GintPreditiva == 3)
                    {
                        clsVariaveis.GstrSQL = "INSERT INTO RECEPTIVO_AG ( ID ,OPERADOR ,DATA ,HORA ,CONTATO ,OBS ,REG_DATA ,REG_HORA ) VALUES ( " + clsReceptivo.Rec_Id_Recept ; ;
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_cpf, "TEXT");
                        clsVariaveis.GstrSQL += " ,'" + dtpData.Value.ToString("yyyy-MM-dd") + "' ,'" + dtpHora.Value.ToString("HH:mm:ss") + "'";
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(txtContato.Text, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(txtObs.Text, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(DateTime.Now.ToString("yyyy-MM-dd"), "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(DateTime.Now.ToString("HH:mm:ss"), "TEXT") + " )";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL = "INSERT INTO AGENDA ( ID ,DATA ,HORA ,OPERADOR ,CONTATO ,OBS ,REG_DATA ,REG_HORA ,DDD ,FONE ,PREDITIVA ) VALUES ( " + clsAtivo.Atv_cod;
                        clsVariaveis.GstrSQL += " ,'" + dtpData.Value.ToString("yyyy-MM-dd") + "' ,'" + dtpHora.Value.ToString("HH:mm:ss") + "'";
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_cpf, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(txtContato.Text, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(txtObs.Text, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(DateTime.Now.ToString("yyyy-MM-dd"), "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(DateTime.Now.ToString("HH:mm:ss"), "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsVariaveis.GstrDDD, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsVariaveis.GstrTel, "TEXT");
                        clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsVariaveis.GintPreditiva.ToString(), "INT") + " )";
                    }
                    bool booAg = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                    clsVariaveis.SalvarInformacao = booAg;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Data inválida", "Agendamento", MessageBoxButtons.OK);
            }
        }
    }
}
