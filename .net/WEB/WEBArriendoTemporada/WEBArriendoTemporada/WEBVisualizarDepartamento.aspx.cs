using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBVisualizarDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarImagenes();
        }

        protected void ConsultarImagenes()
        {
            FotoBLL nuevo = new FotoBLL();
            Repeater1.DataSource = nuevo.listarImagenes();
            Repeater1.DataBind();
        }
    }
}