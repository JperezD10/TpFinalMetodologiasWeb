using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class Bitacora : System.Web.UI.Page
    {
        BLLBitacora _bitacora;
        List<BEBitacora> listBitacora;
        public Bitacora()
        {
            _bitacora = new BLLBitacora();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            listBitacora = _bitacora.TraerDatos();
            GridView1.DataSource = listBitacora;
            GridView1.DataBind();
        }

        protected void btnConnectWS_Click(object sender, EventArgs e)
        {
            WebService1 webService1 = new WebService1();
            webService1.ExportarBitacora(listBitacora);
        }
    }
}