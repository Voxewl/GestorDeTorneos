using System.Configuration;

namespace Gestor_Torneos.Utils
{
    public static class Conexion
    {
        public static string Cadena => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}