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
    public partial class ADMVer_reporte_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int año = int.Parse(Session["reporte2"].ToString());
            lblAño.Text = " " + año;


            //Estaba contra el tiempo
            GridView1.DataSource = MesesConMasGanancias(año);
            GridView1.DataBind();
            primeraZonaArriendo.Text = "Enero: $";
            cantidadPrimeraZona.Text = MesesConMasGanancias(1, año).ToString();
            segundaZonaArriendo.Text = "Febrero: $";
            cantidadSegundaZona.Text = MesesConMasGanancias(2, año).ToString();
            terceraZonaArriendo.Text = "Marzo: $";
            cantidadTerceraZona.Text = MesesConMasGanancias(3, año).ToString();
            Label1.Text = "Abril: $";
            Label2.Text = MesesConMasGanancias(4, año).ToString();
            Label3.Text = "Mayo: $";
            Label4.Text = MesesConMasGanancias(5, año).ToString();
            Label5.Text = "Junio: $";
            Label6.Text = MesesConMasGanancias(6, año).ToString();
            Label7.Text = "Julio: $";
            Label8.Text = MesesConMasGanancias(7, año).ToString();
            Label9.Text = "Agosto: $";
            Label10.Text = MesesConMasGanancias(8, año).ToString();
            Label11.Text = "Septiembre: $";
            Label12.Text = MesesConMasGanancias(9, año).ToString();
            Label13.Text = "Octubre: $";
            Label14.Text = MesesConMasGanancias(10, año).ToString();
            Label15.Text = "Noviembre: $";
            Label16.Text = MesesConMasGanancias(11, año).ToString();
            Label17.Text = "Diciembre: $";
            Label18.Text = MesesConMasGanancias(12, año).ToString();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        public void volverReporte(object sender, EventArgs e)
        {
            Response.Redirect("WEBReportes.aspx");
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
        protected List<ReservaBLL> MesesConMasGanancias(int año)
        {
            ReservaBLL arr = new ReservaBLL();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            var arriendosOrdenados = arr.listarTodos().OrderByDescending(f => f._valor_final).ToList();

            foreach (var item in arriendosOrdenados)
            {
                int anho = int.Parse(item._check_Out.ToString("yyyy"));
                if (año == anho)
                {
                    lista.Add(item);
                }

            }
            return lista;
        }
        protected int MesesConMasGanancias(int mes, int año)
        {
            ReservaBLL arr = new ReservaBLL();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            //  var arriendosOrdenados = arr.listarTodos().OrderByDescending(f => f._check_Out).ToList();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                int numeroMes = int.Parse(item._check_Out.ToString("MM"));
                int anho = int.Parse(item._check_Out.ToString("yyyy"));
                if (mes == numeroMes && anho == año)
                {
                    cont = cont + item._valor_final;
                }
            }
            return cont;

        }
    }
}