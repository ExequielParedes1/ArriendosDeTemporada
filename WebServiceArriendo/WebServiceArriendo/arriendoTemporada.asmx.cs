using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceArriendo.negocio;

namespace WebServiceArriendo
{
    /// <summary>
    /// Descripción breve de arriendoTemporada
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class arriendoTemporada : System.Web.Services.WebService
    {
        #region Usuario
        [WebMethod]
        public int AgregarUsuario(UsuarioBLL usr)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            return nuevo.agregarUsuarioBLL(usr);
        }
        [WebMethod]
        public List<UsuarioBLL> ListarUsuario()
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            return nuevo.ListarUsuarioBLL();
        }
        [WebMethod]
        public int ModificarUsuario(UsuarioBLL usr)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            return nuevo.ModificarUsuarioBLL(usr);
        }
        #endregion
        #region Reserva
        [WebMethod]
        public int AgregarReserva(ReservaBLL arr)
        {
            ReservaBLL nuevo = new ReservaBLL();
            return nuevo.AgregarReservaBLL(arr);
        }
        [WebMethod]
        public List<ReservaBLL> ListarReserva()
        {
            ReservaBLL modelo = new ReservaBLL();
            return modelo.ListarReservaBLL();
        }
        [WebMethod]
        public int ModificarReserva(ReservaBLL arr)
        {
            ReservaBLL modelo = new ReservaBLL();
            return modelo.ModificarReservaBLL(arr);
        }
        #endregion
        #region Caracteristica
        [WebMethod]
        public List<CaracteristicaBLL> listarCaracteristicas()
        {
            CaracteristicaBLL modelo = new CaracteristicaBLL();
            return modelo.listarCaracteristicasBLL();
        }
        [WebMethod]
        public int ModificarCaracteristica(CaracteristicaBLL nuevo)
        {
            CaracteristicaBLL modelo = new CaracteristicaBLL();
            return modelo.ModificarCaracteristicaBLL(nuevo);
        }
        [WebMethod]
        public int AgregarCaracteristica(CaracteristicaBLL nuevo)
        {
            CaracteristicaBLL modelo = new CaracteristicaBLL();
            return modelo.AgregarCaracteristicaBLL(nuevo);
        }
        [WebMethod]
        public int EliminarCarateristica(int idCaracteristica)
        {
            CaracteristicaBLL modelo = new CaracteristicaBLL();
            return modelo.EliminarCarateristicaBLL(idCaracteristica);
        }
        #endregion
        #region Conductor
        [WebMethod]
        public List<ConductorBLL> ListarConductor()
        {
            ConductorBLL nuevo = new ConductorBLL();
            return nuevo.ListarConductorBLL();
        }
        [WebMethod]
        public int ModificarConductor(ConductorBLL con)
        {
            ConductorBLL nuevo = new ConductorBLL();
            return nuevo.ModificarConductorBLL(con);
        }
        [WebMethod]
        public int AgregarConductor(ConductorBLL con)
        {
            ConductorBLL nuevo = new ConductorBLL();
            return nuevo.AgregarConductorBLL(con);
        }
        #endregion
        #region Departamento
        [WebMethod]
        public List<DepartamentoBLL> ListarDepartamento()
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            return nuevo.ListarDepartamentoBLL();
        }
        [WebMethod]
        public int AgregarDepartamento(DepartamentoBLL dpto)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            return nuevo.AgregarDepartamentoBLL(dpto);
        }
        [WebMethod]
        public int ModificarDepartamento(DepartamentoBLL dpto)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            return nuevo.ModificarDepartamentoBLL(dpto);
        }
        #endregion
        #region DetalleMulta
        [WebMethod]
        public List<DetalleMultaBLL> ListarDetalleMulta()
        {
            DetalleMultaBLL nuevo = new DetalleMultaBLL();
            return nuevo.ListarDetalleMultaBLL();
        }
        [WebMethod]
        public int AgregarDetalleMulta(DetalleMultaBLL dm)
        {
            DetalleMultaBLL nuevo = new DetalleMultaBLL();
            return nuevo.AgregarDetalleMultaBLL(dm);
        }
        #endregion
        #region Encargado
        [WebMethod]
        public List<EncargadoBLL> ListarEncargado()
        {
            EncargadoBLL nuevo = new EncargadoBLL();
            return nuevo.ListarEncargadoBLL();
        }
        [WebMethod]
        public int AgregarEncargado(EncargadoBLL en)
        {
            EncargadoBLL nuevo = new EncargadoBLL();
            return nuevo.AgregarEncargadoBLL(en);
        }
        [WebMethod]
        public int ModificarEncargado(EncargadoBLL en)
        {
            EncargadoBLL nuevo = new EncargadoBLL();
            return nuevo.ModificarEncargadoBLL(en);
        }
        #endregion
        #region Acompanante
        [WebMethod]
        public List<AcompananteBLL> ListarAcompanante()
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            return nuevo.ListarAcompananteBLL();
        }
        [WebMethod]
        public int AgregarAcompanante(AcompananteBLL hu)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            return nuevo.agregarAcompanante(hu);
        }
        [WebMethod]
        public int ModificarAcompanante(AcompananteBLL hr)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            return nuevo.ModificarAcompananteBLL(hr);
        }
        [WebMethod]
        public int EliminarAcompanante(string cedula)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            return nuevo.EliminarAcompananteBLL(cedula);
        }
        #endregion
        #region Involucrado
        [WebMethod]
        public int AgregarInvolucrado(InvolucradoBLL inv)
        {
            InvolucradoBLL nuevo = new InvolucradoBLL();
            return nuevo.AgregarInvolucradoBLL(inv);
        }
        [WebMethod]
        public List<InvolucradoBLL> ListaInvolucrado()
        {
            InvolucradoBLL nuevo = new InvolucradoBLL();
            return nuevo.ListarInvolucradoBLL();
        }
        [WebMethod]
        public int EliminarAsociacionFuncionario(InvolucradoBLL inv)
        {
            InvolucradoBLL nuevo = new InvolucradoBLL();
            return nuevo.eliminarAsociacionFuncionario(inv);
        }
        #endregion
        #region ListaCaracteristica
        [WebMethod]
        public int AgregarListaCaracteristica(ListaCaracteristicasBLL lc)
        {
            ListaCaracteristicasBLL nuevo = new ListaCaracteristicasBLL();
            return nuevo.AgregarListaCaracteristicaBLL(lc);
        }
        [WebMethod]
        public int EliminarListaCaracteristica(ListaCaracteristicasBLL lc)
        {
            ListaCaracteristicasBLL nuevo = new ListaCaracteristicasBLL();
            return nuevo.eliminarListaCaracteristicaBLL(lc);
        }
        [WebMethod]
        public List<ListaCaracteristicasBLL> ListarListaCaracteristica()
        {
            ListaCaracteristicasBLL nuevo = new ListaCaracteristicasBLL();
            return nuevo.listarCaracteristicaBLL();
        }
        #endregion
        #region ListaAcompanantes
        [WebMethod]
        public int AgregarListaAcompanante(ListaAcompBLL lh)
        {
            ListaAcompBLL nuevo = new ListaAcompBLL();
            return nuevo.agregarListaAcompananteBLL(lh);
        }
        [WebMethod]
        public List<ListaAcompBLL> ListarListaAcompanante()
        {
            ListaAcompBLL nuevo = new ListaAcompBLL();
            return nuevo.listarListaAcompanante();
        }
        [WebMethod]
        public int EliminarListaAcompanante(ListaAcompBLL lh)
        {
            ListaAcompBLL nuevo = new ListaAcompBLL();
            return nuevo.eliminarListaAcompananteBLL(lh);
        }
        #endregion
        #region Mantencion
        [WebMethod]
        public List<MantencionBLL> ListarMantencion()
        {
            MantencionBLL nuevo = new MantencionBLL();
            return nuevo.ListarMantecionBLL();
        }
        [WebMethod]
        public int AgregarMantencion(MantencionBLL man)
        {
            MantencionBLL nuevo = new MantencionBLL();
            return nuevo.AgregarMantecionBLL(man);
        }
        [WebMethod]
        public int ModificarMantencion(MantencionBLL man)
        {
            MantencionBLL nuevo = new MantencionBLL();
            return nuevo.ModificarMantencionBLL(man);
        }
        #endregion
        #region Multa
        [WebMethod]
        public int AgregarMulta(MultaBLL mul)
        {
            MultaBLL nuevo = new MultaBLL();
            return nuevo.AgregarMultaBLL(mul);
        }
        [WebMethod]
        public List<MultaBLL> ListarMulta()
        {
            MultaBLL nuevo = new MultaBLL();
            return nuevo.ListarMultaBLL();
        }
        [WebMethod]
        public int ModificarMulta(MultaBLL mul)
        {
            MultaBLL nuevo = new MultaBLL();
            return nuevo.ModificarMultaBLL(mul);
        }
        #endregion
        #region Vehiculo
        [WebMethod]
        public int AgregarVehiculo(VehiculoBLL vh)
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            return nuevo.agregarVehiculo(vh);
        }
        [WebMethod]
        public int ModificarVehiculo(VehiculoBLL vh)
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            return nuevo.editarehiculo(vh);
        }
        [WebMethod]
        public List<VehiculoBLL> ListarVehiculo()
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            return nuevo.ListarVehiculoBLL();
        }
        #endregion
        #region Foto

        [WebMethod]
        public int AgregarFoto(FotoBLL nueva)
        {
            FotoBLL nuevo = new FotoBLL();
            return nueva.agregarFoto(nueva);
        }
        [WebMethod]
        public List<FotoBLL> listarImagenes()
        {
            FotoBLL nuevo = new FotoBLL();
            return nuevo.listarImagenes();
        }
        [WebMethod]
        public int EliminarFoto(int nueva)
        {
            FotoBLL nuevo = new FotoBLL();
            return nuevo.eliminarFoto(nueva);
        }
        #endregion
        #region Item
        [WebMethod]
        public int AgregarItem(ItemBLL otro)
        {
            ItemBLL nuevo = new ItemBLL();
            return nuevo.agregarItemBLL(otro);
        }
        [WebMethod]
        public List<ItemBLL> ListarItem()
        {
            ItemBLL nuevo = new ItemBLL();
            return nuevo.listarItemBLL();
        }
        [WebMethod]
        public int EliminarItem(int id)
        {
            ItemBLL nuevo = new ItemBLL();
            return nuevo.eliminarItemBLL(id);
        }
        #endregion
        #region RegistroInventario
        [WebMethod]
        public int AgregarRegistroInventario(InventarioBLL ri)
        {
            InventarioBLL nuevo = new InventarioBLL();
            return nuevo.agregarRegistroInventarioBLL(ri);
        }
        [WebMethod]
        public List<InventarioBLL> ListarRegistroInventario()
        {
            InventarioBLL nuevo = new InventarioBLL();
            return nuevo.ListaRegistroInventarioBLL();
        }
        [WebMethod]
        public int eliminarRegistroInventario(InventarioBLL inv)
        {
            InventarioBLL nuevo = new InventarioBLL();
            return nuevo.eliminarInventarioBLL(inv);
        }
        [WebMethod]
        public int modificarRegistroInventario(InventarioBLL inv)
        {
            InventarioBLL nuevo = new InventarioBLL();
            return nuevo.modificarInventario(inv);
        }
        #endregion
        #region Viaje
        [WebMethod]
        public int AgregarViaje(ViajeBLL nuevo)
        {
            ViajeBLL via = new ViajeBLL();
            return via.AgregarViajeBLL(nuevo);
        }
        [WebMethod]
        public List<ViajeBLL> ListarViaje()
        {
            ViajeBLL nuevo = new ViajeBLL();
            return nuevo.ListarViajeBLL();
        }
        [WebMethod]
        public int ModificarViaje(ViajeBLL viaje)
        {
            ViajeBLL nuevo = new ViajeBLL();
            return nuevo.ModificarViajeBLL(viaje);
        }
        #endregion
        #region ServicioExtra
        [WebMethod]
        public int AgregarServicioExtra(ServicioExtraBLL se)
        {
            ServicioExtraBLL nuevo = new ServicioExtraBLL();
            return nuevo.agregarServicioExtraBLL(se);
        }
        [WebMethod]
        public List<ServicioExtraBLL> ListarServicioExtra()
        {
            ServicioExtraBLL nuevo = new ServicioExtraBLL();
            return nuevo.ListarServicioExtraBLL();
        }
        [WebMethod]
        public int ModificarServicioExtra(ServicioExtraBLL sr)
        {
            ServicioExtraBLL nuevo = new ServicioExtraBLL();
            return nuevo.modificarServicioExtraBLL(sr);
        }
        #endregion
        #region Revision
        [WebMethod]
        public int AgregarRevision(RevisionBLL rev)
        {
            RevisionBLL nuevo = new RevisionBLL();
            return nuevo.AgregarRevisionBLL(rev);
        }
        [WebMethod]
        public int ModificarRevision(RevisionBLL rev)
        {
            RevisionBLL nuevo = new RevisionBLL();
            return nuevo.ModificarRevisionBLL(rev);
        }
        [WebMethod]
        public List<RevisionBLL> ListarRevision()
        {
            RevisionBLL nuevo = new RevisionBLL();
            return nuevo.ListaRevisionBLL();
        }
        #endregion
    }
}
