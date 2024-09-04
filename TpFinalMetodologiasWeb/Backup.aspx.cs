using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class Backup : System.Web.UI.Page
    {
        BLLBackup _backup;
        BLLDVH _bllDigito;
        public Backup()
        {
            _backup = new BLLBackup();
            _bllDigito = new BLLDVH();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }
        protected void Button1_Click2(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = _bllDigito.ConcatenarEncriptarValoresActules();
            DataSet ds2 = new DataSet();
            ds2 = _bllDigito.Sumas_Registros_Horizontal_Por_Tabla_Individual(ds);
            _bllDigito.Guarda_Suma_Encriptada_TotalTablas_Individual(ds2);

            string FileName = "Libreria" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";

            bool estado_backup = _backup.RealizarBackup("C:\\Users\\Usuario\\OneDrive\\Escritorio\\TPv9\\TP\\TP2\\Backups" + "\\" + FileName);

            if (estado_backup == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se realizó el backup correctamente');", true);
                CargarTabla();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al realizar el backup');", true);
            }

        }

        public void CargarTabla()
        {
            string[] nombresArchivos = Directory.GetFiles("C:\\Users\\Usuario\\OneDrive\\Escritorio\\TPv9\\TP\\TP2\\Backups");

            DataTable dt = new DataTable();
            //dt.Columns.Add("Selección");
            dt.Columns.Add("Nombre");
            //dt.Columns.Add("Fecha");


            foreach (var item in nombresArchivos)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = Path.GetFileName(item);
                dt.Rows.Add(dr);
            }

            GridView1.DataSource = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}