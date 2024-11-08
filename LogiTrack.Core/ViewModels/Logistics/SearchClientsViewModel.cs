namespace LogiTrack.Core.ViewModels.Logistics
{
    public class SearchClientsViewModel
    {
        public string? Name { get; set; }
        public string? SearchTerm { get; set; }
        public string? RegistrationNumber { get; set; }
        public bool Active { get; set; }
        public string? Email { get; set; }
        public List<ClientsForClientregisterViewModel> Clients { get; set; } = new List<ClientsForClientregisterViewModel>();
    }
}
