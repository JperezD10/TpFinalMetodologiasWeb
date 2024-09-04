using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALBitacora
    {
        DALConexion con = new DALConexion();
        public void RegistrarBitacora(string fecha, string usuario, string movimiento, string modulo)
        {
            con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "insert into Bitacora values('" + fecha + "', '" + usuario + "', '" + movimiento + "', '" + modulo + "')";
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        public DataTable TraerDatos()
        {
            con.AbrirConexion();
            SqlDataAdapter da = new SqlDataAdapter("select * from Bitacora order by fecha desc", con.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.CerrarConexion();
            return dt;
        }
    }
}
