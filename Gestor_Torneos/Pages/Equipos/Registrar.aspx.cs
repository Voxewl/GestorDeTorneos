using Gestor_Torneos.Logica.BusinessLogic;
using Gestor_Torneos.Logica.Models;
using System;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Equipos
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarEquipos();
        }

        protected void btnRegistrarEquipo_Click(object sender, EventArgs e)
        {
            var equipo = new Equipo
            {
                Nombre = txtNombreEquipo.Text.Trim()
            };

            string resultado = EquipoService.RegistrarEquipo(equipo);

            ltlMensaje.Text = $"<div class='alert {(resultado.Contains("correctamente") ? "alert-success" : "alert-danger")}'>{resultado}</div>";

            if (resultado.Contains("correctamente"))
            {
                txtNombreEquipo.Text = "";
                CargarEquipos();
            }
        }

        private void CargarEquipos()
        {
            gvEquipos.DataBind(); // Usa SqlDataSource
        }

        protected void gvEquipos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEquipos.EditIndex = e.NewEditIndex;
            CargarEquipos();
        }

        protected void gvEquipos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEquipos.EditIndex = -1;
            CargarEquipos();
        }

        protected void gvEquipos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvEquipos.DataKeys[e.RowIndex].Value);
            string nuevoNombre = ((TextBox)gvEquipos.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();

            var equipo = new Equipo
            {
                ID_Equipo = id,
                Nombre = nuevoNombre
            };

            string resultado = EquipoService.ActualizarEquipo(equipo);

            ltlMensaje.Text = $"<div class='alert {(resultado.Contains("correctamente") ? "alert-success" : "alert-danger")}'>{resultado}</div>";

            gvEquipos.EditIndex = -1;
            CargarEquipos();
        }

        protected void gvEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEquipos.DataKeys[e.RowIndex].Value);

            string resultado = EquipoService.EliminarEquipo(id);

            ltlMensaje.Text = $"<div class='alert alert-warning'>{resultado}</div>";

            CargarEquipos();
        }
    }
}
