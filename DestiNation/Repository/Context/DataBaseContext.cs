using DestiNation.Models;
using Microsoft.EntityFrameworkCore;

namespace DestiNation.Repository.Context
{
    public class DataBaseContext: DbContext
    {
        public DbSet<CountryModel> Country { get; set; }

        public DbSet<UserModel> User { get; set; }

        public DbSet<PassportModel> Passport { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

    }
}
