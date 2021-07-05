<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WEBWebForm1.aspx.cs" Inherits="WEBArriendoTemporada.WEBWebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <!--begin::Fonts -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />
    <!--end::Fonts -->

    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="./assets/vendors/custom/fullcalendar/fullcalendar.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Page Vendors Styles -->


    <!--begin:: Global Mandatory Vendors -->
    <link href="./assets/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet"
        type="text/css" />
    <!--end:: Global Mandatory Vendors -->

    <!--begin:: Global Optional Vendors -->
    <link href="./assets/vendors/general/tether/dist/css/tether.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-datetime-picker/css/bootstrap-datetimepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-select/dist/css/bootstrap-select.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/select2/dist/css/select2.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/ion-rangeslider/css/ion.rangeSlider.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/nouislider/distribute/nouislider.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/owl.carousel/dist/assets/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/owl.carousel/dist/assets/owl.theme.default.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/dropzone/dist/dropzone.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/quill/dist/quill.snow.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/@yaireo/tagify/dist/tagify.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/summernote/dist/summernote.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/bootstrap-markdown/css/bootstrap-markdown.min.css" rel="stylesheet"
        type="text/css" />
    <link href="./assets/vendors/general/animate.css/animate.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/toastr/build/toastr.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/dual-listbox/dist/dual-listbox.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/morris.js/morris.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/sweetalert2/dist/sweetalert2.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/custom/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/custom/vendors/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/custom/vendors/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="./assets/vendors/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet"
        type="text/css" />
    <!--end:: Global Optional Vendors -->

    <!--begin::Global Theme Styles(used by all pages) -->

    <link href="./assets/css/demo1/style.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Global Theme Styles -->

    <!--begin::Layout Skins(used by all pages) -->

    <link href="./assets/css/demo1/skins/header/base/light.css" rel="stylesheet" type="text/css" />
    <link href="./assets/css/demo1/skins/header/menu/light.css" rel="stylesheet" type="text/css" />
    <link href="./assets/css/demo1/skins/brand/dark.css" rel="stylesheet" type="text/css" />
    <link href="./assets/css/demo1/skins/aside/dark.css" rel="stylesheet" type="text/css" />
    <!--end::Layout Skins -->

    <link rel="shortcut icon" href="./assets/media/logos/favicon.ico" />
    <!--end::Layout Skins -->

    <script>
        function alertme() {
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: 'Esperando la aprobacion del administrador',
                footer: ''

            })
        }
        function usuarioNoExiste() {
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: 'Usuario o contraseña invalida',
                footer: ''

            })
        }
        function error() {
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: 'No se pudo realizar la tarea',
                footer: ''

            })
        }

    </script>
    <script>
        function showCreateThanksYouForm() {
            Swal.fire(
                'Tarea realizada con exito',
                'Click en ok para continuar',
                'success'
            )

        }
    </script>
    <script>
        function openModalEditarPerfil() {
            $('#ModalPerfil').modal('show');
        }
    </script>

</head>
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--fixed kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-page--loading">
    <form id="form2" runat="server">
        <div id="kt_header_mobile" class="kt-header-mobile  kt-header-mobile--fixed ">
            <div class="kt-header-mobile__logo">
                <a href="Inicio.aspx">
                    <img alt="Logo" src="./assets/media/logos/logo-light.png" />
                </a>
            </div>
            <div class="kt-header-mobile__toolbar">
                <button class="kt-header-mobile__toggler kt-header-mobile__toggler--left"
                    id="kt_aside_mobile_toggler">
                    <span></span>
                </button>

                <button class="kt-header-mobile__toggler" id="kt_header_mobile_toggler">
                    <span>asd
                    </span>

                </button>


            </div>
        </div>
        <!-- end:: Header Mobile -->
        <div class="kt-grid kt-grid--hor kt-grid--root">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--ver kt-page">
                <!-- begin:: Aside -->

                <!-- Uncomment this to display the close button of the panel
