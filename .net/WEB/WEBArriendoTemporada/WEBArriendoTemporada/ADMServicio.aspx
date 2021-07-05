<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMServicio.aspx.cs" Inherits="WEBArriendoTemporada.ADMServicio" %>

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
                <label>Administrar Servicios</label>
            </strong>
        </div>
    </div>
    <br />
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap DatePicker -->

    <div class="container-fluid">
        <a href="#" data-target="#ModalAgregarViaje" data-toggle="modal" class="btn btn-primary btn-icon-split">
            <span class="text">Agregar Servicio</span>
        </a>
    </div>

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
                                        <asp:GridView ID="GridView1" PageSize="4" EnableEventValidation="false" runat="server" AutoGenerateColumns="False" DataKeyNames="idServicio" AllowPaging="True" OnRowDeleting="rowDeletingEvent" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="idServicio" HeaderText="ID" ReadOnly="True" SortExpression="idServicio"></asp:BoundField>
                                                <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                                                <asp:BoundField DataField="valor_servicio" HeaderText="Costo" SortExpression="valor_servicio"></asp:BoundField>

                                                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion"></asp:BoundField>


                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" ShowSelectButton="true" SelectText="Editar" />
                                                <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Desactivar" ControlStyle-CssClass="btn btn-danger" />
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


    <!--Modal agregar viaje-->
    <div class="modal fade" id="ModalAgregarViaje" tabindex="-1" role="dialog" aria-labelledby="ModalLabelV" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV4">Crear Servicio</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label col-sm-2">Nombre</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txt_nombreServicio" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2">Costo</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txt_costo" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="pwd">Estado</label>
                        <div class="col-sm-10">
                            <asp:DropDownList CssClass="form-control" ID="Dl_estado" runat="server">
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="2">Inactivo</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2">Detalle</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txt_detalle" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnAgregarServicio" CssClass="btn btn-primary" runat="server" Text="Agregar Servicio" OnClick="btn_agregarServicio_Click" />

                </div>
            </div>
        </div>
    </div>

    <!--Administrar Viaje-->


    <!-- Modal Eliminar Servicio-->
    <div class="modal fade" id="ModalEliminarA" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Eliminar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Esta seguro que desea eliminar el servicio
                        <asp:Label ID="lblNombreEliminar" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="hidenCod" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" runat="server" OnClick="btn_Eliminar_Click" class="btn btn-danger" Text="Desactivar" />
                </div>
            </div>
        </div>
    </div>

    <!--Modal agregar viaje-->
    <div class="modal fade" id="ModalEditarServicio" tabindex="-1" role="dialog" aria-labelledby="ModalEditarServicio" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV5">Editar Servicio</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label col-sm-2">Nombre</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtNomEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2">Costo</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCostoEdit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2">Detalle</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtDetalleEdit" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="modal-footer">
                    <asp:HiddenField runat="server" ID="idService" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="Editar Servicio" OnClick="btn_editarServicio_Click" />

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
        function openModalSeleccionarViaje() {
            $('#ModalSeleccionarViaje').modal('show');
        }
    </script>
    <script>
        function openModalEditar() {
            $('#ModalEditarServicio').modal('show');
        }
    </script>
    <script>
        function openModalEliminar() {
            $('#ModalEliminarA').modal('show');
        }
    </script>
    <script>
        function openModalEliminarTour() {
            $('#ModalEliminarTour').modal('show');
        }
    </script>

    <script>
        function openModallsitarViaje() {
            $('#ModalAdminiViaje').modal('show');
        }
    </script>
</asp:Content>
