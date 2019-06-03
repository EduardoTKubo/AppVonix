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


namespace TesteCRM
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
            //this.Icon = Properties.Resources.punisher2;

            //tsslabel1.Text = Application.ProductVersion.ToString();
            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");


            foreach (DataRow Acesso in clsBanco.Consulta("SELECT * FROM USUARIO_ACESSO_MENU WHERE COD = " + clsUsuarioLogado.Usu_cod).Rows)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (item.Name == Acesso["ACESSO"].ToString())
                    {
                        item.Enabled = true;
                    }

                    foreach (ToolStripItem subitem in (item as ToolStripMenuItem).DropDownItems)
                    {
                        if (subitem.Name == Acesso["ACESSO"].ToString())
                        {
                            subitem.Enabled = true;
                        }
                    }
                }
            }

        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuCadUsuario_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenForm(new Forms.frmUsuario(), this, "1");
        }

        private void mnuBases_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenForm(new Forms.frmBases(), this, "1");
        }

        private void mnuAtivo_Click(object sender, EventArgs e)
        {
            switch (clsUsuarioLogado.usu_discador)
            {
                case "MANUAL":
                case "POWER":
                    {
                        Classes.clsFuncoes.OpenForm(new Forms.frmAtivo(), this ,"0");
                        break;
                    }
                case "PREDITIVA":
                    {
                        Classes.clsFuncoes.OpenForm(new Forms.frmPreditivo(), this ,"0");
                        break;
                    }
                default:
                    MessageBox.Show("Usuario sem base definida", "Procure seu superior", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

        }

        private void mnuBOffice2_Click(object sender, EventArgs e)
        {
            clsUsuarioLogado.Usu_BOffice = "BACK-OFFICE";
            Classes.clsFuncoes.OpenForm(new Forms.frmBackOffice(), this, "1");
        }

        private void mnuStandby_Click(object sender, EventArgs e)
        {
            clsUsuarioLogado.Usu_BOffice = "STAND-BY";
            Classes.clsFuncoes.OpenForm(new Forms.frmBackOffice(), this, "1");
        }

        private void mnuEstorno_Click(object sender, EventArgs e)
        {
            clsUsuarioLogado.Usu_BOffice = "ESTORNO";
            Classes.clsFuncoes.OpenForm(new Forms.frmBackOffice(), this, "1");
        }

        private void mnuVisualizaVda_Click(object sender, EventArgs e)
        {
            clsUsuarioLogado.Usu_BOffice = "VISUALIZA_VENDA";
            Classes.clsFuncoes.OpenForm(new Forms.frmBackOffice(), this, "1");
        }

        private void mnuRelatorios_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenForm(new Forms.frmRelat1(), this, "1");
        }

        private void mnuReceptivo_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenForm(new Forms.frmReceptivo(), this, "0");
        }

        private void mnuVisuCarga_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmVisuCarga());
        }
    }
}
