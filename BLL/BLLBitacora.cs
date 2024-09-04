using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class BLLBitacora
    {
        DALBitacora ObjBitacora = new DALBitacora();
        public void RegistrarBitacora(string fecha, string usuario, string movimiento, string modulo)
        {
            ObjBitacora.RegistrarBitacora(fecha, usuario, movimiento, modulo);
        }

        public DataTable TraerDatos()
        {
            return ObjBitacora.TraerDatos();
        }
    }
}
