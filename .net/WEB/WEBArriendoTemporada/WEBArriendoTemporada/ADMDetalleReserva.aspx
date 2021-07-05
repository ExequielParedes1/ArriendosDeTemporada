<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMDetalleReserva.aspx.cs" Inherits="WEBArriendoTemporada.ADMDetalleReserva" %>

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
                    <span>Usuario</span>
                </label>
            </li>
            <li title="Returns">
                <label for="tab4" role="button">
                    <span>Acompañante</span>
                </label>
            </li>
            <li title="Servicios">
                <label for="tab5" role="button">
                    <span>Servicios</span>
                </label>
            </li>
            <li title="Multas">
                <label for="tab6" role="button">
                    <span>Multa</span>
                </label>
            </li>
            <li title="Funcionario">
                <label for="tab7" role="button">
                    <span>Funcionario</span>
                </label>
            </li>
        </ul>

        <div class="content">
            <section>
                <h2>Reserva</h2>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Valor final</th>
                            <th scope="col">Check in</th>
                            <th scope="col">Check out</th>
                            <th scope="col">Fecha contrato</th>
                            <th scope="col">Metodo pago</th>
                            <th scope="col">Estado pago</th>
                            <th scope="col">Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtID" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorFinal" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcheckIn" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCheckOut" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaContrato" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMetodoPago" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEstadoPago" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </section>

            <section>
                <h2>Delivery Contents</h2>

                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Direccion</th>
                            <th scope="col">Metros Cuadrados</th>
                            <th scope="col">Valor diario</th>
                            <th scope="col">Zona</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtIdDepartamento" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDirecccion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMtrs" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorDiario" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZona" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>

                <div class="row">
                    <asp:Repeater runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <div class="col-sm-3 col-md-3">
                                <div class="container-fluid">
                                    <div class="kt-portlet kt-portlet--tabs">
                                        <div class="zoom">
                                            <img class="zoom" style="width: 250px; height: 250px;" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"_url")) %>" /><br />
                                            <div class="caption">
                                                <h3><%# DataBinder.Eval(Container.DataItem,"_nombre")  %></h3>
                                                <p><%# DataBinder.Eval(Container.DataItem,"_descripcion")  %></p>
                                                <p>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>



            </section>

            <section>
                <h2>Shipping</h2>

                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Correo</th>
                            <th scope="col">Cedula</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Apellido</th>
                            <th scope="col">Telefono</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreousr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRutusr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombreusr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtApellidousr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefonousr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>


            </section>

            <section>
                <h2>Returns</h2>

                <asp:GridView runat="server" ID="gridHuespedes" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="_cedula" HeaderText="Cedula" SortExpression="_cedula"></asp:BoundField>
                        <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                        <asp:BoundField DataField="_apellido" HeaderText="Palma" SortExpression="_apellido"></asp:BoundField>
                        <asp:BoundField DataField="_telefono" HeaderText="Telefono" SortExpression="_telefono"></asp:BoundField>
                    </Columns>
                </asp:GridView>


            </section>
            <section>
                <h2>Servicios</h2>



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
                <h2>Funcionario</h2>

                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Correo</th>
                            <th scope="col">Cedula</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Apellido</th>
                            <th scope="col">Telefono</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoFun" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRutFun" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombreFun" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtApellidoFun" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefonoFun" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </section>
        </div>
    </div>
    
    <!-- Modal Multas nose que -->
    <div class="modal fade" id="modMultar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Multar</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Nombre multa</label>
                        <div>
                            <asp:TextBox ID="txtNombreMulta" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Descripcion</label>
                        <div>
                            <asp:TextBox ID="txtDescripcionMulta" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Valor</label>
                        <div>
                            <asp:TextBox ID="txtValorMulta" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnEditar" OnClick="clic_multar" class="btn btn-primary" runat="server" Text="Multar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
