using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BE;

namespace BLL
{
    public class BLLBitacora
    {
        DALBitacora ObjBitacora = new DALBitacora();
        public void RegistrarBitacora(BEBitacora bitacora)
        {
            ObjBitacora.RegistrarBitacora(bitacora);
        }

        public List<BEBitacora> TraerDatos()
        {
            return ObjBitacora.TraerBitacoraList();
        }
    }
}
