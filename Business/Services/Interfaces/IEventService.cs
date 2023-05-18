namespace Business.Services.Interfaces
{
    public interface IEventService
    {
        Task SubscribeAsync(string email);
    }
}
