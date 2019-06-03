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
    public partial class frmReceptivo : Form
    {
        public frmReceptivo()
        {
            InitializeComponent();

            clsVariaveis.GintPreditiva = 3;

            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cboOrigem.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'ORIG_RECEPT' and ativo = 1 order by Descricao").Rows)
            {
                cboOrigem.Items.Add(item[0].ToString());
            }

            Limpar();
            InicializaReceptivo();
            PreencheGridAg();
        }

        private void Preenche_Agendado(string _idAg, string _idRecept)
        {
            clsVariaveis.GstrSQL = ("select * from Receptivo where IdRecept = @idRecept ").Replace("@idRecept", _idRecept);

            DataTable dtR = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtR.Rows.Count > 0)
            {
                lblIdAg.Text = _idAg;
                lblIdRecept.Text = _idRecept;

                cboOrigem.Text = dtR.Rows[0]["origem"].ToString();
                txtNome.Text = dtR.Rows[0]["nome"].ToString();
                txtDDD1.Text = dtR.Rows[0]["ddd1"].ToString();
                txtFone1.Text = dtR.Rows[0]["fone1"].ToString();
                txtEmail.Text = dtR.Rows[0]["email"].ToString();
                txtObs.Text = dtR.Rows[0]["obs"].ToString();
            }
        }
               
        private bool BuscarIdRecept()
        {
        Inicio:
            clsVariaveis.GstrSQL = "select top 1 * from Receptivo where Operador = '" + clsUsuarioLogado.Usu_cpf + "' ";
            clsVariaveis.GstrSQL += "and Data is null and Resultado is null order by id_recept desc";
            DataTable dtRcp = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtRcp.Rows.Count != 0)
            {
                clsReceptivo.Rcp_id_recept = dtRcp.Rows[0]["id_recept"].ToString();
                return true;
            }
            else
            {
                clsVariaveis.GstrSQL = "insert into Receptivo ( operador ) values ( '" + clsUsuarioLogado.Usu_cpf + "')";
                bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                if (booIni) { goto Inicio; }
                { return false; }
            }
        }

        private bool EstaOK()
        {
            clsVariaveis.GstrSQL = "";
            if (this.cboOrigem.Text.Trim() == "") { clsVariaveis.GstrSQL += "Informar a origem do contato" + "\r\n"; }
            if (this.txtNome.Text.Trim() == "") { clsVariaveis.GstrSQL += "Informar o nome" + "\r\n"; }
            if (this.txtDDD1.Text.Trim() == "") { clsVariaveis.GstrSQL += "Informar o DDD" + "\r\n"; }
            if (this.txtFone1.Text.Trim() == "") { clsVariaveis.GstrSQL += "Informar o telefone" + "\r\n"; }

            if (clsVariaveis.GstrSQL == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(clsVariaveis.GstrSQL, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void InicializaReceptivo()
        {
            clsReceptivo.Rcp_id_recept = "";
            clsReceptivo.Rcp_id_ag = "";
            clsReceptivo.Rcp_origem = "";
        }

        private void Limpar()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);
        }

        private bool EncerraContato(string _codigo, string _uso, string _res)
        {
            bool resultado = false;

            if (clsReceptivo.Rcp_id_recept == "")
            {
                bool booR = BuscarIdRecept();
                if (booR == false) { return resultado; }
            }


            if (clsReceptivo.Rcp_id_ag != "")
            {
                clsVariaveis.GstrSQL = "update agenda set ativo = 0 where id_ag = " + clsAtivo.Atv_id_ag;
                bool booAg = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            }

            clsVariaveis.GstrSQL = "update Receptivo set Resultado = '" + _res + "' ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("data", DateTime.Now.ToString("yyyy-MM-dd"), "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("horario", DateTime.Now.ToString("HH:mm:ss"), "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("origem", cboOrigem.Text, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("nome", txtNome.Text, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("email", txtEmail.Text, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ddd1", txtDDD1.Text, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("fone1", txtFone1.Text, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("obs", txtObs.Text, "TEXT");
            clsVariaveis.GstrSQL += " where Id_Recept = " + clsReceptivo.Rcp_id_recept;
            bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            if (booIni)
            {
                MessageBox.Show("incluido com sucesso", _res, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Limpar();
                resultado = true;
            }

            return resultado;
        }

        private void PreencheGridAg()
        {
            clsVariaveis.GstrSQL = "select id_ag ,id ,data ,hora ,contato ,obs from Receptivo_Ag where Ativo = 1 and Operador = '" + clsUsuarioLogado.Usu_cpf + "' order by data ,hora";
            dataGridView1.DataSource = clsBanco.Consulta(clsVariaveis.GstrSQL);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Visible = false;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void rbGeral(RadioButton _rb, string _uso, string _res, string _confirma)
        {
            if (EstaOK())
            {
                if (_confirma == "NAO")
                {
                    EncerraContato(clsAtivo.Atv_cod, _uso, _res);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Tem certeza ?", _res, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        EncerraContato(clsAtivo.Atv_cod, _uso, _res);
                    }
                }
            }
            _rb.Checked = false;
        }


        private void txtDDD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtFone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (!clsFuncoes.ValidarEmail(this, txtEmail))
                {
                    MessageBox.Show("email inválido!", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
            }
        }

        private void rbLigMuda_Click(object sender, EventArgs e)
        {
            rbGeral(rbLigMuda, "9", "MUDO", "SIM");
        }

        private void rbLigErrado_Click(object sender, EventArgs e)
        {
            rbGeral(rbLigErrado, "9", "LIGOU ERRADO", "SIM");
        }

        private void rbAgenda_Click(object sender, EventArgs e)
        {
            if (EstaOK())
            {
                if (lblIdRecept.Text == "") { BuscarIdRecept(); }

                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsFuncoes.OpenFormModal(new Forms.frmAgendar());
                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbAgenda, "9", "AG", "NAO");
                }
            }
            rbAgenda.Checked = false;
        }

        private void rbNegativa_Click(object sender, EventArgs e)
        {
            if (EstaOK())
            {
                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsVariaveis.GstrNegativa = "";

                Classes.clsFuncoes.OpenFormModal(new Forms.frmNegativa());

                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbNegativa, "9", Classes.clsVariaveis.GstrNegativa, "NAO");
                }
            }
            rbNegativa.Checked = false;
        }

        private void rbVenda_Click(object sender, EventArgs e)
        {
            if (EstaOK())
            {
                if (lblIdRecept.Text == "") { BuscarIdRecept(); }

                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsVariaveis.GstrNegativa = "";

                clsVenda.Vda_cod = lblIdRecept.Text;
                clsVenda.Vda_origem = cboOrigem.Text;
                clsVenda.Vda_tpOrigem = "3";
                clsVenda.Vda_nome = txtNome.Text;
                clsVenda.Vda_OriVda = "RECEPTIVO";
                clsVenda.Vda_auditor = "";
                Classes.clsFuncoes.OpenFormModal(new Forms.frmVenda());

                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbVenda, "9", "OK", "NAO");
                }
            }
            rbVenda.Checked = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID1 = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            int ID2 = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
            txtObsAg.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentRow.Index].Value);
            Preenche_Agendado(ID1.ToString() , ID2.ToString());
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            PreencheGridAg();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmVisualizaVendas());
        }
    }
}
