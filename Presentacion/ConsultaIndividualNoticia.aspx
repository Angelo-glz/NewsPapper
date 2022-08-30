<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualNoticia.aspx.cs" Inherits="ConsultaIndividualNoticia" %>



<%@ Register src="Controles/ConsultaIndividualNot.ascx" tagname="ConsultaIndividualNot" tagprefix="uc1" %>



<!DOCTYPE html>

<link href="StyleSheet.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <style type="text/css">

    table{
  border-spacing: 5px;
}

*{
  margin:0px;
  padding:0px;
}

    .auto-style4 {
      font-family: Verdana, Calibri;
      font-size: 30px;
      letter-spacing: 2px;
      line-height: 15px;
      color: aliceblue;
      margin-bottom: 10px;
      background-color: #0094ff;
      width: 208px;
      height: 12px;
    }
    .auto-style3 {
      height: 58px;
      width: 55px;
      text-align: left;
    }
    .auto-style14 {
      text-align: center;
    }
    .auto-style2 {
      height: 475px;
      width: 55px;
    }
    h1 {
    }
    .auto-style24 {
      height: 42px;
      font-size: large;
      width: 130px;
    }
    .auto-style25 {
      height: 59px;
      font-size: large;
      width: 130px;
    }
    .auto-style26 {
      width: 86%;
    }
    .auto-style27 {
      height: 40px;
      width: 679px;
      text-align: right;
      font-size: large;
    }
    .auto-style28 {
      width: 679px;
      height: 42px;
      text-align: right;
      font-size: large;
    }
    .auto-style29 {
      height: 40px;
      width: 679px;
      text-align: center;
      font-size: large;
    }
    .auto-style30 {
      width: 1050px;
      height: 59px;
      font-size: large;
      text-align: center;
    }
    .auto-style31 {
      height: 32px;
      font-size: large;
      width: 208px;
    }
    .auto-style32 {
      height: 35px;
      font-size: large;
      width: 208px;
    }
    .auto-style34 {
      height: 46px;
      width: 1050px;
      text-align: right;
      font-size: large;
    }
    .auto-style35 {
      width: 1050px;
      height: 46px;
      text-align: left;
      font-size: large;
    }
    .auto-style37 {
      height: 35px;
      font-size: large;
      width: 55px;
      text-align: left;
    }
    .auto-style38 {
      height: 59px;
      font-size: medium;
      width: 55px;
    }
    .auto-style40 {
      width: 94%;
      text-align: center;
    }
    .auto-style41 {
      height: 35px;
      font-size: large;
      width: 1050px;
      text-align: left;
    }
    .auto-style42 {
      width: 194px;
      text-align: left;
    }
    .auto-style43 {
      width: 208px;
      text-align: right;
      font-size: large;
      height: 35px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <table align="center" cellpadding="0" cellspacing="1" class="auto-style40">
            <tr>
              <td class="auto-style4">BiosNews</td>
              <td class="auto-style34"></td>
              <td class="auto-style3">
                <h3 class="auto-style42">
                  <asp:Label ID="Label1" runat="server" CssClass="auto-style15" Text="Inicia sesión para acceder a formularios "></asp:Label>
                  <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style15" NavigateUrl="~/Logueo.aspx">aquí</asp:HyperLink>
                </h3>
              </td>
            </tr>
            <tr>
              <td class="auto-style31"></td>
              <td class="auto-style35">&nbsp;<div class="auto-style14">
                <h1>Consulta Individual de Noticias</h1>
                </div>
&nbsp; </td>
              <td class="auto-style37">&nbsp;</td>
            </tr>
            <tr>
              <td class="auto-style32"></td>
              <td class="auto-style41">
                <uc1:ConsultaIndividualNot ID="ConsultaIndividualNot1" runat="server" />
                </td>
              <td class="auto-style2"></td>
            </tr>
            <tr>
              <td class="auto-style43">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">&lt;-- Volver</asp:HyperLink>
              </td>
              <td class="auto-style30">
                <asp:Label ID="lblError" runat="server"></asp:Label>
              </td>
              <td class="auto-style38"></td>
            </tr>
          </table>
        <div>
        </div>
    </form>
</body>
</html>
