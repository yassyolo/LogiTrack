namespace LogiTrack.Core.ViewModels.Notifications
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public bool IsRead { get; set; }
    }
}
