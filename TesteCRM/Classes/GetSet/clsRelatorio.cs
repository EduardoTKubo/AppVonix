using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsRelatorio
    {
        private static string rel_titulo = string.Empty;
        public static string Rel_titulo
        {
            get { return rel_titulo.TrimStart().TrimEnd(); }
            set { rel_titulo = value.TrimStart().TrimEnd(); }
        }


    }
}
