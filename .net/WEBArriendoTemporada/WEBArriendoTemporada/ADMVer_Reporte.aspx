<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADMVer_Reporte.aspx.cs" Inherits="WEBArriendoTemporada.WEBVer_Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reporte de reservas</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button runat="server" CssClass="btn btn-info" OnClick="volverReporte" Text="Volver" />
                <asp:Button runat="server" CssClass="btn btn-danger" Text="Descargar" OnClick="Unnamed2_Click" />
            </div>

            <asp:Panel runat="server" ID="DescargarPDF">
                <div class="container">
                    <br />
                    <br />
                    <div>
                        <p class="text-center">
                            <h1>Reportes de reservas por zona</h1>
                            <h3>
                                <asp:Label runat="server" ID="tiempoArriendo" Text="Total"></asp:Label>
                            </h3>
                        </p>
                    </div>
                    <br />
                    <h3>Zonas con mas arriendos</h3>
                    <br />
                    <p>
                        <asp:Label runat="server" ID="primeraZonaArriendo"></asp:Label>
                        <asp:Label runat="server" ID="cantidadPrimeraZona"></asp:Label>
                    </p>
                    <br />
                    <p>
                        <asp:Label runat="server" ID="segundaZonaArriendo"></asp:Label>
                        <asp:Label runat="server" ID="cantidadSegundaZona"></asp:Label>
                    </p>
                    <br />
                    <p>
                        <asp:Label runat="server" ID="terceraZonaArriendo"></asp:Label>
                        <asp:Label runat="server" ID="cantidadTerceraZona"></asp:Label>
                    </p>
                    <br />
                    <p>
                        <asp:Label runat="server" ID="cuartaZonaArriendo"></asp:Label>
                        <asp:Label runat="server" ID="cantidadCuartaZona"></asp:Label>
                    </p>
                    <br />
                    <h2>Departamentos y sus zonas</h2>
                    <br />
                    <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="idDepartamento" HeaderText="#" SortExpression="idDepartamento"></asp:BoundField>
                            <asp:BoundField DataField="_Direccion" HeaderText="Direccion" SortExpression="_Direccion"></asp:BoundField>
                            <asp:BoundField DataField="_Zona" HeaderText="Zona" SortExpression="_Zona"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
