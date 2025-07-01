using Gestor_Torneos.Logica.BusinessLogic;
using Gestor_Torneos.Logica.DataAccess;
using Gestor_Torneos.Logica.Models;
using System;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages.Jugadores
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        private void CargarUsuarios()
        {
            ddlUsuarios.DataSource = UsuarioDAO.ObtenerTodos();
            ddlUsuarios.DataTextField = "UserName";
            ddlUsuarios.DataValueField = "Id";
            ddlUsuarios.DataBind();
            ddlUsuarios.Items.Insert(0, new ListItem("Seleccione un usuario", ""));
        }

        private void CargarJugadores()
        {
            //gvJugadores.DataSource = JugadorService.ObtenerTodos();
            gvJugadores.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var jugador = new Jugador
            {
                UserId = ddlUsuarios.SelectedValue,
                Alias = txtAlias.Text.Trim()
            };

            string mensaje = JugadorService.RegistrarJugador(jugador);
            ltlMensaje.Text = $"<div class='alert alert-info'>{mensaje}</div>";
            CargarJugadores();
        }

        protected void gvJugadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJugadores.EditIndex = e.NewEditIndex;
            CargarJugadores();
        }

        protected void gvJugadores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvJugadores.EditIndex = -1;
            CargarJugadores();
        }

        protected void gvJugadores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int jugadorId = (int)gvJugadores.DataKeys[e.RowIndex].Value;
            string alias = ((TextBox)gvJugadores.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            Jugador jugador = new Jugador
            {
                JugadorId = jugadorId,
                Alias = alias
            };

            string mensaje = JugadorService.ActualizarJugador(jugador);
            ltlMensaje.Text = $"<div class='alert alert-info'>{mensaje}</div>";

            gvJugadores.EditIndex = -1;
            CargarJugadores();
        }

        protected void gvJugadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int jugadorId = (int)gvJugadores.DataKeys[e.RowIndex].Value;

            string mensaje = JugadorService.EliminarJugador(jugadorId);
            ltlMensaje.Text = $"<div class='alert alert-danger'>{mensaje}</div>";

            CargarJugadores();
        }
    }
}
