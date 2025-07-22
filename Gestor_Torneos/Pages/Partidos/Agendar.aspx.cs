using Gestor_Torneos.Logica.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Partidos
{
    public partial class Agendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos();
                CargarPartidos();
            }
        }

        private void CargarTorneos()
        {
            ddlTorneos.DataSource = TorneoService.ObtenerTodos();
            ddlTorneos.DataTextField = "Nombre";
            ddlTorneos.DataValueField = "ID_Torneo";
            ddlTorneos.DataBind();
            ddlTorneos.Items.Insert(0, new ListItem("-- Selecciona un torneo --", "0"));
        }

        protected void ddlTorneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int torneoId = int.Parse(ddlTorneos.SelectedValue);
            var equipos = EquipoService.ObtenerPorTorneo(torneoId);

            ddlEquipo1.DataSource = equipos;
            ddlEquipo1.DataTextField = "Nombre";
            ddlEquipo1.DataValueField = "ID_Equipo";
            ddlEquipo1.DataBind();

            ddlEquipo2.DataSource = equipos;
            ddlEquipo2.DataTextField = "Nombre";
            ddlEquipo2.DataValueField = "ID_Equipo";
            ddlEquipo2.DataBind();
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                int torneoId = int.Parse(ddlTorneos.SelectedValue);
                int equipo1 = int.Parse(ddlEquipo1.SelectedValue);
                int equipo2 = int.Parse(ddlEquipo2.SelectedValue);
                DateTime fecha = DateTime.Parse(txtFecha.Text);

                if (equipo1 == equipo2)
                {
                    MostrarAlerta("Los equipos deben ser distintos.");
                    return;
                }

                PartidoService.AgendarPartido(torneoId, equipo1, equipo2, fecha);
                MostrarAlerta("Partido agendado correctamente.");
                CargarPartidos(); // ✅ Refresca la tabla
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }

        private void CargarPartidos()
        {
            gvPartidos.DataSource = PartidoService.ObtenerResumen();
            gvPartidos.DataBind();
        }

        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

        protected void gvPartidos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPartidos.EditIndex = e.NewEditIndex;
            CargarPartidos();

            GridViewRow row = gvPartidos.Rows[e.NewEditIndex];
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlEquipo1Edit");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlEquipo2Edit");

            int partidoId = (int)gvPartidos.DataKeys[e.NewEditIndex].Value;
            var partido = PartidoService.ObtenerResumen().First(p => p.ID_Partido == partidoId);
            var equipos = EquipoService.ObtenerPorTorneo(partido.ID_Torneo);

            if (ddl1 != null && ddl2 != null)
            {
                ddl1.CssClass = "form-select";
                ddl2.CssClass = "form-select";

                ddl1.DataSource = equipos;
                ddl1.DataTextField = "Nombre";
                ddl1.DataValueField = "ID_Equipo";
                ddl1.DataBind();

                ddl2.DataSource = equipos;
                ddl2.DataTextField = "Nombre";
                ddl2.DataValueField = "ID_Equipo";
                ddl2.DataBind();

                ddl1.Items.Insert(0, new ListItem("-- Equipo 1 --", "0"));
                ddl2.Items.Insert(0, new ListItem("-- Equipo 2 --", "0"));

                if (ddl1.Items.FindByValue(partido.ID_Equipo1.ToString()) != null)
                    ddl1.SelectedValue = partido.ID_Equipo1.ToString();

                if (ddl2.Items.FindByValue(partido.ID_Equipo2.ToString()) != null)
                    ddl2.SelectedValue = partido.ID_Equipo2.ToString();
            }
        }

        protected void gvPartidos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idPartido = Convert.ToInt32(gvPartidos.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvPartidos.Rows[e.RowIndex];
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlEquipo1Edit");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlEquipo2Edit");
            TextBox txtFecha = (TextBox)row.FindControl("txtFechaEdit");

            int equipo1 = int.Parse(ddl1.SelectedValue);
            int equipo2 = int.Parse(ddl2.SelectedValue);
            DateTime fecha = DateTime.Parse(txtFecha.Text);

            if (equipo1 == equipo2)
            {
                MostrarAlerta("Los equipos deben ser distintos.");
                return;
            }

            PartidoService.Actualizar(idPartido, equipo1, equipo2, fecha);

            gvPartidos.EditIndex = -1;
            CargarPartidos();
        }

        protected void gvPartidos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPartidos.EditIndex = -1;
            CargarPartidos();
        }

        protected void gvPartidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPartidos.DataKeys[e.RowIndex].Value);
            PartidoService.Eliminar(id);
            CargarPartidos();
        }
    }
}
