using Fontix.UI.Models;

namespace Fontix.UI.Utils
{
    public interface ISessionAccess
    {
        public int GetUserId();
        public void SetUserId(int userId);

        public List<SelectedTicket>? GetSelectedTickets();
        public void SetSelectedTickets(List<SelectedTicket> selectedTickets);
    }
}