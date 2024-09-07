using BE;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public static class MapHelper
    {
        public static BECompras MapearCompra(SqlDataReader reader) =>
            new BECompras
            {
                _idCompra = Convert.ToInt32(reader["idCompra"]),
                _idProducto = Convert.ToInt32(reader["idProducto"]),
                _cantidad = Convert.ToInt32(reader["cantidad"]),
                _totalAPagar = Convert.ToDecimal(reader["totalAPagar"]),
                //   _fechaCompra = reader["fechaCompra"] != DBNull.Value ? Convert.ToDateTime(reader["fechaCompra"]) : DateTime.Now, 
                _metodoPago = reader["metodoPago"].ToString()
            };

        public static BEProductos MapearProducto(SqlDataReader reader) =>
            new BEProductos
            {
                _idproducto = Convert.ToInt32(reader["idproducto"]),
                _nombre = reader["nombre"].ToString(),
                _categoria = reader["categoria"].ToString(),
                _precio = Convert.ToInt32(reader["precio"]),
                _encriptado = reader["Encriptado"].ToString()
            };

        public static BEUsuario MapearUsuario(SqlDataReader reader) =>
            new BEUsuario
            {
                Usuario = reader["usuario"].ToString(),
                Contraseña = reader["contraseña"].ToString(),
                Rol = Convert.ToInt32(reader["idRol"]),
            };
    }
}
