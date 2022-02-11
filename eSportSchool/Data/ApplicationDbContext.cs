using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PersonData> Persons { get; set; }
        public DbSet<SportTeamData> SportTeamData { get; set; }
        public DbSet<TrainingData> TrainingData { get; set; }
    }
}