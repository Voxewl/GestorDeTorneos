using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Gestor_Torneos.Utils


{
    public static class FormUtils
    {
        public static bool ValidarCamposVacios(params string[] valores)
        {
            foreach (var val in valores)
            {
                if (string.IsNullOrWhiteSpace(val)) return false;
            }
            return true;
        }

        public static void MostrarAlerta(Page page, string mensaje)
        {
            string script = $"alert('{mensaje.Replace("'", "\\'")}');";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alerta", script, true);
        }

        public static void LimpiarControles(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox txt)
                    txt.Text = "";
                else if (control is DropDownList ddl)
                    ddl.SelectedIndex = 0;
                else if (control.HasControls())
                    LimpiarControles(control.Controls);
            }
        }
    }
}