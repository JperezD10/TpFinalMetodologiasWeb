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


        public bool ContraseñaCorrecta(string username, string contraseña_encriptada)
        {
            try
            {
                DataSet ds = new DataSet();
                string ContraseñaGuardada;

                ds = ObjUsuario.ObtenerContraseña(username); //obtengo contraseña guardada
                ContraseñaGuardada = ds.Tables[0].Rows[0][1].ToString();

                return ContraseñaGuardada == contraseña_encriptada;
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
                    Rol = (int)row["idRol"]
                };
            }
            return null;
        }



        
        public DataTable GetUsuario()
        {
            return ObjUsuario.ObtenerTodosUsuarios();
        }


        public static bool ContraseñaValida(string contraseña)
        {
            if (contraseña.Length < 8)
                return false;

            bool tieneMayuscula = contraseña.Any(char.IsUpper);
            bool tieneMinuscula = contraseña.Any(char.IsLower);
            bool tieneNumero = contraseña.Any(char.IsDigit);
            bool tieneCaracterEspecial = contraseña.Any(ch => !char.IsLetterOrDigit(ch));

            return tieneMayuscula && tieneMinuscula && tieneNumero && tieneCaracterEspecial;
        }

        public Result<BEUsuario> Login(string username, string password)
        {
            try
            {
                if (!ContraseñaValida(password))
                    return Result<BEUsuario>.Error("La contraseña no cumple con los requisitos de seguridad.", null);
                password = GetEncriptado(password);
                var dalResul = ObjUsuario.Login(username, password);
                if (dalResul == null)
                    return Result<BEUsuario>.Error("Usuario o Contraseña incorrecta", dalResul);
                return Result<BEUsuario>.Success(dalResul);
            }
            catch (Exception ex)
            {
                return Result<BEUsuario>.Error($"Ha ocurrido un error: {ex.Message}", null);
            }
            
        }
    }
}
