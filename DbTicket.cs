using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zamawianie_biletow.Models;

namespace Zamawianie_biletow
{
    public class DbTicket : IdentityDbContext<UserModel>
    {

        public DbTicket(DbContextOptions<DbTicket> options) : base(options) { }

        public DbSet<Product>   Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
