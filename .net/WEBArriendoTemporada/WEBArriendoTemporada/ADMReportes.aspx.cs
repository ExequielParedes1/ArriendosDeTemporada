using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;
using System.Web.Services;


namespace WEBArriendoTemporada
{
    public partial class WEBReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            ReservaBLL arr = new ReservaBLL();

            anhoFiltro.DataBind();

            prueba.Value = cantidadPorZona("Concepcion").ToString();
            gananciaConcepcion.Text = "$" + string.Format("{0:#,##0}", cantidadDineroPorZona("Concepcion"));
            penco.Value = cantidadPorZona("Penco").ToString();
            gananciaPenco.Text = "$" + string.Format("{0:#,##0}", cantidadDineroPorZona("Penco"));
            tome.Value = cantidadPorZona("Tome").ToString();
            GananciaTome.Text = "$" + string.Format("{0:#,##0}", cantidadDineroPorZona("Tome"));
            San_Pedro.Value = cantidadPorZona("San Pedro").ToString();
            GananciaSanPedro.Text = "$" + string.Format("{0:#,##0}", cantidadDineroPorZona("San Pedro"));
            tituloFecha.Value = "Reporte total";
            #region reporte 2

            int año = 2019;
            Año.Value = 2019.ToString();
            EneroGanancia.Value = GananciaSegunMes(año, 1).ToString();
            FebreroGanancia.Value = GananciaSegunMes(año, 2).ToString();
            MarzoGanancia.Value = GananciaSegunMes(año, 3).ToString();
            AbrilGanancia.Value = GananciaSegunMes(año, 4).ToString();
            MayoGanancia.Value = GananciaSegunMes(año, 5).ToString();
            JunioGnancia.Value = GananciaSegunMes(año, 6).ToString();
            JulioGanancia.Value = GananciaSegunMes(año, 7).ToString();
            AgostoGanancia.Value = GananciaSegunMes(año, 8).ToString();
            SeptiembreGanancia.Value = GananciaSegunMes(año, 9).ToString();
            OctubreGanancia.Value = GananciaSegunMes(año, 10).ToString();
            NoviambreGanancia.Value = GananciaSegunMes(año, 11).ToString();
            DiciembreGanancia.Value = GananciaSegunMes(año, 12).ToString();
            #endregion

            #region Reporte3

            //int añodpto = 2019;
            //AñoDepartamento.Value = 2019.ToString();
            //int idDept = 263;
            //EneroDepartament.Value = GananciaSegunAñoDepartamento(añodpto, 1, idDept).ToString();
            //FebreroDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 2, idDept).ToString();
            //MarzoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 3, idDept).ToString();
            //AbrilDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 4, idDept).ToString();
            //MayoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 5, idDept).ToString();
            //JunioDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 6, idDept).ToString();
            //JulioDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 7, idDept).ToString();
            //AgostoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 8, idDept).ToString();
            //SeptiembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 9, idDept).ToString();
            //OctubreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 10, idDept).ToString();
            //NoviembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 11, idDept).ToString();
            //DiciembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 12, idDept).ToString();
            #endregion


            DepartamentoBLL dpto = new DepartamentoBLL();
            List<object> lista = new List<Object>();

            foreach (var item in dpto.listarTodosDptos())
            {
                System.Web.UI.WebControls.ListItem i;
                i = new System.Web.UI.WebControls.ListItem(item._Direccion, item.idDepartamento.ToString());
                drop_listaDepartamentos.Items.Add(i);
            }


            //drop_listaDepartamentos.DataBind();



