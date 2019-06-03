using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCRM.Forms;

namespace TesteCRM.Classes.GetSet
{
    public class clsUsuario
    {
        private string usu_cod = string.Empty;
        public string Usu_cod
        {
            get { return usu_cod.TrimStart().TrimEnd(); }
            set { usu_cod = value.TrimStart().TrimEnd(); }
        }

        private string usu_equipe = string.Empty;
        public string Usu_equipe
        {
            get { return usu_equipe.TrimStart().TrimEnd(); }
            set { usu_equipe = value.TrimStart().TrimEnd(); }
        }

        private string usu_fila = string.Empty;
        public string Usu_fila
        {
            get { return usu_fila.TrimStart().TrimEnd(); }
            set { usu_fila = value.TrimStart().TrimEnd(); }
        }

        private string usu_matricula = string.Empty;
        public string Usu_matricula
        {
            get { return usu_matricula.TrimStart().TrimEnd(); }
            set { usu_matricula = value.TrimStart().TrimEnd(); }
        }

        private string usu_nome = string.Empty;
        public string Usu_nome
        {
            get { return usu_nome.TrimStart().TrimEnd(); }
            set { usu_nome = value.TrimStart().TrimEnd(); }
        }

        private string usu_cpf = string.Empty;
        public string Usu_cpf
        {
            get { return usu_cpf.TrimStart().TrimEnd(); }
            set { usu_cpf = value.TrimStart().TrimEnd(); }
        }

        private string usu_senha = string.Empty;
        public string Usu_senha
        {
            get { return usu_senha.TrimStart().TrimEnd(); }
            set { usu_senha = value.TrimStart().TrimEnd(); }
        }
        
        private string usu_status = string.Empty;
        public string Usu_status
        {
            get { return usu_status.TrimStart().TrimEnd(); }
            set { usu_status = value.TrimStart().TrimEnd(); }
        }

        private string usu_rank = string.Empty;
        public string Usu_rank
        {
            get { return usu_rank.TrimStart().TrimEnd(); }
            set { usu_rank = value.TrimStart().TrimEnd(); }
        }

        private string usu_pwd2 = string.Empty;
        public string Usu_pwd2
        {
            get { return usu_pwd2.TrimStart().TrimEnd(); }
            set { usu_pwd2 = value.TrimStart().TrimEnd(); }
        }



    }
}