<button class="kt-aside-close " id="kt_aside_close_btn"><i class="la la-close"></i></button>
-->

                <div class="kt-aside  kt-aside--fixed  kt-grid__item kt-grid kt-grid--desktop kt-grid--hor-desktop"
                    id="kt_aside">
                    <!-- begin:: Aside -->
                    <div class="kt-aside__brand kt-grid__item " id="kt_aside_brand" style="background-color: white">
                        <div class="kt-aside__brand-logo">
                            <a href="Inicio.aspx">
                                <img alt="Logo" src="Logo/logo.png" width="65%" />
                            </a>
                        </div>

                        <div class="kt-aside__brand-tools">
                            <button class="kt-aside__brand-aside-toggler" id="kt_aside_toggler">
                                <span>
                                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
                                        width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                            <polygon points="0 0 24 0 24 24 0 24" />
                                            <path
                                                d="M5.29288961,6.70710318 C4.90236532,6.31657888 4.90236532,5.68341391 5.29288961,5.29288961 C5.68341391,4.90236532 6.31657888,4.90236532 6.70710318,5.29288961 L12.7071032,11.2928896 C13.0856821,11.6714686 13.0989277,12.281055 12.7371505,12.675721 L7.23715054,18.675721 C6.86395813,19.08284 6.23139076,19.1103429 5.82427177,18.7371505 C5.41715278,18.3639581 5.38964985,17.7313908 5.76284226,17.3242718 L10.6158586,12.0300721 L5.29288961,6.70710318 Z"
                                                fill="#000000" fill-rule="nonzero"
                                                transform="translate(8.999997, 11.999999) scale(-1, 1) translate(-8.999997, -11.999999) " />
                                            <path
                                                d="M10.7071009,15.7071068 C10.3165766,16.0976311 9.68341162,16.0976311 9.29288733,15.7071068 C8.90236304,15.3165825 8.90236304,14.6834175 9.29288733,14.2928932 L15.2928873,8.29289322 C15.6714663,7.91431428 16.2810527,7.90106866 16.6757187,8.26284586 L22.6757187,13.7628459 C23.0828377,14.1360383 23.1103407,14.7686056 22.7371482,15.1757246 C22.3639558,15.5828436 21.7313885,15.6103465 21.3242695,15.2371541 L16.0300699,10.3841378 L10.7071009,15.7071068 Z"
                                                fill="#000000" fill-rule="nonzero" opacity="0.3"
                                                transform="translate(15.999997, 11.999999) scale(-1, 1) rotate(-270.000000) translate(-15.999997, -11.999999) " />
                                        </g>
                                    </svg></span>
                                <span>
                                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
                                        width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                            <polygon points="0 0 24 0 24 24 0 24" />
                                            <path
                                                d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z"
                                                fill="#000000" fill-rule="nonzero" />
                                            <path
                                                d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z"
                                                fill="#000000" fill-rule="nonzero" opacity="0.3"
                                                transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) " />
                                        </g>
                                    </svg></span>
                            </button>
                            <!--
			<button class="kt-aside__brand-aside-toggler kt-aside__brand-aside-toggler--left" id="kt_aside_toggler"><span></span></button>
			-->
                        </div>
                    </div>
                    <!-- end:: Aside -->
                    <!-- begin:: Aside Menu -->
                    <div class="kt-aside-menu-wrapper kt-grid__item kt-grid__item--fluid" id="kt_aside_menu_wrapper">

                        <div id="kt_aside_menu" class="kt-aside-menu " data-ktmenu-vertical="1" data-ktmenu-scroll="1"
                            data-ktmenu-dropdown-timeout="500">

                            <ul class="kt-menu__nav ">
                                <li class="kt-menu__item  kt-menu__item--active" aria-haspopup="true"><a
                                    href="Inicio.aspx" class="kt-menu__link "><span class="kt-menu__link-icon">
                                        <svg
                                            xmlns="http://www.w3.org/2000/svg"
                                            xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px"
                                            viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <polygon points="0 0 24 0 24 24 0 24" />
                                                <path
                                                    d="M12.9336061,16.072447 L19.36,10.9564761 L19.5181585,10.8312381 C20.1676248,10.3169571 20.2772143,9.3735535 19.7629333,8.72408713 C19.6917232,8.63415859 19.6104327,8.55269514 19.5206557,8.48129411 L12.9336854,3.24257445 C12.3871201,2.80788259 11.6128799,2.80788259 11.0663146,3.24257445 L4.47482784,8.48488609 C3.82645598,9.00054628 3.71887192,9.94418071 4.23453211,10.5925526 C4.30500305,10.6811601 4.38527899,10.7615046 4.47382636,10.8320511 L4.63,10.9564761 L11.0659024,16.0730648 C11.6126744,16.5077525 12.3871218,16.5074963 12.9336061,16.072447 Z"
                                                    fill="#000000" fill-rule="nonzero" />
                                                <path
                                                    d="M11.0563554,18.6706981 L5.33593024,14.122919 C4.94553994,13.8125559 4.37746707,13.8774308 4.06710397,14.2678211 C4.06471678,14.2708238 4.06234874,14.2738418 4.06,14.2768747 L4.06,14.2768747 C3.75257288,14.6738539 3.82516916,15.244888 4.22214834,15.5523151 C4.22358765,15.5534297 4.2250303,15.55454 4.22647627,15.555646 L11.0872776,20.8031356 C11.6250734,21.2144692 12.371757,21.2145375 12.909628,20.8033023 L19.7677785,15.559828 C20.1693192,15.2528257 20.2459576,14.6784381 19.9389553,14.2768974 C19.9376429,14.2751809 19.9363245,14.2734691 19.935,14.2717619 L19.935,14.2717619 C19.6266937,13.8743807 19.0546209,13.8021712 18.6572397,14.1104775 C18.654352,14.112718 18.6514778,14.1149757 18.6486172,14.1172508 L12.9235044,18.6705218 C12.377022,19.1051477 11.6029199,19.1052208 11.0563554,18.6706981 Z"
                                                    fill="#000000" opacity="0.3" />
                                            </g>
                                        </svg></span><span class="kt-menu__link-text">Inicio</span></a></li>


                                <asp:LinkButton runat="server" ID="panelAdmin" class="kt-menu__section ">
                                   <h4 class="kt-menu__section-text">Panel de administracion</h4>
                                    <i class="kt-menu__section-icon flaticon-more-v2"></i>
                                </asp:LinkButton>
                                <li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
                                    <asp:LinkButton href="javascript:;" class="kt-menu__link kt-menu__toggle" runat="server" ID="navAdministrar">
                                    <span class="kt-menu__link-icon">
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px"
                                                viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <rect x="0" y="0" width="24" height="24" />
                                                    <path
                                                        d="M5,5 L5,15 C5,15.5948613 5.25970314,16.1290656 5.6719139,16.4954176 C5.71978107,16.5379595 5.76682388,16.5788906 5.81365532,16.6178662 C5.82524933,16.6294602 15,7.45470952 15,7.45470952 C15,6.9962515 15,6.17801499 15,5 L5,5 Z M5,3 L15,3 C16.1045695,3 17,3.8954305 17,5 L17,15 C17,17.209139 15.209139,19 13,19 L7,19 C4.790861,19 3,17.209139 3,15 L3,5 C3,3.8954305 3.8954305,3 5,3 Z"
                                                        fill="#000000" fill-rule="nonzero"
                                                        transform="translate(10.000000, 11.000000) rotate(-315.000000) translate(-10.000000, -11.000000) " />
                                                    <path
                                                        d="M20,22 C21.6568542,22 23,20.6568542 23,19 C23,17.8954305 22,16.2287638 20,14 C18,16.2287638 17,17.8954305 17,19 C17,20.6568542 18.3431458,22 20,22 Z"
                                                        fill="#000000" opacity="0.3" />
                                                </g>
                                               
                                            </svg></span><span class="kt-menu__link-text">Administrar</span><i
                                                class="kt-menu__ver-arrow la la-angle-right"></i></asp:LinkButton>

                                    <div class="kt-menu__submenu ">
                                        <span class="kt-menu__arrow"></span>
                                        <ul class="kt-menu__subnav">
                                            <li class="kt-menu__item  kt-menu__item--parent" aria-haspopup="true"><span
                                                class="kt-menu__link"><span
                                                    class="kt-menu__link-text">Skins</span></span></li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_AdministrarArriendos" href="AdministrarArriendos.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Arriendos</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_agregarCliente" href="AdministrarUsuario.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Usuarios</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_servicio" href="AdministrarServicio.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Servicios</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_viajes" href="Viaje.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Viajes</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_agregarDepartamento" href="Departamento.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Departamento</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_administrarVehiChofe" href="AdministrarConductoresVehiculos.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Vehiculos y Conductores</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_caracInventa" href="AdministrarCaracteristicaInventario.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Caracteristica y Inventario</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="nav_funcionario" href="AdministrarFuncionario.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Funcionario</span>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true"
                                    data-ktmenu-submenu-toggle="hover">
                                    <asp:LinkButton href="javascript:;" class="kt-menu__link kt-menu__toggle" runat="server" ID="navRestaurar">
                                    <span class="kt-menu__link-icon">
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px"
                                                viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <rect x="0" y="0" width="24" height="24" />
                                                    <path
                                                        d="M2.56066017,10.6819805 L4.68198052,8.56066017 C5.26776695,7.97487373 6.21751442,7.97487373 6.80330086,8.56066017 L8.9246212,10.6819805 C9.51040764,11.267767 9.51040764,12.2175144 8.9246212,12.8033009 L6.80330086,14.9246212 C6.21751442,15.5104076 5.26776695,15.5104076 4.68198052,14.9246212 L2.56066017,12.8033009 C1.97487373,12.2175144 1.97487373,11.267767 2.56066017,10.6819805 Z M14.5606602,10.6819805 L16.6819805,8.56066017 C17.267767,7.97487373 18.2175144,7.97487373 18.8033009,8.56066017 L20.9246212,10.6819805 C21.5104076,11.267767 21.5104076,12.2175144 20.9246212,12.8033009 L18.8033009,14.9246212 C18.2175144,15.5104076 17.267767,15.5104076 16.6819805,14.9246212 L14.5606602,12.8033009 C13.9748737,12.2175144 13.9748737,11.267767 14.5606602,10.6819805 Z"
                                                        fill="#000000" opacity="0.3" />
                                                    <path
                                                        d="M8.56066017,16.6819805 L10.6819805,14.5606602 C11.267767,13.9748737 12.2175144,13.9748737 12.8033009,14.5606602 L14.9246212,16.6819805 C15.5104076,17.267767 15.5104076,18.2175144 14.9246212,18.8033009 L12.8033009,20.9246212 C12.2175144,21.5104076 11.267767,21.5104076 10.6819805,20.9246212 L8.56066017,18.8033009 C7.97487373,18.2175144 7.97487373,17.267767 8.56066017,16.6819805 Z M8.56066017,4.68198052 L10.6819805,2.56066017 C11.267767,1.97487373 12.2175144,1.97487373 12.8033009,2.56066017 L14.9246212,4.68198052 C15.5104076,5.26776695 15.5104076,6.21751442 14.9246212,6.80330086 L12.8033009,8.9246212 C12.2175144,9.51040764 11.267767,9.51040764 10.6819805,8.9246212 L8.56066017,6.80330086 C7.97487373,6.21751442 7.97487373,5.26776695 8.56066017,4.68198052 Z"
                                                        fill="#000000" />
                                                </g>
                                            </svg></span><span class="kt-menu__link-text">Restaurar</span><i
                                                class="kt-menu__ver-arrow la la-angle-right"></i></asp:LinkButton>
                                    <div class="kt-menu__submenu ">
                                        <span class="kt-menu__arrow"></span>

                                        <ul class="kt-menu__subnav">
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="navActivarVehiculo" href="RestaurarVehiculo.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Vehiculo</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="navActivarConductor" href="RestaurarConductor.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Conductor</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="navActivarUsuario" href="RestaurarUsuario.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Usuario</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="navActivarDepartamento" href="RestaurarDepartamento.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Departamento</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="navActivarServicio" href="RestaurarServicios.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Servicios</span>
                                                </asp:LinkButton>
                                            </li>

                                        </ul>
                                    </div>
                                </li>
                                <li class="kt-menu__item " aria-haspopup="true">
                                    <asp:LinkButton runat="server" ID="nav_reportes" target="_blank" href="Reportes.aspx" class="kt-menu__link ">
                                        <i class="kt-menu__link-icon flaticon-cogwheel-1"></i>
                                        <span class="kt-menu__link-text">Reportes</span>
                                    </asp:LinkButton>
                                </li>

                                <li class="kt-menu__item " aria-haspopup="true">
                                    <asp:LinkButton runat="server" ID="nav_losgs" target="_blank" href="Logs.aspx" class="kt-menu__link ">
                                        <i class="kt-menu__link-icon flaticon-cogwheel-1"></i>
                                        <span class="kt-menu__link-text">Logs</span>
                                    </asp:LinkButton>
                                </li>


                                <li class="kt-menu__section ">
                                    <h4 class="kt-menu__section-text">Panel de usuario</h4>
                                    <i class="kt-menu__section-icon flaticon-more-v2"></i>
                                </li>
                                <li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true"
                                    data-ktmenu-submenu-toggle="hover">
                                    <asp:LinkButton href="javascript:;" class="kt-menu__link kt-menu__toggle" runat="server" ID="navServicios">
                                      <span class="kt-menu__link-icon">
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px"
                                                viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <rect x="0" y="0" width="24" height="24" />
                                                    <path
                                                        d="M4,9.67471899 L10.880262,13.6470401 C10.9543486,13.689814 11.0320333,13.7207107 11.1111111,13.740321 L11.1111111,21.4444444 L4.49070127,17.526473 C4.18655139,17.3464765 4,17.0193034 4,16.6658832 L4,9.67471899 Z M20,9.56911707 L20,16.6658832 C20,17.0193034 19.8134486,17.3464765 19.5092987,17.526473 L12.8888889,21.4444444 L12.8888889,13.6728275 C12.9050191,13.6647696 12.9210067,13.6561758 12.9368301,13.6470401 L20,9.56911707 Z"
                                                        fill="#000000" />
                                                    <path
                                                        d="M4.21611835,7.74669402 C4.30015839,7.64056877 4.40623188,7.55087574 4.5299008,7.48500698 L11.5299008,3.75665466 C11.8237589,3.60013944 12.1762411,3.60013944 12.4700992,3.75665466 L19.4700992,7.48500698 C19.5654307,7.53578262 19.6503066,7.60071528 19.7226939,7.67641889 L12.0479413,12.1074394 C11.9974761,12.1365754 11.9509488,12.1699127 11.9085461,12.2067543 C11.8661433,12.1699127 11.819616,12.1365754 11.7691509,12.1074394 L4.21611835,7.74669402 Z"
                                                        fill="#000000" opacity="0.3" />
                                                </g>
                                            </svg></span><span class="kt-menu__link-text">Servicios</span><i
                                                class="kt-menu__ver-arrow la la-angle-right"></i></asp:LinkButton>
                                    <div class="kt-menu__submenu ">
                                        <span class="kt-menu__arrow"></span>
                                        <ul class="kt-menu__subnav">
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="solicitarServicios" href="WEBSolicitarServicios.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Arriendo</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="solicitarTransporte" href="SolicitarTransporte.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Transporte</span>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="kt-menu__item " aria-haspopup="true">
                                                <asp:LinkButton runat="server" class="kt-menu__link " ID="SolicitarServicioExtra" href="WEBSolicitarServicioExtra.aspx">
                                                    <i class="kt-menu__link-bullet kt-menu__link-bullet--dot">
                                                        <span></span></i>
                                                    <span class="kt-menu__link-text">Servicios Extra</span>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </li>

                                <li class="kt-menu__item " aria-haspopup="true">
                                    <asp:LinkButton runat="server" ID="nav_departamentos" target="_blank" href="VisualizarDepartamentos.aspx" class="kt-menu__link ">
                                        <i class="kt-menu__link-icon flaticon-cogwheel-1"></i>
                                        <span class="kt-menu__link-text">Departamentos</span>
                                    </asp:LinkButton>
                                </li>

                                <li class="kt-menu__item " aria-haspopup="true">
                                    <asp:LinkButton runat="server" ID="nav_reservar" target="_blank" href="WEBReservar.aspx" class="kt-menu__link ">
                                        <i class="kt-menu__link-icon flaticon-cogwheel-1"></i>
                                        <span class="kt-menu__link-text">Reservar</span>
                                    </asp:LinkButton>
                                </li>
                                <li class="kt-menu__item " aria-haspopup="true">
                                    <asp:LinkButton runat="server" ID="nav_contactanos" target="_blank" href="Contactanos.aspx" class="kt-menu__link ">
                                        <i class="kt-menu__link-icon flaticon-cogwheel-1"></i>
                                        <span class="kt-menu__link-text">Contactanos</span>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- end:: Aside Menu -->
                </div>
                <!-- end:: Aside -->

            </div>
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor kt-wrapper" id="kt_wrapper">
                <!-- begin:: Header -->
                <div id="kt_header" class="kt-header kt-grid__item  kt-header--fixed ">
                    <div class="kt-header-menu-wrapper" id="kt_header_menu_wrapper">
                    </div>
                    <!-- end:: Header Menu -->
                    <!-- begin:: Header Topbar -->
                    <div class="kt-header__topbar">

                        <!--begin: User Bar -->
                        <div class="kt-header__topbar-item kt-header__topbar-item--user">
                            <asp:LinkButton ID="login2" runat="server" class="kt-header__topbar-wrapper">
                                <div class="kt-header__topbar-user">
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                                </div>

                            </asp:LinkButton>


                            <asp:LinkButton runat="server" ID="menuPerfil" class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="0px,0px">
                                <div class="kt-header__topbar-user">
                                    <span class="kt-header__topbar-welcome kt-hidden-mobile">Hola,</span>
                                    <span class="kt-header__topbar-username kt-hidden-mobile">
                                        <asp:Label ID="lbl_nombreUsuarioTipo" runat="server" Text="INICIADO"></asp:Label></span>
                                    <img class="kt-hidden" alt="Pic" src="./assets/media/users/300_25.jpg" />
                                    <!--use below badge element instead the user avatar to display username's first letter(remove kt-hidden class to display it) -->
                                    <span
                                        class="kt-badge kt-badge--username kt-badge--unified-success kt-badge--lg kt-badge--rounded kt-badge--bold">S</span>
                                </div>
                            </asp:LinkButton>


                            <div
                                class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-top-unround dropdown-menu-xl">
                                <!--begin: Head -->
                                <div class="kt-user-card kt-user-card--skin-dark kt-notification-item-padding-x"
                                    style="background-image: url(./assets/media/misc/bg-1.jpg)">
                                    <div class="kt-user-card__avatar">
                                        <img class="kt-hidden" alt="Pic" src="./assets/media/users/300_25.jpg" />
                                        <!--use below badge element instead the user avatar to display username's first letter(remove kt-hidden class to display it) -->
                                        <span
                                            class="kt-badge kt-badge--lg kt-badge--rounded kt-badge--bold kt-font-success">S</span>
                                    </div>
                                    <div class="kt-user-card__name">
                                        <asp:Label ID="lbl_nombreUsuarioNombre" runat="server" Text="INICIADO"></asp:Label>
                                    </div>

                                </div>
                                <!--end: Head -->

                                <!--begin: Navigation -->
                                <div class="kt-notification">
                                    <a data-target="#ModalPerfil" data-toggle="modal"
                                        class="kt-notification__item">
                                        <div class="kt-notification__item-icon">
                                            <i class="flaticon2-calendar-3 kt-font-success"></i>
                                        </div>
                                        <div class="kt-notification__item-details">
                                            Perfil
                                        </div>
                                    </a>

                                    <div class="kt-header__topbar">
                                    </div>
                                    <!-- end:: Header Topbar -->

                                    <div class="kt-notification__custom kt-space-between">
                                        <asp:LinkButton class="btn btn-label btn-label-brand btn-sm btn-bold" runat="server" ID="nav_cerrar" href="#" data-toggle="modal" data-target="#logoutModal">
                                        <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Cerrar Sesion
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <!--end: Navigation -->
                            </div>
                        </div>
                        <!--end: User Bar -->
                    </div>
                    <!-- end:: Header Topbar -->
                </div>

                <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

                    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                        <div class="kt-subheader   kt-grid__item" id="kt_subheader">
                            <div class="kt-container  kt-container--fluid ">
                                <div class="kt-subheader__main">
                                    <h3 class="kt-subheader__title">Logs </h3>

                                    <span class="kt-subheader__separator kt-hidden"></span>
                                    <div class="kt-subheader__breadcrumbs">
                                        <a href="Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i
                                            class="flaticon2-shelter"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="container-fluid">
                                <div class="kt-portlet kt-portlet--tabs">
                                   
                                      

                                
                                    <div class="kt-portlet__body">
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="kt_portlet_tab_1_1">

                                                <asp:GridView runat="server"  ID="gridLog" class="table table-striped- table-bordered table-hover table-checkable" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="id_nombre" HeaderText="#" SortExpression="id_nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="Fecha_cambio" HeaderText="Fecha Accion" SortExpression="Fecha_cambio"></asp:BoundField>
                                                        <asp:BoundField DataField="Nombre_cambio" HeaderText="Accion" SortExpression="Nombre_cambio"></asp:BoundField>
                                                        <asp:BoundField DataField="Tabla_asociada_id" HeaderText="Afectado" SortExpression="Tabla_asociada_id"></asp:BoundField>
                                                        <asp:BoundField DataField="Tabla_asociada_nombre" HeaderText="Afectado Nombre" SortExpression="Tabla_asociada_nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="Responsable_id" HeaderText="Responsable" SortExpression="Responsable_id"></asp:BoundField>
                                                        <asp:BoundField DataField="Responsable_nombre" HeaderText="Responsable Nombre" SortExpression="Responsable_nombre"></asp:BoundField>
                                                        <asp:BoundField DataField="Responsable_tipo" HeaderText="Responsable Tipo" SortExpression="Responsable_tipo"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>

            </div>
        </div>

        <!-- end::Scrolltop -->

        <!-- Logout Modal-->
        <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="logoutModal" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Listo para salir?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Selecciona salir para cerrar sesion</div>
                    <div class="modal-footer">
                        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="Button1" OnClick="cerrar_click" runat="server" Text="Salir" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="ModalPerfil" tabindex="-1" role="dialog" aria-labelledby="ModalMantencion" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel22">Perfil</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div>
                            <label>Correo</label>
                            <div>
                                <asp:TextBox ID="txtCorreoPerfil" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>
                        <div>
                            <label>Rut</label>
                            <div>
                                <asp:TextBox ID="txtRutPerfil" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>

                        </div>
                        <div>
                            <label>Nombre</label>
                            <div>
                                <asp:TextBox ID="txtNombrePerfil" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div>
                            <label>Apellido</label>
                            <div>
                                <asp:TextBox ID="txtApellidoPerfil" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>

                        </div>
                        <div>
                            <label>Telefono</label>
                            <div>
                                <asp:TextBox ID="txtTelefonoPerfil" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                            </div>

                        </div>
                        <div>
                            <label>Contraseña</label>
                            <div>
                                <asp:TextBox ID="txtContraseñaPerfil" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <div class="container-fluid">
                                <asp:Button runat="server" Text="Guardar" class="btn btn-primary" />
                            </div>
                            <div class="container-fluid">
                                <asp:Button runat="server" Text="Editar" class="btn btn-warning" OnClick="clic_editar_perfil" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- begin::Global Config(global config for global JS sciprts) -->
        <script>
            var KTAppOptions = { "colors": { "state": { "brand": "#5d78ff", "dark": "#282a3c", "light": "#ffffff", "primary": "#5867dd", "success": "#34bfa3", "info": "#36a3f7", "warning": "#ffb822", "danger": "#fd3995" }, "base": { "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"], "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"] } } };
        </script>
        <!-- end::Global Config -->

        <!--begin:: Global Mandatory Vendors -->
        <script src="./assets/vendors/general/jquery/dist/jquery.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/moment/min/moment.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/wnumb/wNumb.js" type="text/javascript"></script>
        <!--end:: Global Mandatory Vendors -->

        <!--begin:: Global Optional Vendors -->
        <script src="./assets/vendors/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/bootstrap-datepicker.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-timepicker/js/bootstrap-timepicker.min.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/bootstrap-timepicker.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-maxlength/src/bootstrap-maxlength.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/custom/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/bootstrap-switch.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/select2/dist/js/select2.full.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/handlebars/dist/handlebars.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/inputmask/dist/inputmask/inputmask.date.extensions.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/general/inputmask/dist/inputmask/inputmask.numeric.extensions.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/general/nouislider/distribute/nouislider.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/autosize/dist/autosize.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/dropzone/dist/dropzone.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/dropzone.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/quill/dist/quill.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/@yaireo/tagify/dist/tagify.polyfills.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/@yaireo/tagify/dist/tagify.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/summernote/dist/summernote.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/markdown/lib/markdown.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/bootstrap-markdown.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/bootstrap-notify.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/jquery-validation.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/toastr/build/toastr.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/dual-listbox/dist/dual-listbox.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/raphael/raphael.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/morris.js/morris.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js"
            type="text/javascript"></script>
        <script src="./assets/vendors/custom/vendors/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/counterup/jquery.counterup.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
        <script src="./assets/vendors/custom/js/vendors/sweetalert2.init.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/jquery.repeater/src/lib.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/jquery.repeater/src/repeater.js" type="text/javascript"></script>
        <script src="./assets/vendors/general/dompurify/dist/purify.js" type="text/javascript"></script>
        <!--end:: Global Optional Vendors -->

        <!--begin::Global Theme Bundle(used by all pages) -->

        <script src="./assets/js/demo1/scripts.bundle.js" type="text/javascript"></script>
        <!--end::Global Theme Bundle -->

        <!--begin::Page Vendors(used by this page) -->
        <script src="./assets/vendors/custom/fullcalendar/fullcalendar.bundle.js" type="text/javascript"></script>
        <script src="//maps.google.com/maps/api/js?key=AIzaSyBTGnKT7dt597vo9QgeQ7BFhvSRP4eiMSM"
            type="text/javascript"></script>
        <script src="./assets/vendors/custom/gmaps/gmaps.js" type="text/javascript"></script>
        <!--end::Page Vendors -->

        <!--begin::Page Scripts(used by this page) -->
        <script src="./assets/js/demo1/pages/dashboard.js" type="text/javascript"></script>
        <!--end::Page Scripts -->
        <script src="./assets/js/demo1/scripts.bundle.js" type="text/javascript"></script>
        <!--end::Global Theme Bundle -->

        <!--begin::Page Vendors(used by this page) -->

        <!--end::Page Vendors -->

        <!--begin::Page Scripts(used by this page) -->

        <!--end::Page Scripts -->
        <!--Validar campos-->
        <script src="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/alertify.min.js"></script>
        <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/alertify.min.css" />
        <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/default.min.css" />
        <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/semantic.min.css" />
        <link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.11.1/build/css/themes/bootstrap.min.css" />

        
        <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.6.0/js/buttons.colVis.min.js"></script>
        <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" rel="stylesheet" />



        <script>
            $(function () {
                $("#gridLog").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
        </script>

    </form>
</body>
</html>

