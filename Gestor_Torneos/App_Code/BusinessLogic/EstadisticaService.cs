using System;

public class EstadisticaService
{
    public static string RegistrarEstadistica(Estadistica est)
    {
        if (est.Victorias < 0 || est.Derrotas < 0 || est.Puntos < 0)
            return "Los valores no pueden ser negativos.";

        EstadisticaDAO.Insertar(est);
        return "Estadística registrada correctamente.";
    }

    public static List<Estadistica> ObtenerTodos()
    {
        return EstadisticaDAO.ObtenerTodos();
    }
}