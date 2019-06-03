using System;
using TesteCRM.Classes.GetSet;

namespace TesteCRM.Classes
{
    class clsInsert
    {

        public static string ComandoInsertUsuario(clsUsuario Usuario)
        {
            string Comando = "insert into Usuario (usuario ,nomecompleto ,cpf ,senha ,turno ,fila ,status ,rank ,matricula ,dt_ini ,pwd2 ) values (";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_nome ,"TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_nome, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_cpf, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_senha, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_equipe, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_fila, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_status, "TEXT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_rank, "INT") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_matricula, "TEXT") + " ,";

            DateTime thisDay = DateTime.Today;
            Comando += "'" + clsFuncoes.ToDateUSA(thisDay.ToString())  + "' ,";

            Comando += clsFuncoes.MontaInsert(Usuario.Usu_pwd2, "BOO") + " )";

            return Comando;
        }


        public static bool GravaLigacao(string _res)
        {
            clsVariaveis.GstrSQL = "insert into ligacao ( data ,hora ,duracao ,ddd ,telefone ,[status] ,idreg ,operador ,pa ,campanha ) ";
            clsVariaveis.GstrSQL += " values ( " + clsFuncoes.MontaInsert(DateTime.Now.ToString("yyyy-MM-dd"), "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(DateTime.Now.ToString("HH:mm:ss"), "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsFuncoes.Duracao(), "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsVariaveis.GstrDDD, "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsVariaveis.GstrTel, "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(_res, "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsAtivo.Atv_cod, "INT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_cpf, "TEXT");
            clsVariaveis.GstrSQL += " ," + clsFuncoes.MontaInsert(clsUsuarioLogado.Usu_nomePC, "TEXT");
            clsVariaveis.GstrSQL += " ,'TESTECRM' )";
            bool booLig = clsBanco.ExecuteQuery(clsVariaveis.GstrSQL);
            return booLig;
        }


    }
}
