using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class DALBitacora
    {
        DALConexion con = new DALConexion();
        public void RegistrarBitacora(BEBitacora bitacora)
        {
            con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = $"insert into Bitacora values('{bitacora.Fecha}', '{bitacora.Usuario}', '{bitacora.Movimiento}', '{bitacora.Modulo}')";
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        public DataTable TraerDatos()
        {
            con.AbrirConexion();
            SqlDataAdapter da = new SqlDataAdapter("select top 20 fecha as Fecha, usuario as Usuario, movimiento as Movimiento, modulo as Modulo from Bitacora order by fecha desc", con.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.CerrarConexion();
            return dt;
        }
    }
}
