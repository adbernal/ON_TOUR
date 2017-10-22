<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelApoderado.aspx.cs" Inherits="ON_TOUR.PanelApoderado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        <table>
            <tr>
                <td>
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblNombreUsuario" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblTipoUsuario" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblIdApoderado" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Cantidad de depositos</td>
                <td><asp:Label ID="lblCantidadDepositos" runat="server" Text="Muchos"></asp:Label></td>
            </tr>
            <tr>
                <td>Progreso</td>
                <td><asp:Label ID="lblProgreso" runat="server" Text="70%"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <asp:GridView ID="gvDepositos" runat="server" AutoGenerateColumns="true" Width="100%"  ViewStateMode="Enabled"></asp:GridView>
                </td>
            </tr>

            <tr>
                <td>Notificar un nuevo deposito</td>
            </tr>
            <tr>
                <td>MONTO:</td>
                <td><asp:TextBox ID="txtMontoDeposito" runat="server"></asp:TextBox></td>
            </tr>
            <!--
            <tr>
                <td>FECHA:</td>
                <td>
                    <asp:Calendar ID="cFecha" runat="server"></asp:Calendar>
                </td>
            </tr>
            -->
            <tr>
                <td>COMENTARIO:</td>
                <td><asp:TextBox ID="txtComentarioDeposito" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>CAPTURA DEL COMPROBANTE:</td>
                <td><asp:FileUpload ID="fupComprobante" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnNotificarDeposito" runat="server" Text="Notificar deposito" OnClick="btnNotificarDeposito_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
