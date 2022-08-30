<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualNot.ascx.cs" Inherits="Controles_ConsultaIndividualNot" %>
<style type="text/css">
  .auto-style1 {
    width: 57%;
  }
  .auto-style6 {
    width: 247px;
    text-align: right;
    font-size: large;
    height: 35px;
  }
  .auto-style7 {
    width: 247px;
    text-align: right;
    height: 40px;
    font-size: large;
  }
  .auto-style8 {
    height: 40px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style9 {
    width: 247px;
    text-align: right;
    height: 59px;
    font-size: large;
  }
  .auto-style10 {
    height: 59px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style11 {
    font-size: large;
  }
  .auto-style12 {
    width: 247px;
    text-align: right;
    height: 42px;
    font-size: large;
  }
  .auto-style13 {
    height: 42px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style16 {
    width: 247px;
    text-align: right;
    height: 44px;
    font-size: large;
  }
  .auto-style17 {
    height: 44px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style20 {
    width: 247px;
    text-align: right;
    font-size: large;
    height: 85px;
  }
  .auto-style21 {
    height: 85px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style22 {
    width: 247px;
    text-align: right;
    font-size: large;
    height: 112px;
  }
  .auto-style23 {
    height: 112px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style24 {
    text-align: left;
    font-size: large;
    height: 35px;
  }
  .auto-style25 {
    font-size: medium;
  }
  .auto-style26 {
    text-align: center;
  }
  .auto-style27 {
    width: 247px;
    text-align: right;
    height: 46px;
    font-size: large;
  }
  .auto-style28 {
    height: 46px;
    font-size: large;
    text-align: left;
    width: 526px;
  }
  .auto-style29 {
    width: 526px;
    text-align: left;
    font-size: large;
    height: 35px;
  }
</style>

<table class="auto-style1">
  <tr>
    <td class="auto-style7">
      <h1 class="auto-style11">Codigo:</h1>
    </td>
    <td class="auto-style8">
      <h2>
        <asp:Label ID="lblCod" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style9">
      <h1 class="auto-style11">Fecha Publicacion:</h1>
    </td>
    <td class="auto-style10">
      <h2>
        <asp:Label ID="lblFecha" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style16">
      <h1 class="auto-style11">Titulo:</h1>
    </td>
    <td class="auto-style17">
      <h2>
        <asp:Label ID="lblTit" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style22">
      <h1 class="auto-style11">Contenido:</h1>
    </td>
    <td class="auto-style23">
      <h2>
        <asp:Label ID="lblContenido" runat="server" CssClass="auto-style25"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style12">
      <h1 class="auto-style11">Importancia:</h1>
    </td>
    <td class="auto-style13">
      <h2>
        <asp:Label ID="lblImport" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style27">
      <h1 class="auto-style11">Ultimo usuario en modificar:</h1>
    </td>
    <td class="auto-style28">
      <h2>
        <asp:Label ID="lblUsu" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style20">
      <h1 class="auto-style11">Autores:</h1>
    </td>
    <td class="auto-style21">
      <h2>
        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style11" Height="69px"></asp:ListBox>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style6">
      <h1>
        <asp:Label ID="lblTipoReserv" runat="server" CssClass="auto-style11"></asp:Label>
      </h1>
    </td>
    <td class="auto-style29">
      <h2>
        <asp:Label ID="lblTipo" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
  <tr>
    <td class="auto-style24" colspan="2">
      <h2 class="auto-style26">
        <asp:Label ID="lblError" runat="server" CssClass="auto-style11"></asp:Label>
      </h2>
    </td>
  </tr>
</table>

