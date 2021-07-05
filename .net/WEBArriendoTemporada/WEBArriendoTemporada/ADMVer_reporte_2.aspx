<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADMVer_reporte_2.aspx.cs" Inherits="WEBArriendoTemporada.ADMVer_reporte_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" CssClass="btn btn-info" OnClick="volverReporte" Text="Volver" />
            <asp:Button runat="server" CssClass="btn btn-danger" Text="Descargar" OnClick="Unnamed2_Click" />

            <asp:Panel runat="server" ID="DescargarPDF">
                <div class="container">


                    <br />
                    <br />


                    <div>
                        <p class="text-center">
                            <h1>Ganancias Mensuales
                                <asp:Label runat="server" ID="lblAño"></asp:Label></h1>
                        </p>
                    </div>


                    <br />
                    <h3>Ganancias por mes</h3>
                    <br />
                    <p>
                        <asp:Label runat="server" ID="primeraZonaArriendo"></asp:Label><asp:Label runat="server" ID="cantidadPrimeraZona"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="segundaZonaArriendo"></asp:Label><asp:Label runat="server" ID="cantidadSegundaZona"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="terceraZonaArriendo"></asp:Label><asp:Label runat="server" ID="cantidadTerceraZona"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label1"></asp:Label><asp:Label runat="server" ID="Label2"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label3"></asp:Label><asp:Label runat="server" ID="Label4"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label5"></asp:Label><asp:Label runat="server" ID="Label6"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label7"></asp:Label><asp:Label runat="server" ID="Label8"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label9"></asp:Label><asp:Label runat="server" ID="Label10"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label11"></asp:Label><asp:Label runat="server" ID="Label12"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label13"></asp:Label><asp:Label runat="server" ID="Label14"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label15"></asp:Label><asp:Label runat="server" ID="Label16"></asp:Label>
                    </p>

                    <p>
                        <asp:Label runat="server" ID="Label17"></asp:Label><asp:Label runat="server" ID="Label18"></asp:Label>
                    </p>


                    <br />

                    <h2>Ganancias por Arriendo</h2>
                    <br />

                    <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="id_reserva" HeaderText="#" SortExpression="id_reserva"></asp:BoundField>
                            <asp:BoundField DataField="_valor_final" HeaderText="Ganancia" SortExpression="_valor_final"></asp:BoundField>
                            <asp:BoundField DataFormatString="{0:dd-MM-yyyy}" DataField="_check_Out" HeaderText="Fecha Finalizacion" SortExpression="_check_Out"></asp:BoundField>
                            <asp:BoundField DataField="_fecha_contrato" HeaderText="Fecha Contrato" SortExpression="_fecha_contrato"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>