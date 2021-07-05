<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMDepartamento.aspx.cs" Inherits="WEBArriendoTemporada.ADMDepartamento" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Detalle del departamento</label>
            </strong>
        </div>
    </div>
    <br />
    <a href="WEBDepartamento.aspx" class="btn btn-primary">Volver a departamento </a>
    <br />
    <br />
    <div class="tabs">
        <input type="radio" id="tab1" name="tab-control" checked>
        <input type="radio" id="tab2" name="tab-control">
        <input type="radio" id="tab3" name="tab-control">
        <input type="radio" id="tab4" name="tab-control">
        <ul>
            <li title="Features">
                <label for="tab1" role="button">
                    <span>Departamento</span>
                </label>
            </li>
            <li title="Delivery Contents">
                <label for="tab2" role="button">
                    <span>Mantencion</span>
                </label>
            </li>
            <li title="Shipping">
                <label for="tab3" role="button">
                    <span>Caracteristica</span>
                </label>
            </li>
            <li title="Returns">
                <label for="tab4" role="button">
                    <span>Inventario</span>
                </label>
            </li>
        </ul>

        <div class="content">
            <section>
                <h2>Reserva</h2>

                <div>
                    <asp:Button Text="Galeria" runat="server" CssClass="btn btn-primary" OnClick="clic_galeria" />
                </div>
                <br />
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Dirección</th>
                                <th scope="col">Metros Cuadrados</th>
                                <th scope="col">Valor diario</th>
                                <th scope="col">Zona</th>
                                <th scope="col">Opciones</th>
                                <th scope="col">Opciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtID" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDirecccion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtMtrs" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtValorDiario" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>

                                <td>
                                    <asp:TextBox ID="txtZona" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>
                                <td>

                                    <div class="container-fluid">
                                        <asp:Button ID="Button1" OnClick="btnEditar_click" runat="server" Text="Editar" class="btn btn-warning" />
                                    </div>
                                </td>
                                <td>
                                    <div class="container-fluid">
                                        <asp:Button ID="Button3" runat="server" Text="Desactivar" class="btn btn-danger" OnClick="clic_desactivar_departamento" />
                                    </div>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>

            </section>

            <section id="Mantencion">
                <h2>Delivery Contents</h2>

                <a href="#" data-target="#ModalMantencion" data-toggle="modal" class="btn btn-primary btn-icon-split">
                    <span class="text">Agregar Mantención</span>
                </a>
                <br />
                <div class="card">

                    <div class="card-body">
                        <div class="kt-portlet kt-portlet--tabs">
                            <div class="kt-portlet__head">

                                <div class="kt-portlet__head-toolbar">
                                    <ul class="nav nav-tabs nav-tabs-bold nav-tabs-line   nav-tabs-line-right nav-tabs-line-brand" role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" data-toggle="tab" href="#kt_portlet_tab_1_5" role="tab">Activas
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" data-toggle="tab" href="#kt_portlet_tab_1_6" role="tab">Inactivas
                                            </a>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="kt_portlet_tab_1_5">
                                        <div class="table-responsive">

                                            <div class="card-body">
                                                <asp:GridView ID="GridMantencionesActivas" runat="server" PageSize="5" class="table table-bordered" AutoGenerateColumns="false" DataKeyNames="id_mantencion" OnSelectedIndexChanging="GridMantenciones_SelectedIndexChanging" OnRowDeleting="GridMantencionesActivas_RowDeleting">
                                                    <Columns>
                                                        <asp:BoundField DataField="id_mantencion" HeaderText="ID" SortExpression="id_mantencion"></asp:BoundField>
                                                        <asp:BoundField DataField="_varlo_total" HeaderText="Valor" SortExpression="_varlo_total"></asp:BoundField>
                                                        <asp:BoundField DataField="_descripcion" HeaderText="Descripción" SortExpression="_descripcion"></asp:BoundField>
                                                        <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_fecha_inicio" HeaderText="Inicio" SortExpression="_fecha_inicio"></asp:BoundField>
                                                        <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_fecha_termino" HeaderText="Término" SortExpression="_fecha_termino"></asp:BoundField>
                                                        <asp:BoundField DataField="_motivo" HeaderText="Motivo" SortExpression="_motivo"></asp:BoundField>
                                                        <asp:BoundField DataField="_tipo_mantencion" HeaderText="Tipo" SortExpression="_tipo_mantencion"></asp:BoundField>
                                                        <asp:BoundField DataField="_encargado_rut" HeaderText="Encargado" SortExpression="_encargado_rut"></asp:BoundField>
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" ShowDeleteButton="true" DeleteText="Editar" />
                                                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Finalizar" />
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="kt_portlet_tab_1_6">
                                        <div class="table-responsive">
                                            <div id="collapseOne4" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample4">
                                                <div class="card-body">
                                                    <asp:GridView ID="GridMantencionesInActivas" runat="server" PageSize="5" class="table table-bordered" AutoGenerateColumns="false" DataKeyNames="id_mantencion" OnSelectedIndexChanging="GridMantenciones_SelectedIndexChanging">
                                                        <Columns>
                                                            <asp:BoundField DataField="id_mantencion" HeaderText="ID" SortExpression="id_mantencion"></asp:BoundField>
                                                            <asp:BoundField DataField="_varlo_total" HeaderText="Valor" SortExpression="_varlo_total"></asp:BoundField>
                                                            <asp:BoundField DataField="_descripcion" HeaderText="Descripción" SortExpression="_descripcion"></asp:BoundField>
                                                            <asp:BoundField DataField="_fecha_inicio" HeaderText="Inicio" SortExpression="_fecha_inicio"></asp:BoundField>
                                                            <asp:BoundField DataField="_fecha_termino" HeaderText="Término" SortExpression="_fecha_termino"></asp:BoundField>
                                                            <asp:BoundField DataField="_motivo" HeaderText="Motivo" SortExpression="_motivo"></asp:BoundField>
                                                            <asp:BoundField DataField="_tipo_mantencion" HeaderText="Tipo" SortExpression="_tipo_mantencion"></asp:BoundField>
                                                            <asp:BoundField DataField="_encargado_rut" HeaderText="Encargado" SortExpression="_encargado_rut"></asp:BoundField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>


            </section>

            <section id="caracteristicas">
                <h2>Shipping</h2>


                <a href="#" data-target="#ModalAddCaract" data-toggle="modal" class="btn btn-primary btn-icon-split">

                    <span class="text">Agregar Caracteristica</span>
                </a>

                <asp:GridView ID="GridCaracteristicas" PageSize="15" class="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="idCaracteristica" AllowPaging="True" OnSelectedIndexChanging="GridCaracteristicas_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="idCaracteristica" HeaderText="ID" SortExpression="idCaracteristica"></asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre"></asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion"></asp:BoundField>
                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="true" SelectText="Cancelar" />
                    </Columns>
                </asp:GridView>


            </section>

            <section id="inventario">
                <h2>Returns</h2>

                <a href="#" data-target="#ModalAddInventario" data-toggle="modal" class="btn btn-primary btn-icon-split">
                    <span class="text">Agregar Inventario</span>
                </a>
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="_id_item_id" PageSize="15" class="table table-bordered" AutoGenerateColumns="false" AllowPaging="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>

                        <asp:BoundField DataField="nombreItem" HeaderText="Item" SortExpression="nombreItem"></asp:BoundField>
                        <asp:BoundField DataField="_valor_total" HeaderText="Valor" SortExpression="_valor_total"></asp:BoundField>
                        <asp:BoundField DataField="_cantidad" HeaderText="Cantidad" SortExpression="_cantidad"></asp:BoundField>
                        <asp:BoundField DataField="fecha_ultima_moficacion" HeaderText="Modificado" SortExpression="fecha_ultima_moficacion"></asp:BoundField>

                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" ShowDeleteButton="true" DeleteText="Editar" />
                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="true" SelectText="Eliminar" />

                    </Columns>
                </asp:GridView>

            </section>
        </div>
    </div>
    <br />
    <br />
    <!--Modal Editar Departamento-->
    <div class="modal fade" id="ModalEditarDepartamento" tabindex="-1" role="dialog" aria-labelledby="ModalEditarDepartamento" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Editar Departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Dirección</label>
                        <div>
                            <asp:TextBox ID="txt_direccionedit" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>MTS Cuadrados</label>
                        <div>
                            <asp:TextBox ID="txt_metrosCedit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Valor Diario</label>
                        <div>
                            <asp:TextBox ID="txt_valorDiariosedit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Zona</label>
                        <div>
                            <asp:TextBox ID="txt_zonaedit" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>N° Habitaciones</label>
                        <div>
                            <asp:TextBox ID="txt_habitacionesedit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>N° Baños</label>
                        <div>
                            <asp:TextBox ID="txt_bañosedit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button ValidationGroup="editarDpto" ID="btn_agregarUsuario" class="btn btn-warning" runat="server" Text="Editar" OnClick="btn_editarrDepartamento_click" />

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Modal Mantencion-->
    <div class="modal fade" id="ModalMantencion" tabindex="-1" role="dialog" aria-labelledby="ModalMantencion" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel22">Mantención departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Valor mantención</label>
                        <div>
                            <asp:TextBox ID="txtValorMantecion" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div>
                        <label>Descripción</label>
                        <div>
                            <asp:TextBox ID="txtDescipcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Fecha Inicio</label>
                        <div>
                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Fecha Termino</label>
                        <div>
                            <asp:TextBox ID="txtFechaTermino" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Motivo Mantención</label>
                        <div>
                            <asp:TextBox ID="txtMotivo" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Tipo Mantención</label>
                        <div>
                            <asp:TextBox ID="txtTipoMantencion" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <div class="container-fluid">
                            <asp:Button runat="server" OnClick="clic_mantencion" Text="Siguiente" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Encargado-->
    <div class="modal fade" id="ModalEncargado" tabindex="-1" role="dialog" aria-labelledby="ModalEncargado" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel21">Encargado de la mantención</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Rut</label>
                        <div class="row">
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtRutEncargado" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="clic_buscarEncargado" />
                            </div>
                        </div>

                    </div>
                    <div>
                        <label>Numero de contacto</label>
                        <div>
                            <asp:TextBox class="form-control form-control-user" onkeypress="return this.value.length<=7" placeholder="Telefono" ID="txtNumeroContactoEncargadoo" runat="server" TextMode="Number" MaxLength="8"></asp:TextBox>
                        </div>

                    </div>
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombreEncargado" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Apellido</label>
                        <div>
                            <asp:TextBox ID="txtApellidoEncargado" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Correo</label>
                        <div>
                            <asp:TextBox ID="txtCorreoEncargado" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>

                        </div>

                    </div>

                    <div class="modal-footer">
                        <asp:Button runat="server" Text="Volver" class="btn btn-primary" OnClick="clic_Volver_mantencion"></asp:Button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Aceptar" OnClick="btn_finalizarMantencion" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Modal para caracteristicas-->
    <div class="modal fade" id="ModalAddCaract" tabindex="-1" role="dialog" aria-labelledby="ModalAddCaract" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel24">Caracteristicas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="GridTodosLosServicios" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="idCaracteristica" AllowPaging="True" OnRowDeleting="GridTodosLosServicios_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="idCaracteristica" HeaderText="ID" SortExpression="idCaracteristica"></asp:BoundField>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre"></asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Agregar" />
                        </Columns>
                    </asp:GridView>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Modal Agregar inventario-->
    <div class="modal fade" id="ModalAddInventario" tabindex="-1" role="dialog" aria-labelledby="ModalAddInventario" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Inventario</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="GrindInventario" PageSize="5" class="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="id_item" AllowPaging="True" OnSelectedIndexChanging="GrindInventario_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="id_item" HeaderText="ID" SortExpression="id_item"></asp:BoundField>
                            <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                            <asp:BoundField DataField="_valor" HeaderText="Valor" SortExpression="_valor"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Agregar" />
                        </Columns>
                    </asp:GridView>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--ModalCantidadInventario-->
    <div class="modal fade" id="ModalCantidadInventario" tabindex="-1" role="dialog" aria-labelledby="ModalCantidadInventario" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel9">Cantidad de elementos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Cantidad de elementos</label>
                        <div>
                            <asp:TextBox ID="txtCantidadInventario" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <asp:HiddenField runat="server" ID="hidencantidad" Value="" />
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <div class="container-fluid">
                            <asp:Button runat="server" OnClick="clic_cantidad_inventario" Text="Aceptar" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--ModalCantidadInventario-->
    <div class="modal fade" id="ModalCantidadInventarioModificar" tabindex="-1" role="dialog" aria-labelledby="ModalCantidadInventarioModificar" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel12">Cantidad de elementos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Cantidad de elementos</label>
                        <div>
                            <asp:TextBox ID="TextBox1" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="modiInventario" runat="server" Value="" />
                    </div>
                    <asp:HiddenField runat="server" ID="HiddenField1" Value="" />
                    <div class="modal-footer center:left">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <div class="container-fluid">
                            <asp:Button runat="server" OnClick="clic_modi_inventario" Text="Modificar" class="btn btn-warning" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Modal Mantencion-->
    <div class="modal fade" id="ModalModificarMantencion" tabindex="-1" role="dialog" aria-labelledby="ModalModificarMantencion" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel0">Modificar mantención departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Valor mantención</label>
                        <div>
                            <asp:TextBox ID="txtModValor" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div>
                        <label>Descripción</label>
                        <div>
                            <asp:TextBox ID="txtModDesc" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Fecha Inicio</label>
                        <div>
                            <asp:TextBox ID="txtModInicio" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

                        </div>
                    </div>
                    <div>
                        <label>Fecha Término</label>
                        <div>
                            <asp:TextBox ID="txtModTermino" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Motivo Mantencion</label>
                        <div>
                            <asp:TextBox ID="txtModMotivo" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </div>

                    </div>
                    <div>
                        <label>Tipo Mantención</label>
                        <div>
                            <asp:TextBox ID="txtmodTipo" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>

                    <asp:HiddenField runat="server" ID="hidenModMantencion" />
                    <div class="modal-footer center:left">

                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <div class="container-fluid">
                            <asp:Button runat="server" OnClick="clic_editar_mantencion" Text="Modificar" class="btn btn-warning" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Modal desactivar departamento-->
    <div class="modal fade" id="ModalDesactivarDepartamento" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarDepartamento" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel23">Desactivar Departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar departamento?
                        <asp:HiddenField runat="server" Value="" ID="hidenCodDesactivar" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" runat="server" OnClick="btn_desactivar_Click" class="btn btn-danger" Text="Desactivar" />
                </div>
            </div>
        </div>
    </div>

    <script>
        function openModalDesactivar() {
            $('#ModalDesactivarDepartamento').modal('show');
        }
    </script>

    <script>
        function openModalAgregarCaracteristica() {
            $('#ModalAddCaract').modal('show');
        }
    </script>

    <script>
        function openModalModificarMantencion() {
            $('#ModalModificarMantencion').modal('show');
        }
    </script>

    <script>
        function openModalEditar() {
            $('#ModalEditarDepartamento').modal('show');
        }
    </script>

    <script>
        function ModarAgregarEncargado() {
            $('#ModalEncargado').modal('show');
        }
    </script>

    <script>
        function ModalCantidadInventario() {
            $('#ModalCantidadInventario').modal('show');
        }
    </script>

    <script>
        function ModalCantidadInventarioModificar() {
            $('#ModalCantidadInventarioModificar').modal('show');
        }
    </script>

    <script>
        function ModalMantencion() {
            $('#ModalMantencion').modal('show');
        }
    </script>

    <!--Validar campos-->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />
</asp:Content>
