<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMRestaurarDepartamento.aspx.cs" Inherits="WEBArriendoTemporada.ADMRestaurarDepartamento" %>

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
                <label>Administrar Departamento</label>
            </strong>
        </div>
    </div>
    <strong>
        <label>Departamento Inactivos</label>
    </strong>

    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-100">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">ID</th>
                                    <th class="cell100 column2">Dirección</th>
                                    <th class="cell100 column3">m²</th>
                                    <th class="cell100 column4">Valor Diario</th>
                                    <th class="cell100 column5">zona</th>
                                    <th class="cell100 column6">N° Habitaciones</th>
                                    <th class="cell100 column7">N° Baños</th>
                                    <th class="cell100 column8">Opciones</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridDepartamentosInactivos" PageSize="5" 
                                            DataKeyNames="idDepartamento" runat="server" BorderWidth="0"
                                            AutoGenerateColumns="False" AllowPaging="True" 
                                            OnSelectedIndexChanging="GridDepartamentosInactivos_SelectedIndexChanging" 
                                            OnRowDeleting="GridDepartamentosInactivos_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="idDepartamento" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="idDepartamento"></asp:BoundField>
                                                <asp:BoundField DataField="direccion" ControlStyle-CssClass="cell100 column2" SortExpression="direccion"></asp:BoundField>
                                                <asp:BoundField DataField="mtrsCuadrados" ControlStyle-CssClass="cell100 column3" SortExpression="mtrsCuadrados"></asp:BoundField>
                                                <asp:BoundField DataField="valirDiario" ControlStyle-CssClass="cell100 column4" SortExpression="valirDiario"></asp:BoundField>
                                                <asp:BoundField DataField="zona" ControlStyle-CssClass="cell100 column5" SortExpression="zona"></asp:BoundField>
                                                <asp:BoundField DataField="nro_habitaciones" ControlStyle-CssClass="cell100 column6" SortExpression="nro_habitaciones"></asp:BoundField>
                                                <asp:BoundField DataField="nro_baños" ControlStyle-CssClass="cell100 column7" SortExpression="nro_baños"></asp:BoundField>
                                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Recuperar" />
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
    <!--===============================================================================================-->
    <script>
        $(document).ready(function () {
            $('#<%=GridDepartamentosInactivos.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[4, 10, 25, 50, -1], [4, 10, 25, 50, "Todo"]],
                "language": {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }


            });
        });
    </script>
    <!--===============================================================================================-->
    <script>
        function openModalLog() {
            $('#ModalLog').modal('show');
        }
    </script>
</asp:Content>
