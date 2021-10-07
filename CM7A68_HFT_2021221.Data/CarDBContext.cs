using Microsoft.EntityFrameworkCore;
using System;
using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;

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


            Brand volkswagen = new Brand() { ID = 1, Name = "Volkswagen" };
            Brand seat = new Brand() { ID = 2, Name = "SEAT" };
            Brand audi = new Brand() { ID = 3, Name = "Audi" };
            Brand skoda = new Brand() { ID = 4, Name = "Skoda" };
            Brand porsche = new Brand() { ID = 5, Name = "Porsche" };
            Brand lamborghini = new Brand() { ID = 6, Name = "Lamborghini" };
            Brand tesla = new Brand() { ID = 7, Name = "Tesla" };
            Brand nissan = new Brand() { ID = 8, Name = "Nissan" };
            Brand toyota = new Brand() { ID = 9, Name = "Porsche" };

            Part part1 = new Part() { ID = 1, Brand = "Febi", Item_number = "006070789A", Name = "Brake pads", Price = 5000, Weight = 0.5 };
            Part part2 = new Part() { ID = 2, Brand = "Febi", Item_number = "806034523A", Name = "Water pipe", Price = 300, Weight = 0.5 };
            Part part3 = new Part() { ID = 3, Brand = "Brembo", Item_number = "0871HFSA23", Name = "Brake discs", Price = 20000, Weight = 10 };

            Car volkswagen1 = new Car() { ID = 1, BrandID = 1, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Golf II", Production_year = 1989 };


            builder.Entity<Car>(entity =>
           {
               entity
               .HasOne(car => car.Brand)
               .WithMany(brand => brand.Cars)
               .HasForeignKey(car => car.BrandID)
               .OnDelete(DeleteBehavior.Restrict);
           });

            builder.Entity<CarPart>()
                .HasKey(cp => new { cp.CarID, cp.PartID });
            builder.Entity<CarPart>()
                .HasOne(cp => cp.Car)
                .WithMany(cp => cp.CarParts)
                .HasForeignKey(cp => cp.CarID);
            builder.Entity<CarPart>()
                .HasOne(cp => cp.Part)
                .WithMany(cp => cp.CarParts)
                .HasForeignKey(cp => cp.PartID);
            builder.Entity<CarPart>().HasData(new { CarID = 1, PartID = 1 },
                                              new { CarID = 1, PartID = 2 }



            );
            builder.Entity<Brand>().HasData(volkswagen);
            builder.Entity<Car>().HasData(volkswagen1);
            builder.Entity<Part>().HasData(part1, part2, part3);








        }



    }
}
