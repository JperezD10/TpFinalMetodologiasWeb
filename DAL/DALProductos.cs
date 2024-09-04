using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProductos
    {

        DALConexion _con = new DALConexion();

        public List<BEProductos> ObtenerProductos()
        {
            List<BEProductos> productos = new List<BEProductos>();

            try
            {
                using (SqlConnection con = _con.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productos.Add(MapHelper.MapearProducto(reader));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }

            return productos;
        }

        public void AgregarProducto(BEProductos producto)
        {
            try
            {
                using (SqlConnection con = _con.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Productos (nombre, categoria, precio) VALUES (@nombre, @categoria, @precio)", con);
                    cmd.Parameters.AddWithValue("@nombre", producto._nombre);
                    cmd.Parameters.AddWithValue("@categoria", producto._categoria);
                    cmd.Parameters.AddWithValue("@precio", producto._precio);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
        }

        public BEProductos ObtenerProductoPorId(int id)
        {
            BEProductos producto = null;

            try
            {
                using (SqlConnection con = _con.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Productos WHERE idproducto = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        producto = MapHelper.MapearProducto(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto por ID: " + ex.Message);
            }

            return producto;
        }
    }



}
