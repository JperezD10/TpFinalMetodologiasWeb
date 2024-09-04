using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCompras
    {
        private DALCompras _dalCompras = new DALCompras();

        public void AgregarCompra(BECompras compra)
        {
            _dalCompras.AgregarCompra(compra);
        }
        public List<BECompras> ObtenerCompras()
        {
            return _dalCompras.ObtenerCompras();
        }
    }
}
