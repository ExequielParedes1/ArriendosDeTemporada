<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMCaracteristicaInventario.aspx.cs" Inherits="WEBArriendoTemporada.ADMCaracteristicaInventario" %>

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
    <link rel="stylesheet" type="text/css" href="assets/css/Modal.css"  />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Administrar Caracteristica y Inventario</label>
            </strong>
        </div>
    </div>

    <br />

    <div class="row">
        <section id="caracteristicas" class="col-lg-6">
            <div class="container-fluid">
                <a href="#modal3" class="btn btn-primary btn-icon-split">Agregar Caracteristicas</a>
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
                                            <th class="cell100 column1" style="width: 10% !important;">ID</th>
                                            <th class="cell100 column2">Nombre</th>
                                            <th class="cell100 column3" style="width: 50% !important;">Descripcion</th>
                                            <th class="cell100 column4">Opcion</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                            <div class="table100-body js-pscroll">
                                <table>
                                    <tbody>
                                        <tr class="row100 body">
                                            <td class="cell100 column1">
                                                <asp:GridView ID="GridTodosLosServicios" PageSize="5" runat="server"
                                                    AutoGenerateColumns="false" DataKeyNames="idCaracteristica"
                                                    AllowPaging="True" BorderWidth="0"
                                                    OnSelectedIndexChanging="GridTodosLosServicios_SelectedIndexChanging"
                                                    OnPageIndexChanging="GridTodosLosServicios_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="idCaracteristica" ControlStyle-CssClass="cell100 column1" SortExpression="idCaracteristica"></asp:BoundField>
                                                        <asp:BoundField DataField="nombre" ControlStyle-CssClass="cell100 column1" SortExpression="nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="descripcion" ControlStyle-CssClass="cell100 column1" SortExpression="descripcion"></asp:BoundField>
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="true" SelectText="Eliminar" />
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
                <a href="#modal4" class="btn btn-primary btn-icon-split">Agregar Inventario</a>
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
                                            <th class="cell100 column1" style="width: 15% !important;">ID</th>
                                            <th class="cell100 column2" style="width: 35% !important;">Nombre</th>
                                            <th class="cell100 column3" style="width: 24% !important;">Valor</th>
                                            <th class="cell100 column4">Opcion</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                            <div class="table100-body js-pscroll">
                                <table>
                                    <tbody>
                                        <tr class="row100 body">
                                            <td class="cell100 column1">
                                                <asp:GridView ID="GridInventario" PageSize="5" runat="server"
                                                    AutoGenerateColumns="false" DataKeyNames="id_item"
                                                    AllowPaging="True" BorderWidth="0"
                                                    OnSelectedIndexChanging="GridInventario_SelectedIndexChanging"
                                                    OnPageIndexChanging="GridInventario_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="id_item" ControlStyle-CssClass="cell100 column1" SortExpression="id_item"></asp:BoundField>
                                                        <asp:BoundField DataField="_nombre" ControlStyle-CssClass="cell100 column1" SortExpression="_nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="_valor" ControlStyle-CssClass="cell100 column1" SortExpression="_valor"></asp:BoundField>
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="true" SelectText="Eliminar" />
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
    <!-- Modal Crear caracteristica-->
    <div id="modal3" class="modalmask">
        <div class="modalbox resize">
            <a href="#close" title="Close" class="close">X</a>
            <h3>Agregar Caracteristica</h3>
            <hr />
            <div>
                <div>
                    <label>Nombre</label>
                    <div>
                        <asp:TextBox ID="txtNombreCarac" CssClass="form-control" placeholder="Nombre ..." runat="server" />
                    </div>
                </div>
                <br />
                <div>
                    <label>Descripción</label>
                    <div>
                        <asp:TextBox ID="txtDescripcionCarac" CssClass="form-control" placeholder="Descripcion ..." runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div>
                    <div>
                        <asp:Button runat="server" OnClick="clic_crear_caract" Text="Aceptar" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Crear Inventario-->
    <div id="modal4" class="modalmask">
        <div class="modalbox resize">
            <a href="#close" title="Close" class="close">X</a>
            <h3>Agregar Inventario</h3>
            <hr />
            <div>
                <div>
                    <label>Nombre</label>
                    <div>
                        <asp:TextBox ID="txtNombreItem" CssClass="form-control !important" placeholder="Nombre ..." runat="server"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div>
                    <label>Precio Unitario</label>
                    <div>
                        <asp:TextBox ID="txtValorItem" CssClass="form-control" placeholder="$0000000" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div>
                    <div>
                        <asp:Button runat="server" OnClick="clic_crear_item" Text="Aceptar" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Crear Inventario-->
    <div class="modal fade" id="ModalDesactivarCaracteristica" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarCaracteristica" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel4">Eliminar Característica</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea eliminar la característica 
                    <asp:Label ID="lblcaracteristica" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="HidenCaracte" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button3" runat="server" OnClick="btn_desactivarCara_clic" class="btn btn-danger" Text="Desactiva" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalEliminarItem" tabindex="-1" role="dialog" aria-labelledby="ModalEliminarItem" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Eliminar Item</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea eliminar el item 
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="HiddItem" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button1" runat="server" OnClick="btn_eliminarItem" class="btn btn-danger" Text="Desactiva" />
                </div>
            </div>
        </div>
    </div>

    <script>
        function openModalDesactivar() {
            $('#ModalDesactivarCaracteristica').modal('show');
        }
    </script>
    <script>
        function openModalEliminarItem() {
            $('#ModalEliminarItem').modal('show');
        }
    </script>
    <script>
        function ModalInventario() {
            $('#ModalCrearInventario').modal('show');
        }
    </script>

    <!--Validar campos-->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />

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
