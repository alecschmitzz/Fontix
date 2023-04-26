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
            return _httpContextAccessor.HttpContext.Session.GetInt32("UserId") ?? 0;
        }
    }
}