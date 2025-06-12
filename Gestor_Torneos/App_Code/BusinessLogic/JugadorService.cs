using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

namespace Gestor_Torneos.BusinessLogic
{
    public class JugadorService
    {
        private readonly JugadorRepository _jugadorRepository;

        public JugadorService()
        {
            _jugadorRepository = new JugadorRepository();
        }

        public List<Jugador> ObtenerTodos()
        {
            return _jugadorRepository.ObtenerTodos();
        }

        public Jugador ObtenerPorId(int id)
        {
            return _jugadorRepository.ObtenerPorId(id);
        }

        public void Agregar(Jugador jugador)
        {
            _jugadorRepository.Agregar(jugador);
        }

        public void Eliminar(int id)
        {
            _jugadorRepository.Eliminar(id);
        }
    }
}