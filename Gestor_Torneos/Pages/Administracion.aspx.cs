using Gestor_Torneos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_Torneos.Pages
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCrearRol_Click(object sender, EventArgs e)
        {
            string createRole = txtRolName.Text;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            try
            {
                if (roleManager.RoleExists(createRole))
                {
                    Response.Write("Rol Duplicado");
                }
                else
                {
                    roleManager.Create(new IdentityRole(createRole));
                    gvRolName.DataBind();
                    txtRolName.Text = string.Empty;
                    Panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminarRol_Click(object sender, EventArgs e)
        {
            string roleId = lblIdRol.Text;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            try
            {
                var role = roleManager.FindById(roleId);
                if (role != null)
                {
                    var result = roleManager.Delete(role);
                    if (result.Succeeded)
                    {
                        gvRolName.DataBind();
                        txtRolName.Text = string.Empty;
                        lblIdRol.Text = string.Empty;
                        lblNomRol.Text = string.Empty;
                        Panel1.Visible = true;
                    }
                    else
                    {
                        Response.Write("Error al eliminar el rol.");
                    }
                }
                else
                {
                    Response.Write("Rol no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void gvRolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRolName.Text = gvRolName.SelectedRow.Cells[2].Text;
            lblNomRol.Text = gvRolName.SelectedRow.Cells[2].Text;
            lblIdRol.Text = gvRolName.SelectedRow.Cells[1].Text;
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtConfirmar.Text)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

                var user = new ApplicationUser
                {
                    UserName = txtUserName.Text,
                    Email = txtCorreo.Text
                };

                IdentityResult result = manager.Create(user, txtPass.Text);
                gvUsuarios.DataBind();

                if (result.Succeeded)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    Panel3.Visible = true;

                    // Limpiar campos
                    txtUserName.Text = string.Empty;
                    txtCorreo.Text = string.Empty;
                    txtPass.Text = string.Empty;
                    txtConfirmar.Text = string.Empty;
                }
                else
                {
                    // Aquí puedes mostrar errores si deseas
                }
            }
            else
            {
                Response.Write("Verifica las Contraseñas");
            }
        }

        protected void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            // Este método necesita ser implementado según tu lógica para eliminar usuarios
            Response.Write("Funcionalidad de borrar usuario no implementada.");
        }

        protected void btnRelacion_Click(object sender, EventArgs e)
        {
            SqlDataSource3.InsertParameters["RoleId"].DefaultValue = lblIdRol.Text;
            SqlDataSource3.InsertParameters["UserId"].DefaultValue = lblIdUser.Text;

            int bandera = SqlDataSource3.Insert();
            if (bandera == 1)
            {
                // Éxito
                lblIdRol.Text = string.Empty;
                lblIdUser.Text = string.Empty;
                lblNomRol.Text = string.Empty;
                lblNomUser.Text = string.Empty;
                Panel3.Visible = true;
            }
            else
            {
                // Fracaso
                lblIdRol.Text = string.Empty;
                lblIdUser.Text = string.Empty;
                lblNomRol.Text = string.Empty;
                lblNomUser.Text = string.Empty;
                Panel4.Visible = true;
            }
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdUser.Text = gvUsuarios.SelectedRow.Cells[1].Text;
            txtUserName.Text = gvUsuarios.SelectedRow.Cells[2].Text;
            lblNomUser.Text = gvUsuarios.SelectedRow.Cells[2].Text;

            string userId = lblIdUser.Text;

            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roles = userManager.GetRoles(userId);

            if (roles.Count > 0)
            {
                string userRole = roles[0];
                txtRolName.Text = userRole;

                // Buscar el rol seleccionado en GridView
                foreach (GridViewRow row in gvRolName.Rows)
                {
                    if (row.Cells[2].Text == userRole)
                    {
                        gvRolName.SelectedIndex = row.RowIndex;
                        lblNomRol.Text = userRole;
                        lblIdRol.Text = row.Cells[1].Text;
                        break;
                    }
                }
            }
            else
            {
                txtRolName.Text = string.Empty;
                gvRolName.SelectedIndex = -1;
                lblNomRol.Text = string.Empty;
                lblIdRol.Text = string.Empty;
            }
        }
    }
}
