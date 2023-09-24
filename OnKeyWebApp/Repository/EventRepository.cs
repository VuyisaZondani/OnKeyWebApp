using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnKeyWebApp.Data;
using OnKeyWebApp.Data.Interface;
using OnKeyWebApp.Models;

namespace OnKeyWebApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Event events)
        {
            _context.Add(events);
            return Save();
        }

        public bool Delete(Event events)
        {
            _context.Remove(events);
            return Save();
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; ;
        }

        public bool Update(Event events)
        {
            _context.Update(events);
            return Save();
        }
    }
}
