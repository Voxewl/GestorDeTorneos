using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

namespace Gestor_Torneos.BusinessLogic
{
    public class EstadisticaService
    {
        private readonly EstadisticaRepository _estadisticaRepository;

        public EstadisticaService()
        {
            _estadisticaRepository = new EstadisticaRepository();
        }

        public List<Estadistica> ObtenerTodas()
        {
            return _estadisticaRepository.ObtenerTodas();
        }

        public Estadistica ObtenerPorEquipo(int idEquipo)
        {
            return _estadisticaRepository.ObtenerPorEquipo(idEquipo);
        }

        public void Actualizar(Estadistica estadistica)
        {
            _estadisticaRepository.Actualizar(estadistica);
        }

        public void CrearParaNuevoEquipo(int idEquipo)
        {
            _estadisticaRepository.CrearInicial(idEquipo);
        }

        // Lógica opcional: actualizar automáticamente después de un partido
        public void RegistrarResultado(int idEquipoGanador, int idEquipoPerdedor)
        {
            var ganador = _estadisticaRepository.ObtenerPorEquipo(idEquipoGanador);
            var perdedor = _estadisticaRepository.ObtenerPorEquipo(idEquipoPerdedor);

            ganador.Victorias++;
            ganador.Puntos += 3;

            perdedor.Derrotas++;

            _estadisticaRepository.Actualizar(ganador);
            _estadisticaRepository.Actualizar(perdedor);
        }
    }
}