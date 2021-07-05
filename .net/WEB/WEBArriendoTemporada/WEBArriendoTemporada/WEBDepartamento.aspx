<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WEBDepartamento.aspx.cs" Inherits="WEBArriendoTemporada.WEBDepartamento" %>

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
                <label>Administrar Departamento</label>
            </strong>
        </div>
    </div>
    <br />
    <a href="#" data-target="#ModalAgregarDepartamento" data-toggle="modal" class="btn btn-success btn-icon-split">
        <span class="icon text-white-50"></span>
        <span class="text">Agregar departamento</span>
    </a>
    <br />
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
                                        <asp:GridView ID="GridDepartamentos" runat="server" DataKeyNames="idDepartamento"
                                            AutoGenerateColumns="false" BorderWidth="0" Height="0"
                                            OnSelectedIndexChanging="GridDepartamentos_SelectedIndexChanging"
                                            OnRowDeleting="GridDepartamentos_RowDeleting"
                                            OnPageIndexChanging="GridDepartamentos_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="idDepartamento" ControlStyle-CssClass="cell100 column1" SortExpression="idDepartamento"></asp:BoundField>
                                                <asp:BoundField DataField="direccion" ControlStyle-CssClass="cell100 column2" SortExpression="direccion"></asp:BoundField>
                                                <asp:BoundField DataField="mtrsCuadrados" ControlStyle-CssClass="cell100 column3" SortExpression="metrosCuadrados"></asp:BoundField>
                                                <asp:BoundField DataField="valirDiario" ControlStyle-CssClass="cell100 column4" SortExpression="valorArriendoDiario"></asp:BoundField>
                                                <asp:BoundField DataField="disponible" ControlStyle-CssClass="cell100 column5" SortExpression="disponible"></asp:BoundField>
                                                <asp:BoundField DataField="zona" ControlStyle-CssClass="cell100 column6" SortExpression="zona"></asp:BoundField>
                                                <asp:BoundField DataField="nro_habitaciones" ControlStyle-CssClass="cell100 column7" SortExpression="nroHabitaciones"></asp:BoundField>
                                                <asp:BoundField DataField="nro_baños" ControlStyle-CssClass="cell100 column8" SortExpression="nroBanios"></asp:BoundField>
                                                <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-info" ShowSelectButton="true" SelectText="Ver" />
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

    <!--Modal agregar departamento-->
    <div class="modal fade" id="ModalAgregarDepartamento" tabindex="-1" role="dialog" aria-labelledby="ModalAgregarDepartamento" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar Departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div>
                        <label>Direccion</label>
                        <div>
                            <asp:TextBox ID="txt_direccion" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>MTS Cuadrados</label>
                        <div>
                            <asp:TextBox ID="txt_metrosC" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Valor Diario</label>
                        <div>
                            <asp:TextBox ID="txt_valorDiarios" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>Estado</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="Dl_estadoDpto" runat="server">
                                <asp:ListItem Value="1">activo</asp:ListItem>
                                <asp:ListItem Value="0">inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div>
                        <label>Zona</label>
                        <div>
                            <asp:DropDownList CssClass="form-control" ID="dltxt_zona" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="Concepcion">Concepcion</asp:ListItem>
                                <asp:ListItem Value="Tome">Tome</asp:ListItem>
                                <asp:ListItem Value="Penco">Penco</asp:ListItem>
                                <asp:ListItem Value="San Pedro">San Pedro</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div>
                        <label>N° Habitaciones</label>
                        <div>
                            <asp:TextBox ID="txt_habitaciones" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <label>N° Baños</label>
                        <div>
                            <asp:TextBox ID="txt_baños" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button ValidationGroup="agregarDpto" ID="btn_agregarUsuario" class="btn btn-primary" runat="server"
                            Text="Agregar" OnClick="btn_agregarDepartamento_click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Modal desactivar departamento-->
    <div class="modal fade" id="ModalDesactivarDepartamento" tabindex="-1" role="dialog" aria-labelledby="ModalDesactivarDepartamento" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel23">Desactivar Departamento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    ¿Esta seguro que desea desactivar departamento?
                        <asp:HiddenField runat="server" Value="" ID="hidenCodDesactivar" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_elimi" runat="server" OnClick="btn_desactivar_Click" class="btn btn-danger" Text="Desactivar" />
                </div>
            </div>
        </div>
    </div>

    <script type="">
        var RegionesYcomunas = {
            "regiones": [{
                "NombreRegion": "Arica y Parinacota",
                "comunas": ["Arica", "Camarones", "Putre", "General Lagos"]
            },
            {
                "NombreRegion": "Tarapacá",
                "comunas": ["Iquique", "Alto Hospicio", "Pozo Almonte", "Camiña", "Colchane", "Huara", "Pica"]
            },
            {
                "NombreRegion": "Antofagasta",
                "comunas": ["Antofagasta", "Mejillones", "Sierra Gorda", "Taltal", "Calama", "Ollagüe", "San Pedro de Atacama", "Tocopilla", "María Elena"]
            },
            {
                "NombreRegion": "Atacama",
                "comunas": ["Copiapó", "Caldera", "Tierra Amarilla", "Chañaral", "Diego de Almagro", "Vallenar", "Alto del Carmen", "Freirina", "Huasco"]
            },
            {
                "NombreRegion": "Coquimbo",
                "comunas": ["La Serena", "Coquimbo", "Andacollo", "La Higuera", "Paiguano", "Vicuña", "Illapel", "Canela", "Los Vilos", "Salamanca", "Ovalle", "Combarbalá", "Monte Patria", "Punitaqui", "Río Hurtado"]
            },
            {
                "NombreRegion": "Valparaíso",
                "comunas": ["Valparaíso", "Casablanca", "Concón", "Juan Fernández", "Puchuncaví", "Quintero", "Viña del Mar", "Isla de Pascua", "Los Andes", "Calle Larga", "Rinconada", "San Esteban", "La Ligua", "Cabildo", "Papudo", "Petorca", "Zapallar", "Quillota", "Calera", "Hijuelas", "La Cruz", "Nogales", "San Antonio", "Algarrobo", "Cartagena", "El Quisco", "El Tabo", "Santo Domingo", "San Felipe", "Catemu", "Llaillay", "Panquehue", "Putaendo", "Santa María", "Quilpué", "Limache", "Olmué", "Villa Alemana"]
            },
            {
                "NombreRegion": "Región del Libertador Gral. Bernardo O’Higgins",
                "comunas": ["Rancagua", "Codegua", "Coinco", "Coltauco", "Doñihue", "Graneros", "Las Cabras", "Machalí", "Malloa", "Mostazal", "Olivar", "Peumo", "Pichidegua", "Quinta de Tilcoco", "Rengo", "Requínoa", "San Vicente", "Pichilemu", "La Estrella", "Litueche", "Marchihue", "Navidad", "Paredones", "San Fernando", "Chépica", "Chimbarongo", "Lolol", "Nancagua", "Palmilla", "Peralillo", "Placilla", "Pumanque", "Santa Cruz"]
            },
            {
                "NombreRegion": "Región del Maule",
                "comunas": ["Talca", "ConsVtución", "Curepto", "Empedrado", "Maule", "Pelarco", "Pencahue", "Río Claro", "San Clemente", "San Rafael", "Cauquenes", "Chanco", "Pelluhue", "Curicó", "Hualañé", "Licantén", "Molina", "Rauco", "Romeral", "Sagrada Familia", "Teno", "Vichuquén", "Linares", "Colbún", "Longaví", "Parral", "ReVro", "San Javier", "Villa Alegre", "Yerbas Buenas"]
            },
            {
                "NombreRegion": "Región del Biobío",
                "comunas": ["Concepción", "Coronel", "Chiguayante", "Florida", "Hualqui", "Lota", "Penco", "San Pedro de la Paz", "Santa Juana", "Talcahuano", "Tomé", "Hualpén", "Lebu", "Arauco", "Cañete", "Contulmo", "Curanilahue", "Los Álamos", "Tirúa", "Los Ángeles", "Antuco", "Cabrero", "Laja", "Mulchén", "Nacimiento", "Negrete", "Quilaco", "Quilleco", "San Rosendo", "Santa Bárbara", "Tucapel", "Yumbel", "Alto Biobío", "Chillán", "Bulnes", "Cobquecura", "Coelemu", "Coihueco", "Chillán Viejo", "El Carmen", "Ninhue", "Ñiquén", "Pemuco", "Pinto", "Portezuelo", "Quillón", "Quirihue", "Ránquil", "San Carlos", "San Fabián", "San Ignacio", "San Nicolás", "Treguaco", "Yungay"]
            },
            {
                "NombreRegion": "Región de la Araucanía",
                "comunas": ["Temuco", "Carahue", "Cunco", "Curarrehue", "Freire", "Galvarino", "Gorbea", "Lautaro", "Loncoche", "Melipeuco", "Nueva Imperial", "Padre las Casas", "Perquenco", "Pitrufquén", "Pucón", "Saavedra", "Teodoro Schmidt", "Toltén", "Vilcún", "Villarrica", "Cholchol", "Angol", "Collipulli", "Curacautín", "Ercilla", "Lonquimay", "Los Sauces", "Lumaco", "Purén", "Renaico", "Traiguén", "Victoria",]
            },
            {
                "NombreRegion": "Región de Los Ríos",
                "comunas": ["Valdivia", "Corral", "Lanco", "Los Lagos", "Máfil", "Mariquina", "Paillaco", "Panguipulli", "La Unión", "Futrono", "Lago Ranco", "Río Bueno"]
            },
            {
                "NombreRegion": "Región de Los Lagos",
                "comunas": ["Puerto Montt", "Calbuco", "Cochamó", "Fresia", "FruVllar", "Los Muermos", "Llanquihue", "Maullín", "Puerto Varas", "Castro", "Ancud", "Chonchi", "Curaco de Vélez", "Dalcahue", "Puqueldón", "Queilén", "Quellón", "Quemchi", "Quinchao", "Osorno", "Puerto Octay", "Purranque", "Puyehue", "Río Negro", "San Juan de la Costa", "San Pablo", "Chaitén", "Futaleufú", "Hualaihué", "Palena"]
            },
            {
                "NombreRegion": "Región Aisén del Gral. Carlos Ibáñez del Campo",
                "comunas": ["Coihaique", "Lago Verde", "Aisén", "Cisnes", "Guaitecas", "Cochrane", "O’Higgins", "Tortel", "Chile Chico", "Río Ibáñez"]
            },
            {
                "NombreRegion": "Región de Magallanes y de la AntárVca Chilena",
                "comunas": ["Punta Arenas", "Laguna Blanca", "Río Verde", "San Gregorio", "Cabo de Hornos (Ex Navarino)", "AntárVca", "Porvenir", "Primavera", "Timaukel", "Natales", "Torres del Paine"]
            },
            {
                "NombreRegion": "Región Metropolitana de Santiago",
                "comunas": ["Cerrillos", "Cerro Navia", "Conchalí", "El Bosque", "Estación Central", "Huechuraba", "Independencia", "La Cisterna", "La Florida", "La Granja", "La Pintana", "La Reina", "Las Condes", "Lo Barnechea", "Lo Espejo", "Lo Prado", "Macul", "Maipú", "Ñuñoa", "Pedro Aguirre Cerda", "Peñalolén", "Providencia", "Pudahuel", "Quilicura", "Quinta Normal", "Recoleta", "Renca", "San Joaquín", "San Miguel", "San Ramón", "Vitacura", "Puente Alto", "Pirque", "San José de Maipo", "Colina", "Lampa", "TilVl", "San Bernardo", "Buin", "Calera de Tango", "Paine", "Melipilla", "Alhué", "Curacaví", "María Pinto", "San Pedro", "Talagante", "El Monte", "Isla de Maipo", "Padre Hurtado", "Peñaflor"]
            }]
        }

        jQuery(document).ready(function () {

            var iRegion = 0;
            var htmlRegion = '<option value="sin-region">Seleccione región</option><option value="sin-region">--</option>';
            var htmlComunas = '<option value="sin-region">Seleccione comuna</option><option value="sin-region">--</option>';

            jQuery.each(RegionesYcomunas.regiones, function () {
                htmlRegion = htmlRegion + '<option value="' + RegionesYcomunas.regiones[iRegion].NombreRegion + '">' + RegionesYcomunas.regiones[iRegion].NombreRegion + '</option>';
                iRegion++;
            });

            jQuery('#regiones').html(htmlRegion);
            jQuery('#comunas').html(htmlComunas);

            jQuery('#regiones').change(function () {
                var iRegiones = 0;
                var valorRegion = jQuery(this).val();
                var htmlComuna = '<option value="sin-comuna">Seleccione comuna</option><option value="sin-comuna">--</option>';
                jQuery.each(RegionesYcomunas.regiones, function () {
                    if (RegionesYcomunas.regiones[iRegiones].NombreRegion == valorRegion) {
                        var iComunas = 0;
                        jQuery.each(RegionesYcomunas.regiones[iRegiones].comunas, function () {
                            htmlComuna = htmlComuna + '<option value="' + RegionesYcomunas.regiones[iRegiones].comunas[iComunas] + '">' + RegionesYcomunas.regiones[iRegiones].comunas[iComunas] + '</option>';
                            iComunas++;
                        });
                    }
                    iRegiones++;
                });
                jQuery('#comunas').html(htmlComuna);
            });
            jQuery('#comunas').change(function () {
                if (jQuery(this).val() == 'sin-region') {
                    alert('selecciones Región');
                } else if (jQuery(this).val() == 'sin-comuna') {
                    alert('selecciones Comuna');
                }
            });
            jQuery('#regiones').change(function () {
                if (jQuery(this).val() == 'sin-region') {
                    alert('selecciones Región');
                }
            });

        });
    </script>

    <script>
        $(document).ready(function () {
            $('#<%=GridDepartamentos.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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
        function openModalDesactivar() {
            $('#ModalDesactivarDepartamento').modal('show');
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

