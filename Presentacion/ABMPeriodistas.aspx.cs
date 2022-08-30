using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;

public partial class ABMPeriodistas : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      Session["Periodista"] = null;
      DeshabilitarABM();
    }
  }

  private void DeshabilitarABM()
  {
    btnBuscar.Enabled = true;
    txtCedula.Enabled = true;
    txtCedula.Text = "";

    btnAgregar.Enabled = false;
    btnEliminar.Enabled = false;
    btnModificar.Enabled = false;

    txtMail.Text = "";
    txtMail.Enabled = false;
    txtNombre.Text = "";
    txtNombre.Enabled = false;

    Session["Periodista"] = null;
  }

  private void Agregar()
  {
    btnBuscar.Enabled = false;
    txtCedula.Enabled = false;

    btnAgregar.Enabled = true;

    txtMail.Enabled = true;
    txtNombre.Enabled = true;
  }

  private void BM()
  {
    btnBuscar.Enabled = false;
    txtCedula.Enabled = false;

    txtMail.Enabled = true;
    txtNombre.Enabled = true;

    btnModificar.Enabled = true;
    btnEliminar.Enabled = true;
  }

  protected void btnBuscar_Click(object sender, EventArgs e)
  {
    try
    {
      Periodista P = FabricaLogica.GetLogicaPeriodista().Buscar(Convert.ToInt32(txtCedula.Text));

      if (P != null)
      {
        txtMail.Text = P.Mail;
        txtNombre.Text = P.Nombre;

        Session["Periodista"] = P;

        BM();
      }
      else
      {
        Agregar();
      }
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }

  protected void btnAgregar_Click(object sender, EventArgs e)
  {
    try
    {
      Periodista P = new Periodista(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtMail.Text);
      FabricaLogica.GetLogicaPeriodista().Agregar(P);
      lblError.Text = "Se agrego el Periodista con exito.";
      DeshabilitarABM();
    }
    catch(Exception ex) { lblError.Text = ex.Message; }
  }

  protected void btnModificar_Click(object sender, EventArgs e)
  {
    try
    {
      int ced = Convert.ToInt32(txtCedula.Text);
      Periodista P = new Periodista(ced, txtNombre.Text, txtMail.Text);
      FabricaLogica.GetLogicaPeriodista().Modificar(P);
      lblError.Text = "Se modifico el Periodista con exito.";
      DeshabilitarABM();
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }

  protected void btnEliminar_Click(object sender, EventArgs e)
  {
    try
    {
      FabricaLogica.GetLogicaPeriodista().Eliminar((Periodista)Session["Periodista"]);
      lblError.Text = "Se elimino el Periodista con exito.";
      DeshabilitarABM();
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }

  protected void btnLimpiar_Click(object sender, EventArgs e)
  {
    DeshabilitarABM();
  }
}