using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class BLLDVV
    {
        DVV _dal = new DVV();

        public DataSet RealizarDigitoVertical()
        {
            DataSet ds = new DataSet();
            ds=_dal.ConcatenarEncriptados();
            return ds;
        }

        public void GuardarEncriptado(DataSet ds)
        {
            _dal.GuardarEncriptado(ds);
        }
    }
}
