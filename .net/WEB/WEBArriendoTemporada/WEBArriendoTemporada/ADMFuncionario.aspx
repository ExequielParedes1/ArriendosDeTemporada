<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMFuncionario.aspx.cs" Inherits="WEBArriendoTemporada.ADMFuncionario" %>

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
                <label>Administrar Funcionario</label>
            </strong>
        </div>
    </div>
    <%--    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Asignacion Funcionario</label>
            </strong>
        </div>
    </div>--%>

    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1" style="width: 5% !important;">ID</th>
                                    <th class="cell100 column2" style="width: 4% !important;">Dia</th>
                                    <th class="cell100 column3" style="width: 7% !important;">Costo<br />
                                        arriendo</th>
                                    <th class="cell100 column4" style="width: 11% !important;">Inicio</th>
                                    <th class="cell100 column5" style="width: 15% !important;">Fin</th>
                                    <th class="cell100 column6" style="width: 17% !important;">Fecha Contrato</th>
                                    <th class="cell100 column7" style="width: 9% !important;">ID Depto</th>
                                    <th class="cell100 column8" style="width: 5% !important;">Pagado</th>
                                    <th class="cell100 column9" style="width: 25% !important;">Asignacion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridView1" PageSize="4" runat="server"
                                            AutoGenerateColumns="False" DataKeyNames="id_reserva"
                                            AllowPaging="True" BorderWidth="0"
                                            OnRowDeleting="GridView1_RowDeleting1"
                                            OnPageIndexChanging="GridView1_PageIndexChanging1">
                                            <Columns>
                                                <asp:BoundField DataField="id_reserva" ControlStyle-CssClass="cell100 column1" SortExpression="_id_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_dias_reserva" ControlStyle-CssClass="cell100 column1" SortExpression="_dias_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_valor_final" ControlStyle-CssClass="cell100 column1" SortExpression="_valor_final"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_in" ControlStyle-CssClass="cell100 column1" SortExpression="_check_in"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_out" ControlStyle-CssClass="cell100 column1" SortExpression="_check_out"></asp:BoundField>
                                                <asp:BoundField DataField="_fecha_contrato" ControlStyle-CssClass="cell100 column1" SortExpression="_fecha_contrato"></asp:BoundField>
                                                <asp:BoundField DataField="_departamento_id_departamento" ControlStyle-CssClass="cell100 column1" SortExpression="_departamento_id_departamento"></asp:BoundField>
                                                <asp:BoundField DataField="_anticipo" ControlStyle-CssClass="cell100 column1" SortExpression="_anticipo"></asp:BoundField>
                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Asignar Funcionario" />
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

    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1" style="width: 0px !important;">ID<br />
                                        Reserva</th>
                                    <th class="cell100 column2" style="width: 0px !important;">Dias</th>
                                    <th class="cell100 column3" style="width: 0px !important;">Valor<br />
                                        Final</th>
                                    <th class="cell100 column4" style="width: 300px !important;">CheckIn</th>
                                    <th class="cell100 column5" style="width: 0px !important;">CheckOut</th>
                                    <th class="cell100 column6" style="width: 300px !important;">Fecha Contrato</th>
                                    <th class="cell100 column7" style="width: 70px !important;">ID<br />
                                        Depto</th>
                                    <th class="cell100 column8" style="width: 100px !important;">Anticipo</th>
                                    <th class="cell100 column9" style="width: 130px !important;">Ver</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="id_reserva" AllowPaging="True" BorderWidth="0"
                                            OnPageIndexChanging="GridView2_PageIndexChanging"
                                            OnRowDeleting="GridView2_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="id_reserva" SortExpression="_id_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_dias_reserva" SortExpression="_dias_reserva"></asp:BoundField>
                                                <asp:BoundField DataField="_valor_final" SortExpression="_valor_final"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_in" SortExpression="_check_in"></asp:BoundField>
                                                <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_out" SortExpression="_check_out"></asp:BoundField>
                                                <asp:BoundField DataField="_fecha_contrato" SortExpression="_fecha_contrato"></asp:BoundField>
                                                <asp:BoundField DataField="_departamento_id_departamento" SortExpression="_departamento_id_departamento"></asp:BoundField>
                                                <asp:BoundField DataField="_anticipo" SortExpression="_anticipo"></asp:BoundField>
                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Ver" />
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

    <!-- Modal asignar -->
    <div class="modal fade" id="ModalAsignar" tabindex="-1" role="dialog" aria-labelledby="ModalAsignar" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Asignar Funcionario</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>

                <div class="modal-body">
                    <asp:HiddenField runat="server" ID="arriendoAsignar" Value="" />
                    <asp:GridView class="table table-striped- table-bordered table-hover table-checkable" DataKeyNames="_correo" AllowPaging="true" AutoGenerateColumns="false" PageSize="4" ID="kt_table_1" Width="100%" CellSpacing="0" runat="server" OnPageIndexChanging="kt_table_1_PageIndexChanging" OnRowDeleting="kt_table_1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                            <asp:BoundField DataField="_apellido" HeaderText="Apellido" SortExpression="_apellido"></asp:BoundField>
                            <asp:BoundField DataField="_numeroContacto" HeaderText="Telefono" SortExpression="_numeroContacto"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Asignar" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalFuncionarioAsignado" tabindex="-1" role="dialog" aria-labelledby="ModalFuncionarioAsignado" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Funcionario asociado</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>

                <div class="modal-body">
                    <asp:Label runat="server" ID="correo"></asp:Label>
                    <asp:Label runat="server" ID="id"></asp:Label>
                    <asp:HiddenField runat="server" ID="hidenFuncionarioAsociadoArriendo" Value="" />
                    <asp:HiddenField runat="server" ID="hidenFuncionarioAsociado" Value="" />
                    <asp:GridView runat="server" ID="gridFuncionarioAsignado" AutoGenerateColumns="false" class="table table-striped- table-bordered table-hover table-checkable" DataKeyNames="_correo" AllowPaging="true" OnRowDeleting="gridFuncionarioAsignado_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                            <asp:BoundField DataField="_apellido" HeaderText="Apellido" SortExpression="_apellido"></asp:BoundField>
                            <asp:BoundField DataField="_numeroContacto" HeaderText="Telefono" SortExpression="_numeroContacto"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" ShowDeleteButton="true" DeleteText="Desvincular" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <script>
        $(document).ready(function () {
            $('#<%=GridView2.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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
        function openModalAsignar() {
            $('#ModalAsignar').modal('show');
        }
    </script>

    <script>
        function openModalFuncionarioAsignado() {
            $('#ModalFuncionarioAsignado').modal('show');
        }
    </script>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" rel="stylesheet" />
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
