<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBVisualizarDepartamento.aspx.cs" Inherits="WEBArriendoTemporada.WEBVisualizarDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="assets/img/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/vendor/perfect-scrollbar/perfect-scrollbar.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/css/main.css">
    <link rel="stylesheet" type="text/css" href="assets/css/util.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/css/Notice.css" />
    <!--===============================================================================================-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Departamentos</label>
            </strong>
        </div>
    </div>
    <br />

    <style type="text/css">
        .zoom {
            /* Aumentamos la anchura y altura durante 2 segundos */
            transition: width 1s, height 1s, transform 1s;
            -moz-transition: width 1s, height 1s, -moz-transform 1s;
            -webkit-transition: width 2s, height 2s, -webkit-transform 2s;
            -o-transition: width 1s, height 1s,-o-transform 1s;
        }

            .zoom:hover {
                /* tranformamos el elemento al pasar el mouse por encima al doble de
           su tamaño con scale(2). */
                transform: scale(1.05);
                -moz-transform: scale(1.05); /* Firefox */
                -webkit-transform: scale(1.05); /* Chrome - Safari */
                -o-transform: scale(1.05); /* Opera */
            }
    </style>

    <div class="container">
        <div class="row">
            <asp:Repeater runat="server" ID="Repeater1">
                <ItemTemplate>

                    <div class="col-sm-3 col-md-3">
                        <div class="container-fluid shadow">
                            <div class="kt-portlet kt-portlet--tabs">
                                <div class="zoom">
                                    <img class="zoom" style="width: 250px; height: 250px;" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"_url")) %>" /><br />
                                    <div class="caption">
                                        <h3><%# DataBinder.Eval(Container.DataItem,"_nombre")  %></h3>
                                        <p><%# DataBinder.Eval(Container.DataItem,"_descripcion")  %></p>
                                        <p>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>
