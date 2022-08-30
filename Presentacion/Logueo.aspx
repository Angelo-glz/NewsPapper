<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

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
      height: 406px;
    }
    .auto-style3 {
      height: 80px;
    }
    .auto-style4 {
      height: 80px;
      width: 162px;
    }
    .auto-style5 {
      height: 406px;
      width: 162px;
    }
    .auto-style6 {
      width: 162px;
      height: 50px;
    }
    .auto-style7 {
      height: 80px;
      width: 1267px;
    }
    .auto-style8 {
      height: 406px;
      width: 1267px;
      text-align: center;
    }
    .auto-style9 {
      width: 1267px;
      height: 50px;
    }
    .auto-style10 {
      height: 50px;
    }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
          <tr>
            <td class="auto-style4"></td>
            <td class="auto-style7"></td>
            <td class="auto-style3"></td>
          </tr>
          <tr>
            <td class="auto-style5"></td>
            <td class="auto-style8">
              <h2>Nombre de Usuario:&nbsp;
                <asp:TextBox ID="txtNomUsu" runat="server" Width="169px"></asp:TextBox>
                <br />
Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="186px"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogueo" runat="server" OnClick="btnLogueo_Click" Text="Iniciar Sesion" />
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" BackColor="#6699FF" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Overline="False" Font-Strikeout="False" ForeColor="Black"></asp:Label>
              </h2>
            </td>
            <td class="auto-style2"></td>
          </tr>
          <tr>
            <td class="auto-style6"></td>
            <td class="auto-style9"></td>
            <td class="auto-style10"></td>
          </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
