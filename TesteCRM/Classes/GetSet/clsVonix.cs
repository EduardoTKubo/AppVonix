using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCRM.Classes.GetSet
{
    class clsVonix
    {
        private static string logadoNoVonix = "NAO";
        public static string LogadoNoVonix
        {
            get { return logadoNoVonix; }
            set { logadoNoVonix = value; }
        }


        private static string callId = string.Empty;
        public static string CallId
        {
            get { return callId; }
            set { callId = value; }
        }

        private static string strDate = string.Empty;
        public static string StrDate
        {
            get { return strDate; }
            set { strDate = value; }
        }

        private static string queue = string.Empty;
        public static string Queue
        {
            get { return queue; }
            set { queue = value; }
        }

        private static string from = string.Empty;
        public static string From
        {
            get { return from; }
            set { from = value; }
        }

        private static string to = string.Empty;
        public static string To
        {
            get { return to; }
            set { to = value; }
        }

        private static string callFilename = string.Empty;
        public static string CallFilename
        {
            get { return callFilename; }
            set { callFilename = value; }
        }

        private static string contactname = string.Empty;
        public static string Contactname
        {
            get { return contactname; }
            set { contactname = value; }
        }

        private static string actionId = string.Empty;
        public static string ActionId
        {
            get { return actionId; }
            set { actionId = value; }
        }



    }
}
