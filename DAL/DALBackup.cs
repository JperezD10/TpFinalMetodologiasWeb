using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALBackup
    {
        DALConexion con = new DALConexion();
        public bool RealizarBackup(string ruta)
        {
            try
            {
                con.AbrirConexion();
                SqlCommand comando = new SqlCommand();
                comando.Connection = con.con;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "BACKUP DATABASE [Libreria] TO  DISK = '" + ruta + "' " +
                    "WITH NOFORMAT, NOINIT, NAME = N'Libreria-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                comando.ExecuteNonQuery();
                con.CerrarConexion();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool RestaurarBackup(string ruta)
        {
            try
            {
                con.AbrirConexion();
                SqlCommand comando = new SqlCommand();
                comando.Connection = con.con;
                comando.CommandType = CommandType.Text;
                //con with rollback cierro todas las transacciones abiertas y revierte la transaccion q este en curso
                comando.CommandText = "USE MASTER ALTER DATABASE [Libreria] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                comando.ExecuteNonQuery();

                comando.CommandText = "USE [master]" +
                    " RESTORE DATABASE [Libreria] FROM DISK = '" + ruta + "' WITH REPLACE;" +
                    " ALTER DATABASE [Libreria] SET MULTI_USER;";


                comando.ExecuteNonQuery();
                con.CerrarConexion();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
