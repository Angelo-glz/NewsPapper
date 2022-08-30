using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class MasterPage : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!(Session["Usuario"] is Usuario))
      Response.Redirect("Default.aspx");
    lblBienvenida.Text = "Hola, " + ((Usuario)Session["Usuario"]).NombreUsuario.ToString() + " utiliza el menu para navegar en las opciones de la pagina.";
    try
    { }  catch(Exception ex) { lblError.Text = ex.Message; }
  }
}
