using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class SiteMaster : MasterPage
    {
        BLLBitacora bLLBitacora;
        public SiteMaster()
        {
            bLLBitacora = new BLLBitacora();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            var usuario = (BEUsuario)Session["Usuario"];
            bLLBitacora.RegistrarBitacora(new BEBitacora
            {
                Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Modulo = "Logout",
                Movimiento = $"Cierre de sesion del usuario",
                Usuario = usuario.Usuario
            });
            Session["Usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}