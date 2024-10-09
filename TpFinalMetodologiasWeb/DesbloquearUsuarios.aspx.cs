using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class DesbloquearUsuarios : System.Web.UI.Page
    {
        private BLLUsuario BLLUsuario;
        private List<BEUsuario> usuariosBloqueados;
        public DesbloquearUsuarios()
        {
            BLLUsuario = new BLLUsuario();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuariosBloqueados();
            }
        }

        protected void DesbloquearUsuario(object sender, EventArgs e)
        {

            HtmlButton btnDesbloquear = (HtmlButton)sender;

            string usuario = btnDesbloquear.Attributes["data-usuario"];

            BLLUsuario.DesbloquearUsuario(usuario);

            CargarUsuariosBloqueados();
        }
        private void CargarUsuariosBloqueados()
        {
            usuariosBloqueados = BLLUsuario.GetUsuariosBloqueados().Data;
            rptUsuariosBloqueados.DataSource = usuariosBloqueados;
            rptUsuariosBloqueados.DataBind();
        }
        protected void rptUsuariosBloqueados_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}