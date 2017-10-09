<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ON_TOUR.LoginApoderado" %>

<!DOCTYPE html>

<html >
<head>
  <meta charset="UTF-8">
  <title>Login Form</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
    <link rel="stylesheet" href="css/login.css" />
    <style></style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
</head>

<body>
  <div class="login">
	<h1>Login</h1>
    <form method="post" runat="server">
        <p>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

            <asp:Label ID="lblTexto" runat="server"></asp:Label>
        </p>
        <asp:Label ID="lbl1" runat="server"></asp:Label>
        <asp:Label ID="lbl2" runat="server"></asp:Label>
        <asp:Label ID="lbl3" runat="server"></asp:Label>
        <asp:TextBox ID="txtCorreo" placeholder="Correo" TextMode="Email" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtClave" placeholder="Contraseña" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" class="btn btn-primary btn-block btn-large" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
     
    </form>
</div>
  
    <script  src="js/index.js"></script>

</body>
</html>
