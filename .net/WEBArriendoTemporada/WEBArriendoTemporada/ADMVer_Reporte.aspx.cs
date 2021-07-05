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
    public partial class WEBVer_Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reporte1"] == null)
            {
                tiempoArriendo.Text = "Total";
                GridView1.DataSource = listarDeptos();
                GridView1.DataBind();
                string primero = "Concepcion";
                primeraZonaArriendo.Text = primero + " :";
                cantidadPrimeraZona.Text = cantidadPorZona(primero).ToString();

                string segundo = "Penco";
                segundaZonaArriendo.Text = segundo + " :";
                cantidadSegundaZona.Text = cantidadPorZona(segundo).ToString();

                string tercero = "Tome";
                terceraZonaArriendo.Text = tercero + " :";
                cantidadTerceraZona.Text = cantidadPorZona(tercero).ToString();

                string cuarto = "San Pedro";
                terceraZonaArriendo.Text = cuarto + " :";
                cantidadTerceraZona.Text = cantidadPorZona(cuarto).ToString();
            }
            else
            {
                string titulo = Session["reporte1"].ToString();
                tiempoArriendo.Text = titulo;
                DateTime inicio = Convert.ToDateTime(Session["reporte1FechaInicio"]);
                DateTime final = Convert.ToDateTime(Session["reporte1FechaFinal"]);

                GridView1.DataSource = listarDeptosPorFechaArriendo(inicio, final);
                GridView1.DataBind();


                string primero1 = "Concepcion";
                primeraZonaArriendo.Text = primero1 + " :";
                cantidadPrimeraZona.Text = cantidadPorZonaPorFecha(primero1, inicio, final).ToString();

                string segundo2 = "Penco";
                segundaZonaArriendo.Text = segundo2 + " :";
                cantidadSegundaZona.Text = cantidadPorZonaPorFecha(segundo2, inicio, final).ToString();

                string tercero3 = "Tome";
                terceraZonaArriendo.Text = tercero3 + " :";
                cantidadTerceraZona.Text = cantidadPorZonaPorFecha(tercero3, inicio, final).ToString();

                string cuarto4 = "San Pedro";
                terceraZonaArriendo.Text = cuarto4 + " :";
                cantidadTerceraZona.Text = cantidadPorZonaPorFecha(cuarto4, inicio, final).ToString();
            }
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

        public int cantidadPorZona(string zona)
        {
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                foreach (var item2 in dpto.listarTodosDptos())
                {
                    if (item._departamento_id_departamento == item2.idDepartamento)
                    {
                        if (item2._Zona.Equals(zona))
                        {
                            cont++;
                        }

                    }
                }
            }
            return cont;
        }

        public int cantidadPorZonaPorFecha(string zona, DateTime inicio, DateTime final)
        {
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                if (item._check_Out >= inicio && item._check_Out <= final)
                {
                    foreach (var item2 in dpto.listarTodosDptos())
                    {
                        if (item._departamento_id_departamento == item2.idDepartamento)
                        {
                            if (item2._Zona.Equals(zona))
                            {
                                cont++;
                            }

                        }
                    }
                }
            }
            return cont;
        }

        public List<DepartamentoBLL> listarDeptos()
        {
            List<DepartamentoBLL> lista = new List<DepartamentoBLL>();
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();

            foreach (var item in arr.listarTodos())
            {
                foreach (var item2 in dpto.listarTodosDptos())
                {
                    if (item._departamento_id_departamento == item2.idDepartamento)
                    {
                        lista.Add(item2);
                    }
                }
            }
            return lista;
        }

        public List<DepartamentoBLL> listarDeptosPorFechaArriendo(DateTime inicio, DateTime final)
        {
            List<DepartamentoBLL> lista = new List<DepartamentoBLL>();
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();

            foreach (var item in arr.listarTodos())
            {
                if (item._check_Out >= inicio && item._check_Out <= final)
                {
                    foreach (var item2 in dpto.listarTodosDptos())
                    {
                        if (item._departamento_id_departamento == item2.idDepartamento)
                        {
                            lista.Add(item2);
                        }
                    }
                }
            }
            return lista;
        }
    }
}