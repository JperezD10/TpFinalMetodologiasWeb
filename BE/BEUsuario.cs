using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario
    {
        private string _id_usuario;

        public string Id_Usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _contraseña;

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public string Rol { get; set; }
    }
}
