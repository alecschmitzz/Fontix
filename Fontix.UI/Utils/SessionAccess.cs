using Fontix.UI.Models;
using Newtonsoft.Json;

namespace Fontix.UI.Utils
{
    public class SessionAccess : ISessionAccess
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionAccess(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            return _httpContextAccessor.HttpContext?.Session.GetInt32("UserId") ?? 0;
        }

        public void SetUserId(int userId)
        {
            _httpContextAccessor.HttpContext?.Session.SetInt32("UserId", userId);
        }

        public List<SelectedTicket>? GetSelectedTickets()
        {
            var selectedTicketsJson = _httpContextAccessor.HttpContext.Session.GetString("SelectedTickets");
            return selectedTicketsJson != null ? JsonConvert.DeserializeObject<List<SelectedTicket>>(selectedTicketsJson) : null;
        }

        public void SetSelectedTickets(List<SelectedTicket> selectedTickets)
        {
            _httpContextAccessor.HttpContext?.Session.SetObjectAsJson("SelectedTickets", selectedTickets);
        }
    }
}