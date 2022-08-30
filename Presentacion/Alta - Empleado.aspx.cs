using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Alta___Empleado : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void btnAgregar_Click(object sender, EventArgs e)
  {
    try
    {
      Usuario U = new Usuario(txtNomUsu.Text, txtPass.Text);

      FabricaLogica.GetLogicaUsuario().Agregar(U);

      lblError.Text = "Se agrego el usuario.";
      txtNomUsu.Text = "";
      txtPass.Text = "";
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }
}