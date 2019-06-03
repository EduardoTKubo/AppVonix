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
    public partial class frmAtivo : Form
    {
        private bool Deslog = false;

        public frmAtivo()
        {
            InitializeComponent();
            
            clsVariaveis.Usu_login_automatico = false;

            tsslabel1.Text = Application.ProductName.ToString();
            tsslabel2.Text = clsUsuarioLogado.Usu_nome.ToString();
            tsslabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                // references - System.Pabx  ver path no properties
                // declarar vonix1 em frmAtivo.Designers.cs

                vonix1.Pabx = "10.0.32.7";
                vonix1.AgenteCod = clsUsuarioLogado.Usu_matricula.ToString();
                vonix1.Connectar();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir o Vonix", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vonix1.Dispose();
                Application.Exit();
            }

            //BuscarRegistro();

        }

        private void InicializaConfigOperador()
        {
            
            clsUsuarioLogado.Usu_origem = "";
            clsUsuarioLogado.Usu_fila = "";
            clsUsuarioLogado.Usu_discador = "";

            clsVariaveis.GstrSQL = "select origem ,fila ,discador from Usuario where cpf = '" + clsUsuarioLogado.Usu_cpf + "' and ativo = 1";
            DataTable dtOpe = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtOpe.Rows.Count > 0)
            {
                clsUsuarioLogado.Usu_origem = dtOpe.Rows[0]["origem"].ToString();
                clsUsuarioLogado.Usu_fila = dtOpe.Rows[0]["fila"].ToString();
                clsUsuarioLogado.Usu_discador = dtOpe.Rows[0]["discador"].ToString();
            }
        }


        private void BuscarRegistro()
        {
            Limpar();
            InicializaConfigOperador();

            if (clsUsuarioLogado.Usu_discador != "PREDITIVA")
            {
                if (BuscarAgenda(clsUsuarioLogado.Usu_cpf) == false)
                {
                    if (BuscarRegLivre(clsUsuarioLogado.Usu_cpf) == false)
                    {
                        if (BuscarRepasse(clsUsuarioLogado.Usu_cpf) == false)
                        {
                            MessageBox.Show("sem registros", "Manual / Power", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }


        private bool BuscarAgenda(string _cpf)
        {
            clsVariaveis.GstrSQL = "select top 1 * from Agenda where Operador = '" + clsUsuarioLogado.Usu_cpf +
                                   "' and ativo = 1 and data <= '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                   "' and hora < '" + DateTime.Now.ToString("HH:mm:ss") + "' order by hora";
            DataTable dtAg = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtAg.Rows.Count > 0)
            {
                clsAtivo.Atv_cod = dtAg.Rows[0]["id"].ToString();
                clsAtivo.Atv_id_ag = dtAg.Rows[0]["id_ag"].ToString();
                clsAtivo.Atv_obs_ag = dtAg.Rows[0]["obs"].ToString();

                clsAtivo.Atv_ini_uso = "9";
                clsAtivo.Atv_ini_oper = dtAg.Rows[0]["operador"].ToString();

                PreencherTela(clsAtivo.Atv_cod, "AGENDA");
                return true;
            }
            else { return false; }
        }


        private bool BuscarRegLivre(string _cpf)
        {
            clsVariaveis.GstrSQL = ("EXEC sp_BuscaReg '" + clsUsuarioLogado.Usu_origem + "' ,'" + clsUsuarioLogado.Usu_cpf + "' ,0 ");
            bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

            clsVariaveis.GstrSQL = "select top 1 codigo ,operador ,resultado from Cadastro where Operador = '" + clsUsuarioLogado.Usu_cpf +
                                   "' and uso = 13 and Origem = '" + clsUsuarioLogado.Usu_origem + "'";
            DataTable dt = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dt.Rows.Count > 0)
            {
                clsAtivo.Atv_cod = dt.Rows[0]["codigo"].ToString();

                clsAtivo.Atv_ini_uso = "0";
                if (dt.Rows[0]["resultado"].ToString() == "")
                {
                    clsAtivo.Atv_ini_oper = "";
                }
                else
                {
                    clsAtivo.Atv_ini_oper = dt.Rows[0]["operador"].ToString();
                }

                PreencherTela(clsAtivo.Atv_cod, "");
                return true;
            }
            else { return false; }
        }


        private bool BuscarRepasse(string _cpf)
        {
            clsVariaveis.GstrSQL = "select top 1 codigo ,operador from Cadastro where uso = 8 and Origem = '" +
                                   clsUsuarioLogado.Usu_origem + "' and horario <= '" + DateTime.Now.ToString("hh:MM:ss") +
                                   "' order by data ,horario new() ";
            DataTable dt = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dt.Rows.Count > 0)
            {
                clsAtivo.Atv_cod = dt.Rows[0]["codigo"].ToString();

                clsAtivo.Atv_ini_uso = "8";
                clsAtivo.Atv_ini_oper = dt.Rows[0]["operador"].ToString();

                PreencherTela(clsAtivo.Atv_cod, "");
                return true;
            }
            else { return false; }
        }

        private void DisplayFone(string _seq, string _dddd, string _fone)
        {
            clsVariaveis.GstrDDD = _dddd;
            clsVariaveis.GstrTel = _fone;
            txtDDD.Text = _dddd;
            txtFone.Text = _fone;

            switch (_seq)
            {
                case "1":
                    lblDDD1.Text = _dddd;
                    lblFone1.Text = _fone;
                    lblDDD2.Text = "**";
                    lblFone2.Text = "********";
                    lblDDD3.Text = "**";
                    lblFone3.Text = "********";
                    lblDDD4.Text = "**";
                    lblFone4.Text = "********";
                    clsVariaveis.GintQTelLigou = 1;
                    break;
                case "2":
                    lblDDD1.Text = "**";
                    lblFone1.Text = "********";
                    lblDDD2.Text = _dddd;
                    lblFone2.Text = _fone;
                    lblDDD3.Text = "**";
                    lblFone3.Text = "********";
                    lblDDD4.Text = "**";
                    lblFone4.Text = "********";
                    clsVariaveis.GintQTelLigou = 2;
                    break;
                case "3":
                    lblDDD1.Text = "**";
                    lblFone1.Text = "********";
                    lblDDD2.Text = "**";
                    lblFone2.Text = "********";
                    lblDDD3.Text = _dddd;
                    lblFone3.Text = _fone;
                    lblDDD4.Text = "**";
                    lblFone4.Text = "********";
                    clsVariaveis.GintQTelLigou = 3;
                    break;
                case "4":
                    lblDDD1.Text = "**";
                    lblFone1.Text = "********";
                    lblDDD2.Text = "**";
                    lblFone2.Text = "********";
                    lblDDD3.Text = "**";
                    lblFone3.Text = "********";
                    lblDDD4.Text = _dddd;
                    lblFone4.Text = _fone;
                    clsVariaveis.GintQTelLigou = 4;
                    break;
                default:
                    clsVariaveis.GintQTelLigou = 0;
                    break;
            }
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
            clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("obs", txtObs.Text, "TEXT").ToString();

            if (lblDDD1.Text != "**")
            {
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso1", _uso, "INT").ToString();
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res1", _res, "TEXT").ToString();
            }
            else if (lblDDD2.Text != "**")
            {
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso2", _uso, "INT").ToString();
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res2", _res, "TEXT").ToString();
            }
            else if (lblDDD3.Text != "**")
            {
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso3", _uso, "INT").ToString();
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res3", _res, "TEXT").ToString();
            }
            else if (lblDDD4.Text != "**")
            {
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("uso4", _uso, "INT").ToString();
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("res4", _res, "TEXT").ToString();
            }

            if (_res == "AG")
            {
                clsVariaveis.GstrSQL += "," + clsFuncoes.MontaUpdate("qtelagendou", clsVariaveis.GintQTelLigou.ToString(), "INT").ToString();
            }
            else
            {
                clsVariaveis.GstrSQL += " ,qtelagendou = 0 ";
            }

            clsVariaveis.GstrSQL += "where codigo = " + _codigo;
            bool booEnc = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            if (booEnc)
            {
                BuscarRegistro();
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Limpar()
        {
            lblCodigo.Text = "";

            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);

            LimpaClsAtivo();
            LimpaClsVariaveis();
            this.lblCodigo.Text = "";
            this.Refresh();
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
            clsVariaveis.GintPreditiva = 0;
            clsVariaveis.GstrNegativa = "";
        }


        private void PreencheDadosFone(string _qfone)
        {
            switch (_qfone)
            {
                case "1":
                    lblDDD1.Text = clsAtivo.Atv_ddd1;
                    lblFone1.Text = clsAtivo.Atv_fone1;
                    clsVariaveis.GstrDDD = clsAtivo.Atv_ddd1;
                    clsVariaveis.GstrTel = clsAtivo.Atv_fone1;
                    clsVariaveis.GintQTelLigou = 1;
                    break;
                case "2":
                    lblDDD2.Text = clsAtivo.Atv_ddd2;
                    lblFone2.Text = clsAtivo.Atv_fone2;
                    clsVariaveis.GstrDDD = clsAtivo.Atv_ddd2;
                    clsVariaveis.GstrTel = clsAtivo.Atv_fone2;
                    clsVariaveis.GintQTelLigou = 2;
                    break;
                case "3":
                    lblDDD3.Text = clsAtivo.Atv_ddd3;
                    lblFone3.Text = clsAtivo.Atv_fone3;
                    clsVariaveis.GstrDDD = clsAtivo.Atv_ddd3;
                    clsVariaveis.GstrTel = clsAtivo.Atv_fone3;
                    clsVariaveis.GintQTelLigou = 3;
                    break;
                case "4":
                    lblDDD4.Text = clsAtivo.Atv_ddd4;
                    lblFone4.Text = clsAtivo.Atv_fone4;
                    clsVariaveis.GstrDDD = clsAtivo.Atv_ddd4;
                    clsVariaveis.GstrTel = clsAtivo.Atv_fone4;
                    clsVariaveis.GintQTelLigou = 4;
                    break;
                default:
                    break;
            }
        }


        private void PreencherTela(string _codigo, string _ehAgenda)
        {
            if (_ehAgenda == "AGENDA")
            {
                clsVariaveis.GstrSQL = ("select * from Cadastro where uso = 9 and codigo = @cod ").Replace("@cod", _codigo);
            }
            else
            {
                clsVariaveis.GstrSQL = ("select * from Cadastro where uso = 13 and codigo = @cod ").Replace("@cod", _codigo);
            }
            DataTable dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtUsu.Rows.Count > 0)
            {
                clsVariaveis.GghIni = DateTime.Now;
                clsAtivo.Atv_cod = dtUsu.Rows[0]["codigo"].ToString();
                clsAtivo.Atv_origem = dtUsu.Rows[0]["origem"].ToString();
                clsAtivo.Atv_tpOrigem = dtUsu.Rows[0]["tp_origem"].ToString();
                clsAtivo.Atv_qTelAg = dtUsu.Rows[0]["qtelagendou"].ToString();
                clsAtivo.Atv_nome = dtUsu.Rows[0]["nome"].ToString();

                lblDDD1.Text = "**";
                lblFone1.Text = "********";
                lblDDD2.Text = "**";
                lblFone2.Text = "********";
                lblDDD3.Text = "**";
                lblFone3.Text = "********";
                lblDDD4.Text = "**";
                lblFone4.Text = "********";

                lblCodigo.Text = dtUsu.Rows[0]["codigo"].ToString();

                lblNome.Text = dtUsu.Rows[0]["nome"].ToString();
                lblCPF.Text = dtUsu.Rows[0]["cpf"].ToString();
                lblEmail.Text = dtUsu.Rows[0]["email"].ToString();
                txtInforme.Text = dtUsu.Rows[0]["informe"].ToString();

                txtDDD.Text = dtUsu.Rows[0]["dddat"].ToString();
                txtFone.Text = dtUsu.Rows[0]["foneat"].ToString();
                txtObs.Text = dtUsu.Rows[0]["obs"].ToString();

                switch (dtUsu.Rows[0]["uso1"].ToString())
                {
                    case "0":
                    case "8":
                        clsAtivo.Atv_ddd1 = dtUsu.Rows[0]["ddd1"].ToString();
                        clsAtivo.Atv_fone1 = dtUsu.Rows[0]["fone1"].ToString();
                        break;
                    case "9":
                        if (dtUsu.Rows[0]["res1"].ToString() == "AG")
                        {
                            clsAtivo.Atv_ddd1 = dtUsu.Rows[0]["ddd1"].ToString();
                            clsAtivo.Atv_fone1 = dtUsu.Rows[0]["fone1"].ToString();
                        }
                        break;
                    default:
                        break;
                }

                switch (dtUsu.Rows[0]["uso2"].ToString())
                {
                    case "0":
                    case "8":
                        clsAtivo.Atv_ddd2 = dtUsu.Rows[0]["ddd2"].ToString();
                        clsAtivo.Atv_fone2 = dtUsu.Rows[0]["fone2"].ToString();
                        break;
                    case "9":
                        if (dtUsu.Rows[0]["res2"].ToString() == "AG")
                        {
                            clsAtivo.Atv_ddd2 = dtUsu.Rows[0]["ddd2"].ToString();
                            clsAtivo.Atv_fone2 = dtUsu.Rows[0]["fone2"].ToString();
                        }
                        break;
                    default:
                        break;
                }

                switch (dtUsu.Rows[0]["uso3"].ToString())
                {
                    case "0":
                    case "8":
                        clsAtivo.Atv_ddd3 = dtUsu.Rows[0]["ddd3"].ToString();
                        clsAtivo.Atv_fone3 = dtUsu.Rows[0]["fone3"].ToString();
                        break;
                    case "9":
                        if (dtUsu.Rows[0]["res3"].ToString() == "AG")
                        {
                            clsAtivo.Atv_ddd3 = dtUsu.Rows[0]["ddd3"].ToString();
                            clsAtivo.Atv_fone3 = dtUsu.Rows[0]["fone3"].ToString();
                        }
                        break;
                    default:
                        break;
                }

                switch (dtUsu.Rows[0]["uso4"].ToString())
                {
                    case "0":
                    case "8":
                        clsAtivo.Atv_ddd4 = dtUsu.Rows[0]["ddd4"].ToString();
                        clsAtivo.Atv_fone4 = dtUsu.Rows[0]["fone4"].ToString();
                        break;
                    case "9":
                        if (dtUsu.Rows[0]["res4"].ToString() == "AG")
                        {
                            clsAtivo.Atv_ddd4 = dtUsu.Rows[0]["ddd4"].ToString();
                            clsAtivo.Atv_fone4 = dtUsu.Rows[0]["fone4"].ToString();
                        }
                        break;
                    default:
                        break;
                }


                if (_ehAgenda == "AGENDA")
                {
                    txtAgenda.Text = clsAtivo.Atv_obs_ag.ToString();

                AG1:
                    switch (clsAtivo.Atv_qTelAg)
                    {
                        case "1":
                            if (clsAtivo.Atv_fone1 != "")
                            {
                                PreencheDadosFone("1");
                                break;
                            }
                            else
                            {
                                clsAtivo.Atv_qTelAg = "2";
                                goto AG1;
                            }
                        case "2":
                            if (clsAtivo.Atv_fone2 != "")
                            {
                                PreencheDadosFone("2");
                                break;
                            }
                            else
                            {
                                clsAtivo.Atv_qTelAg = "3";
                                goto AG1;
                            }

                        case "3":
                            if (clsAtivo.Atv_fone3 != "")
                            {
                                PreencheDadosFone("3");
                                break;
                            }
                            else
                            {
                                clsAtivo.Atv_qTelAg = "4";
                                goto AG1;
                            }

                        case "4":
                            if (clsAtivo.Atv_fone4 != "")
                            {
                                PreencheDadosFone("4");
                                break;
                            }
                            else
                            {
                                clsAtivo.Atv_qTelAg = "5";
                                goto AG1;
                            }
                        default:
                            clsVariaveis.GstrSQL = ("UPDATE CADASTRO SET USO = 101 WHERE CODIGO = @codigo").Replace("@codigo", lblCodigo.Text);
                            bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                            BuscarRegistro();
                            break;
                    }
                }
                else
                {
                    if (clsAtivo.Atv_fone1 != "")
                    {
                        PreencheDadosFone("1");
                    }
                    else if (clsAtivo.Atv_fone2 != "")
                    {
                        PreencheDadosFone("2");
                    }
                    else if (clsAtivo.Atv_fone3 != "")
                    {
                        PreencheDadosFone("3");
                    }
                    else if (clsAtivo.Atv_fone4 != "")
                    {
                        PreencheDadosFone("4");
                    }
                    else
                    {
                        clsVariaveis.GstrSQL = ("UPDATE CADASTRO SET USO = 100 WHERE CODIGO = @codigo").Replace("@codigo", lblCodigo.Text);
                        bool booDel = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                        BuscarRegistro();
                        return;
                    }
                }


            }
        }

        public void Tentativa(string _codigo, string _uso, string _res)
        {
            bool _achou = true;

            switch (clsVariaveis.GintQTelLigou)
            {
                case 1:
                    clsVariaveis.GstrSQL = ("UPDATE CADASTRO SET USO1 = " + _uso + " ,res1 = '" + _res + "'  WHERE CODIGO = " + _codigo);
                    bool boo1 = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                    if (clsAtivo.Atv_fone2 != "")
                    {
                        DisplayFone("2", clsAtivo.Atv_ddd2, clsAtivo.Atv_fone2);
                    }
                    else if (clsAtivo.Atv_fone3 != "")
                    {
                        DisplayFone("3", clsAtivo.Atv_ddd3, clsAtivo.Atv_fone3);
                    }
                    else if (clsAtivo.Atv_fone4 != "")
                    {
                        DisplayFone("4", clsAtivo.Atv_ddd4, clsAtivo.Atv_fone4);
                    }
                    else
                    {
                        _achou = false;
                    }
                    break;

                case 2:
                    clsVariaveis.GstrSQL = ("UPDATE CADASTRO SET USO2 = " + _uso + " ,res2 = '" + _res + "'  WHERE CODIGO = " + _codigo);
                    bool boo2 = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                    if (clsAtivo.Atv_fone3 != "")
                    {
                        DisplayFone("3", clsAtivo.Atv_ddd3, clsAtivo.Atv_fone3);
                    }
                    else if (clsAtivo.Atv_fone4 != "")
                    {
                        DisplayFone("4", clsAtivo.Atv_ddd4, clsAtivo.Atv_fone4);
                    }
                    else
                    {
                        _achou = false;
                    }
                    break;

                case 3:
                    clsVariaveis.GstrSQL = ("UPDATE CADASTRO SET USO3 = " + _uso + " ,res3 = '" + _res + "'  WHERE CODIGO = " + _codigo);
                    bool boo3 = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                    if (clsAtivo.Atv_fone4 != "")
                    {
                        DisplayFone("4", clsAtivo.Atv_ddd4, clsAtivo.Atv_fone4);
                    }
                    else
                    {
                        _achou = false;
                    }
                    break;

                case 4:
                    _achou = false;
                    break;
            }

            if (_achou == false)
            {
                EncerraContato(_codigo, _uso, _res);
            }
            else
            {
                txtDDD.Text = clsVariaveis.GstrDDD;
                txtFone.Text = clsVariaveis.GstrTel;
                // discar
            }

        }

        private void rbGeral(RadioButton _rb, string _uso, string _res, string _tentativa, string _confirma)
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
                        if (_tentativa == "SIM")
                        {
                            Tentativa(clsAtivo.Atv_cod, _uso, _res);
                        }
                        else
                        {
                            EncerraContato(clsAtivo.Atv_cod, _uso, _res);
                        }
                    }
                }
            }
            _rb.Checked = false;
        }


        private void rbCP_Click(object sender, EventArgs e)
        {
            rbGeral(rbCP, "9", rbCP.Text, "SIM", "SIM");
        }

        private void rbEC1_Click(object sender, EventArgs e)
        {
            rbGeral(rbEC1, "9", rbEC1.Text, "SIM", "SIM");
        }

        private void rbNA_Click(object sender, EventArgs e)
        {
            rbGeral(rbNA, "8", rbNA.Text, "SIM", "SIM");
        }

        private void rbMudo_Click(object sender, EventArgs e)
        {
            rbGeral(rbMudo, "8", "MUDO", "SIM", "SIM");
        }

        private void rbOC_Click(object sender, EventArgs e)
        {
            rbGeral(rbOC, "8", rbOC.Text, "SIM", "SIM");
        }

        private void rbLD_Click(object sender, EventArgs e)
        {
            rbGeral(rbLD, "9", rbLD.Text, "NAO", "SIM");
        }

        private void rbLT_Click(object sender, EventArgs e)
        {
            rbGeral(rbLT, "9", rbLT.Text, "NAO", "SIM");
        }

        private void rbLN_Click(object sender, EventArgs e)
        {
            rbGeral(rbLN, "9", rbLN.Text, "NAO", "SIM");
        }

        private void rbTelNE_Click(object sender, EventArgs e)
        {
            rbGeral(rbTelNE, "9", "Telefone não existe", "SIM", "SIM");
        }

        private void frmAtivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsAtivo.Atv_cod != "")
            {
                if (clsAtivo.Atv_id_ag != "")
                {
                    clsVariaveis.GstrSQL = "UPDATE AGENDA SET ATIVO = 1 WHERE ID_AG = " + clsAtivo.Atv_id_ag;
                    bool booAg = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
                }
                clsVariaveis.GstrSQL = "UPDATE CADASTRO SET USO = " + clsAtivo.Atv_ini_uso;
                clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaUpdate("OPERADOR", clsAtivo.Atv_ini_oper, "TEXT");
                clsVariaveis.GstrSQL += " where codigo = " + clsAtivo.Atv_cod;
                bool booCad = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            }
        }

        private void rbAG_Click(object sender, EventArgs e)
        {
            if (clsAtivo.Atv_cod != "")
            {
                Classes.clsVariaveis.SalvarInformacao = false;
                Classes.clsFuncoes.OpenFormModal(new Forms.frmAgendar());
                if (Classes.clsVariaveis.SalvarInformacao)
                {
                    rbGeral(rbAG, "9", rbAG.Text, "NAO","NAO");
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
                    rbGeral(rbNegativa, "9", Classes.clsVariaveis.GstrNegativa, "NAO","NAO");
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
                    rbGeral(rbVenda, "9", "OK", "NAO","NAO");
                }
            }
            rbVenda.Checked = false;
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmVisualizaVendas());
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenFormModal(new Forms.frmAgendas());
        }


        private void vonix1_onConnectVx(string strDate, string ActionId)
        {
            timerLogando.Enabled = true;

            if (Classes.clsVariaveis.Usu_login_automatico)
            {
                txtStatusVonix.Text = "LOGANDO NO VONIX";
            }
            else
            {
                txtStatusVonix.Text = "AGUARDANDO LOGAR NO VONIX";
            }
        }

        private void vonix1_onDialVx(string CallId, string strDate, string Agent, string Queue, string From, string To, string CallFilename, string ContactName, string ActionId)
        {
            //Classes.Receive.CallId = CallId;
            //Classes.Receive.StrDate = strDate.Substring(6, 4) + "-" + strDate.Substring(3, 2) + "-" + strDate.Substring(0, 2);
            //Classes.Receive.Queue = Queue;
            //Classes.Receive.From = From;
            //Classes.Receive.To = To;
            //Classes.Receive.CallFilename = CallFilename;
            //Classes.Receive.ActionId = ActionId;

            txtStatusVonix.Text = "ATENDIMENTO";
            //txtStatusVonix.BackColor = Color.Green;
        }

        private void vonix1_onLoginVx(string strDate, string Location, string ActionId)
        {
            txtStatusVonix.Text = "DISPONIVEL";
            //txtStatusVonix.BackColor = Color.Gray;
        }

        private void vonix1_onDialFailureVx(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            txtStatusVonix.Text = "DISPONIVEL";
            //txtStatusVonix.BackColor = Color.Gray;
        }

        private void vonix1_onHangUpVx(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            //BuscaAgendamento();
            txtStatusVonix.Text = "DISPONIVEL";
            //txtStatusVonix.BackColor = Color.Gray;
        }

        private void vonix1_onStatusVx(string Status, string Location, string ActionId)
        {
            if (Status == "ONLINE")
            {
                timerLogando.Enabled = false;
                //tsslRamal.Text = " Ramal: " + Location;
                txtStatusVonix.Text = "DISPONIVEL";
                //txtStatusVonix.BackColor = Color.Gray;
            }
            else
            {
                txtStatusVonix.Text = "AGUARDANDO LOGAR NO VONIX";
            }
        }

        private void timerLogando_Tick(object sender, EventArgs e)
        {
            if (Classes.clsVariaveis.Usu_login_automatico)
            {
                vonix1.Login();
                timerLogando.Enabled = false;
            }
            else
            {
                vonix1.Status("");
            }
        }

        private void frmAtivo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!Deslog)
                {
                    Deslog = true;
                    if (Classes.clsVariaveis.Usu_login_automatico)
                    {
                        vonix1.Logoff();
                    }
                    System.Threading.Thread.Sleep(2000);
                    vonix1.Desconectar();
                }
                else
                {
                    //if (vonix1.ErroLogoff)
                    //{
                    //    MessageBox.Show("Ocorreu um erro ao deslogar o Agente do Vonix." + Environment.NewLine +
                    //    "Deslog o Agente no Tristerix", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    this.Dispose();
                    //
                }
            }
            catch
            {
                vonix1.Desconectar();
                vonix1.Dispose();
            }
        }
    }
}
