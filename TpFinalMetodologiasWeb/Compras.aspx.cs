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
    public partial class Compras : System.Web.UI.Page
    {
        private BLLProductos _bllProductos = new BLLProductos();
        private BLLCompras _bllCompras = new BLLCompras();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                BECompras nuevaCompra = new BECompras
                {
                    _idProducto = int.Parse(ddlProductos.SelectedValue),
                    _cantidad = int.Parse(txtCantidad.Text),
                    _totalAPagar = (decimal)ViewState["totalAPagar"],
                    //       _fechaCompra = DateTime.Now,
                    _metodoPago = ddlMetodoPago.SelectedValue
                };

                _bllCompras.AgregarCompra(nuevaCompra);
                litMessage.Text = "Compra realizada con éxito.";
            }
            catch (Exception ex)
            {
                litMessage.Text = "Error al realizar la compra: " + ex.Message;
            }
        }
        private void CargarProductos()
        {
            try
            {
                List<BEProductos> productos = _bllProductos.ObtenerProductos();
                ddlProductos.DataSource = productos;
                ddlProductos.DataTextField = "_nombre";
                ddlProductos.DataValueField = "_idproducto";
                ddlProductos.DataBind();
                ddlProductos.Items.Insert(0, new ListItem("--Seleccione un producto--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar los productos: " + ex.Message);
            }
        }
        private void CalcularTotal()
        {
            try
            {
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                decimal total = cantidad * precio;
                lblTotal.Text = "Total a pagar: $" + total.ToString("0.00");
                decimal totalAPagar = cantidad * precio;
                ViewState["totalAPagar"] = totalAPagar;
            }
            catch
            {
                lblTotal.Text = "Total a pagar: $0.00";
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(ddlProductos.SelectedValue);
                txtPrecio.Text = _bllProductos.ObtenerProductoPorId(productId)._precio.ToString();
                CalcularTotal();
            }
            catch (Exception ex)
            {
                Response.Write("Error al seleccionar producto: " + ex.Message);
            }
        }
    }
}