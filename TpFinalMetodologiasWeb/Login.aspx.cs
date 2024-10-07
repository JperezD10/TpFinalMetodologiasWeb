using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public partial class Login : ResultPage
    {
        BLLUsuario BLLUsuario = new BLLUsuario();
        BEUsuario BEUsuario;
        BLLBitacora _bitacora = new BLLBitacora();
        BLLDVH _bllDigito = new BLLDVH();
        protected void Page_Load(object sender, EventArgs e)
        {
            LBLError.Visible = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            //string encriptado;
            //Se realiza DVH
            DataSet ds = new DataSet();
            ds = _bllDigito.ConcatenarEncriptarValoresActules();  //Encripto valores de tablas
            DataSet ds2 = new DataSet();
            ds2 = _bllDigito.Sumas_Registros_Horizontal_Por_Tabla_Individual(ds); //Sumo registros encriptados

            DataSet ds3 = new DataSet();
            ds3 = _bllDigito.GetEncriptadoTablasIndividual(); //traigo encriptado anterior de BD

            //guarda nuevo encriptado de tablas en VarSumaEncriptada
            //_bllDigito.Guarda_Suma_Encriptada_TotalTablas_Individual(ds2);

            //se realiza la comparacion entre tablas actualmente encriptadas y las anteriores
            if ((ds3.Tables[0].Rows[0][1].ToString() != ds2.Tables["dt_usuario"].Rows[0][0].ToString()) ||
                (ds3.Tables[0].Rows[1][1].ToString() != ds2.Tables["dt_productos"].Rows[0][0].ToString()))
            {
                if (GetDatosUsuario() && txtUsuario.Text == "Nadia")  //seria el administrador en este caso
                {
                    Response.Redirect("Restore.aspx"); //redirecciono a Menu Principal
                }
                else
                {
                    LBLError.Text = "No puede ingresar, contacte al administrador (inconsistencia)";
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                    return;
                }
            }

            //DIGITO VERTICAL  -> hacer validacion
           // BLLDVV _dvv = new BLLDVV();
            //_dvv.RealizarDigitoVertical();




            var bllResult = BLLUsuario.Login(txtUsuario.Text, txtContraseña.Text);

            this.ValidateResponse(bllResult, LBLError);
            if (bllResult.Ok)
            {
                _bitacora.RegistrarBitacora(new BEBitacora(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), bllResult.Data.Usuario, "Logueo de usuario", "Módulo Login"));
                Session["Rol"] = bllResult.Data.Rol;
                Session["Usuario"] = bllResult.Data.Usuario;
                Response.Redirect($"{bllResult.Data.DefaultPage}.aspx");
            }
        }



        public bool GetDatosUsuario()
        {
            BEUsuario usuario = BLLUsuario.ObtenerUsuario(txtUsuario.Text);
            if (usuario == null)
                return false;

            Session["Rol"] = usuario.Rol;
            Session["Usuario"] = usuario.Usuario;
            return true;
        }
    }
}