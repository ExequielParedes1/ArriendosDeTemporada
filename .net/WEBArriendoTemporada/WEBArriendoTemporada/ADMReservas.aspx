<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMReservas.aspx.cs" Inherits="WEBArriendoTemporada.ADMReservas" %>

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
                <label>Administrar Arriendos</label>
            </strong>
        </div>
        <br />
        <label>Administrar Arriendos Activos</label>
    </div>

    <!-- ADMINISTRAR ARRIENDOS ACTIVOS -->
    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">ID</th>
                                    <th class="cell100 column2">Dirección</th>
                                    <th class="cell100 column3">m²</th>
                                    <th class="cell100 column4">Valor<br />
                                        Diario</th>
                                    <th class="cell100 column5">Disp</th>
                                    <th class="cell100 column6">Zona</th>
                                    <th class="cell100 column7">N°<br />
                                        Hab.</th>
                                    <th class="cell100 column8">N°<br />
                                        Baños</th>
                                    <th class="cell100 column9">Ver</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="id_reserva" BorderWidth="0"
                                            OnPageIndexChanging="GridView1_PageIndexChanging"
                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="id_reserva" ControlStyle-CssClass="cell100 column1" SortExpression="_id_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_dias_reserva" ControlStyle-CssClass="cell100 column2" SortExpression="_dias_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_valor_final" ControlStyle-CssClass="cell100 column3" SortExpression="_valor_final"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_in" ControlStyle-CssClass="cell100 column4" SortExpression="_check_in"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_out" ControlStyle-CssClass="cell100 column5" SortExpression="_check_out"></asp:BoundField>
                                                <asp:BoundField DataField="_fecha_contrato" ControlStyle-CssClass="cell100 column6" SortExpression="_fecha_contrato"></asp:BoundField>
                                                <asp:BoundField DataField="_departamento_id_departamento" ControlStyle-CssClass="cell100 column7" SortExpression="_departamento_id_departamento"></asp:BoundField>
                                                <asp:BoundField DataField="_anticipo" ControlStyle-CssClass="cell100 column8" SortExpression="_anticipo"></asp:BoundField>
                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Detalle" />
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


    <div class="container">
        <label>Administrar Arriendos Inactivos</label>
    </div>
    <!-- ADMINISTRAR ARRIENDOS INACTIVOS -->
    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">ID</th>
                                    <th class="cell100 column2">Dias</th>
                                    <th class="cell100 column3">Costo Arriendo</th>
                                    <th class="cell100 column4">Comienzo</th>
                                    <th class="cell100 column5">Termino</th>
                                    <th class="cell100 column6">Total Multas</th>
                                    <th class="cell100 column7">Fecha Contrato</th>
                                    <th class="cell100 column8">ID Dpto</th>
                                    <th class="cell100 column9">Pagado</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td>
                                        <asp:GridView ID="GridView2" PageSize="4" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="id_reserva" AllowPaging="True" BorderWidth="0"
                                            OnPageIndexChanging="GridView2_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="id_reserva" ControlStyle-CssClass="cell100 column1" SortExpression="_id_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_dias_reserva" ControlStyle-CssClass="cell100 column1" SortExpression="_dias_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_valor_final" ControlStyle-CssClass="cell100 column1" SortExpression="_valor_final"></asp:BoundField>
                                                <asp:BoundField DataField="_check_in" ControlStyle-CssClass="cell100 column1" SortExpression="_check_in"></asp:BoundField>
                                                <asp:BoundField DataField="_check_out" ControlStyle-CssClass="cell100 column1" SortExpression="_check_out"></asp:BoundField>
                                                <asp:BoundField DataField="_total_multas" ControlStyle-CssClass="cell100 column1" SortExpression="_total_multas"></asp:BoundField>
                                                <asp:BoundField DataField="_fecha_contrato" ControlStyle-CssClass="cell100 column1" SortExpression="_fecha_contrato"></asp:BoundField>
                                                <asp:BoundField DataField="_departamento_id_departamento" ControlStyle-CssClass="cell100 column1" SortExpression="_departamento_id_departamento"></asp:BoundField>
                                                <asp:BoundField DataField="_anticipo" ControlStyle-CssClass="cell100 column1" SortExpression="_anticipo"></asp:BoundField>
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

    <div class="container">
        <label>Administrar Arriendos Anulados</label>
    </div>
    <!-- ADMINISTRAR ARRIENDOS ANULADO -->
    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">ID Reserva</th>
                                    <th class="cell100 column2">Dias reserva</th>
                                    <th class="cell100 column3">Valor Final</th>
                                    <th class="cell100 column4">CheckIn</th>
                                    <th class="cell100 column5">CheckOut</th>
                                    <th class="cell100 column6">Fecha Contrato</th>
                                    <th class="cell100 column7">ID Depto</th>
                                    <th class="cell100 column8">Anticipo</th>
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
                                        <asp:GridView ID="GridView3" PageSize="4" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="id_reserva" AllowPaging="True" 
                                            OnPageIndexChanging="GridView2_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="id_reserva" HeaderText="ID" SortExpression="_id_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_dias_reserva" HeaderText="Dias" SortExpression="_dias_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_valor_final" HeaderText="Costo Arriendo" SortExpression="_valor_final"></asp:BoundField>
                                                <asp:BoundField DataField="_check_in" HeaderText="Comienzo" SortExpression="_check_in"></asp:BoundField>
                                                <asp:BoundField DataField="_check_out" HeaderText="Termino" SortExpression="_check_out"></asp:BoundField>
                                                <asp:BoundField DataField="_total_multas" HeaderText="Total Multas" SortExpression="_total_multas"></asp:BoundField>
                                                <asp:BoundField DataField="_fecha_contrato" HeaderText="Fecha Contrato" SortExpression="_fecha_contrato"></asp:BoundField>
                                                <asp:BoundField DataField="_departamento_id_departamento" HeaderText="ID Dpto" SortExpression="_departamento_id_departamento"></asp:BoundField>
                                                <asp:BoundField DataField="_anticipo" HeaderText="Pagado" SortExpression="_anticipo"></asp:BoundField>
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

    <!-- Modal Desactivar Arriendo-->
    <div class="modal fade" id="ModalDesactivarArriendo" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarConductor" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel4">Desactivar Arriendos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar el arriendoo
                    <asp:Label ID="lblConductor" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="hidenIDArriendo" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button3" runat="server" OnClick="btn_desactivar_arriendo" class="btn btn-danger" Text="Desactiva" />
                </div>
            </div>
        </div>
    </div>


    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#<%=GridView1.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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

    <script>
        function openModalDesactivar() {
            $('#ModalDesactivarArriendo').modal('show');
        }
    </script>

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
