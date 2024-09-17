using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProductos
    {
        private DALProductos _dalProductos = new DALProductos();

        public List<BEProductos> ObtenerProductos()
        {
            return _dalProductos.ObtenerProductos();
        }

        //el nuevo seria
        public Result<List<BEProductos>> GetProductos()
        {
            try
            {
                var productos = _dalProductos.ObtenerProductos();
                return Result<List<BEProductos>>.Success(productos);
            }
            catch (Exception ex)
            {
                return Result<List<BEProductos>>.Error("Ha ocurrido un error", new List<BEProductos>());
            }
        }

        public void AgregarProducto(BEProductos producto)
        {
            _dalProductos.AgregarProducto(producto);
        }
        public BEProductos ObtenerProductoPorId(int id)
        {
            return _dalProductos.ObtenerProductoPorId(id);
        }
    }
}
