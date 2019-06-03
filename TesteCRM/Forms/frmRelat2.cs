using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace TesteCRM.Forms
{
    public partial class frmRelat2 : Form
    {
        public frmRelat2()
        {
            InitializeComponent();

            this.Text = clsRelatorio.Rel_titulo;

            dtPicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1));
            dtPicker2.Value = DateTime.Today;
            dataGridView1.DataSource = "";

            Preencher_CboParametro();

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (cboParametro.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                btnListar.Enabled = false;

                switch (clsRelatorio.Rel_titulo)
                {
                    case "ATIVO - RELAT_POR_BASE":
                        Relat_Base_Ativo_Todos(cboParametro.Text, dtPicker1.Value.ToString(), dtPicker2.Value.ToString());
                        break;

                    case "REL_P_BASE_RECEPTIVO":
                        Relat_Base_Receptivo_Todos(cboParametro.Text, dtPicker1.Value.ToString(), dtPicker2.Value.ToString());
                        break;

                    default:
                        Preencher_Grid();
                        break;
                }
                this.Cursor = Cursors.Default;
                btnListar.Enabled = true;
            }
        }

        private void Enumerar_DataGrid(DataGridView dgv)
        {
            dgv.RowHeadersWidth = 60;
            int numRows = dgv.Rows.Count;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if(row.Index < numRows -1)
                {
                    row.HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void Preencher_CboParametro()
        {
            cboParametro.Items.Clear();
            cboParametro.Items.Add("");
            switch (clsRelatorio.Rel_titulo)
            {
                case "ATIVO - TABULACAO POR OPERADOR":
                case "ATIVO - TABULACAO":
                case "VENDAS":
                    lblParametro.Text = "Equipe";
                    foreach (DataRow item in Classes.clsBanco.Consulta("select descricao from tab_geral where titulo = 'EQUIPE' and ativo = 1 order by descricao").Rows)
                    {
                        cboParametro.Items.Add(item[0].ToString());
                    }
                    cboParametro.Items.Add("TODOS");
                    break;

                case "ATIVO - RELAT_POR_BASE":
                    lblParametro.Text = "Origem";
                    foreach (DataRow item in Classes.clsBanco.Consulta("select ORIGEM from vi_Resultados where data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' group by Origem order by Origem ").Rows)
                    {
                        cboParametro.Items.Add(item[0].ToString());
                    }
                    cboParametro.Items.Add("TODOS");
                    break;

                case "RECEPTIVO - RELAT_POR_BASE":
                case "RECEPTIVO - TABULACAO POR OPERADOR":
                case "RECEPTIVO - TABULACAO POR ORIGEM":
                    lblParametro.Text = "Origem";
                    foreach (DataRow item in Classes.clsBanco.Consulta("select ORIGEM from Receptivo where origem is not null and data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' group by Origem order by Origem ").Rows)
                    {
                        cboParametro.Items.Add(item[0].ToString());
                    }
                    cboParametro.Items.Add("TODOS");
                    break;
            }
        }

        private void Preencher_Grid()
        {
            switch (clsRelatorio.Rel_titulo)
            {
                case "ATIVO - TABULACAO":
                    clsVariaveis.GstrSQL = "select turno ,resultado ,count(*) qtd from vi_Resultados where ";
                    if (this.cboParametro.Text != "TODOS")
                    {
                        clsVariaveis.GstrSQL += " Turno = '" + cboParametro.Text + "' and ";
                    }
                    clsVariaveis.GstrSQL += " data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' group by turno ,resultado order by turno ,resultado ";
                    break;

                case "ATIVO - TABULACAO POR OPERADOR":
                    clsVariaveis.GstrSQL = "select turno ,operador ,resultado ,count(*) qtd from vi_Resultados where ";
                    if (this.cboParametro.Text != "TODOS")
                    {
                        clsVariaveis.GstrSQL += " Turno = '" + cboParametro.Text + "' and ";
                    }
                    clsVariaveis.GstrSQL += " data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' group by turno ,operador ,resultado order by turno ,operador ,resultado ";
                    break;

                case "VENDAS":
                    clsVariaveis.GstrSQL = "select * from vivendas2 where ";
                    if (this.cboParametro.Text != "TODOS")
                    {
                        clsVariaveis.GstrSQL += " Turno = '" + cboParametro.Text + "' and ";
                    }
                    clsVariaveis.GstrSQL += " data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") + "' order by data ,hora ";
                    break;

                case "RECEPTIVO - TABULACAO POR OPERADOR":
                    clsVariaveis.GstrSQL = "select u.turno ,u.nomecompleto as operador ,r.resultado ,count(*) as qtd " +
                                           "from Receptivo as r inner join Usuario as u on u.cpf = r.operador " +
                                           "where r.resultado is not null and ";
                    if (this.cboParametro.Text != "TODOS")
                    {
                        clsVariaveis.GstrSQL += " r.origem = '" + cboParametro.Text + "' and ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " r.origem is not null and ";
                    }
                    clsVariaveis.GstrSQL += " r.data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") +
                                            "' group by u.turno ,u.nomecompleto ,r.resultado order by u.turno ,u.nomecompleto ,r.resultado ";
                    break;

                case "RECEPTIVO - TABULACAO POR ORIGEM":
                    clsVariaveis.GstrSQL = "select resultado ,count(*) as qtd from Receptivo where resultado is not null and ";
                    if (this.cboParametro.Text != "TODOS")
                    {
                        clsVariaveis.GstrSQL += " origem = '" + cboParametro.Text + "' and ";
                    }
                    else
                    {
                        clsVariaveis.GstrSQL += " origem is not null and ";
                    }
                    clsVariaveis.GstrSQL += " data between '" + dtPicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dtPicker2.Value.ToString("yyyy-MM-dd") +
                                            "' group by resultado order by resultado ";
                    break;
            }

            dataGridView1.DataSource = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                //lblTotal.Text = dataGridView1.Rows.Count.ToString();

                switch (clsRelatorio.Rel_titulo)
                {
                    case "VENDAS":
                        Enumerar_DataGrid(dataGridView1);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("nada encontrado para o periodo informado", clsRelatorio.Rel_titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Relat_Base_Ativo(string _origem, string _dtIni, string _dtFim)
        {
            bool booExec = false;

            clsVariaveis.GstrSQL = "delete from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "'";
            booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);


            clsVariaveis.GstrSQL = "insert into Aux_Relat ( usuario ,origem ,uso ,resultado ,codigo ) select '" + clsUsuarioLogado.Usu_cpf + "' ,origem ,uso ,resultado ,codigo from Cadastro ";
            clsVariaveis.GstrSQL += "where Origem = '" + _origem + "' and data between '" +
                                    Convert.ToDateTime(_dtIni).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(_dtFim).ToString("yyyy-MM-dd") + "'";
            booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

            // criando array aTotal
            int[] aTotal;
            aTotal = new int[40];

            DataTable dtPesq;
            // total da base
            clsVariaveis.GstrSQL = "select count(*) qtd from Cadastro where Origem = '" + _origem + "'";
            dtPesq = new DataTable();
            dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtPesq.Rows.Count != 0)
            {
                aTotal[5] = Convert.ToInt32(dtPesq.Rows[0]["qtd"].ToString());
            }

            // total da bloqueado
            clsVariaveis.GstrSQL = "select count(*) qtd from Cadastro where Origem = '" + _origem + "' and Uso > 501 ";
            dtPesq = new DataTable();
            dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtPesq.Rows.Count != 0)
            {
                aTotal[6] = Convert.ToInt32(dtPesq.Rows[0]["qtd"].ToString());
            }

            // total por status
            clsVariaveis.GstrSQL = "select resultado ,count(*) as qtd from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "' and resultado is not null group by resultado order by resultado";
            dtPesq = new DataTable();
            dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtPesq.Rows.Count != 0)
            {
                foreach (DataRow row in dtPesq.Rows)
                {
                    switch (row["resultado"].ToString())
                    {
                        case "CP":
                        case "FAX":
                        case "SE":
                        case "MO":
                            aTotal[13] = aTotal[13] + Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "LIGAÇÃO MUDA":
                            aTotal[14] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "LD":
                        case "LT":
                        case "LN":
                        case "NE":
                        case "AG":
                        case "Ligação descartada":
                            aTotal[15] = aTotal[15] + Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "OC":
                            aTotal[16] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "NA":
                            aTotal[17] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "TELEFONE FORA DE SERVIÇO":
                            aTotal[18] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "TELEFONE NÃO EXISTE":
                            aTotal[19] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "EC1":
                            aTotal[20] = Convert.ToInt32(row["qtd"].ToString());
                            break;

                        case "ACHOU CARO":
                            aTotal[23] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "CLIENTE JÁ FECHOU RENOVAÇÃO NO BOLETO":
                            aTotal[24] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "DESEMPREGADO":
                            aTotal[25] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "INSATISFAÇÃO COM A CARSYSTEM":
                            aTotal[26] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "JÁ É CLIENTE":
                            aTotal[27] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "MORTE/FALECIMENTO":
                            aTotal[28] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "NÃO POSSUI CARTÃO E CHEQUE":
                            aTotal[29] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "NÃO POSSUI VEÍCULO":
                            aTotal[30] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "OPTOU POR SEGURADORA OU CONCORRÊNCIA":
                            aTotal[31] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "PROBLEMAS FINANCEIROS":
                            aTotal[32] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "RECUSOU-SE A FALAR":
                            aTotal[33] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "SEM INTERESSE":
                            aTotal[34] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "SEM INTERESSE NA RENOVAÇÃO":
                            aTotal[35] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        case "OK":
                            aTotal[36] = Convert.ToInt32(row["qtd"].ToString());
                            break;
                        default:
                            break;
                    }
                }

                // preparando excel
                string sOrigem = @"C:\Ekubo\Sistemas\CarSystem\Fonte\RELATORIO_CarSystem_MOD_50.xlsx";
                string sDestino = @"\\srvfiles\CRM\Relatorios\CarSystem\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_RELATORIO_CarSystem_MOD_50.xlsx";
                System.IO.File.Copy(sOrigem, sDestino);


                Excel.Workbook objwBook;
                Excel.Worksheet objwSheet;
                Excel.Application app = new Excel.Application();

                if (app == null)
                {
                    MessageBox.Show("Excel nao instalado", clsRelatorio.Rel_titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                objwBook = app.Workbooks.Open(sDestino);
                objwSheet = (Excel.Worksheet)objwBook.Sheets["Plan1"];

                objwSheet.Cells[1, 2] = _origem;
                objwSheet.Cells[2, 2] = "Período " + _dtIni + " a " + _dtFim;

                objwSheet.Cells[5, 3] = aTotal[5];
                objwSheet.Cells[6, 3] = aTotal[6];

                objwSheet.Cells[13, 3] = aTotal[13];
                objwSheet.Cells[14, 3] = aTotal[14];
                objwSheet.Cells[15, 3] = aTotal[15];
                objwSheet.Cells[16, 3] = aTotal[16];
                objwSheet.Cells[17, 3] = aTotal[17];
                objwSheet.Cells[18, 3] = aTotal[18];
                objwSheet.Cells[19, 3] = aTotal[19];
                objwSheet.Cells[20, 3] = aTotal[20];

                objwSheet.Cells[23, 3] = aTotal[23];
                objwSheet.Cells[24, 3] = aTotal[24];
                objwSheet.Cells[25, 3] = aTotal[25];
                objwSheet.Cells[26, 3] = aTotal[26];
                objwSheet.Cells[27, 3] = aTotal[27];
                objwSheet.Cells[28, 3] = aTotal[28];
                objwSheet.Cells[29, 3] = aTotal[29];
                objwSheet.Cells[30, 3] = aTotal[30];
                objwSheet.Cells[31, 3] = aTotal[31];
                objwSheet.Cells[32, 3] = aTotal[32];
                objwSheet.Cells[33, 3] = aTotal[33];
                objwSheet.Cells[34, 3] = aTotal[34];
                objwSheet.Cells[35, 3] = aTotal[35];

                objwSheet.Cells[36, 3] = aTotal[36];


                // excluindo planilhas nao utilizadas
                for (int i = 50; i > 1; i--)
                {
                    //excluir da ultima para a primeira 50 ,49 ,48 ...
                    app.DisplayAlerts = false;
                    ((Excel.Worksheet)app.Application.ActiveWorkbook.Sheets[i]).Delete();
                    app.DisplayAlerts = true;
                }

                // salvando e fechando arquivo excel
                objwBook.Save();
                objwBook.Close(true);

                // eliminando excel da memoria
                objwSheet = null;
                objwBook = null;
                app.Quit();
                Marshal.ReleaseComObject(app);
                app = null;


                // abrindo o arquivo excel salvo 
                Process.Start(@sDestino);
            }
            else
            {
                MessageBox.Show("Nada a processar", clsRelatorio.Rel_titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void Relat_Base_Ativo_Todos(string _origem, string _dtIni, string _dtFim)
        {
            bool booExec = false;

            clsVariaveis.GstrSQL = "delete from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "'";
            booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);


            // criando array aOrigem
            int iIdx = 0;
            string[] aOrigem;
            aOrigem = new string[50];


            if (cboParametro.Text == "TODOS")
            {
                for (int i = 1; i < cboParametro.Items.Count - 1; i++)
                {
                    //excluir da ultima para a primeira 50 ,49 ,48 ...
                    cboParametro.SelectedIndex = i;
                    aOrigem[i] = cboParametro.Text;
                }
                iIdx = cboParametro.Items.Count - 2;
                cboParametro.SelectedIndex = cboParametro.Items.Count - 1;
            }
            else
            {
                iIdx = 1;
                aOrigem[1] = cboParametro.Text;
            }


            // preparando excel
            string sOrigem = @"C:\Ekubo\Sistemas\CarSystem\Fonte\RELATORIO_CarSystem_MOD_50.xlsx";
            string sDestino = @"\\srvfiles\CRM\Relatorios\CarSystem\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_RELATORIO_CarSystem_MOD_50.xlsx";
            System.IO.File.Copy(sOrigem, sDestino);

            Excel.Workbook objwBook;
            Excel.Worksheet objwSheet;
            Excel.Application app = new Excel.Application();
            //if (app == null)
            //{
            //    MessageBox.Show("Excel nao instalado", clsRelatorio.Rel_titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            objwBook = app.Workbooks.Open(sDestino);



            // criando array aTotal por origem
            int[] aTotal;
            DataTable dtPesq;

            for (int j = 1; j < iIdx + 1; j++)
            {
                clsVariaveis.GstrSQL = "insert into Aux_Relat ( usuario ,origem ,uso ,resultado ,codigo ) select '" + clsUsuarioLogado.Usu_cpf + "' ,origem ,uso ,resultado ,codigo from Cadastro ";
                clsVariaveis.GstrSQL += "where Origem = '" + aOrigem[j] + "' and data between '" +
                                        Convert.ToDateTime(_dtIni).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(_dtFim).ToString("yyyy-MM-dd") + "'";
                booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                aTotal = new int[40];

                // total da base
                clsVariaveis.GstrSQL = "select count(*) qtd from Cadastro where Origem = '" + aOrigem[j] + "'";
                dtPesq = new DataTable();
                dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtPesq.Rows.Count != 0)
                {
                    aTotal[5] = Convert.ToInt32(dtPesq.Rows[0]["qtd"].ToString());
                }

                // total da bloqueado
                clsVariaveis.GstrSQL = "select count(*) qtd from Cadastro where Origem = '" + aOrigem[j] + "' and Uso > 501 ";
                dtPesq = new DataTable();
                dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtPesq.Rows.Count != 0)
                {
                    aTotal[6] = Convert.ToInt32(dtPesq.Rows[0]["qtd"].ToString());
                }

                // total por status
                clsVariaveis.GstrSQL = "select resultado ,count(*) as qtd from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "' and resultado is not null group by resultado order by resultado";
                dtPesq = new DataTable();
                dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtPesq.Rows.Count != 0)
                {
                    foreach (DataRow row in dtPesq.Rows)
                    {
                        switch (row["resultado"].ToString())
                        {
                            case "CP":
                            case "FAX":
                            case "SE":
                            case "MO":
                                aTotal[13] = aTotal[13] + Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "LIGAÇÃO MUDA":
                                aTotal[14] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "LD":
                            case "LT":
                            case "LN":
                            case "NE":
                            case "AG":
                            case "Ligação descartada":
                                aTotal[15] = aTotal[15] + Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OC":
                                aTotal[16] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NA":
                                aTotal[17] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "TELEFONE FORA DE SERVIÇO":
                                aTotal[18] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "TELEFONE NÃO EXISTE":
                                aTotal[19] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "EC1":
                                aTotal[20] = Convert.ToInt32(row["qtd"].ToString());
                                break;

                            case "ACHOU CARO":
                                aTotal[23] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "CLIENTE JÁ FECHOU RENOVAÇÃO NO BOLETO":
                                aTotal[24] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "DESEMPREGADO":
                                aTotal[25] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "INSATISFAÇÃO COM A CARSYSTEM":
                                aTotal[26] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "JÁ É CLIENTE":
                                aTotal[27] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "MORTE/FALECIMENTO":
                                aTotal[28] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NÃO POSSUI CARTÃO E CHEQUE":
                                aTotal[29] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NÃO POSSUI VEÍCULO":
                                aTotal[30] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OPTOU POR SEGURADORA OU CONCORRÊNCIA":
                                aTotal[31] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "PROBLEMAS FINANCEIROS":
                                aTotal[32] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "RECUSOU-SE A FALAR":
                                aTotal[33] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "SEM INTERESSE":
                                aTotal[34] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "SEM INTERESSE NA RENOVAÇÃO":
                                aTotal[35] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OK":
                                aTotal[36] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            default:
                                break;
                        }
                    }

                    objwSheet = new Excel.Worksheet();
                    objwSheet = (Excel.Worksheet)objwBook.Sheets["Plan" + j];

                    objwSheet.Cells[1, 2] = aOrigem[j];
                    objwSheet.Cells[2, 2] = "Período " + Convert.ToDateTime(_dtIni).ToString("dd/MM/yyyy") + " a " + Convert.ToDateTime(_dtFim).ToString("dd/MM/yyyy");

                    objwSheet.Cells[5, 3] = aTotal[5];
                    objwSheet.Cells[6, 3] = aTotal[6];

                    objwSheet.Cells[13, 3] = aTotal[13];
                    objwSheet.Cells[14, 3] = aTotal[14];
                    objwSheet.Cells[15, 3] = aTotal[15];
                    objwSheet.Cells[16, 3] = aTotal[16];
                    objwSheet.Cells[17, 3] = aTotal[17];
                    objwSheet.Cells[18, 3] = aTotal[18];
                    objwSheet.Cells[19, 3] = aTotal[19];
                    objwSheet.Cells[20, 3] = aTotal[20];

                    objwSheet.Cells[23, 3] = aTotal[23];
                    objwSheet.Cells[24, 3] = aTotal[24];
                    objwSheet.Cells[25, 3] = aTotal[25];
                    objwSheet.Cells[26, 3] = aTotal[26];
                    objwSheet.Cells[27, 3] = aTotal[27];
                    objwSheet.Cells[28, 3] = aTotal[28];
                    objwSheet.Cells[29, 3] = aTotal[29];
                    objwSheet.Cells[30, 3] = aTotal[30];
                    objwSheet.Cells[31, 3] = aTotal[31];
                    objwSheet.Cells[32, 3] = aTotal[32];
                    objwSheet.Cells[33, 3] = aTotal[33];
                    objwSheet.Cells[34, 3] = aTotal[34];
                    objwSheet.Cells[35, 3] = aTotal[35];

                    objwSheet.Cells[36, 3] = aTotal[36];
                }
            }

            // excluindo planilhas nao utilizadas
            for (int i = 50; i > iIdx; i--)
            {
                //excluir da ultima para a primeira 50 ,49 ,48 ...
                app.DisplayAlerts = false;
                ((Excel.Worksheet)app.Application.ActiveWorkbook.Sheets[i]).Delete();
                app.DisplayAlerts = true;
            }
            objwBook.Save();
            objwBook.Close(true);

            // eliminando excel da memoria
            objwSheet = null;
            objwBook = null;
            app.Quit();
            Marshal.ReleaseComObject(app);
            app = null;


            // abrindo o arquivo excel salvo 
            Process.Start(@sDestino);
        }


        private void Relat_Base_Receptivo_Todos(string _origem, string _dtIni, string _dtFim)
        {
            bool booExec = false;

            clsVariaveis.GstrSQL = "delete from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "'";
            booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);


            // criando array aOrigem
            int iIdx = 0;
            string[] aOrigem;
            aOrigem = new string[50];


            if (cboParametro.Text == "TODOS")
            {
                for (int i = 1; i < cboParametro.Items.Count - 1; i++)
                {
                    //excluir da ultima para a primeira 50 ,49 ,48 ...
                    cboParametro.SelectedIndex = i;
                    aOrigem[i] = cboParametro.Text;
                }
                iIdx = cboParametro.Items.Count - 2;
                cboParametro.SelectedIndex = cboParametro.Items.Count - 1;
            }
            else
            {
                iIdx = 1;
                aOrigem[1] = cboParametro.Text;
            }


            // preparando excel
            string sOrigem = @"C:\Ekubo\Sistemas\CarSystem\Fonte\RELATORIO_CarSystem_MOD_50.xlsx";
            string sDestino = @"\\srvfiles\CRM\Relatorios\CarSystem\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_RELATORIO_CarSystem_MOD_50.xlsx";
            System.IO.File.Copy(sOrigem, sDestino);

            Excel.Workbook objwBook;
            Excel.Worksheet objwSheet;
            Excel.Application app = new Excel.Application();
            objwBook = app.Workbooks.Open(sDestino);


            // criando array aTotal por origem
            int[] aTotal;
            DataTable dtPesq;

            for (int j = 1; j < iIdx + 1; j++)
            {
                clsVariaveis.GstrSQL = "insert into Aux_Relat ( usuario ,origem ,uso ,resultado ,codigo ) select '" + clsUsuarioLogado.Usu_cpf + "' ,origem ,0 ,resultado ,id_recept from Receptivo ";
                clsVariaveis.GstrSQL += "where Origem = '" + aOrigem[j] + "' and data between '" +
                                        Convert.ToDateTime(_dtIni).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(_dtFim).ToString("yyyy-MM-dd") + "'";
                booExec = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);

                aTotal = new int[40];

                // total da base
                clsVariaveis.GstrSQL = "select count(*) qtd from Receptivo where Origem = '" + aOrigem[j] + "'";
                dtPesq = new DataTable();
                dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtPesq.Rows.Count != 0)
                {
                    aTotal[5] = Convert.ToInt32(dtPesq.Rows[0]["qtd"].ToString());
                }

                // total da bloqueado
                aTotal[6] = 0;

                // total por status
                clsVariaveis.GstrSQL = "select resultado ,count(*) as qtd from Aux_Relat where Usuario = '" + clsUsuarioLogado.Usu_cpf + "' and resultado is not null group by resultado order by resultado";
                dtPesq = new DataTable();
                dtPesq = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
                if (dtPesq.Rows.Count != 0)
                {
                    foreach (DataRow row in dtPesq.Rows)
                    {
                        switch (row["resultado"].ToString())
                        {
                            case "CP":
                            case "FAX":
                            case "SE":
                            case "MO":
                                aTotal[13] = aTotal[13] + Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "LIGAÇÃO MUDA":
                                aTotal[14] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "LD":
                            case "LT":
                            case "LN":
                            case "NE":
                            case "AG":
                            case "Ligação descartada":
                                aTotal[15] = aTotal[15] + Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OC":
                                aTotal[16] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NA":
                                aTotal[17] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "TELEFONE FORA DE SERVIÇO":
                                aTotal[18] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "TELEFONE NÃO EXISTE":
                                aTotal[19] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "EC1":
                                aTotal[20] = Convert.ToInt32(row["qtd"].ToString());
                                break;

                            case "ACHOU CARO":
                                aTotal[23] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "CLIENTE JÁ FECHOU RENOVAÇÃO NO BOLETO":
                                aTotal[24] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "DESEMPREGADO":
                                aTotal[25] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "INSATISFAÇÃO COM A CARSYSTEM":
                                aTotal[26] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "JÁ É CLIENTE":
                                aTotal[27] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "MORTE/FALECIMENTO":
                                aTotal[28] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NÃO POSSUI CARTÃO E CHEQUE":
                                aTotal[29] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "NÃO POSSUI VEÍCULO":
                                aTotal[30] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OPTOU POR SEGURADORA OU CONCORRÊNCIA":
                                aTotal[31] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "PROBLEMAS FINANCEIROS":
                                aTotal[32] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "RECUSOU-SE A FALAR":
                                aTotal[33] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "SEM INTERESSE":
                                aTotal[34] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "SEM INTERESSE NA RENOVAÇÃO":
                                aTotal[35] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            case "OK":
                                aTotal[36] = Convert.ToInt32(row["qtd"].ToString());
                                break;
                            default:
                                break;
                        }
                    }

                    objwSheet = new Excel.Worksheet();
                    objwSheet = (Excel.Worksheet)objwBook.Sheets["Plan" + j];

                    objwSheet.Cells[1, 2] = aOrigem[j];
                    objwSheet.Cells[2, 2] = "Período " + Convert.ToDateTime(_dtIni).ToString("dd/MM/yyyy") + " a " + Convert.ToDateTime(_dtFim).ToString("dd/MM/yyyy");

                    objwSheet.Cells[5, 3] = aTotal[5];
                    objwSheet.Cells[6, 3] = aTotal[6];

                    objwSheet.Cells[13, 3] = aTotal[13];
                    objwSheet.Cells[14, 3] = aTotal[14];
                    objwSheet.Cells[15, 3] = aTotal[15];
                    objwSheet.Cells[16, 3] = aTotal[16];
                    objwSheet.Cells[17, 3] = aTotal[17];
                    objwSheet.Cells[18, 3] = aTotal[18];
                    objwSheet.Cells[19, 3] = aTotal[19];
                    objwSheet.Cells[20, 3] = aTotal[20];

                    objwSheet.Cells[23, 3] = aTotal[23];
                    objwSheet.Cells[24, 3] = aTotal[24];
                    objwSheet.Cells[25, 3] = aTotal[25];
                    objwSheet.Cells[26, 3] = aTotal[26];
                    objwSheet.Cells[27, 3] = aTotal[27];
                    objwSheet.Cells[28, 3] = aTotal[28];
                    objwSheet.Cells[29, 3] = aTotal[29];
                    objwSheet.Cells[30, 3] = aTotal[30];
                    objwSheet.Cells[31, 3] = aTotal[31];
                    objwSheet.Cells[32, 3] = aTotal[32];
                    objwSheet.Cells[33, 3] = aTotal[33];
                    objwSheet.Cells[34, 3] = aTotal[34];
                    objwSheet.Cells[35, 3] = aTotal[35];

                    objwSheet.Cells[36, 3] = aTotal[36];
                }
            }

            // excluindo planilhas nao utilizadas
            for (int i = 50; i > iIdx; i--)
            {
                //excluir da ultima para a primeira 50 ,49 ,48 ...
                app.DisplayAlerts = false;
                ((Excel.Worksheet)app.Application.ActiveWorkbook.Sheets[i]).Delete();
                app.DisplayAlerts = true;
            }
            objwBook.Save();
            objwBook.Close(true);

            // eliminando excel da memoria
            objwSheet = null;
            objwBook = null;
            app.Quit();
            Marshal.ReleaseComObject(app);
            app = null;


            // abrindo o arquivo excel salvo 
            Process.Start(@sDestino);
        }

        private void btXls_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Exportar para o Excel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //pgStatus.Style = ProgressBarStyle.Marquee;
                btXls.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                clsFuncoes.ExportarXLS(dataGridView1);
                btXls.Enabled = true;
                this.Cursor = Cursors.Default;
                //pgStatus.Style = ProgressBarStyle.Blocks;
            }
        }


        private void dtPicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }

            dtPicker1.Enabled = false;
            dtPicker2.Enabled = false;
            Preencher_CboParametro();
            dtPicker1.Enabled = true;
            dtPicker2.Enabled = true;
        }

        private void dtPicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }
            dtPicker1.Enabled = false;
            dtPicker2.Enabled = false;
            Preencher_CboParametro();
            dtPicker1.Enabled = true;
            dtPicker2.Enabled = true;
        }

        private void cboParametro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) { dataGridView1.DataSource = ""; }
        }
    }
}
