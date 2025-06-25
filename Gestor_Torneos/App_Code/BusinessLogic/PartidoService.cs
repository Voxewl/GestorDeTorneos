using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;
using System;

namespace Gestor_Torneos.BusinessLogic
{
    public class PartidoService
    {
        private readonly PartidoRepository _partidoRepository;

        public PartidoService()
        {
            _partidoRepository = new PartidoRepository();
        }

        public List<Partido> ObtenerTodos()
        {
            return _partidoRepository.ObtenerTodos();
        }

        public Partido ObtenerPorId(int id)
        {
            return _partidoRepository.ObtenerPorId(id);
        }

        public void Agregar(Partido partido)
        {
            if (partido.ID_Equipo1 == partido.ID_Equipo2)
                throw new ArgumentException("Los equipos deben ser distintos.");

            _partidoRepository.Agregar(partido);
        }

        public void Actualizar(Partido partido)
        {
            if (partido.ID_Equipo1 == partido.ID_Equipo2)
                throw new ArgumentException("Los equipos deben ser distintos.");

            _partidoRepository.Actualizar(partido);
        }

        public void Eliminar(int id)
        {
            _partidoRepository.Eliminar(id);
        }
    }
}