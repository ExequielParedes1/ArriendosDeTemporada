<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBReservar.aspx.cs" Inherits="WEBArriendoTemporada.WEBReservar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/css/Notice.css" />
    <!--===============================================================================================-->
    <style>
        .box {
            overflow: hidden;
        }

        .content {
            font-size: 15px;
            line-height: 20px;
            padding: 0 20px;
            text-align: justify;
        }

        .left {
            float: left;
            width: 50%;
        }

            .left .content {
                border-right: 5px solid #4BB495;
            }

        .right {
            float: right;
            width: 50%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Reserva</label>
            </strong>
        </div>
    </div>
    <br />
    <br />
    <br />

    <div class="container-fluid shadow">
        <div class="box">
            <div class="left">
                <div class="content">
                    <table style="width: 100%" class="table">
                        <asp:Label Text="" runat="server" />
                        <tr>
                            <th scope="col">
                                <label style="text-align: center">Ubicacion</label>
                            </th>
                            <td>
                                <asp:DropDownList CssClass="form-control" ID="DLZona" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th scope="col">Check In</th>
                            <td>
                                <asp:TextBox ID="txtDate1" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th scope="col">Check out</th>
                            <td>
                                <asp:TextBox ID="txtDate2" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th scope="col">Habitaciones</th>
                            <td>
                                <asp:TextBox ID="txt_habitaciones" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th scope="col">Huéspedes</th>
                            <td>
                                <asp:TextBox ID="txt_huespedes" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th scope="col"></th>
                            <td>
                                <asp:Button ID="btn_reservar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="reservar_clic" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="right">
                <div class="content">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>

                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="assets/img/Reserva/RES01.jpg" alt="pieza1" style="width: 75%;">
                            </div>
                            <div class="carousel-item">
                                <img src="assets/img/Reserva/RES02.jpg" alt="pieza1" style="width: 75%;">
                            </div>
                            <div class="carousel-item">
                                <img src="assets/img/Reserva/RES03.jpg" alt="pieza1" style="width: 75%;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalDeuda" tabindex="-1" role="dialog" aria-labelledby="ModalDeuda" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Deudas</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    Hola

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
        </div>
    </div>
    <!--Validar campos-->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />
    <script>
        function openModalDeudas() {
            $('#ModalDeuda').modal('show');
        }
    </script>


</asp:Content>

