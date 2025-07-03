using Gestor_Torneos.Logica.BusinessLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Jugadores
{
    public partial class RegistrarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarJugadores();
                CargarEquipos();
                gvJugadoresEquipos.DataBind();
            }
        }

        private void CargarJugadores()
        {
            ddlJugadores.DataBind();
            ddlJugadores.Items.Insert(0, new ListItem("Seleccione un jugador", ""));
        }

        private void CargarEquipos()
        {
            ddlEquipos.DataBind();
            ddlEquipos.Items.Insert(0, new ListItem("Seleccione un equipo", ""));
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ddlJugadores.SelectedValue, out int jugadorId) &&
                int.TryParse(ddlEquipos.SelectedValue, out int equipoId))
            {
                string resultado = JugadorEquipoService.AsignarJugadorAEquipo(jugadorId, equipoId);
                lblMensaje.Text = resultado;
                CargarJugadores();
                CargarEquipos();
                gvJugadoresEquipos.DataBind();
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar un jugador y un equipo.";
            }
        }

        protected void gvJugadoresEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int jugadorId = Convert.ToInt32(gvJugadoresEquipos.DataKeys[e.RowIndex].Values["JugadorId"]);
                int equipoId = Convert.ToInt32(gvJugadoresEquipos.DataKeys[e.RowIndex].Values["ID_Equipo"]);

                string resultado = JugadorEquipoService.EliminarAsignacion(jugadorId, equipoId);

                // Cancela la eliminación automática del SqlDataSource
                e.Cancel = true;

                gvJugadoresEquipos.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{resultado}');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }
    }
}
