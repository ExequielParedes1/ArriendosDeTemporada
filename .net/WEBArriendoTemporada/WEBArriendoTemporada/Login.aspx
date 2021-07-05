<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEBArriendoTemporada.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <style>
        body {
            font-family: "Lato", sans-serif;
        }

        .main-head {
            height: 150px;
            background: #FFF;
        }

        .sidenav {
            height: 150%;
            width: 50%;
            background-image: url(https://i.pinimg.com/originals/06/32/cf/0632cfafed349014d7c0c6ed10965dce.jpg);
            overflow-x: hidden;
            padding-top: 30px;
        }

        .main {
            padding: 0px 10px;
        }

        @media screen and (max-height: 550px) {
            .sidenav {
                padding-top: 15px;
            }
        }

        @media screen and (max-width: 500px) {
            .login-form {
                margin-top: 10%;
            }

            .register-form {
                margin-top: 10%;
            }
        }

        @media screen and (min-width: 768px) {
            .main {
                margin-left: 40%;
            }

            .sidenav {
                width: 40%;
                position: fixed;
                z-index: 1;
                top: 0;
                left: 0;
            }

            .login-form {
                margin-top: 80%;
            }

            .register-form {
                margin-top: 20%;
            }
        }


        .login-main-text {
            margin-top: 20%;
            padding: 60px;
            color: #fff;
        }

            .login-main-text h2 {
                font-weight: 300;
            }

        .btn-black {
            background-color: #000 !important;
            color: #fff;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sidenav">
        <div class="login-main-text">
            <h2>Pagina<br>
                Ingreso Usuarios</h2>
            <p>Ingrese sus creedenciales para acceder al sistema.</p>
        </div>
    </div>
    <div class="main">
        <div class="col-md-6 col-sm-12">
            <div class="login-form">
                <form>
                    <div class="form-group">
                        <asp:Label Text="User Name" runat="server" />
                        <asp:TextBox ID="user" placeholder="Email ..." TextMode="Email" class="form-control form-control-user"
                            aria-describedby="emailHelp" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Password" runat="server" />
                        <asp:TextBox ID="pass" TextMode="Password" class="form-control form-control-user"
                            placeholder="Contraseña ..." runat="server" />
                    </div>
                    <asp:Button ID="btn_iniciar" Text="Iniciar"  class="btn btn-outline-secondary" OnClick="btn_iniciar_Click" runat="server" />
                    <asp:LinkButton Visible="false" ID="registrate" Text="Registrar" class="btn btn-secondary"   runat="server" />
                    <asp:Button ID="registrates" Text="Registrar" class="btn btn-outline-secondary" OnClick="registrate_Click" runat="server" />
                </form>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>
    <!--Validar campos-->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />
</asp:Content>
