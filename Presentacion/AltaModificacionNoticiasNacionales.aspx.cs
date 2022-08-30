using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class AltaModificacionNoticiasNacionales : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if(!IsPostBack)
    {
      try
      {
        List<Seccion> listaSec = FabricaLogica.GetLogicaSeccion().Listar();

        foreach (Seccion S in listaSec)
        {
          ddlSeccion.Items.Add(S.Nombre);
        }
        ddlSeccion.DataBind();
        ddlSeccion.Visible = false;
        Session["Secciones"] = listaSec;
      }
      catch(Exception ex) { lblError.Text = ex.Message; }
      Session["Noticia"] = null;
      Session["lPerio"] = null;
      DeshabilitarAM();
    }
  }

  private void DeshabilitarAM()
  {
    txtContenido.Text = "";
    txtContenido.Enabled = false;
    txtFecha.Text = "";
    txtFecha.Enabled = false;
    txtPerio.Text = "";
    txtPerio.Enabled = false;
    txtTitulo.Text = "";
    txtTitulo.Enabled = false;
    ddlImportancia.Enabled = false;
    ddlImportancia.SelectedIndex = 0;
    ListBox1.Items.Clear();
    ddlSeccion.Visible = false;

    btnEliminar.Visible = false;
    btnAccion.Visible = false;
    btnAgPerio.Enabled = false;

    Buscar.Enabled = true;
    txtCodigo.Text = "";
    txtCodigo.Enabled = true;

    lblError.Text = "";

    Session["Noticia"] = null;
    Session["lPerio"] = null;
  }

  private void AM()
  {
    txtCodigo.Enabled = false;

    txtContenido.Enabled = true;
    txtFecha.Enabled = true;
    txtPerio.Enabled = true;
    txtTitulo.Enabled = true;

    ddlImportancia.Enabled = true;
    ddlSeccion.Visible = true;

    btnAgPerio.Enabled = true;
    Buscar.Enabled = false;
  }

  private void Agregar()
  {
    try
    {
      List<Periodista> lPerio = null;

      if ((List<Periodista>)Session["lPerio"] == null)
        throw new Exception("Debe tener al menos un Periodista asignado.");

      lPerio = ((List<Periodista>)Session["lPerio"]);
      Nacional N = new Nacional(txtCodigo.Text, Convert.ToDateTime(txtFecha.Text), txtTitulo.Text, txtContenido.Text, Convert.ToInt32(ddlImportancia.SelectedValue), (Usuario)Session["Usuario"], lPerio, ((List<Seccion>)Session["Secciones"])[ddlSeccion.SelectedIndex]);
      FabricaLogica.GetLogicaNoticia().Agregar(N);
      DeshabilitarAM();
      lblError.Text = "Se dio de alta la noticia con exito";
    }
    catch(Exception ex)
    { lblError.Text = ex.Message; }
  }

  private void Modificar()
  {
    try
    {
      List<Periodista> lPerio = null;

      if ((List<Periodista>)Session["lPerio"] == null && ((List<Periodista>)Session["lPerio"]).Count == 0)
        throw new Exception("Debe tener al menos un Periodista asignado.");

      lPerio = ((List<Periodista>)Session["lPerio"]);
      if (lPerio.Count == 0)
        throw new Exception("Debe tener periodistas asociados.");

      Nacional N = new Nacional(txtCodigo.Text, Convert.ToDateTime(txtFecha.Text), txtTitulo.Text, txtContenido.Text, Convert.ToInt32(ddlImportancia.SelectedValue), (Usuario)Session["Usuario"], lPerio, ((List<Seccion>)Session["Secciones"])[ddlSeccion.SelectedIndex]);
      FabricaLogica.GetLogicaNoticia().Modificar(N);
      DeshabilitarAM();
      lblError.Text = "Se modifico la noticia.";
    }
    catch (Exception ex)
    { lblError.Text = ex.Message; }
  }

  protected void Buscar_Click(object sender, EventArgs e)
  {
    try
    {
      if (txtCodigo.Text == "")
        throw new Exception("Introduzca un codigo valido.");

      Noticia N = FabricaLogica.GetLogicaNoticia().Buscar(txtCodigo.Text);
      Session["Noticia"] = N;

      if (N is Internacional)
        throw new Exception("La noticia es Internacional");
      else if (N == null)
      {
        AM();
        btnAccion.Text = "Agregar";
        btnAccion.Visible = true;
      }
      else if(N is Nacional)
      {
        txtContenido.Text = N.Contenido;
        txtFecha.Text = N.FechaPublicacion.ToString("yyyy-MM-dd");
        ListBox1.DataSource = N.Periodistas;
        ListBox1.DataBind();
        txtTitulo.Text = N.Titulo;
        ddlImportancia.SelectedValue = N.Importancia.ToString();
        ddlSeccion.SelectedValue = ((Nacional)N).Seccion.Nombre;
        ddlSeccion.Visible = true;
        AM();
        btnAccion.Text = "Modificar";
        btnAccion.Visible = true;
        Session["lPerio"] = N.Periodistas;
      }
    }
    catch(Exception ex)
    { lblError.Text = ex.Message; }

  }

  protected void btnLimpiar_Click(object sender, EventArgs e)
  {
    DeshabilitarAM();
  }

  protected void btnAccion_Click(object sender, EventArgs e)
  {
    if (Session["Noticia"] == null)
      Agregar();
    if (Session["Noticia"] is Nacional)
      Modificar();
  }

  protected void btnAgPerio_Click(object sender, EventArgs e)
  {
    try
    {
      Periodista P = FabricaLogica.GetLogicaPeriodista().Buscar(Convert.ToInt32(txtPerio.Text));
      if (P == null)
        throw new Exception("El periodista no existe.");

      if (((List<Periodista>)Session["lPerio"]) != null && ((List<Periodista>)Session["lPerio"]).Count > 0)
      {
        foreach (Periodista Pe in ((List<Periodista>)Session["lPerio"]))
        {
          if (P.Cedula == Pe.Cedula)
            throw new Exception("El periodista ya esta asignado a esta noticia.");
        }
      }

      ListBox1.Items.Add(P.ToString());
      lblError.Text = "Se agrego el periodista.";

      if(Session["lPerio"] == null)
      {
        List<Periodista> lPerio = new List<Periodista>();
        lPerio.Add(P);
        Session["lPerio"] = lPerio;
      }
      else
        ((List<Periodista>)Session["lPerio"]).Add(P);
    }
    catch (Exception ex)
    { lblError.Text = ex.Message; }
  }

  protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
  {
    btnEliminar.Visible = true;
  }

  protected void btnEliminar_Click(object sender, EventArgs e)
  {
    ((List<Periodista>)Session["lPerio"]).RemoveAt(ListBox1.SelectedIndex);

    ListBox1.Items.Clear();
    ListBox1.DataSource = ((List<Periodista>)Session["lPerio"]);
    ListBox1.DataBind();
    btnEliminar.Visible = false;
  }
}