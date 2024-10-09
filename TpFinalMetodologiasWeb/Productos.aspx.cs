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
    public partial class Productos : ResultPage
    {
        private BLLProductos _bllProductos = new BLLProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidatePermission(RolUsuario.WEB_MASTER);
            if (!IsPostBack)
            {
                CargarProductos();
                lblError.Visible = false;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BEProductos nuevoProducto = new BEProductos
                {
                    _nombre = txtnombre.Text,
                    _categoria = txtcategoria.Text,
                    _precio = int.Parse(txtprecio.Text)
                };

                _bllProductos.AgregarProducto(nuevoProducto);
                CargarProductos();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        private void CargarProductos()
        {
            var productos = _bllProductos.GetProductos();
            RepeaterProductos.DataSource = productos.Data;
            RepeaterProductos.DataBind();
            this.ValidateResponse(productos, lblError);
        }
    }
}