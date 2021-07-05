<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBDetalleReserva.aspx.cs" Inherits="WEBArriendoTemporada.WEBDetalleReserva" %>

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
                <label>Detalle Reserva</label>
            </strong>
        </div>
    </div>
    <br />
    <a href="WEBsolicitarServicios.aspx" class="btn btn-primary">Volver a Reserva</a>
    <br />
    <br />
    <div class="tabs">
        <input type="radio" id="tab1" name="tab-control" checked>
        <input type="radio" id="tab2" name="tab-control">
        <input type="radio" id="tab3" name="tab-control">
        <input type="radio" id="tab4" name="tab-control">
        <input type="radio" id="tab5" name="tab-control">
        <input type="radio" id="tab6" name="tab-control">
        <input type="radio" id="tab7" name="tab-control">

        <ul>
            <li title="Features">
                <label for="tab1" role="button">
                    <span>Reserva</span>
                </label>
            </li>
            <li title="Delivery Contents">
                <label for="tab2" role="button">
                    <span>Departamento</span>
                </label>
            </li>
            <li title="Shipping">
                <label for="tab3" role="button">
                    <span>Acompañante</span>
                </label>
            </li>
            <li title="Returns">
                <label for="tab4" role="button">
                    <span>Multa</span>
                </label>
            </li>
            <li title="Servicios">
                <label for="tab5" role="button">
                    <span>Servicios</span>
                </label>
            </li>
            <li title="Multas">
                <label for="tab6" role="button">
                    <span>Viajes</span>
                </label>
            </li>
            <li title="Funcionario">
                <label for="tab7" role="button">
                    <span>Servicios Extras</span>
                </label>
            </li>
        </ul>

        <div class="content">
            <section>
                <h2>Reserva</h2>

                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Total</th>
                            <th>Fecha LLegada</th>
                            <th>Fecha Salida</th>
                            <th>Fecha Contrato</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtID" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaLLegada" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaSalida" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaContrato" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>


            </section>

            <section>
                <h2>Departamento</h2>


                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Direccion</th>
                            <th>Mts2</th>
                            <th>Valor Diario</th>
                            <th>Zona</th>
                            <th>Nro Habitaciones</th>
                            <th>Nro Baños</th>
                            <th>Fotos</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtIDDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDireccionDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMtsDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDiarioDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZonaDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroHabitacionesDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroBañosDpto" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <button type="button" class="btn btn-bold btn-label-brand btn-sm" data-toggle="modal" data-target="#kt_modal_4">Ver</button>
                            </td>
                        </tr>
                    </tbody>
                </table>


            </section>

            <section>
                <h2>Acompañante</h2>

                <asp:LinkButton ID="btnAgregarHuesped" runat="server" data-target="#ModarAgregarHuesped" data-toggle="modal" Text="prueba" class="btn btn-primary btn-icon-split">
                   <span class="text">Agregar Acompañante</span>
                </asp:LinkButton>

                <h4>
                    <asp:Label runat="server" ID="maxHuespedes">Numero de acompañantes alcanzado</asp:Label>
                </h4>

                <asp:GridView PageSize="5" DataKeyNames="_cedula" ID="GridView1" runat="server"
                    AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="_cedula" HeaderText="Rut" SortExpression="_cedula"></asp:BoundField>
                        <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                        <asp:BoundField DataField="_apellido" HeaderText="Apellido" SortExpression="_apellido"></asp:BoundField>
                        <asp:BoundField DataField="_telefono" HeaderText="Telefono" SortExpression="_telefono"></asp:BoundField>
                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="true" DeleteText="Desactivar" />
                    </Columns>
                </asp:GridView>

            </section>

            <section>
                <h2>Multa</h2>

                <asp:GridView runat="server" ID="gridMultas" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="idMulta" HeaderText="ID" SortExpression="idMulta"></asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"></asp:BoundField>
                        <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor"></asp:BoundField>
                        <asp:BoundField DataField="Estado_Multa" HeaderText="Estado" SortExpression="Estado_Multa"></asp:BoundField>
                    </Columns>
                </asp:GridView>

            </section>
            <section>
                <h2>Servicios</h2>

                <asp:GridView ID="GridServiciosContratados" DataKeyNames="idServicio" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="idServicio" HeaderText="ID" SortExpression="idServicio"></asp:BoundField>
                        <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                        <asp:BoundField DataField="valor_servicio" HeaderText="Valor" SortExpression="valor_servicio"></asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descipcion" SortExpression="descripcion"></asp:BoundField>
                    </Columns>
                </asp:GridView>

            </section>
            <section>
                <h2>Viajes</h2>

                <asp:GridView ID="GridView2" DataKeyNames="idServicio" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="idServicio" HeaderText="ID" SortExpression="idServicio"></asp:BoundField>
                        <asp:BoundField DataField="nombreServicio" HeaderText="Nombre" SortExpression="nombreServicio"></asp:BoundField>
                        <asp:BoundField DataField="valor_servicio" HeaderText="Valor" SortExpression="valor_servicio"></asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descipcion" SortExpression="descripcion"></asp:BoundField>
                    </Columns>
                </asp:GridView>


            </section>
            <section>
                <h2>Servicios Extras</h2>


            </section>
        </div>
    </div>
    <br />


    <!-- Modal Agregar Acompañante -->
    <div class="modal fade" id="ModarAgregarHuesped" tabindex="-1" role="dialog" aria-labelledby="ModarAgregarHuesped" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLabelV2">Agregar Acompañantes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Rut</label>
                        <div>
                            <div class="row">
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtRut" CssClass="form-control" placeholder="198263451" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button runat="server" CssClass="btn btn-primary" OnClick="clic_buscarCliente" Text="Buscar" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Jose manuel ...." runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Apellido</label>
                        <div>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="jimenez ...." runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Telefono</label>
                        <div>
                            <asp:TextBox ID="txtTelefono" onkeypress="return this.value.length<=7" placeholder="1234567" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="Button1" ValidationGroup="agregarHuesped" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btn_agregarHuesped_click" />
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="kt_modal_4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Imagenes del departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <asp:Repeater runat="server" ID="Repeater1">
                            <ItemTemplate>
                                <div class="col-sm-3 col-md-3">
                                    <div class="container-fluid">
                                        <div class="kt-portlet kt-portlet--tabs">
                                            <div class="zoom">
                                                <img class="zoom" style="width: 150px; height: 150px;" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"_url")) %>" /><br />
                                                <div class="caption">
                                                    <h3><%# DataBinder.Eval(Container.DataItem,"_nombre")  %></h3>
                                                    <p><%# DataBinder.Eval(Container.DataItem,"_descripcion")  %></p>
                                                    <p></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        function openModalAgregarHuesped() {
            $('#ModarAgregarHuesped').modal('show');
        }
    </script>
    <!--Validar campos-->
    <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
    <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />
</asp:Content>
