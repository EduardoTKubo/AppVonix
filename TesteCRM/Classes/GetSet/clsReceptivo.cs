using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCRM.Classes.GetSet;


namespace TesteCRM.Classes.GetSet
{
    class clsReceptivo
    {
        private static string rcp_id_recept = string.Empty;
        public static string Rcp_id_recept
        {
            get { return rcp_id_recept.TrimStart().TrimEnd(); }
            set { rcp_id_recept = value.TrimStart().TrimEnd(); }
        }

        private static string rcp_origem = string.Empty;
        public static string Rcp_origem
        {
            get { return rcp_origem.TrimStart().TrimEnd(); }
            set { rcp_origem = value.TrimStart().TrimEnd(); }
        }

        private static string rcp_id_ag = string.Empty;
        public static string Rcp_id_ag
        {
            get { return rcp_id_ag.TrimStart().TrimEnd(); }
            set { rcp_id_ag = value.TrimStart().TrimEnd(); }
        }



    }
}
