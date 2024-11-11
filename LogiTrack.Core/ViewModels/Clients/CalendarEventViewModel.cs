namespace LogiTrack.Core.ViewModels.Clients
{
    public class CalendarEventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
