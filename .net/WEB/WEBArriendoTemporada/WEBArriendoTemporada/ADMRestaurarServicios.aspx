<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMRestaurarServicios.aspx.cs" Inherits="WEBArriendoTemporada.ADMRestaurarServicios" %>

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
                <label>Restaurar Servicios</label>
            </strong>
        </div>
    </div>
    <strong>
        <label>Servicios Inactivos</label>
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
                                    <th class="cell100 column2">Nombre</th>
                                    <th class="cell100 column3">Valor</th>
                                    <th class="cell100 column4">Descripcion</th>
                                    <th class="cell100 column5">Opcion</th>
                                    <th class="cell100 column6">Opcion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridServiciosInactivos" PageSize="5" DataKeyNames="idServicio" class="table table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanging="GridServiciosInactivos_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="idServicio" HeaderText="ID" ReadOnly="True" SortExpression="idServicio"></asp:BoundField>
                                                <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                                                <asp:BoundField DataField="valor_servicio" HeaderText="Costo" SortExpression="valor_servicio"></asp:BoundField>

                                                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion"></asp:BoundField>

                                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Recuperar" />
                                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-info" ShowDeleteButton="true" DeleteText="Logs" />
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

