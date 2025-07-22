using System;

public class PartidoResumen
{
    public int ID_Partido { get; set; }
    public int ID_Torneo { get; set; }   // ✅ Necesario para cargar equipos
    public string Torneo { get; set; }
    public int ID_Equipo1 { get; set; }
    public int ID_Equipo2 { get; set; }
    public string Equipo1 { get; set; }
    public string Equipo2 { get; set; }
    public DateTime Fecha { get; set; }
}
