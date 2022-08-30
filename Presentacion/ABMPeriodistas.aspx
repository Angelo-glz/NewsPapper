<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMPeriodistas.aspx.cs" Inherits="ABMPeriodistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style type="text/css">
    .auto-style13 {
      width: 100%;
    }
    .auto-style19 {
      width: 89px;
      height: 30px;
    }
    .auto-style21 {
      height: 30px;
    }
    .auto-style22 {
      width: 89px;
      height: 26px;
    }
    .auto-style24 {
      height: 26px;
    }
    .auto-style25 {
      width: 89px;
      height: 62px;
    }
    .auto-style27 {
      height: 62px;
    }
    .auto-style28 {
      color: #FFFFFF;
      font-size: xx-large;
      width: 1296px;
    }
    .auto-style29 {
      width: 89px;
      height: 27px;
    }
    .auto-style31 {
      height: 27px;
    }
    .auto-style32 {
      height: 62px;
      text-align: center;
    }
    .auto-style33 {
      width: 448px;
      height: 26px;
      text-align: right;
      font-size: medium;
    }
    .auto-style34 {
      width: 448px;
      height: 27px;
      text-align: right;
      font-size: medium;
    }
    .auto-style35 {
      width: 448px;
      height: 30px;
      text-align: center;
    }
    .auto-style37 {
      width: 243px;
      height: 26px;
      text-align: left;
    }
    .auto-style38 {
      width: 243px;
      height: 27px;
      text-align: left;
    }
    .auto-style39 {
      width: 243px;
      height: 30px;
      text-align: left;
      font-size: medium;
    }
    .auto-style40 {
      height: 26px;
      text-align: left;
      width: 646px;
      font-size: small;
    }
    .auto-style41 {
      height: 27px;
      text-align: left;
      width: 646px;
    }
    .auto-style42 {
      height: 30px;
      text-align: center;
      width: 646px;
      font-size: small;
    }
    .auto-style43 {
      font-size: medium;
    }
    .auto-style44 {
      font-size: small;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="auto-style13">
    <tr>
      <td class="auto-style25"></td>
      <td class="auto-style32" colspan="3">
        <h1 class="auto-style28"><strong>ABM</strong>Periodistas</h1>
      </td>
      <td class="auto-style27"></td>
    </tr>
    <tr>
      <td class="auto-style22"></td>
      <td class="auto-style33">
        <h3>Cedula:</h3>
      </td>
      <td class="auto-style37">
        <asp:TextBox ID="txtCedula" runat="server" Height="17px" Width="169px"></asp:TextBox>
      </td>
      <td class="auto-style40">
        <h2>
          <asp:Button ID="btnBuscar" runat="server" CssClass="auto-style44" Text="Buscar" OnClick="btnBuscar_Click" />
        </h2>
      </td>
      <td class="auto-style24"></td>
    </tr>
    <tr>
      <td class="auto-style29"></td>
      <td class="auto-style34">
        <h3>Nombre:</h3>
      </td>
      <td class="auto-style38">
        <asp:TextBox ID="txtNombre" runat="server" Height="18px" Width="169px" Enabled="False"></asp:TextBox>
      </td>
      <td class="auto-style41">&nbsp;</td>
      <td class="auto-style31"></td>
    </tr>
    <tr>
      <td class="auto-style29">&nbsp;</td>
      <td class="auto-style34">
        <h3>Mail:</h3>
      </td>
      <td class="auto-style38">
        <asp:TextBox ID="txtMail" runat="server" Enabled="False" Height="18px" Width="169px"></asp:TextBox>
      </td>
      <td class="auto-style41">&nbsp;</td>
      <td class="auto-style31">&nbsp;</td>
    </tr>
    <tr>
      <td class="auto-style29">&nbsp;</td>
      <td class="auto-style34">
        <h3></h3>
      </td>
      <td class="auto-style38">
        &nbsp;</td>
      <td class="auto-style41">&nbsp;</td>
      <td class="auto-style31">&nbsp;</td>
    </tr>
    <tr>
      <td class="auto-style19"></td>
      <td class="auto-style35">&nbsp;</td>
      <td class="auto-style39">
        <h2>
          <asp:Label ID="lblError" runat="server" CssClass="auto-style43"></asp:Label>
        </h2>
      </td>
      <td class="auto-style42">
        <h2>
          <asp:Button ID="btnAgregar" runat="server" CssClass="auto-style44" Text="Agregar" Enabled="False" OnClick="btnAgregar_Click" />
&nbsp;<asp:Button ID="btnModificar" runat="server" CssClass="auto-style44" Text="Modificar" Enabled="False" OnClick="btnModificar_Click" />
&nbsp;<asp:Button ID="btnEliminar" runat="server" CssClass="auto-style44" Text="Eliminar" Enabled="False" OnClick="btnEliminar_Click" />
&nbsp;<asp:Button ID="btnLimpiar" runat="server" CssClass="auto-style44" Text="Limpiar Formulario" OnClick="btnLimpiar_Click" />
        </h2>
      </td>
      <td class="auto-style21"></td>
    </tr>
  </table>
</asp:Content>

