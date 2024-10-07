using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAL
{
    public class DALConexion
    {
        public SqlConnection con;
        SqlTransaction _transaction;
        public DALConexion()
        {
            /*NADIA CONEXION*/
            con = new SqlConnection("Data Source=DESKTOP-DQVMASA\\MSSQLSERVER01;Initial Catalog=Libreria;Integrated Security=True");

            // MAITE
            // con = new SqlConnection("Data Source=MAITE15\\MSSQLSERVER01;Initial Catalog=sistemalibreria;Integrated Security=True;TrustServerCertificate=True");

            //conexion juli
            //con = new SqlConnection("Data Source=.;Initial Catalog=Libreria;Integrated Security=True");
        }

        private static DALConexion _instance = null;

        public static DALConexion GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DALConexion();
                }

                return _instance;
            }
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

        public DataTable Leer(string st, SqlParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            CerrarConexion();
            AbrirConexion();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand();
            sqlDataAdapter.SelectCommand.CommandType = commandType;
            sqlDataAdapter.SelectCommand.CommandText = st;
            if (parameters != null)
            {
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
            }
            sqlDataAdapter.SelectCommand.Connection = con;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CerrarConexion();
            return dataTable;
        }

        public int Escribir(string st, SqlParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            CerrarConexion();
            AbrirConexion();
            _transaction = con.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandType = commandType,
                CommandText = st,
                Connection = con,
            };
            sqlCommand.Parameters.AddRange(parameters);
            try
            {
                sqlCommand.Transaction = _transaction;
                sqlCommand.ExecuteNonQuery();
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return 0;
            }
            CerrarConexion();
            return 1;
        }
    }
}
