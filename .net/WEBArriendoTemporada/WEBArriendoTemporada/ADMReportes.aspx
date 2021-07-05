<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ADMReportes.aspx.cs" Inherits="WEBArriendoTemporada.WEBReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        :focus {
            outline: none;
        }

        body {
            background-color: #c8d9e0;
            font-family: sans-serif;
        }

        div + div {
            clear: both;
        }

        p {
            line-height: 1.4em;
            color: #9e9e9e;
        }

        .faq-title {
            font-size: 2em;
            margin: 0.4em 0;
        }

        div.seperator {
            width: 7.5em;
            background-color: #e31b1b;
            height: 0.07em;
            margin-left: -1.8em;
        }

        .faq-list > div {
            border-bottom: 0.07em solid #ededed;
            padding: 1em 0em;
        }

            .faq-list > div:last-child {
                border: initial;
            }

        summary {
            font-size: 1.4em;
            font-weight: bold;
            cursor: pointer;
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            summary:hover {
                color: #e31b1b;
                transition: all 0.3s ease;
            }

        details[open] summary ~ * {
            animation: sweep .5s ease-in-out;
        }

        @keyframes sweep {
            0% {
                opacity: 0;
                margin-left: -10px
            }

            100% {
                opacity: 1;
                margin-left: 55px
            }
        }

        details[open] summary {
            color: #e31b1b;
        }

        details[open] p {
            border-left: 2px solid red;
            margin-left: 55px;
            padding-left: 25px;
            opacity: 100;
            transition: all 3s ease;
        }

        details[open] summary:after {
            content: "-";
            font-size: 3.2em;
            margin: -0.5em 0.14em 0 0;
            font-weight: 200;
        }

        .faq-body {
            width: 70em;
            margin: 4em auto;
            box-shadow: 0px 0px 16px #5b5b5b;
            border-radius: 0.2em;
            padding: 5em;
            background-color: #fff;
        }

        .faq-list {
            width: 55em;
            margin: 1em auto;
            padding: 2em 0;
        }

        summary::-webkit-details-marker {
            display: none;
        }

        summary:after {
            background: transparent;
            border-radius: 0.3em;
            content: "+";
            color: #e31b1b;
            float: left;
            font-size: 1.8em;
            font-weight: bold;
            margin: -0.3em 0.25em 0 0;
            padding: 0;
            text-align: center;
            width: 25px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="faq" class="faq-body">
        <div class="faq-header">
            <h3 class="faq-title">Reportes Generales</h3>
            <div class="seperator"></div>
            <div class="faq-list">
                <div>
                    <details>
                        <summary title="Zonas preferenciales de clientes (Más arrendadas)">Zonas preferenciales de clientes (Más arrendadas)</summary>
                        <p class="faq-content">El siguiente grafico muestra las 4 zonas más arrendas.</p>

                        <div class="kt-portlet">
                            <div class="kt-portlet__head">
                                <div class="kt-portlet__head-label">
                                    <h3 class="kt-portlet__head-title kt-font-primary"></h3>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="row">
                                    <div class="col-lg-2 form-group"></div>
                                    <div class="col-lg-3 form-group">
                                        Comienzo
                                            <asp:TextBox runat="server" ID="txtComienzo" TextMode="Date"
                                                CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        Termino
                                            <asp:TextBox runat="server" ID="txtTermino" TextMode="Date"
                                                CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        *
                                        <br />
                                        <asp:Button runat="server" CssClass="btn btn-info form-control"
                                            OnClick="click_filtrar_zona" Text="Filtrar" />
                                    </div>
                                </div>
                                <asp:Panel ID="panelPDF1" runat="server">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <br />
                                            <div class="col-lg-2">
                                            </div>
                                            <h5>
                                                <strong>Ganancias</strong>
                                            </h5>
                                            <p style="color: blue">
                                                <i class="fas fa-money-bill-wave"></i><strong>Concepcion:</strong>
                                                <asp:Label runat="server" ID="gananciaConcepcion"></asp:Label>
                                            </p>
                                            <p style="color: red">
                                                <i class="fas fa-money-bill-wave"></i><strong>Penco:</strong>
                                                <asp:Label runat="server" ID="gananciaPenco"></asp:Label>
                                            </p>
                                            <p style="color: orange">
                                                <i class="fas fa-money-bill-wave"></i><strong>Tome:</strong>
                                                <asp:Label runat="server" ID="GananciaTome"></asp:Label>
                                            </p>
                                            <p style="color: green">
                                                <i class="fas fa-money-bill-wave"></i><strong>San Pedro:</strong>
                                                <asp:Label runat="server" ID="GananciaSanPedro"></asp:Label>
                                            </p>
                                        </div>

                                        <div class="col-lg-9">
                                            <div id="piechart"></div>

                                        </div>

                                        <div class="col-lg-2">
                                            <asp:Button runat="server" CssClass="btn btn-secondary form-control"
                                                OnClick="generarReporte1" Text="Ver reporte" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>



                    </details>
                </div>

                <div>
                    <details>
                        <summary title="Ingreso mensual por año">Ingreso mensual por año</summary>
                        <p class="faq-content">Este gráfico muestra el ingreso mensual segun el año seleccionado.</p>


                        <div class="kt-portlet">
                            <div class="kt-portlet__head">
                                <div class="kt-portlet__head-label">
                                    <h3 class="kt-portlet__head-title kt-font-primary"></h3>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="row">
                                    <div class="col-lg-2 form-group"></div>
                                    <div class="col-lg-3 form-group">
                                        Seleccionar el año
                                        <!--<asp:DropDownList runat="server" ID="anhoFiltro" CssClass="form-control">
                                            </asp:DropDownList>
                                                -->
                                        <asp:DropDownList runat="server" ID="pruebaASD" CssClass="form-control">
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        *
                                        <br />
                                        <asp:Button runat="server" OnClick="clic_filtrar_ganancia"
                                            CssClass="btn btn-primary" Text="Buscar" />
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        Reporte
                                        <br />
                                        <asp:Button runat="server" OnClick="clic_ver_reporte_2" href="#"
                                            class="btn btn-info" Text="Ver reporte" />
                                    </div>
                                </div>
                                <br />
                                <asp:Panel ID="panel2" runat="server">
                                    <div class="row">
                                        <div class="col-lg-2 form-group">
                                            <h5>
                                                <strong>Ganancias</strong>
                                            </h5>
                                        </div>

                                        <div class="col-lg-2 form-group">
                                            <p style="color: cadetblue">
                                                <i class="fas fa-money-bill-wave"></i><strong>Concepcion:</strong>
                                                <asp:Label runat="server" ID="Label1"></asp:Label>
                                            </p>
                                        </div>

                                        <div class="col-lg-2 form-group">
                                            <p style="color: cadetblue">
                                                <i class="fas fa-money-bill-wave"></i><strong>Penco:</strong>
                                                <asp:Label runat="server" ID="Label2"></asp:Label>
                                            </p>
                                        </div>

                                        <div class="col-lg-2 form-group">
                                            <p style="color: cadetblue">
                                                <i class="fas fa-money-bill-wave"></i><strong>Tome:</strong>
                                                <asp:Label runat="server" ID="Label3"></asp:Label>
                                            </p>
                                        </div>

                                        <div class="col-lg-3 form-group">
                                            <p style="color: cadetblue">
                                                <i class="fas fa-money-bill-wave"></i><strong>San Pedro:</strong>
                                                <asp:Label runat="server" ID="Label4"></asp:Label>
                                            </p>
                                        </div>

                                        <br />
                                        <div class="col-md-10">
                                            <div id="chart_div"></div>
                                        </div>
                                        <div class="col-lg-2">
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>


                    </details>
                </div>
                <div>
                    <details>
                        <summary title="Ingresos anual por departamento ">Ingresos anual por departamento</summary>
                        <p class="faq-content">Este gráfico muestra el ingreso anual por cada departamento.</p>



                        <div class="kt-portlet">
                            <div class="kt-portlet__head">
                                <div class="kt-portlet__head-label">
                                    <h3 class="kt-portlet__head-title kt-font-primary"></h3>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="row">
                                    <div class="col-lg-3 form-group">
                                        Departamento
                                        <br />
                                        <asp:DropDownList runat="server" ID="drop_listaDepartamentos"
                                            Width="130" CssClass="form-control">
                                            <asp:ListItem>-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        Selecciona Año
                                        <br />
                                        <asp:DropDownList runat="server" ID="añoDptoFiltro" CssClass="form-control">
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        Filtro
                                        <br />
                                        <asp:Button runat="server" Text="Filtro" OnClick="filtroDepartamento"
                                            CssClass="btn btn-primary" />
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        Reporte
                                        <br />
                                        <asp:Button runat="server" OnClick="clic_ver_reporte_3" href="#"
                                            class="btn btn-primary" Text="Ver reporte" />
                                    </div>
                                </div>
                                <asp:Panel ID="panel1" runat="server">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <br />
                                            <div class="col-lg-2"></div>
                                        </div>
                                        <br />
                                        <div class="col-lg-4">
                                        </div>
                                        <div class="col-md-10">
                                            <div id="chart_divREPORTE3"></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>



                    </details>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="prueba" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="penco" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="tome" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="San_Pedro" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="tituloFecha" ClientIDMode="Static" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <%--<script type="text/javascript">
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(drawStuff);

        var concepcion = parseInt('<%= prueba.Value %>');
        var penco = parseInt('<%= penco.Value %>');
        var tome = parseInt('<%= tome.Value %>');
        var San_Pedro = parseInt('<%= San_Pedro.Value %>');
        var titulo = ('<%= tituloFecha.Value %>');

        function drawStuff() {
            var data = new google.visualization.arrayToDataTable([
                ['  ', ' '],
                [concepcion + ' arriendos en ' + 'Concepcion', concepcion],
                [penco + ' arriendos en ' + 'Penco', penco],
                [tome + ' arriendos en ' + 'Tome', tome],
                [San_Pedro + '  arriendos en ' + ' San Pedro', San_Pedro]
            ]);

            //var options = {,''
            //    title: 'Chess opening moves',
            //    width: 1000,
            //    legend: { position: 'none' },
            //    chart: {
            //        title: 'Chess opening moves',
            //        subtitle: 'popularity by percentage'
            //    },
            //    bars: 'vertical', // Required for Material Bar Charts.
            //    axes: {
            //        x: {
            //            0: { side: 'top', label: 'Cantidad Arriendo Por zona' } // Top x-axis.
            //        }
            //    },
            //    bar: { groupWidth: "100%" }
            //}; 

            var options = {
                 'width': 700, 'height': 300, 'backgroundColor': 'transparent',
                'titleTextStyle': { 'fontSize': 18 },
                
                bars: 'vertical', // Required for Material Bar Charts.
                axes: {
                    x: {
                        0: { side: 'top', label: 'Cantidad Arriendo Por zona' } // Top x-axis.
                    }
                },
                bar: { groupWidth: "50%" }
            };


            var chart = new google.charts.Bar(document.getElementById('top_x_div'));
            chart.draw(data, options);
        };
    </script>--%>


    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        var concepcion = parseInt('<%= prueba.Value %>');
        var penco = parseInt('<%= penco.Value %>');
        var tome = parseInt('<%= tome.Value %>');
        var San_Pedro = parseInt('<%= San_Pedro.Value %>');
        var titulo = ('<%= tituloFecha.Value %>');

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['title', 'asd per Day'],
                [concepcion + ' arriendos en ' + 'Concepcion', concepcion],
                [penco + ' arriendos en ' + 'Penco', penco],
                [tome + ' arriendos en ' + 'Tome', tome],
                [San_Pedro + '  arriendos en ' + ' San Pedro', San_Pedro]
            ]);

            var options = {
                'title': titulo, 'width': 1000, 'height': 300, 'backgroundColor': 'transparent',
                'titleTextStyle': { 'fontSize': 18 }, is3D: true
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart', 'line'] });
        google.setOnLoadCallback(drawSales);

        function drawSales() {
            var Año = parseInt('<%= Año.Value %>');

            var Enero = parseInt('<%= EneroGanancia.Value %>');
            var Febrero = parseInt('<%= FebreroGanancia.Value %>');
            var Marzo = parseInt('<%= MarzoGanancia.Value %>');
            var Abril = parseInt('<%= AbrilGanancia.Value %>');
            var Mayo = parseInt('<%= MayoGanancia.Value %>');
            var Junio = parseInt('<%= JunioGnancia.Value %>');
            var Julio = parseInt('<%= JulioGanancia.Value %>');
            var Agosto = parseInt('<%= AgostoGanancia.Value %>');
            var Septiembre = parseInt('<%= SeptiembreGanancia.Value %>');
            var Octubre = parseInt('<%= OctubreGanancia.Value %>');
            var Noviembre = parseInt('<%= NoviambreGanancia.Value %>');
            var Diciembre = parseInt('<%= DiciembreGanancia.Value %>');

            var data = new google.visualization.DataTable();
            data.addColumn('date', 'X');
            data.addColumn('number', 'Pesos (CLP)');
            //encontrar la forma de meter una lista
            data.addRows(Enero);
            data.addRows([[new Date(Año, 0), Enero]]);
            data.addRows([[new Date(Año,1), Febrero]]);
            data.addRows([[new Date(Año, 2), Marzo]]);
            data.addRows([[new Date(Año, 3), Abril]]);
            data.addRows([[new Date(Año, 4), Mayo]]);
            data.addRows([[new Date(Año, 5), Junio]]);
            data.addRows([[new Date(Año,6), Julio]]);
            data.addRows([[new Date(Año, 7), Agosto]]);
            data.addRows([[new Date(Año, 8), Septiembre]]);
            data.addRows([[new Date(Año,9), Octubre]]);
            data.addRows([[new Date(Año,10), Noviembre]]);
            data.addRows([[new Date(Año,11), Diciembre]]);

            var options = {
                chart: {
                    title: 'Box Office Earnings in First Two Weeks of Opening',
                    subtitle: 'in millions of dollars (USD)'
                },
                hAxis: {
                    title: 'Meses'
                },
                vAxis: {
                    title: 'Ganancias estimadas'
                },
                width: 920,
                height: 350,
                timeline: {
                    groupByRowLabel: true
                }
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart', 'line'] });
        google.setOnLoadCallback(drawSales);

        function drawSales() {
            var AñoDpto = parseInt('<%= AñoDepartamento.Value %>');

            var Enero = parseInt('<%= EneroDepartament.Value %>');
            var Febrero = parseInt('<%= FebreroDepartamento.Value %>');
            var Marzo = parseInt('<%= MarzoDepartamento.Value %>');
            var Abril = parseInt('<%= AbrilDepartamento.Value %>');
            var Mayo = parseInt('<%= MayoDepartamento.Value %>');
            var Junio = parseInt('<%= JunioDepartamento.Value %>');
            var Julio = parseInt('<%= JulioDepartamento.Value %>');
            var Agosto = parseInt('<%= AgostoDepartamento.Value %>');
            var Septiembre = parseInt('<%= SeptiembreDepartamento.Value %>');
            var Octubre = parseInt('<%= OctubreDepartamento.Value %>');
            var Noviembre = parseInt('<%= NoviembreDepartamento.Value %>');
            var Diciembre = parseInt('<%= DiciembreDepartamento.Value %>');

            // alert("Hola" + Noviembre);

            var data = new google.visualization.DataTable();
            data.addColumn('date', 'X');
            data.addColumn('number', 'Pesos (CLP)');
            //encontrar la forma de meter una lista
            data.addRows([[new Date(AñoDpto, 0), Enero]]);
            data.addRows([[new Date(AñoDpto, 1), Febrero]]);
            data.addRows([[new Date(AñoDpto, 2), Marzo]]);
            data.addRows([[new Date(AñoDpto, 3), Abril]]);
            data.addRows([[new Date(AñoDpto, 4), Mayo]]);
            data.addRows([[new Date(AñoDpto, 5), Junio]]);
            data.addRows([[new Date(AñoDpto, 6), Julio]]);
            data.addRows([[new Date(AñoDpto, 7), Agosto]]);
            data.addRows([[new Date(AñoDpto, 8), Septiembre]]);
            data.addRows([[new Date(AñoDpto, 9), Octubre]]);
            data.addRows([[new Date(AñoDpto, 10), Noviembre]]);
            data.addRows([[new Date(AñoDpto, 11), Diciembre]]);

            var options = {
                chart: {
                    title: 'Box Office Earnings in First Two Weeks of Opening',
                    subtitle: 'in millions of dollars (USD)'
                },
                hAxis: {
                    title: 'Meses'
                },
                vAxis: {
                    title: 'Ingresos Reales'
                },
                width: 1000,
                height: 450,
                timeline: {
                    groupByRowLabel: true
                }
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_divREPORTE3'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery.searchabledropdown-1.0.8.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=drop_listaDepartamentos.ClientID%>").searchable({
                maxListSize: 200, // if list size are less than maxListSize, show them all
                maxMultiMatch: 300, // how many matching entries should be displayed
                exactMatch: false, // Exact matching on search
                wildcards: true, // Support for wildcard characters (*, ?)
                ignoreCase: true, // Ignore case sensitivity
                latency: 200, // how many millis to wait until starting search
                warnMultiMatch: 'top {0} matches ...',
                warnNoMatch: 'no matches ...',
                zIndex: 'auto'
            });
        });
    </script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <script>
        $(document).ready(function () { $('#<%=drop_listaDepartamentos.ClientID%>').select2(); });
    </script>

    <!--Reporte 2-->
    <asp:HiddenField runat="server" ID="Año" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="EneroGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="FebreroGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="MarzoGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="AbrilGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="MayoGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="JunioGnancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="JulioGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="AgostoGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="SeptiembreGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="OctubreGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="NoviambreGanancia" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="DiciembreGanancia" ClientIDMode="Static" />

    <!--Reporte 3-->
    <asp:HiddenField runat="server" ID="AñoDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="EneroDepartament" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="FebreroDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="MarzoDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="AbrilDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="MayoDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="JunioDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="JulioDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="AgostoDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="SeptiembreDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="OctubreDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="NoviembreDepartamento" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="DiciembreDepartamento" ClientIDMode="Static" />

</asp:Content>
