using EventEaseApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace EventEaseApp.Services
{
    public class EventService
    {
        private readonly ILocalStorageService _localStorage;
        private const string EventsKey = "events";
        public List<Event> Events { get; private set; } = new();
        private List<Attendee> Attendees { get; set; } = new List<Attendee>();

        public EventService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadEventsAsync()
        {
            var loaded = await _localStorage.GetItemAsync<List<Event>>(EventsKey);
            if (loaded != null)
                Events = loaded;
        }

        public async Task AddEventAsync(Event evt)
        {
            // Assign a unique Id if not set or duplicate
            if (evt.Id == 0 || Events.Any(e => e.Id == evt.Id))
            {
                int nextId = Events.Any() ? Events.Max(e => e.Id) + 1 : 1;
                evt.Id = nextId;
            }
            Events.Add(evt);
            await SaveEventsAsync();
        }

        public async Task SaveEventsAsync()
        {
            await _localStorage.SetItemAsync(EventsKey, Events);
        }

        public void RegisterAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
        }

        public IEnumerable<Attendee> GetAttendeesForEvent(int eventId)
        {
            return Attendees.Where(a => a.EventIds.Contains(eventId));
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            var index = Events.FindIndex(e => e.Id == updatedEvent.Id);
            if (index >= 0)
            {
                Events[index] = updatedEvent;
                await SaveEventsAsync();
            }
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var evt = Events.FirstOrDefault(e => e.Id == eventId);
            if (evt != null)
            {
                Events.Remove(evt);
                await SaveEventsAsync();
            }
        }
    }
}
