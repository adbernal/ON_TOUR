<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelRepresentante.aspx.cs" Inherits="ON_TOUR.PanelRepresentante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Label ID="lblNombreUsuario" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblTipoUsuario" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblMensaje" runat="server" Text="Crear actividad"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbl2" runat="server" Text="Progreso"></asp:Label></td>
                <td><asp:Label ID="lblProgreso" runat="server" Text="80%"></asp:Label></td>
            </tr>
            <tr>
                <td><h3>Creacion de actividad</h3></td>
            </tr>
            <tr>
                <td>Descripcion</td>
                <td><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Monto a recaudado</td>
                <td><asp:TextBox ID="txtMontoRecaudado" runat="server" MaxLength="7"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Fecha</td>
                <td><asp:Calendar ID="cFechaActividad" runat="server"></asp:Calendar></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnCrearActividad" runat="server" Text="Crear" OnClick="btnCrearActividad_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
