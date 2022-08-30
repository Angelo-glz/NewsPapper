<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alta - Empleado.aspx.cs" Inherits="Alta___Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="StyleSheet.css" rel="stylesheet" type="text/css" />

  <style type="text/css">
    .auto-style14 {
      width: 100%;
    }
    .auto-style22 {
      width: 56px;
      height: 75px;
    }
    .auto-style23 {
      height: 75px;
    }
    .auto-style24 {
      height: 75px;
      text-align: center;
    }
    .auto-style25 {
      width: 56px;
      height: 27px;
    }
    .auto-style26 {
      width: 581px;
      height: 27px;
      text-align: right;
    }
    .auto-style27 {
      width: 584px;
      height: 27px;
      text-align: left;
    }
    .auto-style28 {
      height: 27px;
    }
    .auto-style29 {
      width: 56px;
      height: 29px;
    }
    .auto-style32 {
      height: 29px;
    }
    .auto-style33 {
      width: 56px;
      height: 30px;
    }
    .auto-style34 {
      width: 581px;
      height: 30px;
      text-align: right;
    }
    .auto-style35 {
      width: 584px;
      height: 30px;
      text-align: left;
    }
    .auto-style36 {
      height: 30px;
    }
    .auto-style37 {
      width: 581px;
      height: 29px;
      text-align: right;
    }
    .auto-style38 {
      width: 584px;
      height: 29px;
      text-align: left;
    }
    .auto-style39 {
      height: 29px;
      text-align: center;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="auto-style14">
    <tr>
      <td class="auto-style22"></td>
      <td colspan="2" class="auto-style24">
        <h1>&nbsp;Alta - Empleado</h1>
      </td>
      <td class="auto-style23"></td>
    </tr>
    <tr>
      <td class="auto-style25"></td>
      <td class="auto-style26"></td>
      <td class="auto-style27"></td>
      <td class="auto-style28"></td>
    </tr>
    <tr>
      <td class="auto-style29"></td>
      <td class="auto-style37">
        <h2>Nombre de Usuario: </h2>
      </td>
      <td class="auto-style38">
        <h2>
          <asp:TextBox ID="txtNomUsu" runat="server" Width="142px" MaxLength="10"></asp:TextBox>
        </h2>
      </td>
      <td class="auto-style32"></td>
    </tr>
    <tr>
      <td class="auto-style33"></td>
      <td class="auto-style34">
        <h2>Contraseña: </h2>
      </td>
      <td class="auto-style35">
        <h2>
          <asp:TextBox ID="txtPass" runat="server" Width="158px" MaxLength="7"></asp:TextBox>
        </h2>
      </td>
      <td class="auto-style36"></td>
    </tr>
    <tr>
      <td class="auto-style33"></td>
      <td class="auto-style34">
        <h2>&nbsp;</h2>
      </td>
      <td class="auto-style35">&nbsp;</td>
      <td class="auto-style36"></td>
    </tr>
    <tr>
      <td class="auto-style29"></td>
      <td class="auto-style37">&nbsp;</td>
      <td class="auto-style38">
        &nbsp;</td>
      <td class="auto-style32"></td>
    </tr>
    <tr>
      <td class="auto-style33"></td>
      <td class="auto-style34"></td>
      <td class="auto-style35">
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Crear Usuario" />
      </td>
      <td class="auto-style36"></td>
    </tr>
    <tr>
      <td class="auto-style29"></td>
      <td class="auto-style39" colspan="2">
        <asp:Label ID="lblError" runat="server"></asp:Label>
      </td>
      <td class="auto-style32"></td>
    </tr>
  </table>
</asp:Content>

