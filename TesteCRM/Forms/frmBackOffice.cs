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
    public partial class frmBackOffice : Form
    {
        public frmBackOffice()
        {
            InitializeComponent();

            this.Text = clsUsuarioLogado.Usu_BOffice;

            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Limpar();
            CarregarCombos();
            lblIdVenda.Text = "";

        }


        private void CarregarCombos()
        {
            cboFPagto.Items.Clear();
            cboFPagto.Items.Add("BOLETO");
            cboFPagto.Items.Add("CARTAO DE CREDITO");
            cboFPagto.Items.Add("DEBITO EM CONTA");
            cboFPagto.SelectedIndex = 0;

            cboPFPJ.Items.Clear();
            cboPFPJ.Items.Add("PF");
            cboPFPJ.Items.Add("PJ");
            cboPFPJ.SelectedIndex = 0;

            cboSexo.Items.Clear();
            cboSexo.Items.Add("FEM");
            cboSexo.Items.Add("MASC");


            cboAcao.Items.Clear();
            switch (clsUsuarioLogado.Usu_BOffice)
            {
                case "BACK-OFFICE":
                    cboAcao.Items.Add("ATUALIZAR");
                    //cboAcao.Items.Add("CONFIRMAR");
                    cboAcao.Items.Add("ENVIAR PARA STAND-BY");
                    cboAcao.Items.Add("ESTORNAR");
                    cboAcao.SelectedIndex = 0;
                    break;
                case "ESTORNO":
                    cboAcao.Items.Add("");
                    cboAcao.Items.Add("ATUALIZAR");
                    cboAcao.Items.Add("DEVOLVER AO BACK");
                    cboAcao.SelectedIndex = 0;
                    break;
                case "STAND-BY":
                    cboAcao.Items.Add("");
                    cboAcao.Items.Add("ATUALIZAR");
                    cboAcao.Items.Add("DEVOLVER AO BACK");
                    cboAcao.Items.Add("ESTORNAR");
                    cboAcao.SelectedIndex = 0;
                    break;
            }           


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

            cboStatus.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'STATUS_VENDA' and ativo = 1 order by Descricao").Rows)
            {
                cboStatus.Items.Add(item[0].ToString());
            }

            cboStandby.Items.Clear();
            foreach (DataRow item in Classes.clsBanco.Consulta("select Descricao from Tab_Geral where Titulo = 'TPSTANDBY' and ativo = 1 order by Descricao").Rows)
            {
                cboStandby.Items.Add(item[0].ToString());
            }

        }

        private void Inicializa_Office()
        {
            if (clsBackOffice.Bo_id_venda != "")
            {
                if (clsUsuarioLogado.Usu_BOffice != "VISUALIZA_VENDA")
                {
                    clsVariaveis.GstrSQL = "update Vendas set uso_office = " + clsBackOffice.Bo_uso + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("office", clsBackOffice.Bo_office, "TEXT");
                    clsVariaveis.GstrSQL += " where id_venda = " + clsBackOffice.Bo_id_venda;
                    bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                }
            }
        }

        private void Limpar()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, tabPage1);
            clsFuncoes.LimpaCampos(this, tabPage2);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, tabPage4);
            clsFuncoes.LimpaCampos(this, tabPage5);
            clsFuncoes.LimpaCampos(this, tabPage6);
            clsFuncoes.LimpaCampos(this, groupBox3);
            clsFuncoes.LimpaCampos(this, groupBox4);
            clsFuncoes.LimpaCampos(this, groupBox5);
            lblIdVenda.Text = "";
            lblOperador.Text = "";
            clsBackOffice.Bo_id_venda = "";
            clsBackOffice.Bo_uso = "0";
            clsBackOffice.Bo_office = "";
        }


        private void Monta_String_Update()
        {
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("nome", this.txtNome.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cpf", this.txtDoc.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("email", this.txtEmail.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ddd1", this.txtDDD1.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("tel1", this.txtFone1.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ddd2", this.txtDDD2.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("tel2", this.txtFone2.Text, "TEXT") + " ,";

            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("pessoa", this.cboPFPJ.Text, "TEXT") + " ,";
            if (this.cboPFPJ.Text == "PF")
            {
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("sexo", this.cboSexo.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("dtnasc", this.mskDtNasc.Text, "DATE") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("rg", this.txtRG.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("dt_exp_rg", this.mskDtEmissao.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("orgao_emissor", this.txtRGOrgao.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("uf_rg", this.cboUFOrgao.Text, "TEXT") + " ,";
            }
            else if (this.cboPFPJ.Text == "PJ")
            {
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("fantasia", this.txtFantasia.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ie", this.txtIE.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ramo_ativ", this.txtRamoAtv.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("respons", this.txtRespons.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("email_respons", this.txtEmailRespons.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("ddd1_respons", this.txtDDDRespons.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("tel1_respons", this.txtFoneRespons.Text, "TEXT") + " ,";
                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cpf_respons", this.txtCPFRespons.Text, "TEXT") + " ,";
            }

            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cep", this.txtCEP.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("logradouro", this.txtLogradouro.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("numero", this.txtNum.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("compl", this.txtCompl.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("bairro", this.txtBairro.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cidade", this.txtCidade.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("uf", this.cboUF.Text, "TEXT") + " ,";

            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("melhor_dia", this.txtMelhorDia.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("forma_pagto", this.cboFPagto.Text, "TEXT") + " ,";
            switch (this.cboFPagto.Text)
            {
                case "CARTAO DE CREDITO":
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("administradora", this.cboCartao.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("num_cartao", this.txtCartao.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("val_cartao", this.mskValidade.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cod_seg", this.txtCodSeg.Text, "TEXT") + " ,";
                    break;

                case "DEBITO EM CONTA":
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("banco", this.cboBanco.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("agencia", this.txtAgencia.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("dig_ag", this.txtAgenciaDig.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("conta", this.txtConta.Text, "TEXT") + " ,";
                    clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("dig_conta", this.txtContaDig.Text, "TEXT") + " ,";
                    break;
            }

            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("plano", this.cboPlano.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("assist_24hrs", this.chkAssist24H.Checked.ToString(), "BOO") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("instal_atv", this.chkInstalAtv.Checked.ToString(), "BOO") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("tx_entrega", this.chkTxEntrega.Checked.ToString(), "BOO") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("valor", this.txtValor.Text, "REAL") + " ,";

            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("cod_site", this.txtCodGerado.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("obs_wel", this.txtObs.Text, "TEXT") + " ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("status_venda", this.cboStatus.Text, "TEXT");
        }


        private void Preencher_Tela(string _id_venda)
        {
            if (_id_venda != "")
            {
                lblIdVenda.Text = _id_venda;

                clsVariaveis.GstrSQL = ("select v.* ,u.nomecompleto nome_operador from Vendas as v inner join usuario as u on u.cpf = v.operador where v.Id_Venda = @id ").Replace("@id", _id_venda);
                DataTable dtVda = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtVda.Rows.Count != 0)
                {
                    lblOperador.Text = "Operador : " + dtVda.Rows[0]["nome_operador"].ToString();
                    clsBackOffice.Bo_uso = dtVda.Rows[0]["uso_office"].ToString();
                    clsBackOffice.Bo_office = dtVda.Rows[0]["office"].ToString();

                    txtNome.Text = dtVda.Rows[0]["nome"].ToString();
                    txtDoc.Text = dtVda.Rows[0]["cpf"].ToString();
                    txtEmail.Text = dtVda.Rows[0]["email"].ToString();
                    txtDDD1.Text = dtVda.Rows[0]["ddd1"].ToString();
                    txtFone1.Text = dtVda.Rows[0]["tel1"].ToString();
                    txtDDD2.Text = dtVda.Rows[0]["ddd2"].ToString();
                    txtFone2.Text = dtVda.Rows[0]["tel2"].ToString();

                    if (dtVda.Rows[0]["pessoa"].ToString() == "PF")
                    {
                        cboPFPJ.SelectedIndex = 0;
                        cboSexo.Text = dtVda.Rows[0]["sexo"].ToString();
                        if (dtVda.Rows[0]["dtnasc"].ToString() != "")
                        {
                            DateTime dtV = Convert.ToDateTime(dtVda.Rows[0]["dtnasc"].ToString());
                            mskDtNasc.Text = dtV.ToString("dd/MM/yyyy");
                        }
                        txtRG.Text = dtVda.Rows[0]["rg"].ToString();
                        if (dtVda.Rows[0]["dt_exp_rg"].ToString() != "")
                        {
                            DateTime dtV = Convert.ToDateTime(dtVda.Rows[0]["dt_exp_rg"].ToString());
                            mskDtEmissao.Text = dtV.ToString("dd/MM/yyyy");
                        }
                        txtRGOrgao.Text = dtVda.Rows[0]["orgao_emissor"].ToString();
                        cboUFOrgao.Text = dtVda.Rows[0]["uf_rg"].ToString();
                    }
                    else if (dtVda.Rows[0]["pessoa"].ToString() == "PJ")
                    {
                        cboPFPJ.SelectedIndex = 1;
                        txtFantasia.Text = dtVda.Rows[0]["fantasia"].ToString();
                        txtIE.Text = dtVda.Rows[0]["ie"].ToString();
                        txtRamoAtv.Text = dtVda.Rows[0]["ramo_ativ"].ToString();
                        txtRespons.Text = dtVda.Rows[0]["respons"].ToString();
                        txtEmailRespons.Text = dtVda.Rows[0]["email_respons"].ToString();
                        txtDDDRespons.Text = dtVda.Rows[0]["ddd1_respons"].ToString();
                        txtFoneRespons.Text = dtVda.Rows[0]["tel1_respons"].ToString();
                        txtCPFRespons.Text = dtVda.Rows[0]["cpf_respons"].ToString();
                    }
                    txtCEP.Text = dtVda.Rows[0]["cep"].ToString();
                    txtLogradouro.Text = dtVda.Rows[0]["logradouro"].ToString();
                    txtNum.Text = dtVda.Rows[0]["numero"].ToString();
                    txtCompl.Text = dtVda.Rows[0]["compl"].ToString();
                    txtBairro.Text = dtVda.Rows[0]["bairro"].ToString();
                    txtCidade.Text = dtVda.Rows[0]["cidade"].ToString();
                    cboUF.Text = dtVda.Rows[0]["uf"].ToString();


                    txtMelhorDia.Text = dtVda.Rows[0]["melhor_dia"].ToString();
                    switch (dtVda.Rows[0]["forma_pagto"].ToString())
                    {
                        case "BOLETO":
                            cboFPagto.SelectedIndex = 0;
                            break;

                        case "CARTAO DE CREDITO":
                            cboFPagto.SelectedIndex = 1;
                            cboCartao.Text = dtVda.Rows[0]["administradora"].ToString();
                            txtCartao.Text = dtVda.Rows[0]["num_cartao"].ToString();
                            mskValidade.Text = dtVda.Rows[0]["val_cartao"].ToString();
                            txtCodSeg.Text = dtVda.Rows[0]["cod_seg"].ToString();
                            break;

                        case "DEBITO EM CONTA":
                            cboFPagto.SelectedIndex = 2;
                            cboBanco.Text = dtVda.Rows[0]["banco"].ToString();
                            txtAgencia.Text = dtVda.Rows[0]["agencia"].ToString();
                            txtAgenciaDig.Text = dtVda.Rows[0]["dig_ag"].ToString();
                            txtConta.Text = dtVda.Rows[0]["conta"].ToString();
                            txtContaDig.Text = dtVda.Rows[0]["dig_conta"].ToString();
                            break;
                    }
                    cboPlano.Text = dtVda.Rows[0]["plano"].ToString();
                    if (dtVda.Rows[0]["assist_24hrs"].ToString() != "") { chkAssist24H.Checked = true; }
                    if (dtVda.Rows[0]["instal_atv"].ToString() != "") { chkInstalAtv.Checked = true; }
                    if (dtVda.Rows[0]["tx_entrega"].ToString() != "") { chkTxEntrega.Checked = true; }
                    txtValor.Text = dtVda.Rows[0]["valor"].ToString().Replace(".", ",");
                    txtCodGerado.Text = dtVda.Rows[0]["cod_site"].ToString();
                    txtObs.Text = dtVda.Rows[0]["obs_wel"].ToString();

                    cboStatus.Text = dtVda.Rows[0]["status_venda"].ToString();

                }
            }
        }

        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
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

        private void mskDtNasc_Leave(object sender, EventArgs e)
        {
            string res = clsFuncoes.ValidarData(this, mskDtNasc);
            if (res != "")
            {
                MessageBox.Show(res, "Data Nasc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDtNasc.Focus();
            }
        }

        private void mskDtEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
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

        private void txtDDDRespons_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtFoneRespons_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtCPFRespons_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
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

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            if (txtCEP.Text.Trim() != "")
            {
                txtCEP.Text = Convert.ToUInt64(txtCEP.Text).ToString(@"00000000");
            }
        }

        private void mskValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);
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

        private void cboFPagto_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = cboFPagto.SelectedIndex;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Inicializa_Office();

            Limpar();

            Classes.clsFuncoes.OpenForm(new Forms.frmBackOfficeLocaliza(), this, "1");

            if (clsBackOffice.Bo_id_venda != "")
            {
                Preencher_Tela(clsBackOffice.Bo_id_venda);
            }


        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = cboFPagto.SelectedIndex; ;
        }

        private void cboPFPJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = cboPFPJ.SelectedIndex;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = cboPFPJ.SelectedIndex; ;
        }

        private void frmBackOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Inicializa_Office();
        }

        private void btnAcao_Click(object sender, EventArgs e)
        {
            if (clsBackOffice.Bo_id_venda != "" && cboAcao.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza ?", cboAcao.Text, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    switch (cboAcao.Text)
                    {
                        case "ATUALIZAR":
                            clsVariaveis.GstrSQL = "update Vendas set ";
                            Monta_String_Update();
                            clsVariaveis.GstrSQL += " ,Office = '" + clsUsuarioLogado.Usu_cpf + "' where Id_venda = " + clsBackOffice.Bo_id_venda;
                            if (clsBanco.ExecuteQuery(clsVariaveis.GstrSQL))
                            {
                                MessageBox.Show("Atualizado com sucesso", cboStatus.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

                        case "CONFIRMAR":

                            break;

                        case "DEVOLVER AO BACK":
                            clsVariaveis.GstrSQL = "update Vendas set Resultado = 'OK' ,Estorno = 0 ,St_Standby = 0 ,Uso_Office = 0 ,Office = '" + clsUsuarioLogado.Usu_cpf + "' ";
                            clsVariaveis.GstrSQL += " ,cor_estorno = null ,dt_cor_estorno = null ,cancel_office = null ,cancel_outros = null ,";
                            Monta_String_Update();
                            clsVariaveis.GstrSQL += "  where Id_venda = " + clsBackOffice.Bo_id_venda;
                            if (clsBanco.ExecuteQuery(clsVariaveis.GstrSQL))
                            {
                                MessageBox.Show("devolvido ao Back-Office com sucesso", cboStatus.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Limpar();
                            }
                            break;

                        case "ESTORNAR":
                            clsVariaveis.GstrSQL = "update Vendas set Resultado = 'OK' ,Estorno = 1 ,St_Standby = 0 ,Uso_Office = 0 ,Office = '" + clsUsuarioLogado.Usu_cpf + "' ";
                            clsVariaveis.GstrSQL += " ,cor_estorno = null ,dt_cor_estorno = null ,";
                            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("Dt_Estorno", DateTime.Now.ToString("yyyy-MM-dd"), "TEXT") + " ,";
                            Monta_String_Update();
                            clsVariaveis.GstrSQL += "  where Id_venda = " + clsBackOffice.Bo_id_venda;
                            if (clsBanco.ExecuteQuery(clsVariaveis.GstrSQL))
                            {
                                MessageBox.Show("estornado com sucesso", cboStatus.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Limpar();
                            }
                            break;

                        case "ENVIAR PARA STAND-BY":
                            if(cboStandby.Text != "")
                            {
                                clsVariaveis.GstrSQL = "update Vendas set Resultado = 'OK' ,St_Standby = 0 ,Uso_Office = 0 ,Office = '" + clsUsuarioLogado.Usu_cpf + "' ,";
                                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("Tp_standby", cboStandby.Text, "TEXT") + ", ";
                                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("Dt_Standby", DateTime.Now.ToString("yyyy-MM-dd"), "TEXT") + ", ";
                                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("Hr_standby", DateTime.Now.ToString("HH:mm:ss"), "TEXT") + ", ";
                                clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("Obs_standby", txtObsStandby.Text, "TEXT") + ", ";
                                Monta_String_Update();
                                clsVariaveis.GstrSQL += "  where Id_venda = " + clsBackOffice.Bo_id_venda;
                                if (clsBanco.ExecuteQuery(clsVariaveis.GstrSQL))
                                {
                                    MessageBox.Show("enviado para Stand_by com sucesso", cboStatus.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Limpar();
                                }
                            }
                            else
                            {
                                MessageBox.Show("informar o Stand-By desejado", cboStatus.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }


    }
}
