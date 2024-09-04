using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECompras
    {
        private int idCompras;

        public int _idCompra
        {
            get { return idCompras; }
            set { idCompras = value; }
        }
        private int idProducto;

        public int _idProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        private int cantidad;

        public int _cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private DateTime fechacompra;

        /*	public DateTime _fechaCompra
            {
                get { return fechacompra; }
                set { fechacompra = value; }
            }*/
        private string metodoPago;

        public string _metodoPago
        {
            get { return metodoPago; }
            set { metodoPago = value; }
        }
        private decimal totalAPagar;

        public decimal _totalAPagar
        {
            get { return totalAPagar; }
            set { totalAPagar = value; }
        }

    }


}

