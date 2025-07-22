using Gestor_Torneos.Logica.BusinessLogic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Torneos
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                // Cargar los torneos existentes en el GridView
                CargarTorneos();
            }
        }

        private void CargarTorneos()
        {
           // Usamos el SqlDataSource definido en el front-end
            gvTorneos.DataBind();  // Actualizamos el GridView
        }

        protected void btnRegistrarTorneo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreTorneo = txtNombreTorneo.Text.Trim();
                int tipoId = int.Parse(ddlTipoTorneo.SelectedValue);
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Value).Date;  // Fecha sin hora
                DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Value) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Value).Date; // Fecha sin hora
                string descripcionTorneo = txtDescripcionTorneo.Text.Trim();  // Obtener la descripción

                if (!string.IsNullOrEmpty(nombreTorneo))
                {
                    // Registrar el torneo
                    TorneoService.Insertar(nombreTorneo, tipoId, fechaInicio, fechaFin, descripcionTorneo);
                    CargarTorneos();  // Actualizar el GridView
                    MostrarAlerta("Torneo registrado exitosamente.");
                }
                else
                {
                    MostrarAlerta("El nombre del torneo no puede estar vacío.");
                }
            }
            catch (ArgumentException ex)
            {
                MostrarAlerta(ex.Message);  // Mostramos el mensaje de validación de fecha
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }

        protected void gvTorneos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener los controles editables
            GridViewRow row = gvTorneos.Rows[e.RowIndex];
            TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
            DropDownList ddlTipos = (DropDownList)row.FindControl("ddlTipos");
            TextBox txtFechaInicio = (TextBox)row.FindControl("txtFechaInicio");
            TextBox txtFechaFin = (TextBox)row.FindControl("txtFechaFin");
            TextBox txtDescripcion = (TextBox)row.FindControl("txtDescripcion");

            // Obtener el ID del torneo
            int idTorneo = (int)gvTorneos.DataKeys[e.RowIndex].Value;

            // Validar fechas
            if (DateTime.Parse(txtFechaInicio.Text) > DateTime.Parse(txtFechaFin.Text))
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    "alert('La fecha de inicio no puede ser posterior a la fecha de fin');", true);
                return;
            }

            try
            {
                // Actualizar usando tu capa de negocio
                TorneoService.Actualizar(
                    idTorneo,
                    txtNombre.Text,
                    int.Parse(ddlTipos.SelectedValue),
                    DateTime.Parse(txtFechaInicio.Text),
                    string.IsNullOrEmpty(txtFechaFin.Text) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Text),
                    txtDescripcion.Text
                );
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('Error al actualizar: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }

        protected void gvTorneos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTorneos.EditIndex = -1;
            CargarTorneos(); // Método que enlaza los datos al GridView
        }

        protected void gvTorneos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTorneos.EditIndex = e.NewEditIndex;
            CargarTorneos();
        }

        protected void gvTorneos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idTorneo = Convert.ToInt32(gvTorneos.DataKeys[e.RowIndex].Value);
                TorneoService.Eliminar(idTorneo);
                CargarTorneos();  // Actualizar el GridView
                MostrarAlerta("Torneo eliminado.");
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al eliminar: " + ex.Message);
            }
        }

        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}
