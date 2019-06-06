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
    public partial class frmPreditivo : Form
    {
        public frmPreditivo()
        {
            InitializeComponent();

            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Limpar();

            if (clsVonix.LogadoNoVonix == "NAO")
            {
                txtStatusVonix.Text = ConectaAoDiscador();
            }
            else
            {
                txtStatusVonix.Text = "LOGADO";
            }

        }



        private void InicializaVonix()
        {
            clsVonix.CallId = "";
            clsVonix.StrDate = "";
            clsVonix.Queue = "";
            clsVonix.From = "";
            clsVonix.To = "";
            clsVonix.CallFilename = "";
            clsVonix.Contactname = "";
            clsVonix.ActionId = "";
        }

        private bool EncerraContato(string _codigo, string _uso, string _res)
        {
            if (clsAtivo.Atv_id_ag != "")
            {
                clsVariaveis.GstrSQL = "update agenda set ativo = 0 where id_ag = " + clsAtivo.Atv_id_ag;
                bool booAg = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            }


            clsVariaveis.GstrSQL = "update CADASTRO set uso = " + _uso +
                                   " ,resultado = '" + _res +
                                   "' ,operador = '" + clsUsuarioLogado.Usu_cpf +
                                   "' ,data     = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                   "' ,horario  = '" + DateTime.Now.ToString("HH:mm:ss") +
                                   "' ,duracao  = '" + Classes.clsFuncoes.Duracao() +
                                   "' ,repasses = repasses + 1 ";
            clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("dddat", clsVariaveis.GstrDDD, "TEXT").ToString();
            clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("foneat", clsVariaveis.GstrTel, "TEXT").ToString();

            switch (clsVariaveis.GintQTelLigou)
            {
                case 1:
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso1", _uso, "INT").ToString();
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res1", _res, "TEXT").ToString();
                    break;

                case 2:
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso2", _uso, "INT").ToString();
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res2", _res, "TEXT").ToString();
                    break;

                case 3:
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso3", _uso, "INT").ToString();
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res3", _res, "TEXT").ToString();
                    break;

                case 4:
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso4", _uso, "INT").ToString();
                    clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res4", _res, "TEXT").ToString();
                    break;

                default:
                    break;
            }

            clsVariaveis.GstrSQL += "where codigo = " + _codigo;
            bool booEnc = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            if (booEnc)
            {

                Limpar();
                ListaAgendamento();
                return true;
            }
            else
            {
                return false;
            }

        }


        private void LimpaClsAtivo()
        {
            clsAtivo.Atv_cod = "";
            clsAtivo.Atv_origem = "";
            clsAtivo.Atv_tpOrigem = "";
            clsAtivo.Atv_nome = "";

            clsAtivo.Atv_id_ag = "";
            clsAtivo.Atv_obs_ag = "";

            clsAtivo.Atv_qTelAg = "";
            clsAtivo.Atv_ini_uso = "";
            clsAtivo.Atv_ini_oper = "";

            clsAtivo.Atv_ddd1 = "";
            clsAtivo.Atv_fone1 = "";
            clsAtivo.Atv_ddd2 = "";
            clsAtivo.Atv_fone2 = "";
            clsAtivo.Atv_ddd3 = "";
            clsAtivo.Atv_fone3 = "";
            clsAtivo.Atv_ddd4 = "";
            clsAtivo.Atv_fone4 = "";
        }


        private void LimpaClsVariaveis()
        {
            clsVariaveis.GstrDDD = "";
            clsVariaveis.GstrTel = "";
            clsVariaveis.GintQTelLigou = 0;
            clsVariaveis.GintPreditiva = 1;
            clsVariaveis.GstrNegativa = "";
        }


        private void Limpar()
        {
            LimpaClsAtivo();
            LimpaClsVariaveis();
            InicializaVonix();

            string sVonix = txtStatusVonix.Text;
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox3);
            clsFuncoes.LimpaCampos(this, groupBox8);
            txtStatusVonix.Text = sVonix;
            ListaAgendamento();
            this.lblCodigo.Text = "";
        }


        private void ListaAgendamento()
        {
            try
            {
                clsVariaveis.GstrSQL = "select id_ag ,data ,hora ,contato ,obs from Agenda where ativo = 1 and Operador = '" + clsUsuarioLogado.Usu_cpf + "' order by data,hora";

                dtgAg.DataSource = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtgAg.Rows.Count > 0)
                {
                    foreach (DataGridViewColumn column in dtgAg.Columns)
                    {
                        if (column.DataPropertyName == "id_ag")
                            column.Visible = false;
                        else
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lista Agendamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmPreditivo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (clsVonix.LogadoNoVonix == "SIM")
                {
                    vonix1.Logoff();
                }
                System.Threading.Thread.Sleep(2000);
                vonix1.Desconectar();
                vonix1.Dispose();
                clsVonix.LogadoNoVonix = "NAO";
            }
            catch
            {
                clsVonix.LogadoNoVonix = "NAO";
                vonix1.Desconectar();
                vonix1.Dispose();
            }
        }

        private void frmPreditivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsAtivo.Atv_cod != "")
            {
                if (clsAtivo.Atv_id_ag != "")
                {
                    clsVariaveis.GstrSQL = "UPDATE AGENDA SET ATIVO = 1 WHERE ID_AG = " + clsAtivo.Atv_id_ag;
                    bool booAg = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                    clsVariaveis.GstrSQL = "UPDATE CADASTRO SET USO = 9 where codigo = " + clsAtivo.Atv_cod;
                    bool booCad = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                }
                else
                {
                    clsVariaveis.GstrSQL = "UPDATE CADASTRO SET USO = 0 where codigo = " + clsAtivo.Atv_cod;
                    bool booCad = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                }

            }
        }


        private void PreencherTela(string _codigo, string _ddd, string _fone, string _ehAgenda, string _id_ag, string _obsAg)
        {
            clsVariaveis.GstrSQL = "select top 1 codigo from AUX_TEL_PRED where TELEFONE = '" + _ddd + _fone + "'";
            DataTable dt1 = new DataTable();
            dt1 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dt1.Rows.Count > 0)
            {
                _codigo = dt1.Rows[0]["id"].ToString();

                clsVariaveis.GstrSQL = ("select * from Cadastro where codigo = @cod ").Replace("@cod", clsAtivo.Atv_cod);
            }
            else
            {
                if (_codigo != "")
                {
                    clsVariaveis.GstrSQL = ("select * from Cadastro where codigo = @cod ").Replace("@cod", _codigo);
                }
                else
                {
                    return;
                }
            }

            DataTable dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtUsu.Rows.Count > 0)
            {

                LimpaClsVariaveis();
                LimpaClsAtivo();

                clsAtivo.Atv_cod = dtUsu.Rows[0]["codigo"].ToString();
                clsAtivo.Atv_origem = dtUsu.Rows[0]["origem"].ToString();
                clsAtivo.Atv_tpOrigem = dtUsu.Rows[0]["tp_origem"].ToString();
                clsAtivo.Atv_qTelAg = dtUsu.Rows[0]["qtelagendou"].ToString();
                clsAtivo.Atv_nome = dtUsu.Rows[0]["nome"].ToString();
                clsVariaveis.GstrDDD = _ddd;
                clsVariaveis.GstrTel = _fone;

                if (_ehAgenda == "AGENDA")
                {
                    clsAtivo.Atv_id_ag = _id_ag;
                    txtAgenda.Text = _obsAg;
                }

                lblDDD1.Text = _ddd;
                lblFone1.Text = _fone;

                lblCodigo.Text = dtUsu.Rows[0]["codigo"].ToString();

                lblNome.Text = dtUsu.Rows[0]["nome"].ToString();
                lblCPF.Text = dtUsu.Rows[0]["cpf"].ToString();
                lblEmail.Text = dtUsu.Rows[0]["email"].ToString();
                txtInforme.Text = dtUsu.Rows[0]["informe"].ToString();

                if (_fone == dtUsu.Rows[0]["fone1"].ToString())
                {
                    clsVariaveis.GintQTelLigou = 1;
                }
                else if (_fone == dtUsu.Rows[0]["fone2"].ToString())
                {
                    clsVariaveis.GintQTelLigou = 2;
                }
                else if (_fone == dtUsu.Rows[0]["fone3"].ToString())
                {
                    clsVariaveis.GintQTelLigou = 3;
                }
                else if (_fone == dtUsu.Rows[0]["fone4"].ToString())
                {
                    clsVariaveis.GintQTelLigou = 4;
                }
                else
                {
                    clsVariaveis.GintQTelLigou = 0;
                }

                txtDDD.Text = _ddd;
                txtFone.Text = _fone;

                clsVariaveis.GghIni = DateTime.Now;
            }
        }


        private void rbGeral(RadioButton _rb, string _uso, string _res, string _confirma)
        {
            if (clsAtivo.Atv_cod != "")
            {
                if (_confirma == "NAO")
                {
                    clsInsert.GravaLigacao(_res);
                    EncerraContato(clsAtivo.Atv_cod, _uso, _res);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Tem certeza ?", _res, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        clsInsert.GravaLigacao(_res);
                        EncerraContato(clsAtivo.Atv_cod, _uso, _res);
                    }
                }
            }
            _rb.Checked = false;
        }


        private void btnLocaliza_Click(object sender, EventArgs e)
        {
            if (txtFone.Text != "")
            {
                clsVariaveis.GstrSQL = "select top 1 codigo from Aux_Tel_Pred where Telefone = '" +
                                       txtDDD.Text + txtFone.Text + "' order by id desc";
                DataTable dtReg = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtReg.Rows.Count > 0)
                {
                    LimpaClsVariaveis();
                    LimpaClsAtivo();

                    clsAtivo.Atv_cod = dtReg.Rows[0]["codigo"].ToString();
                    clsVariaveis.GstrDDD = txtDDD.Text;
                    clsVariaveis.GstrTel = txtFone.Text;
                    PreencherTela(clsAtivo.Atv_cod, clsVariaveis.GstrDDD, clsVariaveis.GstrTel, "PREDITIVO", "", "");
                }
                else
                {
                    MessageBox.Show("Fone não localizado", "Preditivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void rbCP_Click(object sender, EventArgs e)
        {
            rbGeral(rbCP, "9", rbCP.Text, "SIM");
        }

        private void rbEC1_Click(object sender, EventArgs e)
        {
            rbGeral(rbEC1, "9", rbEC1.Text, "SIM");
        }

        private void rbMudo_Click(object sender, EventArgs e)
        {
            rbGeral(rbMudo, "9", "MUDO", "SIM");
        }

        private void rbLD_Click(object sender, EventArgs e)
        {
            rbGeral(rbLD, "9", rbLD.Text, "SIM");
        }

        private void rbLT_Click(object sender, EventArgs e)
        {
            rbGeral(rbLT, "9", rbLT.Text, "SIM");
        }

        private void rbLN_Click(object sender, EventArgs e)
        {
            rbGeral(rbLN, "9", rbLN.Text, "SIM");
        }

        private void rbAG_Click(object sender, EventArgs e)
        {
            if (clsAtivo.Atv_cod != "")
            {
                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsFuncoes.OpenFormModal(new Forms.frmAgendar());
                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbAG, "9", rbAG.Text, "NAO");
                }
            }
            rbAG.Checked = false;
        }

        private void rbNegativa_Click(object sender, EventArgs e)
        {
            if (clsAtivo.Atv_cod != "")
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
            if (clsAtivo.Atv_cod != "")
            {
                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsVariaveis.GstrNegativa = "";

                clsVenda.Vda_cod = clsAtivo.Atv_cod;
                clsVenda.Vda_origem = clsAtivo.Atv_origem;
                clsVenda.Vda_tpOrigem = clsAtivo.Atv_tpOrigem;
                clsVenda.Vda_nome = clsAtivo.Atv_nome;
                clsVenda.Vda_OriVda = "TLMK";
                clsVenda.Vda_auditor = "";
                Classes.clsFuncoes.OpenFormModal(new Forms.frmVenda());

                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbVenda, "9", "OK", "NAO");
                }
                else
                {
                    MessageBox.Show("Não houve confirmação", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            rbVenda.Checked = false;
        }

        private void dtgAg_DoubleClick(object sender, EventArgs e)
        {
            string ID = Convert.ToString(dtgAg[0, dtgAg.CurrentRow.Index].Value);

            clsVariaveis.GstrSQL = "select * from Agenda where Id_Ag = '" + ID + "' and ativo = 1";
            DataTable dt1 = new DataTable();
            dt1 = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dt1.Rows.Count > 0)
            {
                PreencherTela(dt1.Rows[0]["id"].ToString(),
                              dt1.Rows[0]["ddd"].ToString(),
                              dt1.Rows[0]["fone"].ToString(), "AGENDA",
                              dt1.Rows[0]["id_ag"].ToString(),
                              dt1.Rows[0]["OBS"].ToString());
            }
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmVisualizaVendas());
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmAgendas());
            ListaAgendamento();
        }




        private string ConectaAoDiscador()
        {
            txtStatusLigacao.Text = "";

            if (clsVonix.LogadoNoVonix == "SIM")
            {
                timerLogando.Enabled = false;
                return "LOGADO";
            }
            else
            {
                try
                {
                    vonix1.Pabx = "10.0.32.7";
                    vonix1.AgenteCod = clsUsuarioLogado.Usu_matricula.ToString();
                    vonix1.Connectar();

                    timerLogando.Enabled = false;
                    return "LOGANDO";
                }
                catch
                {
                    clsVonix.LogadoNoVonix = "NAO";
                    timerLogando.Enabled = true;
                    return "FALHA AO LOGAR NO VONIX";
                }
            }
        }


        private void vonix1_onConnect(string strDate, string ActionId)
        {
            // ocorre quando a conexao com o dialer é estabelecida
            //txtStatusVonix.Text = ConectaAoDiscador();

            timerLogando.Enabled = false;
            txtStatusVonix.Text = "LOGADO";
            txtStatusLigacao.Text = "";
        }

        private void vonix1_onDial(string CallId, string strDate, string Agent, string Queue, string From, string To, string CallFilename, string ContactName, string ActionId)
        {
            // qdo o agente realizado uma chamada
            //clsVonix.CallId = CallId;
            //clsVonix.StrDate = strDate.Substring(6, 4) + "-" + strDate.Substring(3, 2) + "-" + strDate.Substring(0, 2);
            clsVonix.Queue = Queue;
            //clsVonix.From = From;
            //clsVonix.To = To;
            clsVonix.CallFilename = CallFilename;
            //clsVonix.Contactname = ContactName;
            //clsVonix.ActionId = ActionId;
            txtStatusLigacao.Text = "Discando para : " + To;
        }

        private void vonix1_onDialAnswer(string CallId, string strDate)
        {
            // qdo a chamada é atendida
            txtStatusLigacao.Text = "Cliente Atendeu";
        }

        private void vonix1_onDialFailure(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            // qdo a chamada nao eh atendida ou falha
            txtStatusLigacao.Text = "encerramento : " + CauseDescription;
        }

        private void vonix1_onLogin(string strDate, string Location, string ActionId)
        {
            // qdo o agente se loga
            timerLogando.Enabled = false;
            txtStatusVonix.Text = "LOGADO";
            txtStatusLigacao.Text = "";
            clsVonix.LogadoNoVonix = "SIM";
        }

        private void vonix1_onLogoff(string strDate, string Location, int Duration, string ActionId)
        {
            // qdo o agente se desloga
            timerLogando.Enabled = true;
            txtStatusVonix.Text = "DESLOGADO";
            txtStatusLigacao.Text = "";
            clsVonix.LogadoNoVonix = "NAO";
        }

        private void vonix1_onPause(string strDate, int Reason, string ActionId)
        {
            // qdo o agente entra em pausa
            txtStatusLigacao.Text = "em pausa : " + Reason;
        }

        private void vonix1_onUnpause(string strDate, string ActionId)
        {
            // qdo o agente sai da pausa
            txtStatusLigacao.Text = "retorno da pausa  ";
        }

        private void vonix1_onReceive(string CallId, string strDate, string Queue, string From, string To, string CallFilename, string ContactName, string ActionId)
        {
            // qdo o agente recebe uma chamada
            Limpar();

            clsVonix.CallId = CallId;
            clsVonix.StrDate = strDate.Substring(6, 4) + "-" + strDate.Substring(3, 2) + "-" + strDate.Substring(0, 2);
            clsVonix.Queue = Queue;
            clsVonix.From = From;
            clsVonix.To = To;
            clsVonix.CallFilename = CallFilename;
            clsVonix.Contactname = ContactName;
            clsVonix.ActionId = ActionId;

            txtStatusLigacao.Text = "EM ATENDIMENTO : " + From;


            int pos = clsVonix.ActionId.IndexOf("-");
            if (pos >= 0)
            {
                clsVonix.ActionId = clsVonix.ActionId.Substring(0, pos);
            }
            clsAtivo.Atv_cod = clsVonix.ActionId;

            PreencheTel();
            PreencherTela(clsAtivo.Atv_cod, clsVariaveis.GstrDDD, clsVariaveis.GstrTel, "PREDITIVO", "", "");

        }

        private void vonix1_onReceiveAnswer(string CallId, string strDate, int WaitSeconds)
        {
            // qdo o agente atende a chamada
            txtStatusLigacao.Text = "chamada atendida";
        }

        private void vonix1_onReceiveFailure(string CallId, string strDate, int RingingSeconds)
        {
            // qdo o agente nao atende a chamada
            txtStatusLigacao.Text = "chamada descartada";
            EncerraContato(clsAtivo.Atv_cod, "0", "LIGACAO DESCARTADA");
        }


        private void PreencheTel()
        {
            if (clsVonix.From.Length > 10)
            {
                clsVariaveis.GstrDDD = clsVonix.From.Substring(0, 2);
                clsVariaveis.GstrTel = clsVonix.From.Substring(2, 9);
            }
            else
            {
                clsVariaveis.GstrDDD = clsVonix.From.Substring(0, 2);
                clsVariaveis.GstrTel = clsVonix.From.Substring(2, 8);
            }
        }

        private void vonix1_onHangUp(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            // ocorre no desligamento da chamada / discada ou recebida
            txtStatusLigacao.Text = "Ligação desligada";
        }

        private void vonix1_onStatus(string Status, string Location, string ActionId)
        {
            // ocorre em resposta a chamada do status
            txtStatusLigacao.Text = "";
            if (Status == "ONLINE")
            {
                timerLogando.Enabled = false;
                txtStatusVonix.Text = "LOGADO";
            }
            else
            {
                timerLogando.Enabled = true;
                txtStatusVonix.Text = "AGUARDANDO LOGAR NO VONIX";
            }
        }

        private void timerLogando_Tick_1(object sender, EventArgs e)
        {
            if (clsVonix.LogadoNoVonix == "NAO")
            {
                vonix1.Login();
                timerLogando.Enabled = false;
            }
            else
            {
                timerLogando.Enabled = true;
                vonix1.Status("");
            }
        }
    }
}
