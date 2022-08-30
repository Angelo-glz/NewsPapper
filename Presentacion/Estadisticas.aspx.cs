using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Linq;
using EntidadesCompartidas;
using Logica;

public partial class Estadisticas : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    if (!IsPostBack)
    {
      try
      {
        XmlNode mDoc = FabricaLogica.GetLogicaNoticia().EstadisticaNoticias();

        XElement doc = XElement.Parse(mDoc.OuterXml);
        Session["Document"] = doc;
        FiltrarTodos();
      }
      catch (Exception ex) { lblError.Text = ex.Message; }
    }
  }

  protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
  {
    try
    {
      if (e.Item.Value.ToString() == "Todos")
      {
        FiltrarTodos();
      }
      else if (e.Item.Value.ToString() == "Internacional" || e.Item.Value.ToString() == "Nacional")
      {
        Filtrar(e.Item.Value.ToString());
      }
      else if (e.Item.Value.ToString() == "Filtrar por fecha")
        FiltrarFechaTipo();
      else if (e.Item.Value.ToString() == "Limpiar Filtros")
        FiltrarTodos();
    }
    catch(Exception ex) { lblError.Text = ex.Message; }
  }

  private void FiltrarTodos()
  {
    try
    {
      XElement mXml = (XElement)Session["Document"];
      

      List<object> result = (from uN in (mXml.Elements("Noticia"))
                             select new
                             {
                               Tipo = uN.Element("Tipo").Value,
                               Codigo = uN.Element("Codigo").Value,
                               Fecha = uN.Element("FechaPubli").Value,
                               Titulo = uN.Element("Titulo").Value,
                               Importancia = uN.Element("Importancia").Value
                             }).ToList<object>();

      GridView1.DataSource = result;
      GridView1.DataBind();
    }catch(Exception ex) {  lblError.Text = ex.Message; }
  }

  private void Filtrar(string Tipo)
  {
    XElement mXml = (XElement)Session["Document"];

    List<object> result = (from uN in mXml.Elements("Noticia")
                            where uN.Element("Tipo").Value == Tipo
                            select new
                            {
                              Tipo = uN.Element("Tipo").Value,
                              Codigo = uN.Element("Codigo").Value,
                              Fecha = uN.Element("FechaPubli").Value,
                              Titulo = uN.Element("Titulo").Value,
                              Importancia = uN.Element("Importancia").Value
                            }).ToList<object>();


    GridView1.DataSource = result;
    GridView1.DataBind();
  }

  private void FiltrarFechaTipo()
  {
    try
    {
      XElement mXml = (XElement)Session["Document"];

      List<object> result1 = (from uN in mXml.Elements("Noticia")
                              group uN by new
                              { uN.Element("Tipo").Value, Convert.ToDateTime(uN.Element("FechaPubli").Value).Year } 
                    into Grupo
                              select new
                              {
                                Fecha = Convert.ToDateTime(Grupo.First().Element("FechaPubli").Value).Year,
                                Tipo = Grupo.First().Element("Tipo").Value,
                                Cantidad = Grupo.Count()
                              }).ToList<object>();

      GridView1.DataSource = result1;
      GridView1.DataBind();
    }
    catch (Exception ex) { lblError.Text = ex.Message; }
  }
}