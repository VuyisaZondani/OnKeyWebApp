using Microsoft.EntityFrameworkCore;
using OnKeyWebApp.Data;
using OnKeyWebApp.Data.Interface;
using OnKeyWebApp.Models;

namespace OnKeyWebApp.Repository
{
    public class MusicClubRepository : IMusicClubRepository
    {
        private readonly ApplicationDbContext _context;

        public MusicClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(MusicClub musicClub)
        {
            _context.Add(musicClub);
            return Save();
        }

        public bool Delete(MusicClub musicClub)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MusicClub>> GetAllMusicClubs()
        {
            return await _context.MusicClubs.ToListAsync();
        }

        public Task<MusicClub> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(MusicClub musicClub)
        {
            throw new NotImplementedException();
        }
    }
}