            string añoStr = pruebaASD.SelectedItem.ToString();
            Session["reporte2"] = añoStr;
        }
        public void validarTipoUsuario()
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = (UsuarioBLL)Session["usuario"];
            if (nuevo == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (!nuevo._tipo.Equals("admin"))
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
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
        public int cantidadDineroPorZona(string zona)
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
                            cont = cont + item._valor_final;
                        }

                    }
                }

            }
            return cont;
        }
        public int cantidadPorZonaFecha(string zona, DateTime inicio, DateTime final)
        {
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                if (item._check_in >= inicio && item._check_Out <= final)
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
        public int GananciaPorZonaFecha(string zona, DateTime inicio, DateTime final)
        {
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                if (item._check_in >= inicio && item._check_Out <= final)
                {
                    foreach (var item2 in dpto.listarTodosDptos())
                    {
                        if (item._departamento_id_departamento == item2.idDepartamento)
                        {
                            if (item2._Zona.Equals(zona))
                            {
                                cont = cont + item._valor_final;
                            }

                        }
                    }
                }

            }
            return cont;
        }
        public void click_filtrar_zona(object sender, EventArgs e)
        {
            if (txtComienzo.Text.Equals("") || txtTermino.Text.Equals(""))
            {
                Response.Redirect("ADMReportes.aspx");
            }
            else
            {
                DateTime inicio = Convert.ToDateTime(txtComienzo.Text);
                DateTime final = Convert.ToDateTime(txtTermino.Text);

                prueba.Value = cantidadPorZonaFecha("Concepcion", inicio, final).ToString();
                gananciaConcepcion.Text = "$" + string.Format("{0:#,##0}", GananciaPorZonaFecha("Concepcion", inicio, final));
                penco.Value = cantidadPorZonaFecha("Penco", inicio, final).ToString();
                gananciaPenco.Text = "$" + string.Format("{0:#,##0}", GananciaPorZonaFecha("Penco", inicio, final));
                tome.Value = cantidadPorZonaFecha("Tome", inicio, final).ToString();
                GananciaTome.Text = "$" + string.Format("{0:#,##0}", GananciaPorZonaFecha("Tome", inicio, final));
                tituloFecha.Value = "Reporte desde " + inicio.ToString("dd:MM:yyyy") + " hasta " + final.ToString("dd:MM:yyyy");

                Session["reporte1"] = "Reporte desde " + inicio.ToString("dd/MM/yyyy") + " hasta " + final.ToString("dd:MM:yyyy");
                Session["reporte1FechaInicio"] = txtComienzo.Text;
                Session["reporte1FechaFinal"] = txtTermino.Text;
                txtComienzo.Text = "";
                txtTermino.Text = "";
            }

        }
        [WebMethod]
        public static double Sumar(double Valor1, double Valor2)
        {
            return Valor1 + Valor2;
        }

        public int GananciaSegunMes(int año, int mes)
        {
            ReservaBLL arr = new ReservaBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            int cont = 0;
            foreach (var item in arr.listarTodos())
            {
                string anho = item._check_Out.ToString("yyyy");
                string mesh = item._check_Out.ToString("MM");
                if (int.Parse(anho) == año && int.Parse(mesh) == mes)
                {
                    cont = cont + item._valor_final;
                }

            }
            return cont;
        }
        public int GananciaSegunAñoDepartamento(int año, int mes, int idDepartamento)
        {
            ReservaBLL arr = new ReservaBLL();
            
            int cont = 0;

            foreach (var item in arr.listarTodos())
            {

                if (item._departamento_id_departamento == idDepartamento)
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
        public List<Object> listarAnhos()
        {
            List<Object> lista = new List<object>();
            ReservaBLL arr = new ReservaBLL();

            foreach (var item in arr.listarTodos())
            {
                lista.Add(item._check_Out.ToString("yyyy"));
            }

            return lista;
        }
        public List<string> listaFinal()
        {
            Dictionary<string, int> uniqueStore = new Dictionary<string, int>();
            List<string> finalList = new List<string>();
            foreach (string currValue in listarAnhos())
            {
                if (!uniqueStore.ContainsKey(currValue))
                {
                    uniqueStore.Add(currValue, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }

        public void clic_filtrar_ganancia(object sender, EventArgs e)
        {
            string añoStr = pruebaASD.SelectedItem.ToString();
            Session["reporte2"] = añoStr;
            
            int año = int.Parse(añoStr);

            EneroGanancia.Value = GananciaSegunMes(año, 1).ToString();
            FebreroGanancia.Value = GananciaSegunMes(año, 2).ToString();
            MarzoGanancia.Value = GananciaSegunMes(año, 3).ToString();
            AbrilGanancia.Value = GananciaSegunMes(año, 4).ToString();
            MayoGanancia.Value = GananciaSegunMes(año, 5).ToString();
            JunioGnancia.Value = GananciaSegunMes(año, 6).ToString();
            JulioGanancia.Value = GananciaSegunMes(año, 7).ToString();
            AgostoGanancia.Value = GananciaSegunMes(año, 8).ToString();
            SeptiembreGanancia.Value = GananciaSegunMes(año, 9).ToString();
            OctubreGanancia.Value = GananciaSegunMes(año, 10).ToString();
            NoviambreGanancia.Value = GananciaSegunMes(año, 11).ToString();
            DiciembreGanancia.Value = GananciaSegunMes(año, 12).ToString();





        }
        public void filtroDepartamento(object sender, EventArgs e)
        {


            int añodpto = int.Parse(añoDptoFiltro.SelectedItem.ToString());
            int idDept = int.Parse(drop_listaDepartamentos.SelectedValue);

            Session["reporte3Año"] = añodpto;
            Session["reporte3IDdpto"] = idDept;
            Session["nombreDepto"] = drop_listaDepartamentos.SelectedItem.ToString();
            anhoFiltro.DataSource = this.listaFinal();
           

            AñoDepartamento.Value = añodpto.ToString();
            EneroDepartament.Value = GananciaSegunAñoDepartamento(añodpto, 1, idDept).ToString();
            FebreroDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 2, idDept).ToString();
            MarzoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 3, idDept).ToString();
            AbrilDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 4, idDept).ToString();
            MayoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 5, idDept).ToString();
            JunioDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 6, idDept).ToString();
            JulioDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 7, idDept).ToString();
            AgostoDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 8, idDept).ToString();
            SeptiembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 9, idDept).ToString();
            OctubreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 10, idDept).ToString();
            NoviembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 11, idDept).ToString();
            DiciembreDepartamento.Value = GananciaSegunAñoDepartamento(añodpto, 12, idDept).ToString();

            DepartamentoBLL dptoment = new DepartamentoBLL();

            foreach (var item in dptoment.listarTodosDptos())
            {

                System.Web.UI.WebControls.ListItem i;
                i = new System.Web.UI.WebControls.ListItem(item._Direccion, item.idDepartamento.ToString());
                drop_listaDepartamentos.Items.Add(i);
            }


        }

        public void generarReporte1(object sender, EventArgs e)
        {

            Response.Redirect("ADMVer_reporte.aspx");
        }
        public void clic_ver_reporte_2(object sender, EventArgs e)
        {
            Response.Redirect("ADMVer_reporte_2.aspx");
        }
        public void clic_ver_reporte_3(object sender, EventArgs e)
        {
            Response.Redirect("ADMVer_reporte_3.aspx");
        }

    }
}