<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBSolicitarServicioExtra.aspx.cs" Inherits="WEBArriendoTemporada.WEBSolicitarServicioExtra" %>

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
                <label>Solicitar Servicios Extra</label>
            </strong>
        </div>
    </div>
    <br />
    <section id="serviciosExtras">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalSolicitarServicioExtra">
            Servicios extra
        </button>
    </section>

    <section id="serviciosAprobados">
        <asp:GridView ID="GridServiciosContratados" DataKeyNames="idServicio" runat="server" PageSize="5" class="table table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="idServicio" HeaderText="ID" SortExpression="idServicio"></asp:BoundField>
                <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                <asp:BoundField DataField="valor_servicio" HeaderText="Valor" SortExpression="valor_servicio"></asp:BoundField>
                <asp:BoundField DataField="descripcion" HeaderText="Descipcion" SortExpression="descripcion"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </section>


    <!--Modal listar Servicios extras -->
    <div class="modal fade" id="ModalSolicitarServicioExtra" tabindex="-1" role="dialog" aria-labelledby="ModalSolicitarServicioExtra" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV4">Servicios Extras</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <asp:GridView ID="GridListarServiciosExtra" DataKeyNames="idServicio" runat="server" PageSize="5" class="table table-bordered" AutoGenerateColumns="false" OnRowDeleting="GridListarServiciosExtra_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="idServicio" HeaderText="ID" SortExpression="idServicio"></asp:BoundField>
                            <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                            <asp:BoundField DataField="valor_servicio" HeaderText="Valor" SortExpression="valor_servicio"></asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="Descipcion" SortExpression="descripcion"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Agregar" ControlStyle-CssClass="btn btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <!--Modal para escoger el Arriendo a cargar servicio-->
    <div class="modal fade" id="ModalEscogerArriendo" tabindex="-1" role="dialog" aria-labelledby="ModalEscogerArriendo" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV5">Arriendo a cargar servicio</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Arriendos asociados</label>
                    <asp:DropDownList ID="dl_arriendosAsociados" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_asignar" CssClass="btn btn-primary" OnClick="Click_asignarServicioArriendo" runat="server" Text="Agregar" />
                </div>

            </div>
        </div>
    </div>

    <script>
        function openModalAsignarArriendo() {
            $('#ModalEscogerArriendo').modal('show');
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

