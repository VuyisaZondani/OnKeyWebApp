using OnKeyWebApp.Models;

namespace OnKeyWebApp.Data.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetByIdAsync(int id);
        Task<Event> GetByIdAsyncNoTracking(int id);
        bool Add(Event events);
        bool Update(Event events);
        bool Delete(Event events);
        bool Save();
    }
}
