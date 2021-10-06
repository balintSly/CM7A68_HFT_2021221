using Microsoft.EntityFrameworkCore;
using System;
using CM7A68_HFT_2021221.Models;

namespace CM7A68_HFT_2021221.Data
{
    public class CarDBContext : DbContext
    {
        string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDB.mdf;Integrated Security=True";
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public CarDBContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies()
                        .UseSqlServer(connstring);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>(entity =>
           {
               entity
               .HasOne(car => car.Brand)
               .WithMany(brand => brand.Cars)
               .HasForeignKey(car => car.BrandID)
               .OnDelete(DeleteBehavior.Restrict);
           });
            builder.Entity<Part>(entity =>
            {
                entity
                .HasMany(part => part.Compatible_cars)
                .WithMany(car => car.Parts);
            });

            Brand volkswagen = new Brand() { ID = 1, Name = "Volkswagen" };
            Brand seat = new Brand() { ID = 1, Name = "SEAT" };
            Brand audi = new Brand() { ID = 1, Name = "Audi" };
            Brand skoda = new Brand() { ID = 1, Name = "Skoda" };
            Brand porsche = new Brand() { ID = 1, Name = "Porsche" };
            Brand lamborghini = new Brand() { ID = 1, Name = "Lamborghini" };
            Brand tesla = new Brand() { ID = 1, Name = "Tesla" };
            Brand nissan = new Brand() { ID = 1, Name = "Nissan" };
            Brand toyota = new Brand() { ID = 1, Name = "Porsche" };





        }



    }
}
