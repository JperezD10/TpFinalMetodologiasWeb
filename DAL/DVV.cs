using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DVV
    {
        DALConexion _con = new DALConexion();

        public string GetEncriptado(string _contraseña)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(_contraseña));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        public DataSet ConcatenarEncriptados()
        {
            _con.AbrirConexion();
            DataSet ds = new DataSet();
            SqlDataAdapter da_usuario = new SqlDataAdapter("select Encriptado from Usuarios", _con.con);
            SqlDataAdapter da_productos = new SqlDataAdapter("select Encriptado from Productos", _con.con);
            da_usuario.Fill(ds, "Usuarios");
            da_productos.Fill(ds, "Productos");

            _con.CerrarConexion();

            ds = Suma_Registros(ds);

            //Guarda_Encriptado(ds);

            return ds;
        }


        public void GuardarEncriptado(DataSet ds)
        {
            _con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = _con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "delete DVV";
            comando.ExecuteNonQuery();
            foreach (DataTable item in ds.Tables)
            {
                comando.CommandText = "insert into DVV values('" + item.ToString() + "', '"+ ds.Tables[item.ToString()].Rows[0][0] + "' )";
                comando.ExecuteNonQuery();

            }
            _con.CerrarConexion();
        }

        
        public DataSet Suma_Registros(DataSet ds)
        {
            string concatenado = "";
            DataSet ds_nuevo = new DataSet();


            foreach (DataTable tabla in ds.Tables) //por cada tabla, (usuarios, productos)
            {
                ds_nuevo.Tables.Add(tabla.ToString());
                ds_nuevo.Tables[tabla.ToString()].Columns.Add("ConcatEncriptado");

                for (int n = 1; n <= tabla.Rows.Count; n++)
                {
                    concatenado += tabla.Rows[n - 1][0].ToString();

                }
                ds_nuevo.Tables[tabla.ToString()].Rows.Add(concatenado);
            }

            return ds_nuevo;
        }
    }
}
