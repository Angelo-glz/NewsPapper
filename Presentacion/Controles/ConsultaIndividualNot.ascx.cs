using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Controles_ConsultaIndividualNot : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if(!IsPostBack)
    {
      try
      {
        Noticia N = FabricaLogica.GetLogicaNoticia().Buscar(Session["Noticia"].ToString());

        lblCod.Text = N.Codigo;
        lblFecha.Text = N.FechaPublicacion.ToString();
        lblImport.Text = N.Importancia.ToString();
        lblTit.Text = N.Titulo;
        lblUsu.Text = N.Usuario.NombreUsuario.ToString();
        ListBox1.DataSource = N.Periodistas;
        ListBox1.DataBind();
        lblContenido.Text = N.Contenido;

        if (N is Internacional)
        {
          lblTipoReserv.Text = "Pais: ";
          lblTipo.Text = ((Internacional)N).Pais;
        }
        else
        {
          lblTipoReserv.Text = "Seccion: ";
          lblTipo.Text = ((Nacional)N).Seccion.Nombre;
        }
      }
      catch(Exception ex) { lblError.Text = ex.Message; }

    }
  }
}