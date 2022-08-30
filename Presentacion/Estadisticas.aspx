<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--<link href="StyleSheet.css" rel="stylesheet" type="text/css" />--%>

  <style type="text/css">
    .auto-style2 {
      height: 475px;
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
      width: 1354px;
      height: 33px;
    }
    .auto-style16 {
      width: 93px;
      height: 33px;
      text-align: center;
    }
    .auto-style17 {
      height: 33px;
      font-family: Verdana, Calibri;
      font-size: 30px;
      letter-spacing: 2px;
      line-height: 15px;
      color: aliceblue;
      width: 70%;
      margin-bottom: 10px;
      background-color: #0094ff;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="auto-style14">
            <tr>
              <td class="auto-style11"></td>
              <td class="auto-style12">&nbsp;<div class="auto-style14">
                <asp:Menu ID="Menu1" runat="server" BackColor="#40AEFF" DynamicHorizontalOffset="2" EnableTheming="True" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium" ForeColor="Black" Height="32px" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" RenderingMode="Table" StaticSubMenuIndent="10px" Width="541px">
                  <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                  <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <DynamicMenuStyle BackColor="#E3EAEB" />
                  <DynamicSelectedStyle BackColor="#1C5E55" />
                  <Items>
                    <asp:MenuItem Text="Tipo de noticia" Value="Tipo de noticia">
                      <asp:MenuItem Text="Nacional" Value="Nacional"></asp:MenuItem>
                      <asp:MenuItem Text="Internacional" Value="Internacional"></asp:MenuItem>
                      <asp:MenuItem Text="Todos" Value="Todos"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Filtrar por fecha" Value="Filtrar por fecha"></asp:MenuItem>
                    <asp:MenuItem Text="Limpiar Filtros" Value="Limpiar Filtros"></asp:MenuItem>
                  </Items>
                  <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                  <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <StaticSelectedStyle BackColor="#1C5E55" />
                </asp:Menu>
                </div>
&nbsp; </td>
              <td class="auto-style13"></td>
            </tr>
            <tr>
              <td class="auto-style5"></td>
              <td class="auto-style8">
                <asp:GridView ID="GridView1" runat="server" Height="429px" Width="1110px" BorderStyle="Inset" BorderWidth="3px" Font-Bold="False" Font-Size="Large" ForeColor="White">
                  <HeaderStyle Font-Size="X-Large" />
                  <PagerSettings Visible="False" />
                </asp:GridView>
              </td>
              <td class="auto-style2"></td>
            </tr>
            <tr>
              <td class="auto-style15"></td>
              <td class="auto-style16">
                <asp:Label ID="lblError" runat="server"></asp:Label>
              </td>
              <td class="auto-style17"></td>
            </tr>
          </table>
</asp:Content>
