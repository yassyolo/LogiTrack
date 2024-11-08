namespace LogiTrack.Core.ViewModels.Clients
{
    public class ContactDetailsViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AlternativePhoneNumber { get; set; } = string.Empty;
    }
}
