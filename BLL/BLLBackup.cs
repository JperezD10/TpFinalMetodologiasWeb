using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLBackup
    {
        DALBackup dal = new DALBackup();
        public bool RealizarBackup(string ruta)
        {
            return dal.RealizarBackup(ruta);
        }

        public bool RestaurarBackup(string ruta)
        {
           return dal.RestaurarBackup(ruta);
        }
    }
}
