<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ON_TOUR.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Formulario de registro</h1>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label><br />
        <asp:Label ID="lblEstado" runat="server"></asp:Label>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Seleccione colegio </asp:Label>
            <asp:DropDownList ID="ddlColegio" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlColegio_SelectedIndexChanged" AppendDataBoundItems="true"><asp:ListItem Text="SELECCIONE..." disabled="true"/></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Seleccione curso </asp:Label>
            <asp:DropDownList ID="ddlCurso" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Correo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Rut sin puntos</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtRut" runat="server" MaxLength="10" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Nombre </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="30" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Apellido Paterno </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtApellidoP" runat="server" MaxLength="30" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Apellido Materno </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtApellidoM" runat="server" MaxLength="30" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Direccion </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Telefono </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="20" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Sexo </asp:Label>
            <div class="col-md-10">
                <asp:RadioButton ID="rbtM" runat="server" Text="M" GroupName="rbtSexo" />
                <asp:RadioButton ID="rbtF" runat="server" Text="F" GroupName="rbtSexo" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha Nacimiento </asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="cFechaNacimiento" runat="server"></asp:Calendar>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnProbar" runat="server" Text="Probar" OnClick="btnProbar_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
