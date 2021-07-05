<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBGaleriaDepartamento.aspx.cs" Inherits="WEBArriendoTemporada.WEBGaleriaDepartamento" %>

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
    <br />
    <div class="container">
        <div class="notice notice-success">
            <strong>
                <label>Subir imagenes depto</label>
            </strong>
        </div>
    </div>
    <br />
    <a href="ADMDepartamento.aspx" class="btn btn-primary">Volver a detalle departamento</a>
    <label>   </label>
    <a href="#" data-target="#ModalImagen" data-toggle="modal" class="btn btn-primary btn-icon-split">Agregar imagen</a>
    <br />
    <br />

    <div class="accordion  accordion-toggle-arrow" id="accordionExample4">
        <div class="row">
            <asp:Repeater runat="server" ID="Repeater1">
                <ItemTemplate>
                    <div class="col-sm-3 col-md-3">
                        <div class="container-fluid shadow">
                            <div class="kt-portlet kt-portlet--tabs">
                                <div class="zoom">
                                    <img class="zoom" style="width: 250px; height: 250px;" src="data:image/jpg;base64,
                                        <%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"_url")) %>" /><br />
                                    <div class="caption">
                                        <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("id_foto") %>' Visible="false" />
                                        <h3><%# DataBinder.Eval(Container.DataItem,"_nombre")  %></h3>
                                        <p><%# DataBinder.Eval(Container.DataItem,"_descripcion")  %></p>
                                        <p>
                                            <asp:LinkButton ID="lnkDelete" CssClass="btn btn-danger" Text="Eliminar" runat="server" OnClick="clic_eliminar_imagen" OnClientClick="return confirm('Esta seguro que desea eliminar?');" />
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

    <script>

    </script>

    <!-- Modal Agregar Imagen -->
    <div class="modal fade" id="ModalImagen" tabindex="-1" role="dialog" aria-labelledby="ModalImagen" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel" style="text-align:center">Agregar nueva imagen</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre departamento ..." runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Descripcion</label>
                        <div>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeholder="Descripcion ..." runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label>Imagen</label>
                        <div>
                            <asp:FileUpload runat="server" ID="uploadImagen" />
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                    <asp:Button runat="server" OnClick="subirImagenClic" Text="Agregar" class="btn btn-primary" />
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
