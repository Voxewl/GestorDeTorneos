using System.Collections.Generic;
using Gestor_Torneos.DataAccess;
using Gestor_Torneos.Models;

namespace Gestor_Torneos.BusinessLogic
{
    public class EquipoService
    {
        private readonly EquipoRepository _equipoRepository;

        public EquipoService()
        {
            _equipoRepository = new EquipoRepository();
        }

        public List<Equipo> ObtenerTodos()
        {
            return _equipoRepository.ObtenerTodos();
        }

        public Equipo ObtenerPorId(int id)
        {
            return _equipoRepository.ObtenerPorId(id);
        }

        public void Agregar(Equipo equipo)
        {
            _equipoRepository.Agregar(equipo);
        }

        public void Actualizar(Equipo equipo)
        {
            _equipoRepository.Actualizar(equipo);
        }

        public void Eliminar(int id)
        {
            _equipoRepository.Eliminar(id);
        }
    }
}