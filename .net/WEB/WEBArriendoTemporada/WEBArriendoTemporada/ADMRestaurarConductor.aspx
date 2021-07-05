<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMRestaurarConductor.aspx.cs" Inherits="WEBArriendoTemporada.ADMRestaurarConductor" %>

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
                <label>Restaurar Conductor</label>
            </strong>
        </div>
    </div>
    <br />
    <strong>
        <label>Conductores inactivos</label>
    </strong>
    <div class="limiter">
        <div class="container-table100">
            <div class="wrap-table100">
                <div class="table100 ver2 m-b-60">
                    <div class="table100-head">
                        <table>
                            <thead>
                                <tr class="row100 head">
                                    <th class="cell100 column1" style="width:200px">Rut</th>
                                    <th class="cell100 column2" style="width:200px">Nombre</th>
                                    <th class="cell100 column3">Apellido</th>
                                    <th class="cell100 column4">Email</th>
                                    <th class="cell100 column5">Telefono</th>
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
                                        <asp:GridView ID="GridConductoresInactivos" PageSize="5" DataKeyNames="rut" 
                                            runat="server" AutoGenerateColumns="False" 
                                            AllowPaging="True" BorderWidth="0"
                                            OnSelectedIndexChanging="GridConductoresInactivos_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="rut" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="rut"></asp:BoundField>
                                                <asp:BoundField DataField="nombre" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="nombre"></asp:BoundField>
                                                <asp:BoundField DataField="apellido" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="apellido"></asp:BoundField>
                                                <asp:BoundField DataField="email" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="email"></asp:BoundField>
                                                <asp:BoundField DataField="telefono" ControlStyle-CssClass="cell100 column1" ReadOnly="True" SortExpression="telefono"></asp:BoundField>


                                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Recuperar" />
                                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-info" ShowDeleteButton="true" DeleteText="Logs" Visible="false"/>
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
</asp:Content>

