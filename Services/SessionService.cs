using System;

namespace EventEaseApp.Services
{
    public class SessionService
    {
        public Guid SessionId { get; private set; } = Guid.NewGuid();
        public string? UserName { get; set; }
        public string? LastVisitedPage { get; set; }
        public DateTime LastActivity { get; set; } = DateTime.Now;

        public void UpdateActivity(string page)
        {
            LastVisitedPage = page;
            LastActivity = DateTime.Now;
        }
    }
}
