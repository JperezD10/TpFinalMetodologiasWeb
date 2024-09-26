using BE;
using System;
using System.Data;
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

        public static BEUsuario MapearUsuario(SqlDataReader reader)
        {
            if (Convert.ToInt32(reader["idRol"]) == (int)RolUsuario.WEB_MASTER)
                return new UsuarioWebMaster
                {
                    Usuario = reader["usuario"].ToString(),
                    Contraseña = reader["contraseña"].ToString(),
                    Rol = Convert.ToInt32(reader["idRol"]),
                };
            return new UsuarioCliente
            {
                Usuario = reader["usuario"].ToString(),
                Contraseña = reader["contraseña"].ToString(),
                Rol = Convert.ToInt32(reader["idRol"]),
            };
        }
            

        public static BEUsuario MapearUsuario(DataRow Row)
        {
            {
                if (Convert.ToInt32(Row["idRol"]) == (int)RolUsuario.WEB_MASTER)
                    return new UsuarioWebMaster
                    {
                        Usuario = Row["usuario"].ToString(),
                        Contraseña = Row["contraseña"].ToString(),
                        Rol = Convert.ToInt32(Row["idRol"]),
                    };
                return new UsuarioCliente
                {
                    Usuario = Row["usuario"].ToString(),
                    Contraseña = Row["contraseña"].ToString(),
                    Rol = Convert.ToInt32(Row["idRol"]),
                };
            }
        }

        public static BEBitacora MapearBitacora(DataRow Row) =>
            new BEBitacora
            {
                Usuario = Row["usuario"].ToString(),
                Fecha = Row["fecha"].ToString(),
                Modulo = Row["modulo"].ToString(),
                Movimiento = Row["movimiento"].ToString(),
            };
    }
}
