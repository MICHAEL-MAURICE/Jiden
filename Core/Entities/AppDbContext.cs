using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Core.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection.Emit;

namespace Core.Entities
{
    public class AppDbContext : IdentityDbContext<AppUser> {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Image>()
      .HasOne(image => image.Proudect)
      .WithMany(proudect => proudect.Images)
      .HasForeignKey(image => image.Proudectid)
      .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null instead of deleting

            modelBuilder.Entity<Proudect>()
                .HasMany(proudect => proudect.Images)
                .WithOne(image => image.Proudect)
                .HasForeignKey(image => image.Proudectid)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete images when deleting a product

            modelBuilder.Entity<AppUser>()
                .HasOne(user => user.Image)
                .WithOne(image => image.AppUser)
                .HasForeignKey<AppUser>(user => user.ProfileImage)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Proudect>Proudects { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<GeographicalDistributionRange> GeographicalDistributionRanges { get; set; }

        public DbSet<TypeOfMedication> TypeOfMedications { get; set; }
        public DbSet<WayMedicineUsed> WayMedicineUsed { get; set; }
        public DbSet<PharmaceuticalForm> PharmaceuticalForms { get; set; }
        public DbSet<Discrimination> Discriminations { get; set; }
        public DbSet<Image>Images { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PricingSettings> PricingSettings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProudectOrder> ProudectOrders { get; set; }



    }

    

}
