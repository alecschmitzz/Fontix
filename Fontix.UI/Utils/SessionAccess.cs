namespace Fontix.UI.Utils
{
    public class SessionAccess : ISessionAccess
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionAccess(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public int GetUserId()
        {
            return httpContextAccessor.HttpContext.Session.GetInt32("UserId") ?? 0;
        }

        public void SetUserId(int userId)
        {
            httpContextAccessor.HttpContext.Session.SetInt32("UserId", userId);
        }
    }
}