using System;
using System.Data;
using System.Windows.Forms;
using TesteCRM.Classes;
using TesteCRM.Classes.GetSet;

namespace TesteCRM.Forms
{
    public partial class frmVisualizaVendas : Form
    {
        public frmVisualizaVendas()
        {
            InitializeComponent();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            string _dtIni = "";
            if (checkBox1.Checked)
            {
                _dtIni = clsFuncoes.PrimeiroDiadoMesAnterior("SQL");

            }
            else
            {
                // 1º dia do mes corrente
                _dtIni = clsFuncoes.PrimeiroDiadoMes("SQL");
            }
            

            clsVariaveis.GstrSQL = "select id_venda ,data ,hora ,nome ,forma_pagto ,valorf ,status from vivendas2 where Operador = '" + 
                                   clsUsuarioLogado.Usu_cpf + "' and data between '" + _dtIni + "' and '" + 
                                   DateTime.Now.ToString("yyyy-MM-dd") + "' order by data ,hora";
            dataGridView1.DataSource = clsBanco.Consulta(clsVariaveis.GstrSQL);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "id_venda")
                    column.Visible = false;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PreencherGrid();
        }
    }
}
