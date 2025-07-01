using System;

public class PartidoService
{
    /// <summary>
    /// Registra un nuevo partido, validando que los equipos no sean iguales.
    /// </summary>
    public static string RegistrarPartido(Partido partido)
    {
        if (partido.ID_Equipo1 == partido.ID_Equipo2)
            return "No se puede registrar un partido con el mismo equipo enfrentándose a sí mismo.";

        if (partido.Fecha < DateTime.Today.AddYears(-1) || partido.Fecha > DateTime.Today.AddYears(5))
            return "La fecha del partido no es válida.";

        // Aquí puedes añadir más validaciones si lo deseas (goles, estado del torneo, etc.)

        PartidoDAO.Insertar(partido);
        return "Partido registrado correctamente.";
    }

    /// <summary>
    /// Retorna todos los partidos registrados.
    /// </summary>
    public static List<Partido> ObtenerTodos()
    {
        return PartidoDAO.ObtenerTodos();
    }
}