<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="WEBArriendoTemporada.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="section-6-container section-container section-container-image-bg" id="section-6">
        <div class="container">
            <div class="row">
                <div class="col section-6 section-description wow fadeIn">
                    <h2>Contactanos ... </h2>
                    <div class="divider-1 wow fadeInUp"><span></span></div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 section-6-box wow fadeInUp">
                    <div class="section-6-form">
                        <form role="form" action="assets/contact.php" method="post">
                            <div class="form-group">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d798.522438272376!2d-73.04818797075292!3d-36.81636912511145!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9669b5c975b5bf99%3A0x8b60ed9c910e159b!2zR3JhbCBDcnV6IDEyNzMtMTIwMSwgQ29uY2VwY2nDs24sIELDrW8gQsOtbw!5e0!3m2!1ses-419!2scl!4v1623179961157!5m2!1ses-419!2scl" frameborder="0" style="border: 0; width: 100%; height: 312px;" allowfullscreen></iframe>
                            </div>
                            <div class="form-group">
                                <i class="ion-ios-location-outline"></i>
                                <p>Gral Cruz 1273 ,+56945777116 </p>
                            </div>
                        </form>
                    </div>
                </div>

                <div class="col-md-5 offset-md-1 section-6-box wow fadeInDown">
                    <h3></h3>
                    <div class="section-6-form">
                        <form role="form" action="assets/contact.php" method="post">

                            <div id="errormessage"></div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Nombre" data-rule="minlen:4" data-msg="Please enter at least 4 chars" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtCorreo" class="form-control" name="email" placeholder="Email" data-rule="email" data-msg="Please enter a valid email" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtAsunto" class="form-control" name="subject" placeholder="Asunto" data-rule="minlen:4" data-msg="Please enter at least 8 chars of subject" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txrMensaje" Rows="5" TextMode="MultiLine" data-rule="required" data-msg="Escribe tu mensaje" placeholder="Mensaje" class="form-control" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <button type="submit" class="btn btn-primary btn-customized" id="btn_registrar" onclick="correoDelUsuario">
                                Enviar Mensaje
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <section id="contact">
        <div class="container-fluid">

            <div class="row wow fadeInUp">

                <div class="col-lg-6">

                    <div class="form">

                        <div role="form" class="contactForm">
                            <div class="text-center">
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section>
    <!-- #contact -->
</asp:Content>
