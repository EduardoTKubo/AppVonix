using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;


namespace TesteCRM
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //this.Icon = TesteCRM.Properties.Resources.punisher2;
        }
               
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            string strInf = txtLogin.Text.Trim();
            if (strInf != "" )
            {
                if (strInf.Length > 5)
                {
                    string resp = clsFuncoes.ValidarDoc(this, txtLogin);
                    if (resp != "")
                    {
                        MessageBox.Show(resp, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLogin.Focus();
                    }
                    else
                    {
                        clsVariaveis.GstrSQL = "select pwd2 from Usuario where Ativo = 1 and CPF = '" + txtLogin.Text + "' ";
                        DataTable dt1 = new DataTable();
                        dt1 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0]["pwd2"].ToString() == "True")
                            {
                                txtSenha.Enabled = true;
                                txtSenha.Focus();
                            }
                        }
                    }
                }
            }
        }

        public void btnAcesso_Click(object sender, EventArgs e)
        {
            if (clsUsuarioLogado.IsLoginOK(txtLogin.Text, txtSenha.Text))
            {
                Classes.clsVariaveis.IsAuthorizedLogin = true;
                clsUsuarioLogado.DadosUsuarioLogado(txtLogin.Text);
                clsUsuarioLogado.MapOperacional(clsUsuarioLogado.Usu_cpf);
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario não localizado","Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
