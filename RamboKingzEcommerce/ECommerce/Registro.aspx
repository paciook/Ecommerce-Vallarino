<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ECommerce.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>

    <link href="~/css/Site.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="img/logo.png" type="image/png" sizes="32x32"/>
    <link rel="icon" href="img/logo.png" type="image/png" sizes="32x32"/>


    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 237px;
        }
        .auto-style6 {
            height: 50px;
        }
        .auto-style8 {
            width: 329px;
            height: 50px;
        }
        .auto-style9 {
            width: 40%;
            margin-bottom: 0;
        }
        .auto-style10 {
            width: 237px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-md navbar-dark bg-primary">
                <h1 style=" margin: 0 auto; margin-bottom: 2%; margin-top:2%; color:snow;">Registrese</h1>
            </nav>
        </div>
            <table style="margin-left: auto; margin-right: auto; margin-top: 5%;" class="auto-style9">
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbUsuario" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txUsuario" runat="server" Width="231px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbContraseña" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txContraseña" runat="server" Width="231px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbNombre" runat="server" Text="Nombre y apellido"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txNombre" runat="server" Width="315px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txEmail" runat="server" Width="315px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbTelefono" runat="server" Text="Telefono"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txTelefono" runat="server" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbDireccion" runat="server" Text="Direccion"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txDireccion" runat="server" Width="315px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        <div class="col-sm-4 text-center" style="margin: 0 auto; margin-top:4%;">
            <asp:Button ID="btRegistrar" runat="server" Text="Crear cuenta" class="btn btn-primary btn-lg w-100" OnClick="btRegistrar_Click" />
        </div>
        <div style="text-align: center; color: red;">
            <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
