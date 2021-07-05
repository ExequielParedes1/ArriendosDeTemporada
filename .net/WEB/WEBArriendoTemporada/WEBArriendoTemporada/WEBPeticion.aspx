<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBPeticion.aspx.cs" Inherits="WEBArriendoTemporada.WEBPeticion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $('#<%=GridDepartamentos.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todo"]],
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


            }

            );

        });
    </script>
    <script>
        function ModalCalendario() {
            $('#ModalCalendario').modal('show');
        }
    </script>
    <script>
        function openModalPagar() {
            $('#ModalPagar').modal('show');
        }
    </script>
    <script>
        function openModalFotosDeptos() {
            $('#kt_modal_4').modal('show');
        }
    </script>

    <style type="text/css">
        .zoom {
            /* Aumentamos la anchura y altura durante 2 segundos */
            transition: width 1s, height 1s, transform 1s;
            -moz-transition: width 1s, height 1s, -moz-transform 1s;
            -webkit-transition: width 2s, height 2s, -webkit-transform 2s;
            -o-transition: width 1s, height 1s,-o-transform 1s;
        }

            .zoom:hover {
                /* tranformamos el elemento al pasar el mouse por encima al doble de
           su tamaño con scale(2). */
                transform: scale(1.05);
                -moz-transform: scale(1.05); /* Firefox */
                -webkit-transform: scale(1.05); /* Chrome - Safari */
                -o-transform: scale(1.05); /* Opera */
            }
    </style>
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
        <div class="kt-container  kt-container--fluid ">
            <div class="kt-subheader__main">
                <h3 class="kt-subheader__title">Reserva </h3>

                <span class="kt-subheader__separator kt-hidden"></span>
                <div class="kt-subheader__breadcrumbs">
                    <a href="Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i
                        class="flaticon2-shelter"></i></a>
                    <span class="kt-subheader__breadcrumbs-separator"></span>
                    <a href="WEBSolicitarServicioExtra.aspx" class="kt-subheader__breadcrumbs-link">Finalizar Reserva </a>


                </div>
            </div>
        </div>
    </div>

    <div class="row container-fluid">
        <div class="col-xl-3 col-md-5 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Cantidad de días</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="LblDias" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-5 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Total a pagar</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">$<asp:Label ID="LblPrecio" runat="server" Text="0"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-5 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Adelanto a pagar</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">$<asp:Label ID="lblAdelanto" runat="server" Text="0"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:LinkButton runat="server" class="col-xl-3 col-md-5 mb-4" data-target="#ModalCarro" data-toggle="modal">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Carro de Arriendos</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                Cantidad:
                                <asp:Label ID="lblCantidadArriendos" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-shopping-cart fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </asp:LinkButton>
    </div>

    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800"></h1>
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">
                    <asp:Label ID="Label1" runat="server" Text="Peticion"></asp:Label></h6>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-2">
                        <div class="form-group">
                            Ubicacion
                       <asp:TextBox ID="txtZona" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="form-group">
                            Check In
                         <asp:TextBox ID="txtDate1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="form-group">
                            Check out
                         <asp:TextBox ID="txtDate2" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="form-group">
                            Habitaciones
                         <asp:TextBox ID="txt_habitaciones" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="form-group">
                            Huespedes
                         <asp:TextBox ID="txt_huespedes" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800"></h1>
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">
                    <asp:Label ID="lblDepartamento" runat="server" Text="Seleccione Departamento"></asp:Label></h6>
            </div>
            <div class="card-body">

                <asp:GridView ID="GridDepartamentos" AllowPaging="true" runat="server" class="table table-bordered" 
                    DataKeyNames="idDepartamento" AutoGenerateColumns="false" 
                    OnRowDeleting="GridDepartamentos_RowDeleting"
                    OnSelectedIndexChanging="GridDepartamentos_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="idDepartamento" HeaderText="ID" SortExpression="idDepartamento"></asp:BoundField>
                        <asp:BoundField DataField="direccion" HeaderText="Dirección" SortExpression="direccion"></asp:BoundField>
                        <asp:BoundField DataField="mtrsCuadrados" HeaderText="m²" SortExpression="metrosCuadrados"></asp:BoundField>
                        <asp:BoundField DataField="valirDiario" HeaderText="Valor Diario" SortExpression="valorArriendoDiario"></asp:BoundField>
                        <asp:BoundField DataField="disponible" HeaderText="Disponible" SortExpression="disponible"></asp:BoundField>
                        <asp:BoundField DataField="zona" HeaderText="Zona" SortExpression="zona"></asp:BoundField>
                        <asp:BoundField DataField="nro_habitaciones" HeaderText="N° de Habitaciones" SortExpression="nroHabitaciones"></asp:BoundField>
                        <asp:BoundField DataField="nro_baños" HeaderText="N° de Baños" SortExpression="nroBanios"></asp:BoundField>
                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-info" ShowSelectButton="true" SelectText="Ver" />
                        <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="true" DeleteText="Agregar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <a href="#" data-target="#ModalPagar" data-toggle="modal" class="btn btn-primary btn-icon-split">
            <span class="icon text-white-50">
                <i class="fas fa-flag"></i>
            </span>
            <span class="text">Reservar</span>
        </a>
    </div>


    <div class="modal fade" id="ModalPagar" tabindex="-1" role="dialog" aria-labelledby="ModalPagar" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: yellow">
                    <h5 class="modal-title" id="exampleModalLabel23"><strong>Pagar</strong></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">

                    <div>
                        <label>Total: </label>
                        <asp:Label runat="server" Text="0" ID="lblDeuda"></asp:Label><br />

                        <label>Pago</label>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pagando" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>

                        </div>
                        <label>Metodo de pago</label>
                        <asp:DropDownList CssClass="form-control" ID="dlTarjeta" runat="server">
                            <asp:ListItem>Visa</asp:ListItem>
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>Cta Rut</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" OnClick="Click_Pagar" runat="server" class="btn btn-primary" Text="Pagar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalCarro" tabindex="-1" role="dialog" aria-labelledby="ModalCarro" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel4">Reservas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <asp:GridView runat="server" ID="GridCarro" AutoGenerateColumns="false" class="table table-bordered" DataKeyNames="idDepartamento" OnRowDeleting="GridCarro_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="idDepartamento" HeaderText="ID" SortExpression="idDepartamento"></asp:BoundField>
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="direccion"></asp:BoundField>
                            <asp:BoundField DataField="valirDiario" HeaderText="Valor Diario" SortExpression="valorArriendoDiario"></asp:BoundField>
                            <asp:BoundField DataField="zona" HeaderText="Zona" SortExpression="zona"></asp:BoundField>
                            <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="true" DeleteText="Cancelar" />
                        </Columns>
                    </asp:GridView>

                    <asp:HiddenField runat="server" Value="" ID="HidenCaracte" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
        </div>
    </div>
    <!--Modal fecha especifica-->
    <div class="modal fade" id="ModalCalendario" tabindex="-1" role="dialog" aria-labelledby="ModalCalendario" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel5">Especifique dias de uso</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <center>
                                Dias disponible
                            </center>
                            <asp:Calendar runat="server" ID="calendarasd"></asp:Calendar>
                        </div>
                        <div class="col-lg-6">
                            <label>Fecha inicio</label>
                            <asp:TextBox runat="server" ID="fechaInicio" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label>Fecha Termino</label>
                            <asp:TextBox runat="server" ID="TextBox1" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button runat="server" Text="Siguiente" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="kt_modal_4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Imagenes departamento</h5>
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
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>

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
</asp:Content>
