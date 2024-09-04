using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Label1.Text = "Nos vemos " + Session["Usuario"].ToString();
            Session["Usuario"] = null;
            */

            //salida 
            if (Session["Usuario"] != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}