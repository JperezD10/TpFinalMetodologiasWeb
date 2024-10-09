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
    public partial class Bitacora : ResultPage
    {
        BLLBitacora _bitacora;
        List<BEBitacora> listBitacora;
        public bool showMessage { get; set; } = false;
        public Bitacora()
        {
            _bitacora = new BLLBitacora();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidatePermission(RolUsuario.WEB_MASTER);
            listBitacora = _bitacora.TraerDatos();
            Repeater1.DataSource = listBitacora;
            Repeater1.DataBind();
        }

        protected void btnConnectWS_Click(object sender, EventArgs e)
        {
            WebService1 webService1 = new WebService1();
            showMessage = webService1.ExportarBitacora(listBitacora);
        }
    }
}