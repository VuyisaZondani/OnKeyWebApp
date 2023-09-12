﻿using OnKeyWebApp.Models;

namespace OnKeyWebApp.Data
{
    public interface IMusicClubRepository
    {
        Task<IEnumerable<MusicClub>> GetAllMusicClubs();
        Task<MusicClub> GetByIdAsync(int id);
        bool Add(MusicClub musicClub);
        bool Update(MusicClub musicClub);
        bool Delete(MusicClub musicClub);
        bool Save();

    }
}
