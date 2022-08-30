using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      if (!IsPostBack)
      {
        if (Session["Usuario"] != null)
        {
          Label1.Text = "";
          HyperLink1.Text = "";
        }
        Session["Secciones"] = FabricaLogica.GetLogicaSeccion().Listar();
        Session["Noticias"] = FabricaLogica.GetLogicaNoticia().ListarUlt5Dias();

        ddlSecciones.DataSource = (List<Seccion>)Session["Secciones"];
        ddlSecciones.DataBind();

        for (int i = DateTime.Today.Day; i >= DateTime.Today.Day - 4; i--)
        {
          ddlDias.Items.Add(i.ToString());
        }
        ListarSinFiltros();
      }
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }

  protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
  {
    try
    {
      if (e.Item.Value.ToString() == "Limpiar Filtros")
      {
        ListarSinFiltros();
        ddlSecciones.Visible = false;
        RadioButtonList1.ClearSelection();
        lblError.Text = "";
      }
      else if (e.Item.Value.ToString() == "Filtrar por fecha" && ddlDias.SelectedIndex != 0)
      {
        if (ddlSecciones.Visible == true)
          FiltrarSecciones(ddlSecciones.SelectedValue);
        else if (RadioButtonList1.SelectedItem == null)
          FiltrarFecha();
        else
          FiltrarFecha(RadioButtonList1.SelectedValue, RadioButtonList1.SelectedValue);
        lblError.Text = "";
      }
      else
      {
        lblError.Text = "Seleccione un dia.";
      }
    }
    catch(Exception ex) { lblError.Text = ex.Message; }
  }

  private void ListarSinFiltros()
  {
    try
    {
      List<Noticia> list = (List<Noticia>)Session["Noticias"];

      List<object> result = (from uN in list
                             select new
                             {
                               Tipo = uN.Tipo,
                               Codigo = uN.Codigo,
                               Fecha = uN.FechaPublicacion.ToLongDateString(),
                               Titulo = uN.Titulo
                             }).ToList<object>();

      GridView1.DataSource = result;
      GridView1.DataBind();
      Session["actual"] = result;
      Session["Lista"] = list;
    }catch(Exception ex) {  lblError.Text = ex.Message; }
  }

  private void FiltrarTipo(string Tipo)
  {
    List<Noticia> list = (List<Noticia>)Session["Lista"];

    List<object> result = (from uN in list
                            where uN.Tipo == Tipo
                            select new
                            {
                              Tipo = uN.Tipo,
                              Codigo = uN.Codigo,
                              Fecha = uN.FechaPublicacion.ToLongDateString(),
                              Titulo = uN.Titulo

                            }).ToList<object>();


    GridView1.DataSource = result;
    GridView1.DataBind();
    Session["actual"] = result;
  }

  private void FiltrarFecha(string Tipo1 = "Nacional", string Tipo2 = "Internacional")
  {
    List<Noticia> list = (List<Noticia>)Session["Lista"];
    List<object> result = null;

    string fecha = DateTime.Now.AddDays(ddlDias.SelectedIndex * -1 + 1).ToShortDateString();

    result = (from uN in list
              where (uN.FechaPublicacion.ToShortDateString() == fecha) && (uN.Tipo == Tipo1 || uN.Tipo == Tipo2)
    select new
              {
                Tipo = uN.Tipo,
                Codigo = uN.Codigo,
                Fecha = uN.FechaPublicacion.ToLongDateString(),
                Titulo = uN.Titulo

              }).ToList<object>();

    GridView1.DataSource = result;
    GridView1.DataBind();
    Session["actual"] = result;
  }

  private void FiltrarSecciones(string Seccion)
  {
    List<Noticia> lNoticias = (List<Noticia>)Session["Lista"];
    List<object> result = null;

    string fecha = DateTime.Now.AddDays(ddlDias.SelectedIndex * -1+1).ToShortDateString();

    result = (from uN in lNoticias
              where (uN.Tipo == "Nacional" && ((Nacional)uN).Seccion.Nombre == Seccion && ((ddlDias.SelectedIndex == 0)||(uN.FechaPublicacion.ToShortDateString() == fecha)))
              select new
              {
                Tipo = uN.Tipo,
                Codigo = uN.Codigo,
                Fecha = uN.FechaPublicacion.ToLongDateString(),
                Titulo = uN.Titulo
              }).ToList<object>();

    if (result == null)
      lblError.Text = "Es nulo";
    GridView1.DataSource = result;
    GridView1.DataBind();
    Session["actual"] = result;
  }

  protected void ddlSecciones_SelectedIndexChanged(object sender, EventArgs e)
  {
    FiltrarSecciones(ddlSecciones.SelectedValue);
  }

  protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
  {
    ddlSecciones.Visible = false;
    FiltrarTipo(RadioButtonList1.SelectedValue);
    if (RadioButtonList1.SelectedValue == "Nacional")
    {
      ddlSecciones.Visible = true;
    }
  }

  protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
  {
    try
    {
      List<object> lNoticias = ((List<object>)Session["actual"]);
      object codigo = lNoticias[Convert.ToInt32(GridView1.SelectedIndex)];
      var propertyName = "Codigo";
      propertyName = codigo.GetType().GetProperty(propertyName).GetValue(codigo, null).ToString();
      Session["Noticia"] = propertyName;

      Response.Redirect("~/ConsultaIndividualNoticia.aspx");
    }
    catch(Exception ex) { lblError.Text = ex.Message; }
  }
}