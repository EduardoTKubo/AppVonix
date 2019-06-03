using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsAtivo
    {
        private static string atv_cod = string.Empty;
        public static string Atv_cod
        {
            get { return atv_cod.TrimStart().TrimEnd(); }
            set { atv_cod = value.TrimStart().TrimEnd(); }
        }

        private static string atv_origem = string.Empty;
        public static string Atv_origem
        {
            get { return atv_origem.TrimStart().TrimEnd(); }
            set { atv_origem = value.TrimStart().TrimEnd(); }
        }

        private static string atv_tpOrigem = string.Empty;
        public static string Atv_tpOrigem
        {
            get { return atv_tpOrigem.TrimStart().TrimEnd(); }
            set { atv_tpOrigem = value.TrimStart().TrimEnd(); }
        }

        private static string atv_nome = string.Empty;
        public static string Atv_nome
        {
            get { return atv_nome.TrimStart().TrimEnd(); }
            set { atv_nome = value.TrimStart().TrimEnd(); }
        }


        // agenda
        private static string atv_id_ag = string.Empty;
        public static string Atv_id_ag
        {
            get { return atv_id_ag.TrimStart().TrimEnd(); }
            set { atv_id_ag = value.TrimStart().TrimEnd(); }
        }

        private static string atv_obs_ag = string.Empty;
        public static string Atv_obs_ag
        {
            get { return atv_obs_ag.TrimStart().TrimEnd(); }
            set { atv_obs_ag = value.TrimStart().TrimEnd(); }
        }


        // ref ao registro pego
        private static string atv_ini_uso = string.Empty;
        public static string Atv_ini_uso
        {
            get { return atv_ini_uso.TrimStart().TrimEnd(); }
            set { atv_ini_uso = value.TrimStart().TrimEnd(); }
        }

        private static string atv_ini_oper = string.Empty;
        public static string Atv_ini_oper
        {
            get { return atv_ini_oper.TrimStart().TrimEnd(); }
            set { atv_ini_oper = value.TrimStart().TrimEnd(); }
        }

        private static string atv_qTelAg = string.Empty;
        public static string Atv_qTelAg
        {
            get { return atv_qTelAg.TrimStart().TrimEnd(); }
            set { atv_qTelAg = value.TrimStart().TrimEnd(); }
        }


        // fones 
        private static string atv_ddd1 = string.Empty;
        public static string Atv_ddd1
        {
            get { return atv_ddd1.TrimStart().TrimEnd(); }
            set { atv_ddd1 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_fone1 = string.Empty;
        public static string Atv_fone1
        {
            get { return atv_fone1.TrimStart().TrimEnd(); }
            set { atv_fone1 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_ddd2 = string.Empty;
        public static string Atv_ddd2
        {
            get { return atv_ddd2.TrimStart().TrimEnd(); }
            set { atv_ddd2 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_fone2 = string.Empty;
        public static string Atv_fone2
        {
            get { return atv_fone2.TrimStart().TrimEnd(); }
            set { atv_fone2 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_ddd3 = string.Empty;
        public static string Atv_ddd3
        {
            get { return atv_ddd3.TrimStart().TrimEnd(); }
            set { atv_ddd3 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_fone3 = string.Empty;
        public static string Atv_fone3
        {
            get { return atv_fone3.TrimStart().TrimEnd(); }
            set { atv_fone3 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_ddd4 = string.Empty;
        public static string Atv_ddd4
        {
            get { return atv_ddd4.TrimStart().TrimEnd(); }
            set { atv_ddd4 = value.TrimStart().TrimEnd(); }
        }

        private static string atv_fone4 = string.Empty;
        public static string Atv_fone4
        {
            get { return atv_fone4.TrimStart().TrimEnd(); }
            set { atv_fone4 = value.TrimStart().TrimEnd(); }
        }




    }
}
