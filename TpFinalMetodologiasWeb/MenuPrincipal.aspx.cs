using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        public BLLPermisos permisos = new BLLPermisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");
            /*if (Session["Usuario"] != null && Session["Rol"] != null)
            {
                string rol = Session["Rol"].ToString();

                // Redirigir según el rol
                if (rol == "web master")
                {
                    Response.Redirect("Productos.aspx");
                }
                else if (rol == "cliente")
                {
                    Response.Redirect("Compras.aspx");
                }
            }
            else
            {
                // Si el usuario no está autenticado, redirigir a la página de inicio de sesión
                Response.Redirect("Login.aspx");
            }*/
        }


        protected void btnfecha(object sender, EventArgs e)
        {
            TextBoxFecha.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");

        }

        protected void TextBoxFecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}