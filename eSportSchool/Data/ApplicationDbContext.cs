using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Infra;

namespace eSportSchool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            initializeTables(b);
        }

        private static void initializeTables(ModelBuilder b)
        {
            eSportSchoolDB.InitializeTables(b);
        }

    }
}