using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    Session["Usuario"] = null;
  }

  protected void btnLogueo_Click(object sender, EventArgs e)
  {
    try
    {
      Usuario Usu = new Usuario(txtNomUsu.Text, txtPass.Text);
      if (FabricaLogica.GetLogicaUsuario().Loguear(Usu))
      {
        Session["Usuario"] = Usu;
        Response.Redirect("~/ABMPeriodistas.aspx");
      }
      else
        lblError.Text = "Nombre de usuario o contraseña equivocado.";
    }
    catch(Exception ex) { lblError.Text = ex.Message; }
  }
}