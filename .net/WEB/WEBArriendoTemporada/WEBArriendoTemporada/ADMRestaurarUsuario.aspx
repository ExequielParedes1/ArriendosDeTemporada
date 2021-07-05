<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMRestaurarUsuario.aspx.cs" Inherits="WEBArriendoTemporada.ADMRestaurarUsuario" %>

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
                <label>Restaurar Usuarios</label>
            </strong>
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
                                    <th class="cell100 column1">ID</th>
                                    <th class="cell100 column2">Dirección</th>
                                    <th class="cell100 column3">m²</th>
                                    <th class="cell100 column4">Valor<br />
                                        Diario</th>
                                    <th class="cell100 column5">Disp</th>
                                    <th class="cell100 column6">Zona</th>
                                    <th class="cell100 column7">N°<br />
                                        Hab.</th>
                                    <th class="cell100 column8">N°<br />
                                        Baños</th>
                                    <th class="cell100 column9">Ver</th>
                                    <th class="cell100 column10">Desactivar</th>
                                    <th class="cell100 column11"></th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <div class="table100-body js-pscroll">
                        <table>
                            <tbody>
                                <tr class="row100 body">
                                    <td class="cell100 column1">
                                        <asp:GridView ID="GridUsuariosHistoricos" PageSize="5" DataKeyNames="_correo" 
                                            runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnSelectedIndexChanging="rowSelectedIndexChanging" AllowPaging="True" 
                                            OnPageIndexChanging="GridUsuariosHistoricos_PageIndexChanging" 
                                            OnRowDeleting="GridUsuariosHistoricos_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="_correo" HeaderText="Correo" ReadOnly="True" SortExpression="_correo"></asp:BoundField>
                                                <asp:BoundField DataField="_cedula" HeaderText="Rut" ReadOnly="True" SortExpression="_cedula"></asp:BoundField>
                                                <asp:BoundField DataField="_nombre" HeaderText="Nombre" SortExpression="_nombre"></asp:BoundField>
                                                <asp:BoundField DataField="_apellido" HeaderText="Apellido" SortExpression="_apellido"></asp:BoundField>
                                                <asp:BoundField DataField="_numeroContacto" HeaderText="Numero de contacto" SortExpression="_numeroContacto"></asp:BoundField>
                                                <asp:BoundField DataField="_contraseña" HeaderText="Contrase&#241;a" SortExpression="_contraseña"></asp:BoundField>
                                                <asp:BoundField DataField="_tipo" HeaderText="Tipo" SortExpression="_tipo"></asp:BoundField>
                                                <asp:BoundField DataField="_estado" HeaderText="Estado" SortExpression="_estado"></asp:BoundField>
                                                <asp:CommandField ButtonType="Button" HeaderText="Opciones" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Recuperar" />

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

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('#<%=GridUsuariosHistoricos.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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
        function openModalLog() {
            $('#ModalLog').modal('show');
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
