using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BE;

namespace BLL
{
    public class BLLUsuario
    {
        DALUsuario ObjUsuario = new DALUsuario();


        public void RegistrarUsuario(string usuario, string contraseña)
        {

            ObjUsuario.RegistrarUsuario(usuario, contraseña);
        }

        public string GetEncriptado(string contraseña)
        {
            return ObjUsuario.GetEncriptado(contraseña);
        }

        public DataSet ObtenerContraseña(string usuario)
        {
            return ObjUsuario.ObtenerContraseña(usuario);
        }


        public bool CompararContraseñas(string username, string contraseña_encriptada)
        {
            try
            {
                DataSet ds = new DataSet();
                string ContraseñaGuardada;

                ds = ObjUsuario.ObtenerContraseña(username); //obtengo contraseña guardada
                ContraseñaGuardada = ds.Tables[0].Rows[0][1].ToString();

                if (ContraseñaGuardada == contraseña_encriptada)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BEUsuario ObtenerUsuario(string usuario)
        {
            DataSet ds = ObjUsuario.ObtenerUsuario(usuario);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new BEUsuario
                {
                    Usuario = row["usuario"].ToString(),
                    Contraseña = row["contraseña"].ToString(),
                    Rol = row["idRol"].ToString()
                };
            }
            return null;
        }



        
        public DataTable GetUsuario()
        {
            return ObjUsuario.ObtenerTodosUsuarios();
        }


        public static bool ValidarContraseña(string contraseña)
        {
            if (contraseña.Length < 8)
                return false;

            bool tieneMayuscula = contraseña.Any(char.IsUpper);
            bool tieneMinuscula = contraseña.Any(char.IsLower);
            bool tieneNumero = contraseña.Any(char.IsDigit);
            bool tieneCaracterEspecial = contraseña.Any(ch => !char.IsLetterOrDigit(ch));

            return tieneMayuscula && tieneMinuscula && tieneNumero && tieneCaracterEspecial;
        }

    }
}
