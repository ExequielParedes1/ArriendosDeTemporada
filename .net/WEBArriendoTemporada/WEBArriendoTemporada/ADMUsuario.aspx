<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMUsuario.aspx.cs" Inherits="WEBArriendoTemporada.ADMUsuario" %>

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
                <label>Administrar Usuarios</label>
            </strong>
        </div>
    </div>
    <br />
    <div class="container-fluid">
        <a href="#" data-target="#modarAgregarUsr" data-toggle="modal" class="btn btn-primary btn-icon-split">
            <span class="text">Agregar Usuario</span>
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
                                    <th class="cell100 column1">Correo</th>
                                    <th class="cell100 column2">Nombre</th>
                                    <th class="cell100 column3">Apellidos</th>
                                    <th class="cell100 column4">Valor</th>
                                    <th class="cell100 column5">Rut</th>
                                    <th class="cell100 column6">Telefono</th>
                                    <th class="cell100 column7">Tipo</th>
                                    <th class="cell100 column8">Estado</th>
                                    <th class="cell100 column9">Editar</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView DataKeyNames="_correo" AllowPaging="true" AutoGenerateColumns="false"
                                            ID="kt_table_1" BorderWidth="0" runat="server"
                                            OnRowDeleting="dataTable_RowDeleting"
                                            OnSelectedIndexChanging="dataTable_SelectedIndexChanging"
                                            OnPageIndexChanging="dataTable_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="_correo" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="_correo"></asp:BoundField>
                                                <asp:BoundField DataField="_nombre" ControlStyle-CssClass="cell100 column2" SortExpression="_nombre"></asp:BoundField>
                                                <asp:BoundField DataField="_apellido" ControlStyle-CssClass="cell100 column3" SortExpression="_apellido"></asp:BoundField>
                                                <asp:BoundField DataField="_cedula" ControlStyle-CssClass="cell100 column4" ReadOnly="True" SortExpression="_rut"></asp:BoundField>
                                                <asp:BoundField DataField="_numeroContacto" ControlStyle-CssClass="cell100 column5" SortExpression="_numeroContacto"></asp:BoundField>
                                                <asp:BoundField DataField="_tipo" ControlStyle-CssClass="cell100 column6" SortExpression="_tipo"></asp:BoundField>
                                                <asp:BoundField DataField="_estado" ControlStyle-CssClass="cell100 column7" SortExpression="_estado"></asp:BoundField>
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


    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1" style="width: 200px">Correo</th>
                                    <th class="cell100 column2" style="width: 180px">Nombre</th>
                                    <th class="cell100 column3" style="width: 50px">Apellidos</th>
                                    <th class="cell100 column4" style="width: 210px">Rut</th>
                                    <th class="cell100 column5" style="width: 100px">Telefono</th>
                                    <th class="cell100 column6" style="width: 200px">Tipo</th>
                                    <th class="cell100 column7" style="width: 100px">Estado</th>
                                    <th class="cell100 column8" style="width: 200px">Opcion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridPendientes" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="_correo" AllowPaging="True" BorderWidth="0"
                                            OnPageIndexChanging="GridPendientes_PageIndexChanging"
                                            OnRowDeleting="GridPendientes_RowDeleting"
                                            OnSelectedIndexChanging="GridPendientes_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="_correo" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="_correo"></asp:BoundField>
                                                <asp:BoundField DataField="_nombre" ControlStyle-CssClass="cell100 column2" SortExpression="_nombre"></asp:BoundField>
                                                <asp:BoundField DataField="_apellido" ControlStyle-CssClass="cell100 column3" SortExpression="_apellido"></asp:BoundField>
                                                <asp:BoundField DataField="_cedula" ControlStyle-CssClass="cell100 column4" ReadOnly="True" SortExpression="_rut"></asp:BoundField>
                                                <asp:BoundField DataField="_numeroContacto" ControlStyle-CssClass="cell100 column5" SortExpression="_numeroContacto"></asp:BoundField>
                                                <asp:BoundField DataField="_tipo" ControlStyle-CssClass="cell100 column6" SortExpression="_tipo"></asp:BoundField>
                                                <asp:BoundField DataField="_estado" ControlStyle-CssClass="cell100 column7" SortExpression="_estado"></asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" SelectText="Aprobar"></asp:CommandField>
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



    <!-- Agregar Usuario-->
    <div class="modal fade" id="modarAgregarUsr" tabindex="-1" role="dialog" aria-labelledby="modarAgregarUsr" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar nuevo usuario</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>RUT</label>
                        <div>
                            <asp:TextBox ID="txtRut" CssClass="form-control" runat="server" oninput="checkRut(this)"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txt_nombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Apellido(s)</label>
                        <div>
                            <asp:TextBox ID="txt_apellidoUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Numero contacto</label>
                        <div>
                            <asp:TextBox ID="txt_numeroContactoUsuario" onkeypress="return this.value.length<=7" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Correo</label>
                        <div>
                            <asp:TextBox ID="txt_correoUsuario" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Contraseña</label>
                        <div>
                            <asp:TextBox ID="txt_contraseñaUsuario" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Repetir Contraseña</label>
                        <div>
                            <asp:TextBox ID="txt_repetir_contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Tipo</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="Dl_tipoUsuario" runat="server">
                                <asp:ListItem>cliente</asp:ListItem>
                                <asp:ListItem>funcionario</asp:ListItem>
                                <asp:ListItem>admin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                    <asp:Button ValidationGroup="agregarUsuario" ID="btnAgregarUsuario" OnClick="agregarUsuario_Click" runat="server" Text="Agregar" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>



    <!-- Editar Usuario-->




    <div class="modal fade" id="modalEditar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Editar Usuario</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Cedula</label>
                        <div>
                            <asp:TextBox ID="txtRutEdit" CssClass="form-control" runat="server" oninput="checkRut(this)"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombreEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Apellido(s)</label>
                        <div>
                            <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Numero contacto</label>
                        <div>
                            <asp:TextBox ID="txtTelefonoEdit" MaxLength="8" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Correo</label>
                        <div>
                            <asp:TextBox ID="txtCorreoEdit" CssClass="form-control" ReadOnly="true" runat="server" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Contraseña</label>
                        <div>
                            <asp:TextBox ID="txtPassEdit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Tipo</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="DLTipoEdit" runat="server">
                                <asp:ListItem>cliente</asp:ListItem>
                                <asp:ListItem>funcionario</asp:ListItem>
                                <asp:ListItem>admin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnEditar" ValidationGroup="editarUsuario" class="btn btn-warning" runat="server" OnClick="btnEditClick" Text="Editar" />
                </div>
            </div>
        </div>
    </div>

    <!-- Desactivar Usuario-->
        <!-- Modal -->
    <div class="modal fade" id="ModalDesactivarUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel23">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="ModalDesactivarUsuarioE" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarDepartamento" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel23E">Desactivar Usuario</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar a
                    <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>?
                        <asp:HiddenField runat="server" Value="" ID="hidenCodDesactivar" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" runat="server" OnClick="btn_desactivar_Click" class="btn btn-danger" Text="Desactivar" />
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
            $('#modalEditar').modal('show');
        }
    </script>

    <script>
        function openModalDesactivar() {
            $('#ModalDesactivarUsuario').modal('show');
        }
    </script>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('#<%=kt_table_1.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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
        function checkRut(rut) {
            // Despejar Puntos
            var valor = rut.value.replace('.', '');
            // Despejar Guión
            valor = valor.replace('-', '');

            // Aislar Cuerpo y Dígito Verificador
            cuerpo = valor.slice(0, -1);
            dv = valor.slice(-1).toUpperCase();

            // Formatear RUN
            rut.value = cuerpo + '-' + dv

            // Si no cumple con el mínimo ej. (n.nnn.nnn)
            if (cuerpo.length < 7) { rut.setCustomValidity("RUT Incompleto"); return false; }

            // Calcular Dígito Verificador
            suma = 0;
            multiplo = 2;

            // Para cada dígito del Cuerpo
            for (i = 1; i <= cuerpo.length; i++) {

                // Obtener su Producto con el Múltiplo Correspondiente
                index = multiplo * valor.charAt(cuerpo.length - i);

                // Sumar al Contador General
                suma = suma + index;

                // Consolidar Múltiplo dentro del rango [2,7]
                if (multiplo < 7) { multiplo = multiplo + 1; } else { multiplo = 2; }

            }

            // Calcular Dígito Verificador en base al Módulo 11
            dvEsperado = 11 - (suma % 11);

            // Casos Especiales (0 y K)
            dv = (dv == 'K') ? 10 : dv;
            dv = (dv == 0) ? 11 : dv;

            // Validar que el Cuerpo coincide con su Dígito Verificador
            if (dvEsperado != dv) { rut.setCustomValidity("RUT Inválido"); return false; }

            // Si todo sale bien, eliminar errores (decretar que es válido)
            rut.setCustomValidity('');
        }
    </script>

</asp:Content>

