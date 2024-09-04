using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class BLLDVH
    {

        DALDVH _dal = new DALDVH();

        public DataSet GetEncriptado()
        {
            return _dal.GetEncriptado();
        }

        public void Guarda_Suma_Encriptada_TotalTablas(DataSet ds)
        {
            _dal.Guarda_Suma_Encriptada_TotalTablas(ds);
        }
        public DataSet ConcatenarEncriptarValoresActules()
        {
            return _dal.ConcatenarEncriptarValoresActules();
        }

        public DataSet Sumas_Registros_Horizontal_Por_Tabla(DataSet ds)
        {
            return _dal.Sumas_Registros_Horizontal_Por_Tabla(ds);
        }



        //prueba encriptado tabla individual
        public DataSet Sumas_Registros_Horizontal_Por_Tabla_Individual(DataSet ds)
        {
            return _dal.Sumas_Registros_Horizontal_Por_Tabla_Individual(ds);
        }

        public void Guarda_Suma_Encriptada_TotalTablas_Individual(DataSet ds)
        {
            _dal.Guarda_Suma_Encriptada_TotalTablas_Individual(ds);
        }

        public DataSet GetEncriptadoTablasIndividual()
        {
            return _dal.GetEncriptadoTablasIndividual();
        }
    }
}
