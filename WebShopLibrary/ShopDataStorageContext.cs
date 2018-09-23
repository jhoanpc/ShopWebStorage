using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebShopLibrary.Models;

namespace WebShopLibrary
{
    public class ShopDataStorageContext : DbContext
    {
        public ShopDataStorageContext()
        {

        }
        public ShopDataStorageContext(DbContextOptions options): base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Categories>()
                 .HasMany(c => c.Productss)
                 .WithOne(p => p.Categoriess);*/

            modelBuilder.Entity<Products>()
                .HasOne<Categories>(p => p.Categoriess)
                .WithMany(c => c.Productss)
                .HasForeignKey(f => f.IdCategories);
        }
    }
}
