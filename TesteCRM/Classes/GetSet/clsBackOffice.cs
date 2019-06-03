using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsBackOffice
    {

        private static string bo_id_venda = string.Empty;
        public static string Bo_id_venda
        {
            get { return bo_id_venda.TrimStart().TrimEnd(); }
            set { bo_id_venda = value.TrimStart().TrimEnd(); }
        }

        private static string bo_uso = string.Empty;
        public static string Bo_uso
        {
            get { return bo_uso.TrimStart().TrimEnd(); }
            set { bo_uso = value.TrimStart().TrimEnd(); }
        }

        private static string bo_office = string.Empty;
        public static string Bo_office
        {
            get { return bo_office.TrimStart().TrimEnd(); }
            set { bo_office = value.TrimStart().TrimEnd(); }
        }

    }
}
