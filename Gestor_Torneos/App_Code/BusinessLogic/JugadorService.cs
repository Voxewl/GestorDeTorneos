using System;
using System.Collections.Generic;
using System.Linq;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

public class JugadorService
{
    /// <summary>
    /// Registra un nuevo jugador.
    /// </summary>
    public static string RegistrarJugador(Jugador jugador)
    {
        if (string.IsNullOrWhiteSpace(jugador.Alias) || string.IsNullOrWhiteSpace(jugador.UserId))
            return "Alias y UserId son obligatorios.";

        JugadorDAO.Insertar(jugador);
        return "Jugador registrado correctamente.";
    }

    public static List<Jugador> ObtenerTodos()
    {
        return JugadorDAO.ObtenerTodos();
    }
}