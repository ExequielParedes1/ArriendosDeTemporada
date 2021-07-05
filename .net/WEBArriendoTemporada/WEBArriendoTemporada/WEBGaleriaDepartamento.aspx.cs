using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;
using System.Drawing;
using WEBArriendoTemporada.metodos;
namespace WEBArriendoTemporada
{
    public partial class WEBGaleriaDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            ConsultarImagenes();
        }

        
        protected void subirImagenClic(object sender, EventArgs e)
        {
            try
            {
                DepartamentoBLL dpto = new DepartamentoBLL();
                dpto = (DepartamentoBLL)Session["Departamento"];

                Redimension redimension = new Redimension();

                int tamanio = uploadImagen.PostedFile.ContentLength;
                byte[] imagenOriginal = new byte[tamanio];

                uploadImagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                Bitmap ImagenOriginalBinaria = new Bitmap(uploadImagen.PostedFile.InputStream);

                System.Drawing.Image imtThumbnail;
                int tamaniothumbnail = 200;
                imtThumbnail = redimension.RedimensionarImagenFondo(ImagenOriginalBinaria, tamaniothumbnail);
                byte[] bImagenThumbnail = new byte[tamaniothumbnail];

                ImageConverter Convertido = new ImageConverter();
                bImagenThumbnail = (byte[])Convertido.ConvertTo(imtThumbnail, typeof(byte[]));

                FotoBLL nuevo = new FotoBLL();

                if (txtNombre.Text == "")
                {
                    throw new Exception("El campo nombre no puede estar vacio");
                }
                else
                {
                    nuevo._nombre = txtNombre.Text;
                }
                if (txtDescripcion.Text == "")
                {
                    throw new Exception("El campo descripcion no puede estar vacio");
                }
                else
                {
                    nuevo._descripcion = txtDescripcion.Text;
                }


                nuevo._id_departamento_id = dpto.idDepartamento;
                nuevo._url = bImagenThumbnail;

                if (nuevo.agregarFotoBLL(nuevo) == 1)
                {
                  
                    UsuarioBLL logueado = new UsuarioBLL();
                    logueado = (UsuarioBLL)Session["usuario"];

                    

                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("WEBGaleriaDepartamento.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("WEBGaleriaDepartamento.aspx");
                }
            }
            catch (Exception exp)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }



        }
        public void validarTareasRealizadas()
        {
            validar nuevo = new validar();
            nuevo = (validar)Session["registrado"];

            if (nuevo != null)
            {
                if (nuevo.realizado)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "showCreateThanksYouForm()", true);
                    Session.Remove("registrado");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", " error()", true);
                    Session.Remove("registrado");
                }
            }
        }
        protected void ConsultarImagenes()
        {
            DepartamentoBLL dpto = new DepartamentoBLL();
            dpto = (DepartamentoBLL)Session["Departamento"];
            FotoBLL nuevo = new FotoBLL();
            Repeater1.DataSource = nuevo.listarImagenesPorDpto(dpto.idDepartamento);
            Repeater1.DataBind();
        }
        public void clic_eliminar_imagen(object sender, EventArgs e)
        {
            FotoBLL nuevo = new FotoBLL();
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int customerId = int.Parse((item.FindControl("lblCustomerId") as Label).Text);

            if (nuevo.eliminarImagen(customerId) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("WEBGaleriaDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("WEBGaleriaDepartamento.aspx");
            }


        }
    }
}