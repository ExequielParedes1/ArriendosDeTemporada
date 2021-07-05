<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBRegistrar.aspx.cs" Inherits="WEBArriendoTemporada.WEBRegistrar" %>

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
            height: 900px;
            width: 900px;
            background-image: url(https://i.pinimg.com/originals/06/32/cf/0632cfafed349014d7c0c6ed10965dce.jpg);
            overflow-x: hidden;
            padding-top: 50px;
        }

        .main {
            padding: 0px 20px;
        }

        @media screen and (max-height: 50px) {
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

    <div class="container">
        <div class="sidenav">
            <div class="login-main-text">
                <h2>Pagina<br>
                    Ingreso Usuarios</h2>
                <p>Ingrese sus creedenciales para acceder al sistema.</p>
            </div>
        </div>

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Crea cuenta!</h1>
                            </div>

                            <div class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txt_nombre" class="form-control form-control-user"
                                            placeholder="Nombre" runat="server" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txt_apellido" class="form-control form-control-user"
                                            placeholder="Apellido(s)" runat="server" />
                                        <span class="focus-input100"></span>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txt_rut" class="form-control form-control-user"
                                        placeholder="11111111-1" runat="server" />
                                    <span class="focus-input100"></span>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txt_numeroContacto" class="form-control form-control-user"
                                        TextMode="Number" placeholder="Telefono" onkeypress="return this.value.length<=7"
                                        MaxLength="8" runat="server" />
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="correo" class="form-control form-control-user"
                                        TextMode="Email" runat="server" />
                                    <span class="focus-input100"></span>
                                </div>

                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox class="form-control form-control-user" ID="pass"
                                            runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                        <span class="focus-input100"></span>
                                    </div>

                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control form-control-user" placeholder="Repite la contraseña"
                                            ID="pass2" runat="server" TextMode="Password"></asp:TextBox>
                                        <span class="focus-input100"></span>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                                            ErrorMessage="Contraseñas no coinciden" ControlToCompare="pass"
                                            ForeColor="Red" ControlToValidate="pass2">
                                        </asp:CompareValidator>
                                    </div>
                                </div>
                                <asp:Button ID="btn_registrar" class="btn btn-primary btn-user btn-block"
                                    runat="server" Text="Registrar" OnClick="btn_registrar_click" />
                                <a class="small" href="WEBRecuperarCuenta.aspx">Olvidaste Contraseña?</a><br />
                                <a class="small" href="Login.aspx">Recordaste que tienes una cuenta? Inicia sesion!</a>
                            </div>
                        </div>
                    </div>
                </div>
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
