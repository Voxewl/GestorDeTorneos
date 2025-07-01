using System;
using System.Web.UI;

namespace Gestor_Torneos.Utils
{
    public static class ErrorHandler
    {
        public static void Loggear(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[ERROR]: {ex.Message}\n{ex.StackTrace}");
        }

        public static void Mostrar(Page page, Exception ex)
        {
            Loggear(ex);
            FormUtils.MostrarAlerta(page, "Ocurrió un error inesperado.");
        }
    }
}