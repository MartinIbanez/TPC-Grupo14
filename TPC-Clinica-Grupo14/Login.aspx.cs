using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Clinica_Grupo14
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }



        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio(); 

            int nroUser = 5;

            try
            {

                usuario = new Usuario(txtUser.Value, txtPassword.Value, nroUser); //crea instancia usuario
                negocio.Loguear(usuario);
                nroUser = (int)usuario.TipoUsuario;

                if (negocio.Loguear(usuario))
                {
                    if (negocio.Loguear(usuario))
                    {
                        Session.Add("usuario", usuario);
                        Session.Add("IDUsuario", usuario.Id);


                        switch (nroUser)
                        {
                            case 1:
                                Response.Redirect("MenuAdministrador.aspx", false);
                                break;
                            case 2:
                                Response.Redirect("MenuRecepcionista.aspx", false);
                                break;
                            case 3:
                                Response.Redirect("MenuMedico.aspx", false);
                                break;
                            case 4:
                                Response.Redirect("MenuPaciente.aspx", false);
                                break;
                            case 5:
                                Response.Redirect("Login.aspx", false);
                                break;
                        }

                    }
                    

                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }


            }

            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}

