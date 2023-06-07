namespace Fontix.UI.Utils
{
    public interface ISessionAccess
    {
        public int GetUserId();
        public void SetUserId(int userId);
    }
}