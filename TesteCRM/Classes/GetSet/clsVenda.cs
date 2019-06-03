using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsVenda
    {
        private static string vda_cod = string.Empty;
        public static string Vda_cod
        {
            get { return vda_cod.TrimStart().TrimEnd(); }
            set { vda_cod = value.TrimStart().TrimEnd(); }
        }

        private static string vda_origem = string.Empty;
        public static string Vda_origem
        {
            get { return vda_origem.TrimStart().TrimEnd(); }
            set { vda_origem = value.TrimStart().TrimEnd(); }
        }

        private static string vda_tpOrigem = string.Empty;
        public static string Vda_tpOrigem
        {
            get { return vda_tpOrigem.TrimStart().TrimEnd(); }
            set { vda_tpOrigem = value.TrimStart().TrimEnd(); }
        }

        private static string vda_OriVda = string.Empty;
        public static string Vda_OriVda
        {
            get { return vda_OriVda.TrimStart().TrimEnd(); }
            set { vda_OriVda = value.TrimStart().TrimEnd(); }
        }

        private static string vda_nome = string.Empty;
        public static string Vda_nome
        {
            get { return vda_nome.TrimStart().TrimEnd(); }
            set { vda_nome = value.TrimStart().TrimEnd(); }
        }

        private static string vda_auditor = string.Empty;
        public static string Vda_auditor
        {
            get { return vda_auditor.TrimStart().TrimEnd(); }
            set { vda_auditor = value.TrimStart().TrimEnd(); }
        }

    }
}
