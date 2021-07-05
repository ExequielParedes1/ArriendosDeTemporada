<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBSolicitarTransporte.aspx.cs" Inherits="WEBArriendoTemporada.WEBSolicitarTransporte" %>

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
                <label>Servicios Transporte</label>
            </strong>
        </div>
    </div>
    <br />
    <div class="container-fluid">
        <a href="#" data-target="#ModalSolicitarTransporte" data-toggle="modal" class="btn btn-primary btn-icon-split">
            <span class="text">Solicitar transporte</span>
        </a>
    </div>
    <br />
    <strong>
        <label>Transporte a espera de Confirmacion</label>
    </strong>

    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-110">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1">Id</th>
                                    <th class="cell100 column2">Inicio</th>
                                    <th class="cell100 column3">Termino</th>
                                    <th class="cell100 column4">Origen</th>
                                    <th class="cell100 column5">Destino</th>
                                    <th class="cell100 column5">Reserva</th>
                                    <th class="cell100 column5">Opcion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridEsperaSolicitud" PageSize="5" runat="server" 
                                            AutoGenerateColumns="False" DataKeyNames="id_viaje" 
                                            AllowPaging="True" BorderStyle="None"
                                            OnRowDeleting="GridEsperaSolicitud_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="id_viaje" ControlStyle-CssClass="cell100 column1" SortExpression="id_viaje"></asp:BoundField>
                                                <asp:BoundField DataField="inicio" ControlStyle-CssClass="cell100 column2" SortExpression="inicio"></asp:BoundField>
                                                <asp:BoundField DataField="termino" ControlStyle-CssClass="cell100 column3" SortExpression="termino"></asp:BoundField>
                                                <asp:BoundField DataField="origen" ControlStyle-CssClass="cell100 column4" SortExpression="origen"></asp:BoundField>
                                                <asp:BoundField DataField="destino" ControlStyle-CssClass="cell100 column5" SortExpression="destino"></asp:BoundField>
                                                <asp:BoundField DataField="id_reserva_id" ControlStyle-CssClass="cell100 column6" SortExpression="id_reserva_id"></asp:BoundField>

                                                <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Cancelar" ControlStyle-CssClass="btn btn-danger" />
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

    <!-- Modal Solicitar Transporte -->
    <div class="modal fade" id="ModalSolicitarTransporte" tabindex="-1" role="dialog" aria-labelledby="ModalSolicitarTransporte" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV3">Solicitar Servicio</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Origen</label>
                        <div>
                            <asp:TextBox ID="txtOrigen" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Destino</label>
                        <div>
                            <asp:TextBox ID="txtDestino" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Comienzo</label>
                        <div>
                            <asp:TextBox ID="txtComienzo" CssClass="form-control" placeholder="Fecha Comienzo" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Termino</label>
                        <div>
                            <asp:TextBox ID="txtTermino" runat="server" placeholder="Fecha Termino" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Departamento a cargar</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DLdpto" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <label>Vehiculo</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DDLVehiculo" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <label>Conductor</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DDLConductor" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnSolicitarTrans" class="btn btn-primary" runat="server" Text="Solicitar" OnClick="btnSolicitarTransporte" />
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


    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script>
        $('.js-pscroll').each(function () {
            var ps = new PerfectScrollbar(this);

            $(window).on('resize', function () {
                ps.update();
            })
        });


    </script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>

    <script>
        function openModalSolicitarTransporte() {
            $('#ModalSolicitarTransporte').modal('show');
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $('[id*=txtComienzo]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('[id*=txtTermino]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
        });
    </script>
</asp:Content>
