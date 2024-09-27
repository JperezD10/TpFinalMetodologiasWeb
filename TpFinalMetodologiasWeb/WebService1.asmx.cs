using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace TpFinalMetodologiasWeb
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public bool ExportarBitacora(List<BEBitacora> bitacora)
        {
            try
            {
                string ruta = Server.MapPath("~/Archivos/bitacoras.xml");

                string directorio = Path.GetDirectoryName(ruta);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<BEBitacora>));

                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    serializer.Serialize(writer, bitacora);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
