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
    public partial class Login : System.Web.UI.Page
    {
        BLLUsuario BLLUsuario = new BLLUsuario();
        BEUsuario BEUsuario = new BEUsuario();
        BLLBitacora _bitacora = new BLLBitacora();
        BLLDVH _bllDigito = new BLLDVH();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            string encriptado;
            try
            {
                // Validar la contraseña 
                if (!BLLUsuario.ContraseñaValida(txtContraseña.Text))
                {

                    LBLError.Visible = true;
                    LBLError.Text = "La contraseña no cumple con los requisitos de seguridad.";
                    return;
                }

                //Se realiza DVH
                DataSet ds = new DataSet();
                ds = _bllDigito.ConcatenarEncriptarValoresActules();  //Encripto valores de tablas
                DataSet ds2 = new DataSet();
                ds2 = _bllDigito.Sumas_Registros_Horizontal_Por_Tabla_Individual(ds); //Sumo registros encriptados

                DataSet ds3 = new DataSet();
                ds3 = _bllDigito.GetEncriptadoTablasIndividual(); //traigo encriptado anterior de BD

                //guarda nuevo encriptado de tablas en VarSumaEncriptada
                //_bllDigito.Guarda_Suma_Encriptada_TotalTablas_Individual(ds2);

                BEUsuario.Usuario = txtUsuario.Text;


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
                encriptado = BLLUsuario.GetEncriptado(txtContraseña.Text);
                if (!BLLUsuario.ContraseñaCorrecta(txtUsuario.Text, encriptado))
                {
                    LBLError.Visible = true;
                    LBLError.Text = "Usuario o contraseña incorrecta, intente nuevamente";
                    return;
                }

                //si las contraseñas son iguales
                _bitacora.RegistrarBitacora(new BEBitacora(DateTime.Now.ToString("yyyy-MM-dd"), BEUsuario.Usuario, "Logueo de usuario", "Módulo Login"));


                if (GetDatosUsuario())
                {
                    Response.Redirect("MenuPrincipal.aspx");
                }
                else
                {
                    LBLError.Visible = true;
                    LBLError.Text = "Error al obtener el rol del usuario.";
                }


                /*BEUsuario usuario = BLLUsuario.ObtenerUsuario(txtUsuario.Text);
                if (usuario != null)
                {
                    Session["Rol"] = usuario.Rol;
                    Session["Usuario"] = usuario.Usuario;

                    Response.Redirect("MenuPrincipal.aspx");
                    /*if (int.Parse(usuario.Rol) == 1)
                    {
                        //Response.Redirect("Productos.aspx");
                        Response.Redirect("MenuPrincipal.aspx");
                    }
                    else if (int.Parse(usuario.Rol) == 2)
                    {
                        Response.Redirect("MenuPrincipal.aspx");
                    }*/
                /* }
                    else
                    {
                        LBLError.Visible = true;
                        LBLError.Text = "Error al obtener el rol del usuario.";
                    }*/
            }
            catch
            {
                LBLError.Text = "Error, intente nuevamente";
                LBLError.Visible = true;
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