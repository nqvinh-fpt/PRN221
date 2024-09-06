namespace Ha.Pages.Events
{
    public interface IUserService
    {
        Task<int> GetRegisteredUserCount();
    }
}
