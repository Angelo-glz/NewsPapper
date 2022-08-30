<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaModificacionNoticiasNacionales.aspx.cs" Inherits="AltaModificacionNoticiasNacionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style type="text/css">
    .auto-style14 {
      width: 100%;
    }
    .auto-style15 {
      text-align: right;
    }
    .auto-style16 {
      text-align: right;
      height: 21px;
    }
    .auto-style17 {
      height: 21px;
    }
    .auto-style18 {
      text-align: right;
      height: 32px;
    }
    .auto-style19 {
      height: 32px;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="auto-style14">
    <tr>
      <td class="auto-style18">
        <h3>Codigo: </h3>
      </td>
      <td class="auto-style19">
        <asp:TextBox ID="txtCodigo" runat="server" MaxLength="5"></asp:TextBox>
&nbsp;<asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" Text="Buscar" />
      </td>
      <td class="auto-style18">
        <h3>Fecha Publicacion: </h3>
      </td>
      <td class="auto-style19">
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="auto-style15">
        <h3>Titulo: </h3>
      </td>
      <td>
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
      </td>
      <td class="auto-style15">
        <h3>Importancia:</h3>
      </td>
      <td>
        <asp:DropDownList ID="ddlImportancia" runat="server">
          <asp:ListItem Value="0"></asp:ListItem>
          <asp:ListItem Value="1"></asp:ListItem>
          <asp:ListItem Value="2"></asp:ListItem>
          <asp:ListItem Value="3"></asp:ListItem>
          <asp:ListItem Value="4"></asp:ListItem>
        </asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="auto-style15">
        <h3>Contenido: </h3>
      </td>
      <td>
        <asp:TextBox ID="txtContenido" runat="server" Width="398px" TextMode="MultiLine"></asp:TextBox>
      </td>
      <td class="auto-style15">
        <h3>Periodistas Autores:</h3>
      </td>
      <td>
        <asp:TextBox ID="txtPerio" runat="server" placeholder="Cedula de periodista..."></asp:TextBox>
&nbsp;<asp:Button ID="btnAgPerio" runat="server" OnClick="btnAgPerio_Click" Text="Agregar Periodista" />
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Visible="False" />
      </td>
    </tr>
    <tr>
      <td class="auto-style15">
        <h3>Seccion: </h3>
      </td>
      <td>
        <asp:DropDownList ID="ddlSeccion" runat="server">
        </asp:DropDownList>
      </td>
      <td class="auto-style15">&nbsp;</td>
      <td>
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
      </td>
    </tr>
    <tr>
      <td class="auto-style16"></td>
      <td class="auto-style17">
        <asp:Label ID="lblError" runat="server"></asp:Label>
      </td>
      <td class="auto-style16">
        <asp:Button ID="btnAccion" runat="server" OnClick="btnAccion_Click" Text="Button" Visible="False" />
      </td>
      <td class="auto-style17">
        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Formulario" />
      </td>
    </tr>
  </table>
</asp:Content>

