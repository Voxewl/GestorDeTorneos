namespace Gestor_Torneos.BusinessLogic
{
    public class EquipoService
    {
        private readonly EquipoRepository _equipoRepository;

        public EquipoService(string connectionString)
        {
            _equipoRepository = new EquipoRepository(connectionString);
        }

        public void AgregarEquipo(Equipo equipo)
        {
            if (equipo == null) throw new ArgumentNullException(nameof(equipo));
            if (string.IsNullOrWhiteSpace(equipo.Nombre)) throw new ArgumentException("El nombre del equipo no puede estar vacío.");

            _equipoRepository.AgregarEquipo(equipo);
        }

        public List<Torneo> ObtenerTorneos()
        {
            return _equipoRepository.ObtenerTorneos();
        }
    }
}