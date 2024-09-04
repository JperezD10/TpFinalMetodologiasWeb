using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALPermisos
    {
        DALConexion con = new DALConexion();
        DALUsuario user = new DALUsuario();
        public bool HasPermission(string CurrentUser, string CurrentForm)
        {

            int RolId = user.ObtenerRolPorUsuario(CurrentUser);
            int FormId = GetFormIdbYFormName(CurrentForm);


            if (RolId != -1 && FormId != -1) //si hay datos verifico si esta permitido para ver el form
            {
                int resultado = GetUserRole(RolId, FormId);
                return resultado > 0;
            }
            else
            {
                return false;
            }

        }


        public int GetUserRole(int rol, int form)
        {
            con.AbrirConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PermisosRoles where idRol=" + rol + " and idForm=" + form + " and isAllowed=1";
            cmd.ExecuteNonQuery();
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            con.CerrarConexion();
            return resultado;
        }


        public int GetFormIdbYFormName(string currentForm)
        {
            con.AbrirConexion();
            SqlCommand cmd = new SqlCommand("GetFormIdByName", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormName", currentForm);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            con.CerrarConexion();
            return resultado;
        }
    }
}
