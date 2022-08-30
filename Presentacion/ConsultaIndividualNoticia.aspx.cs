using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConsultaIndividualNoticia : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      if (Session["Noticia"] == null)
        Response.Redirect("~/Default.aspx");

      if (Session["Usuario"] != null)
      {
        Label1.Text = "";
        HyperLink2.Text = "";
      }
    }
  }
}