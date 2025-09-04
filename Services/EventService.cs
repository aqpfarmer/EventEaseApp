using EventEaseApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventEaseApp.Services
{
    public class EventService
    {
        public List<Event> Events { get; } = new List<Event>
        {
            new Event { Id = 1, Name = "Blazor Conference 2025", Date = new DateTime(2025, 10, 15), Location = "Seattle Convention Center", Description = "Join us for a day of Blazor talks, workshops, and networking!", ImageUrl = "images/conf2.jpg" },
            new Event { Id = 2, Name = "Tech Meetup", Date = new DateTime(2025, 11, 5), Location = "Online", Description = "Monthly tech meetup for developers.", ImageUrl = "images/conf1.jpg" }
        };

        public List<Attendee> Attendees { get; } = new List<Attendee>();

        public void RegisterAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
        }

        public IEnumerable<Attendee> GetAttendeesForEvent(int eventId)
        {
            return Attendees.Where(a => a.EventIds.Contains(eventId));
        }
    }
}
