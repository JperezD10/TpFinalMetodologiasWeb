using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class Restore : System.Web.UI.Page
    {
        BLLBackup _bll = new BLLBackup();
        BLLDVH _bllDigito = new BLLDVH();
        BLLUsuario _bllUsuario = new BLLUsuario();
        BLLProductos _bllProductos = new BLLProductos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "No se detectaron inconsistencias";
            DataSet ds = new DataSet();
            ds = _bllDigito.ConcatenarEncriptarValoresActules();  //Encripto valores de tablas por fila

            DataTable Tusuario = new DataTable();
            Tusuario = _bllUsuario.GetUsuario();

            List<BEProductos> lProductos = new List<BEProductos>();
            lProductos = _bllProductos.ObtenerProductos();

            string resultado = "";
            int n = 0;
            foreach (DataRow row in Tusuario.Rows) //recorre los usuarios
            {
                if (row[3].ToString() != ds.Tables["dt_usuario"].Rows[n][0].ToString()) //compara Encriptado de T. Usuarios con Encriptado realizado actual
                {
                    resultado += " Id de usuario: " + row[0].ToString() + ";";
                }
                n++;
                if (!string.IsNullOrEmpty(resultado))
                {
                    Label2.Text = "Se detectaron registros erroneos en la tabla Usuarios, registros <br/>: " + resultado;
                    Label2.ForeColor = Color.Red;
                }
            }


            n = 0;
            foreach (var item in lProductos) //recorre lista productos
            {
                if (item._encriptado.ToString() != ds.Tables["dt_productos"].Rows[n][0].ToString()) //compara Encriptado de lista productos con Encriptado realizado actual
                {
                    resultado += " Id de producto: " + item._idproducto.ToString() + ";";
                }

                n++;
                if (!string.IsNullOrEmpty(resultado))
                {
                    Label2.Text = "Se detectaron registros erroneos en la tabla Usuarios, registros <br/>: " + resultado;
                    Label2.ForeColor = Color.Red;
                }
            }

            /*

            //REALIZAR DVH POR TABLA para ver tabla con inconsistencia
            DataSet ds = new DataSet();
            ds = _bllDigito.ConcatenarEncriptarValoresActules();  //Encripto valores de tablas



            DataSet ds2 = new DataSet();
            ds2 = _bllDigito.Sumas_Registros_Horizontal_Por_Tabla_Individual(ds);

            //_bllDigito.Guarda_Suma_Encriptada_TotalTablas_Individual(ds2);

            DataSet ds3 = new DataSet();
            ds3 = _bllDigito.GetEncriptadoTablasIndividual();


            //ds3[0][1] --> usuarios y encriptado
            //ds3[1][1] --> productos y encriptado
            Label2.Text = "Se encontraron inconsistencias en la base de datos de la tabla:";
            Label2.ForeColor = System.Drawing.Color.Red;
            if (ds3.Tables[0].Rows[0][1].ToString() != ds2.Tables["dt_usuario"].Rows[0][0].ToString())
            {
                Label2.Text += " - Usuarios";
            }
            if (ds3.Tables[0].Rows[1][1].ToString() != ds2.Tables["da_productos"].Rows[0][0].ToString())
            {
                Label2.Text += " - Productos";
            }
            if((ds3.Tables[0].Rows[0][1].ToString() == ds2.Tables["dt_usuario"].Rows[0][0].ToString())&&
                    (ds3.Tables[0].Rows[1][1].ToString() == ds2.Tables["da_productos"].Rows[0][0].ToString()))
            {
                Label2.Text = "No se encontraron insconsistencias en la BD";
                Label2.ForeColor = System.Drawing.Color.Green;
            }
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.FileName);

            string filePath = Server.MapPath("~/Backups/") + fileName;
            FileUpload1.SaveAs(filePath);
            Label1.Text = "";

            try
            {
                _bll.RestaurarBackup(filePath);
                Label1.Text = "Se realizó el restore correctamente";
                Label1.ForeColor = Color.Green;
                Label2.Visible = false;
            }
            catch (Exception ex)
            {
                Label1.Text = $"Error: {ex.Message}";
                Label1.ForeColor = Color.Red;
            }
        }
    }
}