<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<link href="StyleSheet.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <style type="text/css">
    .auto-style1 {
      width: 100%;
    }
    .auto-style2 {
      height: 475px;
    }
    .auto-style3 {
      height: 58px;
    }
    .auto-style4 {
      font-family: Verdana, Calibri;
      font-size: 30px;
      letter-spacing: 2px;
      line-height: 15px;
      color: aliceblue;
      margin-bottom: 10px;
      background-color: #0094ff;
      width: 166px;
      height: 12px;
    }
    .auto-style5 {
      height: 475px;
      width: 166px;
    }
    .auto-style6 {
      width: 166px;
      height: 46px;
    }
    .auto-style7 {
      height: 58px;
      width: 1177px;
      text-align: center;
    }
    .auto-style8 {
      height: 475px;
      width: 1177px;
    }
    .auto-style9 {
      width: 1177px;
      height: 46px;
      text-align: center;
    }
    .auto-style10 {
      height: 46px;
    }
    .auto-style11 {
      width: 166px;
      height: 32px;
    }
    .auto-style12 {
      width: 1177px;
      height: 32px;
      text-align: right;
    }
    .auto-style13 {
      height: 32px;
    }
    .auto-style14 {
      text-align: center;
    }
    .auto-style15 {
      font-size: medium;
    }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <table align="center" cellpadding="0" cellspacing="1" class="auto-style1">
            <tr>
              <td class="auto-style4">BiosNews</td>
              <td class="auto-style7"></td>
              <td class="auto-style3">
                <h3>
                  <asp:Label ID="Label1" runat="server" CssClass="auto-style15" Text="Inicia sesión para acceder a formularios"></asp:Label>
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style15" NavigateUrl="~/Logueo.aspx">aquí</asp:HyperLink>
                </h3>
              </td>
            </tr>
            <tr>
              <td class="auto-style11"></td>
              <td class="auto-style12">&nbsp;<div class="auto-style14">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                  <asp:ListItem name="Tipo" Value="Nacional">Nacional</asp:ListItem>
                  <asp:ListItem name="Tipo" Value="Internacional">Internacional</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Menu ID="Menu1" runat="server" BackColor="#40AEFF" DynamicHorizontalOffset="2" EnableTheming="True" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium" ForeColor="Black" Height="32px" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" RenderingMode="Table" StaticSubMenuIndent="10px" Width="541px">
                  <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                  <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <DynamicMenuStyle BackColor="#E3EAEB" />
                  <DynamicSelectedStyle BackColor="#1C5E55" />
                  <Items>
                    <asp:MenuItem Text="Filtrar por fecha" Value="Filtrar por fecha"></asp:MenuItem>
                    <asp:MenuItem Text="Limpiar Filtros" Value="Limpiar Filtros"></asp:MenuItem>
                  </Items>
                  <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                  <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <StaticSelectedStyle BackColor="#1C5E55" />
                </asp:Menu>
                <h1 class="auto-style15">Dias: <asp:DropDownList ID="ddlDias" runat="server" EnableTheming="True">
                  <asp:ListItem>-</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                  Secciones:
                <asp:DropDownList ID="ddlSecciones" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSecciones_SelectedIndexChanged" Visible="False" DataTextField="Nombre" DataValueField="Nombre">
                  <asp:ListItem>-</asp:ListItem>
                </asp:DropDownList>
                </h1>
&nbsp;
                </div>
&nbsp; </td>
              <td class="auto-style13"></td>
            </tr>
            <tr>
              <td class="auto-style5"></td>
              <td class="auto-style8">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="429px" Width="1110px" BorderStyle="Inset" BorderWidth="3px" Font-Bold="False" Font-Size="Large" ForeColor="White" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                  <Columns>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:CommandField ShowSelectButton="True" />
                  </Columns>
                  <HeaderStyle Font-Size="X-Large" />
                  <PagerSettings Visible="False" />
                </asp:GridView>
              </td>
              <td class="auto-style2"></td>
            </tr>
            <tr>
              <td class="auto-style6"></td>
              <td class="auto-style9">
                <asp:Label ID="lblError" runat="server"></asp:Label>
              </td>
              <td class="auto-style10"></td>
            </tr>
          </table>
        </div>
    </form>
</body>
</html>
