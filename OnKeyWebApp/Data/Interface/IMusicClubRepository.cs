using OnKeyWebApp.Models;

namespace OnKeyWebApp.Data.Interface
{
    public interface IMusicClubRepository
    {
        Task<IEnumerable<MusicClub>> GetAllMusicClubs();
        Task<MusicClub> GetByIdAsync(int id);
        Task<MusicClub> GetByIdAsyncNoTracking(int id);
        bool Add(MusicClub musicClub);
        bool Update(MusicClub musicClub);
        bool Delete(MusicClub musicClub);
        bool Save();

    }
}
