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
    public partial class frmVenda : Form
    {
        public string _Discagem;

        public frmVenda()
        {
            InitializeComponent();

            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Limpar();
            CarregarCombos();

            lblCodigo.Text = clsVenda.Vda_cod;
            txtNome.Text = clsVenda.Vda_nome;
            txtDDD1.Text = clsVariaveis.GstrDDD;
            txtFone1.Text = clsVariaveis.GstrTel;
        }


        private void CarregarCombos()
        {
            cboFPagto.Items.Clear();
            cboFPagto.Items.Add("BOLETO");
            cboFPagto.Items.Add("CARTAO DE CREDITO");
            cboFPagto.Items.Add("DEBITO EM CONTA");
            cboFPagto.SelectedIndex = 0;

            cboSexo.Items.Clear();
            cboSexo.Items.Add("FEM");
            cboSexo.Items.Add("MASC");

            cboBanco.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'DEBITOCTA' and ativo = 1 order by Descricao").Rows)
            {
                cboBanco.Items.Add(item[0].ToString());
            }

            cboCartao.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'CCREDITO' and ativo = 1 order by Descricao").Rows)
            {
                cboCartao.Items.Add(item[0].ToString());
            }

            cboPlano.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'PLANOS' and ativo = 1 order by Descricao").Rows)
            {
                cboPlano.Items.Add(item[0].ToString());
            }


            cboUF.Items.Clear();
            cboUFOrgao.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'UF' and ativo = 1 order by Descricao").Rows)
            {
                cboUF.Items.Add(item[0].ToString());
                cboUFOrgao.Items.Add(item[0].ToString());
            }

        }


        private void Limpar()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);
            clsFuncoes.LimpaCampos(this, groupBox4);
        }


        private void tabControl2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = cboFPagto.SelectedIndex;
        }

        private void cboFPagto_SelectedValueChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = cboFPagto.SelectedIndex;
        }

        private void txtDDD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtFone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtDDD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtFone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void mskDtNasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void mskDtEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtDoc_Leave(object sender, EventArgs e)
        {
            string resp = clsFuncoes.ValidarDoc(this, txtDoc);
            if (resp != "")
            {
                MessageBox.Show(resp, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoc.Focus();
            }
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

        private void mskDtNasc_Leave(object sender, EventArgs e)
        {
            string res = clsFuncoes.ValidarData(this, mskDtNasc);
            if (res != "")
            {
                MessageBox.Show(res, "Data Nasc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDtNasc.Focus();
            }
        }

        private void mskDtEmissao_Leave(object sender, EventArgs e)
        {
            string res = clsFuncoes.ValidarData(this, mskDtEmissao);
            if (res != "")
            {
                MessageBox.Show(res, "Data de emissão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDtEmissao.Focus();
            }
        }

        private void txtEmailRespons_Leave(object sender, EventArgs e)
        {
            if (txtEmailRespons.Text != "")
            {
                if (!clsFuncoes.ValidarEmail(this, txtEmailRespons))
                {
                    MessageBox.Show("email inválido!", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailRespons.Focus();
                }
            }
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            if (txtCEP.Text.Trim() != "")
            {
                txtCEP.Text = Convert.ToUInt64(txtCEP.Text).ToString(@"00000000");
            }
        }

        private void txtCPFRespons_Leave(object sender, EventArgs e)
        {
            string resp = clsFuncoes.ValidarDoc(this, txtCPFRespons);
            if (resp != "")
            {
                MessageBox.Show(resp, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPFRespons.Focus();
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                try
                { 
                    txtValor.Text = Convert.ToDouble(txtValor.Text).ToString("N2");
                }
                catch
                {
                    MessageBox.Show("Valor invalido", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValor.Focus();
                }
            }
        }

        private void mskValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (lblCodigo.Text == "")
            {
                return;
            }
            else
            {
                string msg = "";
                if(txtNome.Text.Trim() == "") { msg += "Informar o nome" + "\r\n"; }
                if (txtDoc.Text.Trim() == "") { msg += "Informar o documento" + "\r\n"; }
                if (cboPlano.Text.Trim() == "") { msg += "Informar o plano" + "\r\n"; }
                if (txtValor.Text.Trim() == "") { msg += "Informar o valor" + "\r\n"; }
                if(msg != "")
                {
                    MessageBox.Show(msg , "Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (txtSenha.Text.Trim() == "")
                {
                    MessageBox.Show("Auditor , informe a senha para liberação", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            // conferir senha do auditor
            clsVariaveis.GstrSQL = ("select cpf from Usuario where Ativo = 1 and Senha = '@senha'  and Status in ('ADMIN','AUDITOR','SUPERVISOR','ROOT')").Replace("@senha", txtSenha.Text.Trim());
            DataTable dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtUsu.Rows.Count == 0)
            {
                MessageBox.Show("Senha incorreta", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            clsVenda.Vda_auditor = dtUsu.Rows[0]["cpf"].ToString();
            dtUsu.Clear();


            try
            {
                //DataTable dt = clsBanco.ExecuteQueryRetorno(ComandoInsertVenda());

                string Comando = "insert into Vendas ( codigo ,tp_origem ,origem ,data ,hora ,operador ,turno ,auditor ,";
                Comando += "nome ,cpf ,email ,ddd1 ,tel1 ,ddd2 ,tel2 ,pessoa ,";
                Comando += "sexo ,dtnasc ,rg ,dt_exp_rg ,orgao_emissor ,uf_rg ,";
                Comando += "fantasia ,ie ,ramo_ativ ,respons ,email_respons ,ddd1_respons ,tel1_respons ,cpf_respons ,";
                Comando += "cep ,logradouro ,numero ,compl ,bairro ,cidade ,uf ,";
                Comando += "forma_pagto ,melhor_dia ,";
                Comando += "administradora ,num_cartao ,cod_seg ,val_cartao ,";
                Comando += "banco ,agencia ,dig_ag ,conta ,dig_conta ,";
                Comando += "plano ,assist_24hrs ,instal_atv ,tx_entrega ,valor ,";
                Comando += "obs_wel ,cod_site ) values (";
                Comando += clsFuncoes.MontaInsert(clsVenda.Vda_cod, "INT") + " ,";
                Comando += clsFuncoes.MontaInsert(clsVenda.Vda_tpOrigem, "INT") + " ,";
                Comando += clsFuncoes.MontaInsert(clsVenda.Vda_origem, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(DateTime.Now.ToString("yyyy-MM-dd"), "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(DateTime.Now.ToString("HH:mm:ss"), "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_cpf, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_equipe, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(clsVenda.Vda_auditor, "TEXT") + " ,";

                Comando += clsFuncoes.MontaInsert(txtNome.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtDoc.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtEmail.Text, "EMAIL") + " ,";
                Comando += clsFuncoes.MontaInsert(txtDDD1.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtFone1.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtDDD2.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtFone2.Text, "TEXT") + " ,";

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        Comando += clsFuncoes.MontaInsert("PF", "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(cboSexo.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(mskDtNasc.Text, "DATE") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtRG.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(mskDtEmissao.Text, "DATE") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtRGOrgao.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(cboUFOrgao.Text, "TEXT") + " ,";
                        Comando += "null ,null ,null ,null ,null ,null ,null ,null ,";
                        break;
                    case 1:
                        Comando += clsFuncoes.MontaInsert("PJ", "TEXT") + " ,";
                        Comando += "null ,null ,null ,null ,null ,null ,";
                        Comando += clsFuncoes.MontaInsert(txtFantasia.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtIE.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtRamoAtv.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtRespons.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtEmailRespons.Text, "EMAIL") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtDDDRespons.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtFoneRespons.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtCPFRespons.Text, "TEXT") + " ,";
                        break;
                }
                
                Comando += clsFuncoes.MontaInsert(txtCEP.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtLogradouro.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtNum.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtCompl.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtBairro.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtCidade.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(cboUF.Text, "TEXT") + " ,";

                Comando += clsFuncoes.MontaInsert(cboFPagto.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtMelhorDia.Text, "TEXT") + " ,";

                switch (cboFPagto.Text)
                {
                    case "BOLETO":
                        Comando += "null ,null ,null ,null ,null ,null ,null ,null ,null ,";
                        break;
                    case "CARTAO DE CREDITO":
                        Comando += clsFuncoes.MontaInsert(cboCartao.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtCartao.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtCodSeg.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(mskValidade.Text, "TEXT") + " ,";
                        Comando += "null ,null ,null ,null ,null";
                        break;
                    case "DEBITO EM CONTA":
                        Comando += "null ,null ,null ,null ,";
                        Comando += clsFuncoes.MontaInsert(cboBanco.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtAgencia.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtAgenciaDig.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtConta.Text, "TEXT") + " ,";
                        Comando += clsFuncoes.MontaInsert(txtContaDig.Text, "TEXT") + " ,";
                        break;                    
                }

                Comando += clsFuncoes.MontaInsert(cboPlano.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(chkAssist24H.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(chkInstalAtv.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(chkTxEntrega.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtValor.Text, "REAL") + " ,";

                Comando += clsFuncoes.MontaInsert(txtObs.Text, "TEXT") + " ,";
                Comando += clsFuncoes.MontaInsert(txtCodGerado.Text, "TEXT") + " )";

                bool booOK = clsBanco.ExecuteQuery(Comando);
                if (booOK)
                {
                    Classes.clsVariaveis.SalvarInformacao = true;
                    MessageBox.Show("Incluído com sucesso", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }
}
