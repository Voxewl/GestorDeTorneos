using System.Web.UI;

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
    }
}