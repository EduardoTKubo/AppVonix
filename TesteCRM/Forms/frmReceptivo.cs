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
            InicializaVonix();
            PreencheGridAg();


            if (clsVonix.LogadoNoVonix == "NAO")
            {
                txtStatusVonix.Text = ConectaAoDiscador();
            }
            else
            {
                txtStatusVonix.Text = "LOGADO";
            }
        }

        private void Incluir_Receptivo()
        {
            Limpar();

            clsVariaveis.GstrSQL = "Insert into Receptivo ( data ,horario ,resultado ,operador ,nome ,ddd1 ,fone1 ,wave ,nomefila ,origem ) " +
                                   "values ( cast(getdate() as date) ,'" + DateTime.Now.ToString("HH:mm:ss") + "' ,NULL ,";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_cpf, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVonix.Contactname, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVariaveis.GstrDDD, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVariaveis.GstrTel, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVonix.CallFilename, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVonix.Queue, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaInsert(clsVonix.Queue, "TEXT") + ")";
            bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

            if (booIni)
            {
                clsVariaveis.GstrSQL = "select top 1 * from Receptivo where Data = cast(getdate() as date) " +
                               "and Operador = '" + clsUsuarioLogado.Usu_cpf +
                               "' and ddd1   = '" + clsVariaveis.GstrDDD +
                               "' and fone1  = '" + clsVariaveis.GstrTel +
                               "' and Resultado is NULL order by id_recept desc";
                DataTable dtR = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtR.Rows.Count > 0)
                {
                    clsReceptivo.Rec_Id_Recept = dtR.Rows[0]["id_recept"].ToString();
                    lblIdRecept.Text = dtR.Rows[0]["id_recept"].ToString();
                    cboOrigem.Text = dtR.Rows[0]["origem"].ToString();
                    txtNome.Text = dtR.Rows[0]["nome"].ToString();
                    txtDDD1.Text = dtR.Rows[0]["ddd1"].ToString();
                    txtFone1.Text = dtR.Rows[0]["fone1"].ToString();
                }
            }
        }

        private void Preenche_Agendado(string _idAg, string _idRecept)
        {
            DataTable dtR = Classes.clsBanco.Consulta("select * from Receptivo where Id_Recept = " + _idRecept);
            if (dtR.Rows.Count > 0)
            {
                InicializaVonix();

                clsReceptivo.Rec_Id_Recept = _idRecept;
                //clsVonix.CallFilename = dtR.Rows[0]["WAVE"].ToString();
                //clsVonix.Queue = dtR.Rows[0]["NOMEFILA"].ToString();
                clsVariaveis.GstrDDD = dtR.Rows[0]["ddd1"].ToString();
                clsVariaveis.GstrTel = dtR.Rows[0]["fone1"].ToString();

                lblIdAg.Text = _idAg;
                lblIdRecept.Text = _idRecept;

                cboOrigem.Text = dtR.Rows[0]["origem"].ToString();
                txtNome.Text = dtR.Rows[0]["nome"].ToString();
                txtDDD1.Text = dtR.Rows[0]["ddd1"].ToString();
                txtFone1.Text = dtR.Rows[0]["fone1"].ToString();
                txtEmail.Text = dtR.Rows[0]["email"].ToString();
                txtObs.Text = dtR.Rows[0]["obs"].ToString();

                //try
                //{
                //    vonix1.Dial(clsVariaveis.GstrDDD + clsVariaveis.GstrTel);
                //}
                //catch
                //{
                //    MessageBox.Show("Erro ao conectar com o Vonix", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

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
                lblIdRecept.Text = dtRcp.Rows[0]["id_recept"].ToString();
                clsReceptivo.Rec_Id_Recept = dtRcp.Rows[0]["id_recept"].ToString();
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

        private void Limpar()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);
        }

        private bool EncerraContato(string _codigo, string _uso, string _res)
        {
            bool resultado = false;

            if (lblIdRecept.Text == "")
            {
                bool booR = BuscarIdRecept();
                if (booR == false) { return resultado; }
            }


            if (lblIdAg.Text != "")
            {
                clsVariaveis.GstrSQL = "update Receptivo_AG set ativo = 0 where id_ag = " + lblIdAg.Text;
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
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("wave", clsVonix.CallFilename, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("nomefila", clsVonix.Queue, "TEXT") + ", ";
            clsVariaveis.GstrSQL += clsFuncoes.MontaUpdate("obs", txtObs.Text, "TEXT");
            clsVariaveis.GstrSQL += " where Id_Recept = " + lblIdRecept.Text;
            bool booIni = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            if (booIni)
            {
                //MessageBox.Show("tabulado com sucesso", _res, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Limpar();
                InicializaVonix();
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
                    EncerraContato(lblIdRecept.Text, _uso, _res);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Tem certeza ?", _res, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        EncerraContato(lblIdRecept.Text, _uso, _res);
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
            int nLin = dataGridView1.RowCount;
            if (nLin != 0)
            {
                dataGridView1.Enabled = false;
                int ID1 = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                int ID2 = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
                txtObsAg.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentRow.Index].Value);
                Preenche_Agendado(ID1.ToString(), ID2.ToString());
                dataGridView1.Enabled = true;
            }
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
                    return "LOGADO";
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
            txtStatusVonix.Text = ConectaAoDiscador();
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
            txtStatusLigacao.Text = "Discando";
        }

        private void vonix1_onDialAnswer(string CallId, string strDate)
        {
            // qdo a chamada é atendida
            txtStatusLigacao.Text = "Cliente Atendeu";
        }

        private void vonix1_onDialFailure(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            // qdo a chamada nao eh atendida ou falha
            txtStatusLigacao.Text = "encerrou ou falha na ligação";
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

            txtStatusLigacao.Text = "EM ATENDIMENTO";
            PreencheTel();

            cboOrigem.Text = Queue;
            txtNome.Text = ContactName;
            Incluir_Receptivo();

            //// quando receptivo ActionId = ""
            //if (ActionId == "")
            //{
            //    Incluir_Receptivo();
            //}
            //else
            //{
            //    cboOrigem.Text = Queue;
            //    txtNome.Text = ContactName;
            //}
            
        }

        private void vonix1_onReceiveAnswer(string CallId , string strDate , int WaitSeconds )
        {
            // qdo o agente atende a chamada
            txtStatusLigacao.Text = "chamada atendida";
        }

        private void vonix1_onReceiveFailure(string CallId , string strDate, int RingingSeconds)
        {
            // qdo o agente nao atende a chamada
            txtStatusLigacao.Text = "chamada descartada";
            EncerraContato(clsAtivo.Atv_cod, "0", "LIGACAO DESCARTADA");
        }


        private void PreencheTel()
        {
            if (clsVonix.From.Length > 10)
            {
                txtDDD1.Text = clsVonix.From.Substring(0, 2);
                txtFone1.Text = clsVonix.From.Substring(2, 9);
                clsVariaveis.GstrDDD = txtDDD1.Text;
                clsVariaveis.GstrTel = txtFone1.Text;
            }
            else
            {
                txtDDD1.Text = clsVonix.From.Substring(0, 2);
                txtFone1.Text = clsVonix.From.Substring(2, 8);
                clsVariaveis.GstrDDD = txtDDD1.Text;
                clsVariaveis.GstrTel = txtFone1.Text;
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

        private void timerLogando_Tick(object sender, EventArgs e)
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

        private void frmReceptivo_FormClosed(object sender, FormClosedEventArgs e)
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
                vonix1.Desconectar();
                vonix1.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtDDD1.Text != "" && txtFone1.Text != "")
            {
                try
                {
                    vonix1.Dial(txtDDD1.Text + txtFone1.Text);
                }
                catch
                {
                    MessageBox.Show("Erro ao conectar com o Vonix", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
