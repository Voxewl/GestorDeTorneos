using Gestor_Torneos.Logica.BusinessLogic;
using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Torneos
{
    public partial class AsignarATorneo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos();
                CargarEquipos(); // Carga inicial con todos los equipos (sin torneo seleccionado)
            }
        }

        private void CargarTorneos()
        {
            ddlTorneos.DataSource = TorneoService.ObtenerTodos();
            ddlTorneos.DataTextField = "Nombre";
            ddlTorneos.DataValueField = "ID_Torneo";
            ddlTorneos.DataBind();
            ddlTorneos.Items.Insert(0, new ListItem("-- Selecciona --", "0"));
        }

        private void CargarEquipos()
        {
            ddlEquipos.DataSource = EquipoService.ObtenerTodos();
            ddlEquipos.DataTextField = "Nombre";
            ddlEquipos.DataValueField = "ID_Equipo";
            ddlEquipos.DataBind();
        }

        private void CargarEquiposNoAsignados(int torneoId)
        {
            var todos = EquipoService.ObtenerTodos();
            var asignados = EquipoTorneoDAO.ObtenerTodos()
                               .Where(et => et.ID_Torneo == torneoId)
                               .Select(et => et.ID_Equipo)
                               .ToHashSet();

            var disponibles = todos.Where(e => !asignados.Contains(e.ID_Equipo)).ToList();

            ddlEquipos.DataSource = disponibles;
            ddlEquipos.DataTextField = "Nombre";
            ddlEquipos.DataValueField = "ID_Equipo";
            ddlEquipos.DataBind();

            if (!disponibles.Any())
            {
                ddlEquipos.Items.Insert(0, new ListItem("-- Todos asignados --", "0"));
                ddlEquipos.Enabled = false;
            }
            else
            {
                ddlEquipos.Enabled = true;
            }
        }

        protected void ddlTorneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int torneoId = int.Parse(ddlTorneos.SelectedValue);
            if (torneoId > 0)
            {
                CargarEquiposNoAsignados(torneoId);
                CargarAsignados();
            }
            else
            {
                ddlEquipos.Items.Clear();
                gvAsignados.DataSource = null;
                gvAsignados.DataBind();
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int torneoId = int.Parse(ddlTorneos.SelectedValue);
            int equipoId = int.Parse(ddlEquipos.SelectedValue);

            if (torneoId == 0 || equipoId == 0)
            {
                lblMensaje.Text = "Debes seleccionar un torneo y un equipo.";
                return;
            }

            string resultado = EquipoTorneoService.AsignarEquipoATorneo(equipoId, torneoId);
            lblMensaje.Text = resultado;

            // Recargar equipos disponibles y tabla
            CargarEquiposNoAsignados(torneoId);
            CargarAsignados();
        }

        private void CargarAsignados()
        {
            int torneoId = int.Parse(ddlTorneos.SelectedValue);
            if (torneoId == 0) return;

            var asignaciones = EquipoTorneoDAO.ObtenerTodos()
                .Where(et => et.ID_Torneo == torneoId)
                .Join(EquipoService.ObtenerTodos(), et => et.ID_Equipo, e => e.ID_Equipo, (et, e) => new
                {
                    et.ID_Equipo,
                    NombreEquipo = e.Nombre,
                    et.FechaRegistro
                }).ToList();

            gvAsignados.DataSource = asignaciones;
            gvAsignados.DataBind();
        }

        protected void gvAsignados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int torneoId = int.Parse(ddlTorneos.SelectedValue);
            int equipoId = (int)gvAsignados.DataKeys[e.RowIndex].Value;

            EquipoTorneoDAO.EliminarAsignacion(equipoId, torneoId);
            lblMensaje.Text = "Asignación eliminada.";

            // Recargar equipos disponibles y tabla
            CargarEquiposNoAsignados(torneoId);
            CargarAsignados();
        }
    }
}
