using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLPermisos
    {

        DALPermisos permisos = new DALPermisos();
        public bool HasPermission(string CurrentUser,string CurrentForm)
        {
            return permisos.HasPermission(CurrentUser, CurrentForm);
        }
    }
}
