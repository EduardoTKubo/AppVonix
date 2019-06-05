using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsReceptivo
    {
        private static string rec_Id_Recept = string.Empty;
        public static string Rec_Id_Recept
        {
            get { return rec_Id_Recept.TrimStart().TrimEnd(); }
            set { rec_Id_Recept = value.TrimStart().TrimEnd(); }
        }


    }
}
