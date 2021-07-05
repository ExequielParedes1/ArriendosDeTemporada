<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMConductoresVehiculos.aspx.cs" Inherits="WEBArriendoTemporada.ADMConductoresVehiculos" %>

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
    <link rel="stylesheet" type="text/css" href="assets/css/Modal.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Administrar Conductores y Vehiculos</label>
            </strong>
        </div>
    </div>

    <br />

    <div class="row">
        <section id="caracteristicas" class="col-lg-6">
            <div class="container-fluid">
                <a href="#" data-target="#ModalAgregarVehiculo" data-toggle="modal" class="btn btn-primary btn-icon-split">
                    <span class="text">Agregar Vehiculo</span>
                </a>
            </div>

            <br />

            <div class="accordion  accordion-toggle-arrow" id="accordionExample4">
                <div class="container-fluid">
                    <h1 class="h3 mb-2 text-gray-800"></h1>
                    <!-- DataTales Example -->
                    <div class="card">
                        <div class="table100 ver2 m-b-110">
                            <div class="table100-head">
                                <table>
                                    <thead>
                                        <tr class="row100 head">
                                            <th class="cell100 column1" style="width: 0% !important;">Patente</th>
                                            <th class="cell100 column2">Modelo</th>
                                            <th class="cell100 column3" style="width: 0% !important;">Año</th>
                                            <th class="cell100 column4">Color</th>
                                            <th class="cell100 column4">Opcion1</th>
                                            <th class="cell100 column4">Opcion2</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                            <div class="table100-body js-pscroll">
                                <table>
                                    <tbody>
                                        <tr class="row100 body">
                                            <td class="cell100 column1">
                                                <asp:GridView ID="GridListarVehiculo" PageSize="4" runat="server" 
                                                    AutoGenerateColumns="False" DataKeyNames="patente" 
                                                    AllowPaging="True" BorderWidth="0"
                                                    OnRowDeleting="GridListarVehiculo_RowDeleting" 
                                                    OnSelectedIndexChanging="GridListarVehiculo_SelectedIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="patente" ControlStyle-CssClass="cell100 column1" SortExpression="patente"></asp:BoundField>
                                                        <asp:BoundField DataField="modelo" ControlStyle-CssClass="cell100 column1" SortExpression="modelo"></asp:BoundField>
                                                        <asp:BoundField DataField="año" ControlStyle-CssClass="cell100 column1" SortExpression="año"></asp:BoundField>
                                                        <asp:BoundField DataField="color" ControlStyle-CssClass="cell100 column1" SortExpression="color"></asp:BoundField>
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" ShowSelectButton="true" SelectText="Editar" />
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="true" DeleteText="Desactivar" />
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
        </section>

        <section id="inventario" class="col-lg-6">
            <div class="container-fluid">
                <a href="#" data-target="#ModalAgregarConductor" data-toggle="modal" class="btn btn-primary btn-icon-split">
                    <span class="text">Agregar Conductor</span>
                </a>
            </div>

            <br />

            <div class="accordion  accordion-toggle-arrow" id="accordionExample6">
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800"></h1>
                    <!-- DataTales Example -->
                    <div class="card">
                        <div class="table100 ver2 m-b-110">
                            <div class="table100-head">
                                <table>
                                    <thead>
                                        <tr class="row100 head">
                                            <th class="cell100 column1" style="width: 0% !important;">Rut</th>
                                            <th class="cell100 column2" style="width: 0% !important;">Nombre</th>
                                            <th class="cell100 column3" style="width: 0% !important;">apellido</th>
                                            <th class="cell100 column4">email</th>
                                            <th class="cell100 column4">telefono</th>
                                            <th class="cell100 column4">Opcion1</th>
                                            <th class="cell100 column4">Opcion2</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                            <div class="table100-body js-pscroll">
                                <table>
                                    <tbody>
                                        <tr class="row100 body">
                                            <td class="cell100 column1">
                                                <asp:GridView ID="GridConductores" PageSize="4"
                                                    runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="rut" BorderWidth="0"
                                                    AllowPaging="True" OnRowDeleting="GridConductores_RowDeleting"
                                                    OnSelectedIndexChanging="GridConductores_SelectedIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="rut" ControlStyle-CssClass="cell100 column1" SortExpression="rut"></asp:BoundField>
                                                        <asp:BoundField DataField="nombre" ControlStyle-CssClass="cell100 column1" SortExpression="nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="apellido" ControlStyle-CssClass="cell100 column1" SortExpression="apellido"></asp:BoundField>
                                                        <asp:BoundField DataField="email" ControlStyle-CssClass="cell100 column1" SortExpression="Email"></asp:BoundField>
                                                        <asp:BoundField DataField="telefono" ControlStyle-CssClass="cell100 column1" SortExpression="telefono"></asp:BoundField>
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning " ShowSelectButton="true" SelectText="Editar" />
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="true" DeleteText="Desactivar" />
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
        </section>
    </div>


    <!--===============================================================================================-->
    <!-- Modal Agregar Vehiculo -->
    <div class="modal fade" id="ModalAgregarVehiculo" tabindex="-1" role="dialog" aria-labelledby="ModalLabelV" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV2">Agregar Vehículo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Patente</label>
                        <div>
                            <asp:TextBox ID="txtPatente" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Modelo</label>
                        <div>
                            <asp:TextBox ID="txtModelo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Año</label>
                        <div>
                            <asp:TextBox ID="txtAño" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Color</label>
                        <div>
                            <asp:TextBox ID="txtColor" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Estado</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DLEstadoVehiculo" runat="server">
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button1" ValidationGroup="agregarVehiculo" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btn_agregarVehiculo_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Agregar Conductor-->
    <div class="modal fade" id="ModalAgregarConductor" tabindex="-1" role="dialog" aria-labelledby="ModalAgregarConductor" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV3">Agregar Conductor</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Rut</label>
                        <div>
                            <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Apellido</label>
                        <div>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Correo</label>
                        <div>
                            <asp:TextBox ID="txt_correo" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Estado</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DLDisponibleConductor" runat="server">
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <label>Teléfono</label>
                        <div>
                            <asp:TextBox class="form-control form-control-user" onkeypress="return this.value.length<=7" placeholder="Teléfono" ID="txtTelefono" runat="server" TextMode="Number" MaxLength="8"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnAgregarConductor" ValidationGroup="agregarConductor" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btn_agregarConductor_Click" />
                </div>
            </div>
        </div>
    </div>

    <!--Modal Editar Vehiculo-->
    <div class="modal fade" id="ModalEditarVehiculo" tabindex="-1" role="dialog" aria-labelledby="ModalEditarVehiculo" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Editar Vehículo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="btn_editarVehiculo_click">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Patente</label>
                        <div>
                            <asp:TextBox ID="txtPatenteEdit" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Modelo</label>
                        <div>
                            <asp:TextBox ID="txtModeloEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Año</label>
                        <div>
                            <asp:TextBox ID="txtAñoEdit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Color</label>
                        <div>
                            <asp:TextBox ID="txtColorEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <asp:HiddenField runat="server" Value="" ID="hidenCod" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button2" ValidationGroup="editarVehiculo" class="btn btn-warning" runat="server" Text="Editar" OnClick="btn_editarVehiculo_click" />
                </div>
            </div>
        </div>
    </div>

    <!--Modal Editar Conductor-->
    <div class="modal fade" id="ModalEditarConductor" tabindex="-1" role="dialog" aria-labelledby="ModalEditarConductor" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV4">Editar Conductor</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Rut</label>
                        <div>
                            <asp:TextBox ID="txtRutEdit" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombreEdit" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Apellido</label>
                        <div>
                            <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Teléfono</label>
                        <div>
                            <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" onkeypress="return this.value.length<=7" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button4" ValidationGroup="editarConductor" class="btn btn-warning" runat="server" Text="Editar" OnClick="btn_EditarConductor_Click" />
                </div>
            </div>
        </div>
    </div>

    <!--Modal desactivar Vehiculo-->
    <div class="modal fade" id="ModalDesactivarVehiculo" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarVehiculo" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel23">Desactivar Vehículo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar el vehículo patente
                    <asp:Label ID="lblPatente" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="hidenCodDesactivar" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" runat="server" OnClick="btn_desactivar_Click" class="btn btn-danger" Text="Desactivar" />
                </div>
            </div>
        </div>
    </div>

    <!--Modal desactivar Conductor-->
    <div class="modal fade" id="ModalDesactivarConductor" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarConductor" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel4">Desactivar Conductor</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar al conductor 
                    <asp:Label ID="lblConductor" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="HiddenConductor" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button3" runat="server" OnClick="btn_desactivarConductor_Click" class="btn btn-danger" Text="Desactiva" />
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
        function openModalEditar() {
            $('#ModalEditarVehiculo').modal('show');
        }
    </script>
    <script>
        function ModalEditarConductor() {
            $('#ModalEditarConductor').modal('show');
        }
    </script>
    <script>
        function openModalDesactivar() {
            $('#ModalDesactivarVehiculo').modal('show');
        }
    </script>
    <script>
        function openModalDesactivarConductor() {
            $('#ModalDesactivarConductor').modal('show');
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
