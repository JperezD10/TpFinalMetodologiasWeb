using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProductos
    {

        private int idproducto;

        public int _idproducto
        {
            get { return idproducto; }
            set { idproducto = value; }
        }

        private string nombre;

        public string _nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string categoria;

        public string _categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        private int precio;

        public int _precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string encriptado;

        public string _encriptado
        {
            get { return encriptado; }
            set { encriptado = value; }
        }


    }
}
