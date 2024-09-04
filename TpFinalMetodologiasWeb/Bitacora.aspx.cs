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
        public Bitacora()
        {
            _bitacora = new BLLBitacora();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _bitacora.TraerDatos();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}