using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

namespace Gestor_Torneos.BusinessLogic
{
    public class TorneoService
    {
        private readonly TorneoRepository _torneoRepository;

        public TorneoService()
        {
            _torneoRepository = new TorneoRepository();
        }

        public List<Torneo> ObtenerTodos()
        {
            return _torneoRepository.ObtenerTodos();
        }

        public Torneo ObtenerPorId(int id)
        {
            return _torneoRepository.ObtenerPorId(id);
        }

        public void Agregar(Torneo torneo)
        {
            _torneoRepository.Agregar(torneo);
        }

        public void Actualizar(Torneo torneo)
        {
            _torneoRepository.Actualizar(torneo);
        }

        public void Eliminar(int id)
        {
            _torneoRepository.Eliminar(id);
        }
    }
}