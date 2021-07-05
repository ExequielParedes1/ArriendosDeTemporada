using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMVer_reporte_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int año = int.Parse(Session["reporte3Año"].ToString());
            lblAño.Text = " " + año;
            int iddpto = int.Parse(Session["reporte3IDdpto"].ToString());

            string nombre = Session["nombreDepto"].ToString();
            //falta agregar el titulo
            lblTitulo.Text = nombre;
            //Estaba contra el tiempo
            GridView1.DataSource = MesesConMasGanancias(año, iddpto);
            GridView1.DataBind();

            string script = @"<script type='text/javascript'>
                alert('Credenciales Correctas: " + GananciaSegunAñoDepartamento(1) + "');  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


            primeraZonaArriendo.Text = "Enero: $";
            cantidadPrimeraZona.Text = GananciaSegunAñoDepartamento(1).ToString();
            segundaZonaArriendo.Text = "Febrero: $";
            cantidadSegundaZona.Text = GananciaSegunAñoDepartamento(2).ToString();
            terceraZonaArriendo.Text = "Marzo: $";
            cantidadTerceraZona.Text = GananciaSegunAñoDepartamento(3).ToString();
            Label1.Text = "Abril: $";
            Label2.Text = GananciaSegunAñoDepartamento(4).ToString();
            Label3.Text = "Mayo: $";
            Label4.Text = GananciaSegunAñoDepartamento(5).ToString();
            Label5.Text = "Junio: $";
            Label6.Text = GananciaSegunAñoDepartamento(6).ToString();
            Label7.Text = "Julio: $";
            Label8.Text = GananciaSegunAñoDepartamento(7).ToString();
            Label9.Text = "Agosto: $";
            Label10.Text = GananciaSegunAñoDepartamento(8).ToString();
            Label11.Text = "Septiembre: $";
            Label12.Text = GananciaSegunAñoDepartamento(9).ToString();
            Label13.Text = "Octubre: $";
            Label14.Text = GananciaSegunAñoDepartamento(10).ToString();
            Label15.Text = "Noviembre: $";
            Label16.Text = GananciaSegunAñoDepartamento(11).ToString();
            Label17.Text = "Diciembre: $";
            Label18.Text = GananciaSegunAñoDepartamento(12).ToString();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        public void volverReporte(object sender, EventArgs e)
        {
            Response.Redirect("ADMReportes.aspx");
        }

        [Obsolete]
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "aplication/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            DescargarPDF.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 10f, 5f, 10f);
            HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            htmlParser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();
        }
        protected List<ReservaBLL> lista()
        {
            ReservaBLL nuevo = new ReservaBLL();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            foreach (var item in nuevo.listarTodos())
            {
                lista.Add(item);
            }

            return lista;

        }
        protected List<ReservaBLL> MesesConMasGanancias(int año, int idDepto)
        {
            ReservaBLL arr = new ReservaBLL();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            var arriendosOrdenados = arr.listarTodos().OrderByDescending(f => f._valor_final).ToList();

            foreach (var item in arriendosOrdenados)
            {
                if (item._departamento_id_departamento == idDepto)
                {
                    int anho = int.Parse(item._check_Out.ToString("yyyy"));
                    if (año == anho)
                    {
                        lista.Add(item);
                    }
                }
            }
            return lista;
        }

        public int GananciaSegunAñoDepartamento(int mes)
        {
            ReservaBLL arr = new ReservaBLL();
            //DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;

            int año = int.Parse(Session["reporte3Año"].ToString());
            lblAño.Text = " " + año;
            int iddpto = int.Parse(Session["reporte3IDdpto"].ToString());

            foreach (var item in arr.listarTodos())
            {
                if (item._departamento_id_departamento == iddpto)
                {
                    string anho = item._check_Out.ToString("yyyy");
                    string mesh = item._check_Out.ToString("MM");
                    if (int.Parse(anho) == año && int.Parse(mesh) == mes)
                    {
                        cont = cont + item._valor_final;
                    }
                }
            }
            return cont;
        }
    }
}