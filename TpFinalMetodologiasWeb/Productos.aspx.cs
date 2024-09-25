﻿using BE;
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
            if (!IsPostBack)
            {
                CargarProductos();
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
                Response.Write("Error: " + ex.Message);
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