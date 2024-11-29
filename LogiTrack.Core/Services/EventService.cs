using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CalendarEventViewModel>?> GetUserEventsAsync(string username)
        {
            var events = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.CalendarEvent>().Include(x => x.User).Where(x => x.User.UserName == username)
                .Select(x => new CalendarEventViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    Title = x.Title,
                    Type = x.EventType,
                }).ToListAsync();
            if (events.Count == 0)
            {
                return new List<CalendarEventViewModel>();
            }

            return events;
        }
    }
}
