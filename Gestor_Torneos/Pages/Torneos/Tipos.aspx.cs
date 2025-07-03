using Gestor_Torneos.Logica.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Torneos
{
    public partial class Tipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
                gvTiposTorneo.DataBind();
            }
        }

        protected void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreTipo.Text.Trim();
                if (!string.IsNullOrEmpty(nombre))
                {
                    TipoTorneoService.Insertar(nombre);
                    txtNombreTipo.Text = "";
                    gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
                    gvTiposTorneo.DataBind();
                    MostrarAlerta("Tipo de torneo agregado correctamente.");
                }
                else
                {
                    MostrarAlerta("El nombre no puede estar vacío.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }

        protected void gvTiposTorneo_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int tipoId = Convert.ToInt32(gvTiposTorneo.DataKeys[e.RowIndex].Value);
                TipoTorneoService.Eliminar(tipoId);
                gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
                gvTiposTorneo.DataBind();
                MostrarAlerta("Tipo de torneo eliminado.");
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
        protected void gvTiposTorneo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTiposTorneo.EditIndex = e.NewEditIndex;
            gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
            gvTiposTorneo.DataBind();
        }

        protected void gvTiposTorneo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTiposTorneo.EditIndex = -1;
            gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
            gvTiposTorneo.DataBind();
        }

        protected void gvTiposTorneo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int tipoId = Convert.ToInt32(gvTiposTorneo.DataKeys[e.RowIndex].Value);
                string nuevoNombre = ((TextBox)gvTiposTorneo.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();

                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    TipoTorneoService.Actualizar(tipoId, nuevoNombre);
                    MostrarAlerta("Tipo de torneo actualizado correctamente.");
                }
                else
                {
                    MostrarAlerta("El nombre no puede estar vacío.");
                }

                gvTiposTorneo.EditIndex = -1;
                gvTiposTorneo.DataSource = TipoTorneoService.ObtenerTodos();
                gvTiposTorneo.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al actualizar: " + ex.Message);
            }
        }

    }
}