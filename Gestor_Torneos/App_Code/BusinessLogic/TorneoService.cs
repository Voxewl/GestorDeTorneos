namespace Gestor_Torneos.BusinessLogic
{
    public class TorneoService
    {
        private readonly TorneoRepository _torneoRepository;

        public TorneoService()
        {
            _torneoRepository = new TorneoRepository();  // Usamos la clase Repository
        }

        public List<Torneo> ObtenerTorneos()
        {
            return _torneoRepository.ObtenerTodosLosTorneos();
        }

        public void AgregarTorneo(Torneo torneo)
        {
            _torneoRepository.AgregarTorneo(torneo);
        }
    }
}