using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMSecciones : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      Session["Seccion"] = null;
      DeshabilitarABM();
    }
  }

  private void DeshabilitarABM()
  {
    btnBuscar.Enabled = true;
    txtCodigo.Enabled = true;
    txtCodigo.Text = "";

    btnAgregar.Enabled = false;
    btnEliminar.Enabled = false;
    btnModificar.Enabled = false;

    txtNombre.Text = "";
    txtNombre.Enabled = false;

    Session["Seccion"] = null;
  }

  private void Agregar()
  {
    btnBuscar.Enabled = false;
    txtCodigo.Enabled = false;

    btnAgregar.Enabled = true;

    txtNombre.Enabled = true;
  }

  private void BM()
  {
    btnBuscar.Enabled = false;
    txtCodigo.Enabled = false;

    txtNombre.Enabled = true;

    btnModificar.Enabled = true;
    btnEliminar.Enabled = true;
  }

  protected void btnBuscar_Click(object sender, EventArgs e)
  {
    try
    {
      Seccion S = null;
      S = FabricaLogica.GetLogicaSeccion().Buscar(txtCodigo.Text);

      if (S == null)
      {
        Agregar();
      }
      else
      {
        BM();
        Session["Seccion"] = S;
        txtNombre.Text = S.Nombre;
      }
    }
    catch (Exception ex)
    {
      lblError.Text = ex.Message;
    }
  }

  protected void btnAgregar_Click(object sender, EventArgs e)
  {
    try
    {
      Seccion S = new Seccion(txtCodigo.Text, txtNombre.Text);
      FabricaLogica.GetLogicaSeccion().Agregar(S);

      DeshabilitarABM();
      lblError.Text = "Se agrego la seccion";
    }
    catch (Exception ex)
    {
      lblError.Text = ex.Message;
    }

  }

  protected void btnModificar_Click1(object sender, EventArgs e)
  {
    try
    {
      Seccion S = new Seccion(txtCodigo.Text, txtNombre.Text);
      FabricaLogica.GetLogicaSeccion().Modificar(S);
      lblError.Text = "Se modifico la seccion.";
      DeshabilitarABM();
    }
    catch (Exception ex) { lblError.Text = ex.Message; }

  }

  protected void btnEliminar_Click1(object sender, EventArgs e)
  {
    try
    {
      FabricaLogica.GetLogicaSeccion().Eliminar((Seccion)Session["Seccion"]);
      lblError.Text = "Se elimino la seccion con exito.";
      DeshabilitarABM();
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }

  protected void btnLimpiar_Click1(object sender, EventArgs e)
  {
    DeshabilitarABM();
  }
}