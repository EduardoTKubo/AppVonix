using System.Data;
using System;

namespace TesteCRM.Classes.GetSet
{
    class clsUsuarioLogado
    {
        private static string usu_cod = string.Empty;
        public static string Usu_cod
        {
            get { return clsUsuarioLogado.usu_cod; }
        }

        private static string usu_equipe = string.Empty;
        public static string Usu_equipe
        {
            get { return clsUsuarioLogado.usu_equipe; }
        }

        private static string usu_matricula = string.Empty;
        public static string Usu_matricula
        {
            get { return clsUsuarioLogado.usu_matricula; }
        }

        private static string usu_nome = string.Empty;
        public static string Usu_nome
        {
            get { return clsUsuarioLogado.usu_nome; }
        }

        private static string usu_cpf = string.Empty;
        public static string Usu_cpf
        {
            get { return clsUsuarioLogado.usu_cpf; }
        }

        private static string usu_senha = string.Empty;
        public static string Usu_senha
        {
            get { return clsUsuarioLogado.usu_senha; }
        }

        private static string usu_status = string.Empty;
        public static string Usu_status
        {
            get { return clsUsuarioLogado.usu_status; }
        }

        private static string usu_rank = string.Empty;
        public static string Usu_rank
        {
            get { return clsUsuarioLogado.usu_rank; }
        }


        public static string usu_fila = string.Empty;
        public static string Usu_fila
        {
            get { return usu_fila; }
            set { usu_fila = value.TrimStart().TrimEnd(); }
        }

        public static string usu_origem = string.Empty;
        public static string Usu_origem
        {
            get { return usu_origem; }
            set { usu_origem = value.TrimStart().TrimEnd(); }
        }

        public static string usu_discador = string.Empty;
        public static string Usu_discador
        {
            get { return usu_discador; }
            set { usu_discador = value.TrimStart().TrimEnd(); }
        }

        public static string usu_nomePC = string.Empty;
        public static string Usu_nomePC
        {
            get { return usu_nomePC; }
            set { usu_nomePC = value.TrimStart().TrimEnd(); }
        }

        private static string usu_BOffice = string.Empty;
        public static string Usu_BOffice
        {
            get { return usu_BOffice.TrimStart().TrimEnd(); }
            set { usu_BOffice = value.TrimStart().TrimEnd(); }
        }

        public static void CarregarUsuarioLogado(DataTable dt)
        {
            //clsUsuario.usu_cod = Convert.ToInt32(dt.Rows[0][0].ToString());
            clsUsuarioLogado.usu_cod = dt.Rows[0][0].ToString();
            clsUsuarioLogado.usu_equipe = dt.Rows[0][1].ToString();
            clsUsuarioLogado.usu_matricula = dt.Rows[0][2].ToString();
            clsUsuarioLogado.usu_nome = dt.Rows[0][3].ToString();
            clsUsuarioLogado.usu_cpf = dt.Rows[0][4].ToString();
            clsUsuarioLogado.usu_senha = dt.Rows[0][5].ToString();
            clsUsuarioLogado.usu_status = dt.Rows[0][6].ToString();
            clsUsuarioLogado.usu_rank = dt.Rows[0][7].ToString();
            clsUsuarioLogado.usu_discador = dt.Rows[0][8].ToString();
            clsUsuarioLogado.usu_nomePC = Environment.MachineName;
        }


        public static bool IsLoginOK(string cpf, string senha)
        {
            if (cpf.Length < 6)
            {
                clsVariaveis.GstrSQL = ("select * from Usuario where Ativo = 1 and Matricula = '@cpf' ").Replace("@cpf", cpf);
            }
            else
            {
                if(senha.Length > 0)
                {
                    clsVariaveis.GstrSQL = ("select * from Usuario where Ativo = 1 and CPF ='@cpf' and Senha = '@senha' ").Replace("@cpf", cpf).Replace("@senha", senha);
                }
                else
                {
                    clsVariaveis.GstrSQL = ("select * from Usuario where Ativo = 1 and CPF ='@cpf' ").Replace("@cpf", cpf);
                }
                
            }

            if (Classes.clsBanco.Consulta(clsVariaveis.GstrSQL).Rows.Count > 0)
                return true;
            return false;
        }


        public static void DadosUsuarioLogado(string cpf)
        {
            string Cabecalho = "[cod],[turno],[matricula],[nomecompleto],[cpf],[senha],[status],[rank],[discador]";

            DataTable dtPassed = new DataTable();
            if (cpf.Length < 6)
            {
                dtPassed = Classes.clsBanco.Consulta(("select " + Cabecalho + " from Usuario where Ativo = 1 and Matricula = '@cpf' ").Replace("@cpf", cpf));
            }
            else
            {
                dtPassed = Classes.clsBanco.Consulta(("select " + Cabecalho + " from Usuario where Ativo = 1 and CPF = '@cpf' ").Replace("@cpf", cpf));
            }

            if (dtPassed.Rows.Count > 0)
            {
                CarregarUsuarioLogado(dtPassed);
            }

        }


        public static void MapOperacional(string _cpf)
        {
            clsVariaveis.GstrSQL = "select * from Map_Operacional where Operador = '" + _cpf + 
                                   "' and data = '" + DateTime.Now.ToString("yyyy-MM-dd") + 
                                   "' and PA = '" + clsUsuarioLogado.usu_nomePC + "' ";
            DataTable dtUsu = new DataTable();
            dtUsu = Classes.clsBanco.Consulta(clsVariaveis.GstrSQL);
            if (dtUsu.Rows.Count == 0 )
            {
                clsVariaveis.GstrSQL = "insert into Map_Operacional ( Operador ,pa ,data ,inicio ) " +
                                       "values ( '" + _cpf + "' ,'" + clsUsuarioLogado.usu_nomePC +
                                       "' ,'" + DateTime.Now.ToString("yyyy-MM-dd") +
                                       "' ,'" + DateTime.Now.ToString("HH:mm:ss") + "' )";
                bool booMap = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            }
        }

    }
}
