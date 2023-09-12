using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnKeyWebApp.Models;

namespace OnKeyWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<MusicClub> MusicClubs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MusicClub_Event> MusicClub_Events { get; set; }

    }
}
