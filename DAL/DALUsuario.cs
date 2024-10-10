using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Security.Cryptography;
using BE;

namespace DAL
{
    public class DALUsuario
    {


        DALConexion con = new DALConexion();

        public void RegistrarUsuario(string usuario, string contraseña)
        {
            con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "insert into Usuarios values('" + usuario + "', '" + contraseña + "')";
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }


        public string GetEncriptado(string contraseña)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(contraseña));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }


        public DataSet ObtenerContraseña(string usuario)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select usuario, contraseña from Usuarios where usuario='" + usuario + "'", con.con);
            da.Fill(ds);
            con.CerrarConexion();
            return ds;
        }
        public DataSet ObtenerUsuario(string usuario)
        {
            // NADIA CONEXION con=new SqlConnection("Data Source=DESKTOP-DQVMASA\\MSSQLSERVER01;Initial Catalog=Libreria;Integrated Security=True");

            DataSet ds = new DataSet();
            var con = DALConexion.GetInstance.con;
            string query = "SELECT * FROM Usuarios WHERE usuario=@usuario";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@usuario", usuario);
            da.Fill(ds);
            return ds;
        }






        public int ObtenerRolPorUsuario(String usuario)
        {
            con.AbrirConexion();
            SqlCommand cmd = new SqlCommand("GetRoleByUsername", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", usuario);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            con.CerrarConexion();
            return resultado;

        }


        public DataTable ObtenerTodosUsuarios()
        {
            DataTable dt = new DataTable();
            con.AbrirConexion();
            SqlDataAdapter da = new SqlDataAdapter("select * from usuarios", con.con);
            da.Fill(dt);
            con.CerrarConexion();
            return dt;
        }

        public BEUsuario Login(string username, string password)
        {
            var conn = DALConexion.GetInstance;
            var datatable = conn.Leer($"SELECT * FROM USUARIOS WHERE usuario = '{username}'", null);
            foreach (DataRow dr in datatable.Rows)
            {
                return MapHelper.MapearUsuario(dr);
            }
            return null;
        }

        public List<BEUsuario> GetUsuariosBloqueados()
        {
            var conn = DALConexion.GetInstance;
            var list = new List<BEUsuario>();
            var datatable = conn.Leer($"select * from Usuarios where Bloqueado = 1", null);
            foreach (DataRow dr in datatable.Rows)
            {
                list.Add(MapHelper.MapearUsuario(dr));
            }
            return list;
        }

        public bool DesbloquearUsuario(string usuario)
        {
            var conn = DALConexion.GetInstance;
            var result = conn.Escribir($"update Usuarios set Bloqueado = 0 , IntentosRestantes = 3 where usuario = @usuario", new SqlParameter[] {new SqlParameter("@usuario", usuario)});
            return result > 0;
        }

        public bool BloquearUsuario(string usuario)
        {
            var conn = DALConexion.GetInstance;
            var result = conn.Escribir($"update Usuarios set Bloqueado = 1, IntentosRestantes = 0 where usuario = @usuario", new SqlParameter[] { new SqlParameter("@usuario", usuario) });
            return result > 0;
        }

        public bool ActualizarIntentosRestantes(string usuario, int intentosRestantes)
        {
            var conn = DALConexion.GetInstance;
            var result = conn.Escribir($"update Usuarios set IntentosRestantes = @intentosRestantes where usuario = @usuario", new SqlParameter[] 
            { 
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@intentosRestantes", intentosRestantes)
            });
            return result > 0;
        }

        public bool ReestablecerIntentos(string usuario)
        {
            var conn = DALConexion.GetInstance;
            var result = conn.Escribir($"update Usuarios set IntentosRestantes = 3 where usuario = @usuario", new SqlParameter[] { new SqlParameter("@usuario", usuario) });
            return result > 0;
        }
    }
}
