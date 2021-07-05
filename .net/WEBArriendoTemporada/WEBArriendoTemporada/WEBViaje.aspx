<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBViaje.aspx.cs" Inherits="WEBArriendoTemporada.WEBViaje" %>

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
    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Administrar Viajes Solitados</label>
            </strong>
        </div>
    </div>
    <br />
    <strong>
        <label>Administrar Viajes Solitados</label>
    </strong>
    <strong>
        <label>Viajes Pendientes</label>
    </strong>


    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">ID</th>
                                    <th class="cell100 column2">Inicio</th>
                                    <th class="cell100 column3">Termino</th>
                                    <th class="cell100 column4">Origen</th>
                                    <th class="cell100 column5">Destino</th>
                                    <th class="cell100 column6">Conductor</th>
                                    <th class="cell100 column7">Vehiculo</th>
                                    <th class="cell100 column8">ID Arriendo</th>
                                    <th class="cell100 column9">Opcion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridViajesPendientes" AutoGenerateColumns="false" PageSize="5"
                                            runat="server" DataKeyNames="id_viaje" AllowPaging="True" BorderStyle="None"
                                            OnSelectedIndexChanging="GridViajesPendientes_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="id_viaje" ControlStyle-CssClass="cell100 column1" SortExpression="id_viaje"></asp:BoundField>
                                                <asp:BoundField DataField="inicio" ControlStyle-CssClass="cell100 column2" SortExpression="inicio"></asp:BoundField>
                                                <asp:BoundField DataField="termino" ControlStyle-CssClass="cell100 column3" SortExpression="termino"></asp:BoundField>
                                                <asp:BoundField DataField="origen" ControlStyle-CssClass="cell100 column4" SortExpression="origen"></asp:BoundField>
                                                <asp:BoundField DataField="destino" ControlStyle-CssClass="cell100 column5" SortExpression="destino"></asp:BoundField>
                                                <asp:BoundField DataField="rutConductor" ControlStyle-CssClass="cell100 column6" SortExpression="rutConductor"></asp:BoundField>
                                                <asp:BoundField DataField="patenteVehiculo" ControlStyle-CssClass="cell100 column7" SortExpression="patenteVehiculo"></asp:BoundField>
                                                <asp:BoundField DataField="id_arriendo_id" ControlStyle-CssClass="cell100 column8" SortExpression="id_arriendo_id"></asp:BoundField>
                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Aprobar" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--===============================================================================================-->
    <script src="assets/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="assets/vendor/bootstrap/js/popper.js"></script>
    <script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="assets/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="assets/vendor/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script>
        $('.js-pscroll').each(function () {
            var ps = new PerfectScrollbar(this);

            $(window).on('resize', function () {
                ps.update();
            })
        });
    </script>
    <!--===============================================================================================-->
    <script src="assets/js/main.js"></script>

</asp:Content>
