using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCompras
    {
        DALConexion _con = new DALConexion();

        public void AgregarCompra(BECompras compra)
        {
            try
            {
                using (SqlConnection con = _con.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Compras (idProducto, cantidad, totalAPagar, fechaCompra, metodoPago) VALUES (@idProducto, @cantidad, @totalAPagar, @fechaCompra, @metodoPago)", con);
                    cmd.Parameters.AddWithValue("@idProducto", compra._idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", compra._cantidad);
                    cmd.Parameters.AddWithValue("@totalAPagar", compra._totalAPagar);
                    //  cmd.Parameters.AddWithValue("@fechaCompra", compra._fechaCompra != null ? (DateTime)compra._fechaCompra : DateTime.Now); // Usar la fecha actual si _fechaCompra es nulo

                    cmd.Parameters.AddWithValue("@metodoPago", compra._metodoPago);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la compra: " + ex.Message);
            }
        }

        public List<BECompras> ObtenerCompras()
        {
            List<BECompras> compras = new List<BECompras>();

            try
            {
                using (SqlConnection con = _con.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Compras", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BECompras compra = new BECompras
                        {
                            _idCompra = Convert.ToInt32(reader["idCompra"]),
                            _idProducto = Convert.ToInt32(reader["idProducto"]),
                            _cantidad = Convert.ToInt32(reader["cantidad"]),
                            _totalAPagar = Convert.ToDecimal(reader["totalAPagar"]),
                            //   _fechaCompra = reader["fechaCompra"] != DBNull.Value ? Convert.ToDateTime(reader["fechaCompra"]) : DateTime.Now, 
                            _metodoPago = reader["metodoPago"].ToString()
                        };
                        compras.Add(compra);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las compras: " + ex.Message);
            }

            return compras;
        }
    }
}

