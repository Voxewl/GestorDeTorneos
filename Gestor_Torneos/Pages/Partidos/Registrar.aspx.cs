//using Gestor_Torneos.Logica.BusinessLogic;
//using Gestor_Torneos.Logica.Models;
//using System;

//namespace Gestor_Torneos.Pages.Partidos
//{
//    public partial class Registrar : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//                CargarPartidos();
//        }

//        protected void btnRegistrarPartido_Click(object sender, EventArgs e)
//        {
//            int equipo1Id = int.Parse(ddlEquipo1.SelectedValue);
//            int equipo2Id = int.Parse(ddlEquipo2.SelectedValue);
//            DateTime fechaPartido;

//            if (equipo1Id == equipo2Id)
//            {
//                ltlMensaje.Text = "<div class='alert alert-warning'>Los equipos no pueden ser iguales.</div>";
//                return;
//            }

//            if (!DateTime.TryParse(txtFecha.Text, out fechaPartido))
//            {
//                ltlMensaje.Text = "<div class='alert alert-danger'>Fecha inválida.</div>";
//                return;
//            }

//            var partido = new Partido
//            {
//                ID_Equipo1 = equipo1Id,
//                ID_Equipo2 = equipo2Id,
//                Fecha = fechaPartido
//            };

//            string resultado = PartidoService.RegistrarPartido(partido);

//            ltlMensaje.Text = $"<div class='alert {(resultado.Contains("correctamente") ? "alert-success" : "alert-danger")}'>{resultado}</div>";

//            if (resultado.Contains("correctamente"))
//            {
//                txtFecha.Text = "";
//                CargarPartidos();
//            }
//        }

//        private void CargarPartidos()
//        {
//            gvPartidos.DataBind(); // Usa SqlDataSource
//        }
//    }
//}