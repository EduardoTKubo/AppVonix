﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesteCRM.Classes
{
    class clsBanco
    {
        private static SqlConnection sqlCon = null;
        private static SqlCommand sqlCom = null;
        private static SqlDataAdapter sqlAdapter = null;
        private static DataTable Dt = null;

        public static DataTable Consulta(string select)
        {
            try
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = Classes.clsVariaveis.Conexao;
                sqlCon.Open();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = select;
                sqlCom.CommandTimeout = 540;
                sqlAdapter = new SqlDataAdapter(sqlCom);
                Dt = new DataTable();
                sqlAdapter.Fill(Dt);

                return Dt;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public static bool ExecuteQuery(string Comando)
        {
            try
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = Classes.clsVariaveis.Conexao;
                sqlCon.Open();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = Comando;
                sqlCom.ExecuteNonQuery();

                return true;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "ExecuteQuery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public static DataTable ExecuteQueryRetorno(string Comando)
        {
            try
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = Classes.clsVariaveis.Conexao;
                sqlCon.Open();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = Comando;
                sqlAdapter = new SqlDataAdapter(sqlCom);
                Dt = new DataTable();
                sqlAdapter.Fill(Dt);
                sqlCon.Close();

                return Dt;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "ExecuteQueryRetorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
    }
}
