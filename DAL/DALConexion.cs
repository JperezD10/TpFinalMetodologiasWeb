using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALConexion
    {
        public SqlConnection con;

        public DALConexion()
        {
            /*NADIA CONEXION*/
            con = new SqlConnection("Data Source=DESKTOP-DQVMASA\\MSSQLSERVER01;Initial Catalog=Libreria;Integrated Security=True");

            // MAITE
            // con = new SqlConnection("Data Source=MAITE15\\MSSQLSERVER01;Initial Catalog=sistemalibreria;Integrated Security=True;TrustServerCertificate=True");
        }
        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void CerrarConexion()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
