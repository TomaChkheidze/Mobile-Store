using Microsoft.EntityFrameworkCore;
using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Data
{
    public class MobileStoreContext : DbContext
    {
        public MobileStoreContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //convert media type
            builder.Entity<Phone>()
                        .Property(e => e.Media)
                        .HasConversion(
                            v => string.Join(';', v),
                            v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
