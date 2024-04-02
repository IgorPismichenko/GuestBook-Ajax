using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace GuestBook_Ajax.Models
{
    public class GBContext: DbContext
    {
        public GBContext(DbContextOptions<GBContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}
