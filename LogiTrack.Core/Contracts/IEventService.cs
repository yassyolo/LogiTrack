using LogiTrack.Core.ViewModels.Clients;

namespace LogiTrack.Core.Contracts
{
    public interface IEventService
    {
        Task<List<CalendarEventViewModel>?> GetUserEventsAsync(string username);
    }
}
