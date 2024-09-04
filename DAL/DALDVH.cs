using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class DALDVH
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

        public DataSet ConcatenarEncriptarValoresActules()
        {
            _con.AbrirConexion();
            DataSet ds = new DataSet();
            SqlDataAdapter da_usuario = new SqlDataAdapter("select concat(usuario,contraseña, idRol) from Usuarios", _con.con);
            SqlDataAdapter da_productos = new SqlDataAdapter("select concat(idproducto, nombre, categoria,precio) from Productos", _con.con);

            //cargo tablas
            da_usuario.Fill(ds, "dt_usuario");
            da_productos.Fill(ds, "dt_productos");
            _con.CerrarConexion();
            ds = EncriptarConcatenadoTablas(ds);

            return ds;
        }

        public DataSet EncriptarConcatenadoTablas(DataSet ds)
        {
            string valoresE;
            DataSet dsNuevo = new DataSet();

            foreach (DataTable item in ds.Tables)
            {
                dsNuevo.Tables.Add(item.ToString());
                dsNuevo.Tables[item.ToString()].Columns.Add("ConcatEncriptadoo");
                for (int i = 1; i <= ds.Tables[item.ToString()].Rows.Count; i++)
                {
                    valoresE = GetEncriptado(ds.Tables[item.ToString()].Rows[i - 1][0].ToString());
                    dsNuevo.Tables[item.ToString()].Rows.Add(valoresE);
                }
            }
            return dsNuevo;
        }

        public DataSet Sumas_Registros_Horizontal_Por_Tabla(DataSet ds)
        {
            string sumaStrings = "";
            DataSet tables = new DataSet();

            foreach (DataTable item in ds.Tables)
            {
                tables.Tables.Add(item.ToString());
                tables.Tables[item.ToString()].Columns.Add("ConcatEncriptadoo");
                for (int n = 1; n <= ds.Tables[item.ToString()].Rows.Count; n++)
                {
                    sumaStrings += ds.Tables[item.ToString()].Rows[n - 1][0].ToString();

                }
                tables.Tables[item.ToString()].Rows.Add(sumaStrings);
            }

            return tables;
        }

        public void Guarda_Suma_Encriptada_TotalTablas(DataSet ds)
        {
            _con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = _con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "delete VarSumaEncriptada";
            comando.ExecuteNonQuery();
            foreach (DataTable item in ds.Tables)
            {
                comando.CommandText = "insert into VarSumaEncriptada values('" + ds.Tables[item.ToString()].Rows[0][0] + "')";
                comando.ExecuteNonQuery();

            }
            _con.CerrarConexion();
        }

        public DataSet GetEncriptado()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from VarSumaEncriptada", _con.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }




        //////prueba de encriptacion sumado tablas individuales
        public DataSet Sumas_Registros_Horizontal_Por_Tabla_Individual(DataSet ds)
        {
            string sumaStrings = "";
            DataSet tables = new DataSet();

            foreach (DataTable item in ds.Tables)
            {
                tables.Tables.Add(item.ToString());
                tables.Tables[item.ToString()].Columns.Add("ConcatEncriptadoo");
                for (int n = 1; n <= ds.Tables[item.ToString()].Rows.Count; n++)
                {
                    sumaStrings += ds.Tables[item.ToString()].Rows[n - 1][0].ToString();

                }
                tables.Tables[item.ToString()].Rows.Add(sumaStrings);
                sumaStrings = "";
            }

            return tables;
        }




        public void Guarda_Suma_Encriptada_TotalTablas_Individual(DataSet ds)
        {
            _con.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = _con.con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "delete SumaEncriptadaTablas";
            comando.ExecuteNonQuery();
            foreach (DataTable item in ds.Tables)
            {
                comando.CommandText = "insert into SumaEncriptadaTablas values('" + item.ToString() + "','" + ds.Tables[item.ToString()].Rows[0][0] + "')";
                comando.ExecuteNonQuery();

            }
            _con.CerrarConexion();
        }


        public DataSet GetEncriptadoTablasIndividual()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SumaEncriptadaTablas", _con.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        /*
        public void InsertarEncriptadoPorFila(string encriptado, int id)
        {
            _con.AbrirConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _con.con;
            cmd.CommandType = CommandType.Text;
            encriptado=GetEncriptado("Nadia03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f41");
            cmd.CommandText = "insert into Productos (Encriptado) values('"+encriptado+"') where idProducto=2";
            cmd.ExecuteNonQuery();
            _con.CerrarConexion();
        }*/
    }
}
