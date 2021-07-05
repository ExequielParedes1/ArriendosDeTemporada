<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBSolicitarServicios.aspx.cs" Inherits="WEBArriendoTemporada.WEBSolicitarServicios" %>

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
    <link rel="stylesheet" type="text/css" href="assets/css/Tabs.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/Modal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Servicio</label>
            </strong>
        </div>
    </div>
    <br />
    <br />
    <div>
        <div class="row container-fluid">
            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-4 col-md-5 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Total a pagar (CLP)</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lblGastoTotal" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="col-auto">
                                <i class="fas fa-calendar fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-4 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Pagado (CLP)</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lblPagado" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="col-auto">
                                <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-4 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Diferencia (CLP)</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lblDiferencia" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="col-auto">
                                <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />


    <div class="tabs">
        <input type="radio" id="tab1" name="tab-control" checked>
        <input type="radio" id="tab2" name="tab-control">
        <ul>
            <li title="Features">
                <label for="tab1" role="button">
                    <span>Activos</span>
                </label>
            </li>
            <li title="Delivery Contents">
                <label for="tab2" role="button">
                    <span>Pagos finalizados</span>
                </label>
            </li>
        </ul>

        <div class="content">
            <section>
                <h2>Activos</h2>


                <div class="tab-pane active" id="kt_portlet_tab_1_1">
                    <asp:GridView ID="GridArriendo" runat="server" class="table table-bordered" DataKeyNames="id_reserva" AutoGenerateColumns="false" OnRowDeleting="GridArriendo_RowDeleting" OnSelectedIndexChanging="GridArriendo_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="id_reserva" HeaderText="ID" SortExpression="id_reserva"></asp:BoundField>
                            <asp:BoundField DataField="_valor_final" HeaderText="Valor Total" SortExpression="_valor_final"></asp:BoundField>
                            <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_in" HeaderText="CheckIn" SortExpression="_check_in"></asp:BoundField>
                            <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_Out" HeaderText="CheckOut" SortExpression="_check_Out"></asp:BoundField>
                            <asp:BoundField DataField="_fecha_contrato" HeaderText="Fecha solicitud" SortExpression="_fecha_contrato"></asp:BoundField>
                            <asp:BoundField DataField="_departamento_id_departamento" HeaderText="DPTO. Asociado" SortExpression="_departamento_id_departamento"></asp:BoundField>
                            <asp:BoundField DataField="_anticipo" HeaderText="Pagado" SortExpression="_anticipo"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-info" ShowSelectButton="true" SelectText="Informacion" />
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Pagar" />
                        </Columns>
                    </asp:GridView>
                </div>



            </section>

            <section>
                <h2>Finalizados</h2>

                <div class="tab-pane" id="kt_portlet_tab_1_2">
                    <asp:GridView ID="GridVArriendoFinalizado" runat="server" PageSize="5" DataKeyNames="id_reserva"
                        AutoGenerateColumns="false" OnRowDeleting="GridArriendo_RowDeleting" class="table table-bordered"
                        OnSelectedIndexChanging="GridArriendo_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="id_reserva" HeaderText="ID" SortExpression="id_reserva"></asp:BoundField>
                            <asp:BoundField DataField="_check_in" HeaderText="Comienzo" SortExpression="_check_in"></asp:BoundField>
                            <asp:BoundField DataField="_check_Out" HeaderText="Termino" SortExpression="_check_Out"></asp:BoundField>
                            <asp:BoundField DataField="_total_multas" HeaderText="Multas" SortExpression="_total_multas"></asp:BoundField>
                            <asp:BoundField DataField="_departamento_id_departamento" HeaderText="DPTO" SortExpression="_departamento_id_departamento"></asp:BoundField>
                            <asp:BoundField DataField="_valor_final" HeaderText="Pagado" SortExpression="_valor_final"></asp:BoundField>
                            <asp:BoundField DataField="_fecha_contrato" HeaderText="Contrato" SortExpression="_fecha_contrato"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>


            </section>
        </div>
    </div>
    <br />



    <!-- Modal Pagar-->
    <div class="modal fade" id="ModalPagar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Pago </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Pago del departamento ID: </label>
                    <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
                    <div>
                        <label>Deuda: </label>
                        <asp:Label runat="server" Text="0" ID="lblDeuda"></asp:Label><br />
                        <label>¿Cuanto desea pagar?</label>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pagando" placeholder="0000000" CssClass="form-control"  TextMode="Number"></asp:TextBox>
                        </div>
                        <label>Metodo de pago</label>
                        <asp:DropDownList CssClass="form-control" ID="dlTarjeta" runat="server">
                            <asp:ListItem>Visa</asp:ListItem>
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>Cta Rut</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" ValidationGroup="pagarGroup" OnClick="Click_pagarDeuda" runat="server" class="btn btn-primary" Text="Pagar" />
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

    <script src="Scripts/jquery-1.10.2.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#<%=GridArriendo.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todo"]],
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
        function openModalPagar() {
            $('#ModalPagar').modal('show');
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
    <!--==========================================-->
    <script src="assets/js/main.js"></script>
</asp:Content>
