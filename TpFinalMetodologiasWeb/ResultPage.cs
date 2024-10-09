using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public class ResultPage: Page
    {
        protected void ValidateResponse<T>(Result<T> result, Label label)
        {
            if (!result.Ok)
            {
                label.Text = result.Message;
            }
            label.Visible = !result.Ok;
        }

        protected void ValidatePermission(RolUsuario rol)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            BEUsuario usuario = (BEUsuario)Session["Usuario"];
            if (usuario.Rol != (int)rol)
                Response.Redirect("UnauthorizatedAccess.aspx");
        }
    }
}