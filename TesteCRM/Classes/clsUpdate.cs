using System;
using TesteCRM.Classes.GetSet;
using TesteCRM.Classes;

namespace TesteCRM.Classes
{
    class clsUpdate
    {

        public static string ComandoUpdateUsuario(clsUsuario Usuario)
        {
            string Comando = "update Usuario set " + clsFuncoes.MontaUpdate("usuario", Usuario.Usu_nome, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("nomecompleto", Usuario.Usu_nome, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("senha", Usuario.Usu_senha, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("turno", Usuario.Usu_equipe, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("fila", Usuario.Usu_fila, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("status", Usuario.Usu_status, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("rank", Usuario.Usu_rank, "INT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("matricula", Usuario.Usu_matricula, "INT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("pwd2", Usuario.Usu_pwd2, "BOO").ToString();
            Comando += " where cod = " + Usuario.Usu_cod;
            
            return Comando;
        }

    }
}
