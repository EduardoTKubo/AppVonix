using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Forms
{
    public partial class frmRelat1 : Form
    {
        public frmRelat1()
        {
            InitializeComponent();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                clsRelatorio.Rel_titulo = "VENDAS";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton1.Checked = false;
            }
            
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                clsRelatorio.Rel_titulo = "ATIVO - TABULACAO POR OPERADOR";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton3.Checked = false;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                clsRelatorio.Rel_titulo = "ATIVO - TABULACAO";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton2.Checked = false;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                clsRelatorio.Rel_titulo = "ATIVO - RELAT_POR_BASE";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton4.Checked = false;
            }
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                clsRelatorio.Rel_titulo = "RECEPTIVO - RELAT_POR_BASE";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton5.Checked = false;
            }
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                clsRelatorio.Rel_titulo = "RECEPTIVO - TABULACAO POR OPERADOR";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton6.Checked = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                clsRelatorio.Rel_titulo = "RECEPTIVO - TABULACAO POR ORIGEM";
                Classes.clsFuncoes.OpenForm(new Forms.frmRelat2(), this, "1");
                radioButton7.Checked = false;
            }
        }
    }
}
