using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TesteCRM.Classes
{
    class clsVariaveis
    {
        private static string conexao = @"Data Source=10.0.32.63;Initial Catalog=Carsystem; User ID=sa; Password=SRV@admin2012;";

        public static string Conexao
        {
            get { return clsVariaveis.conexao; }
        }
                     

        private static bool isAuthorizedLogin = false;
        public static bool IsAuthorizedLogin
        {
            get { return clsVariaveis.isAuthorizedLogin; }
            set { clsVariaveis.isAuthorizedLogin = value; }
        }


        private static bool salvarInformacao = false;
        public static bool SalvarInformacao
        {
            get { return clsVariaveis.salvarInformacao; }
            set { clsVariaveis.salvarInformacao = value; }
        }



        private static string gstrSQL = string.Empty;
        public static string GstrSQL
        {
            get { return clsVariaveis.gstrSQL; }
            set { clsVariaveis.gstrSQL = value; }
        }

        private static string gstrDDD = string.Empty;
        public static string GstrDDD
        {
            get { return clsVariaveis.gstrDDD; }
            set { clsVariaveis.gstrDDD = value; }
        }

        private static string gstrTel = string.Empty;
        public static string GstrTel
        {
            get { return clsVariaveis.gstrTel; }
            set { clsVariaveis.gstrTel = value; }
        }

        private static int gintQTelLigou = 0;
        public static int GintQTelLigou
        {
            get { return clsVariaveis.gintQTelLigou; }
            set { clsVariaveis.gintQTelLigou = value; }
        }

        private static int gintPreditiva = 0;
        public static int GintPreditiva
        {
            get { return clsVariaveis.gintPreditiva; }
            set { clsVariaveis.gintPreditiva = value; }
        }
        
        private static string gstrNegativa = string.Empty;
        public static string GstrNegativa
        {
            get { return clsVariaveis.gstrNegativa; }
            set { clsVariaveis.gstrNegativa = value; }
        }

        private static DateTime ghrIni = DateTime.Now;
        public static DateTime GghIni
        {
            get { return clsVariaveis.ghrIni; }
            set { clsVariaveis.ghrIni = value; }
        }

               
    }
}
