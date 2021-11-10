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
            Brand toyota = new Brand() { ID = 9, Name = "Toyota" };
            Brand suzuki = new Brand() { ID = 10, Name = "Suzuki" };

            Part part1 = new Part() { ID = 1, Brand = "Febi", Item_number = "006070789A", Name = "Brake pads", Price = 5000, Weight = 0.5 };
            Part part2 = new Part() { ID = 2, Brand = "Febi", Item_number = "806034523A", Name = "Water pipe", Price = 300, Weight = 0.5 };
            Part part3 = new Part() { ID = 3, Brand = "Brembo", Item_number = "0871HFSA23", Name = "Brake discs", Price = 20000, Weight = 20 };
            Part part4 = new Part() { ID = 4, Brand = "Continental", Item_number = "700325JS", Name = "Tire", Price = 20000, Weight = 8 };
            Part part5 = new Part() { ID = 5, Brand = "Toyo", Item_number = "00003525GF", Name = "Tire", Price = 25000, Weight = 9 };
            Part part6 = new Part() { ID = 6, Brand = "Hankook", Item_number = "8786662TTR", Name = "Tire", Price = 10000, Weight = 7 };
            Part part7 = new Part() { ID = 7, Brand = "Bosch", Item_number = "998776TZH", Name = "Battery", Price = 50000, Weight = 30 };
            Part part8 = new Part() { ID = 8, Brand = "BBS", Item_number = "6766555657TZ", Name = "Rim", Price = 80000, Weight = 30 };
            Part part9 = new Part() { ID = 9, Brand = "Bosch", Item_number = "6667677676R", Name = "Brake discs", Price = 20000, Weight = 22 };
            Part part10 = new Part() { ID = 10, Brand = "Hella", Item_number = "99998776OP", Name = "Headlights", Price = 60000, Weight = 2 };

            Car volkswagen1 = new Car() { ID = 1, BrandID = 1, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Golf II", Production_year = 1989 };
            Car volkswagen2 = new Car() { ID = 2, BrandID = 1, Cylinder_capacity = 2, Cylinder_number = 4, Model = "Golf III GTI", Production_year = 1995 };
            Car seat1 = new Car() { ID = 3, BrandID = 2, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Leon", Production_year = 2004 };
            Car audi1 = new Car() { ID = 4, BrandID = 3, Cylinder_capacity = 5.2, Cylinder_number = 10, Model = "R8", Production_year = 2008 };
            Car skoda1 = new Car() { ID = 5, BrandID = 4, Cylinder_capacity = 1.2, Cylinder_number = 3, Model = "Fabia", Production_year = 1999 };
            Car porsche1 = new Car() { ID = 6, BrandID = 5, Cylinder_capacity = 3.8, Cylinder_number = 6, Model = "911 Turbo S", Production_year = 2020 };
            Car lamborghini1 = new Car() { ID = 7, BrandID = 6, Cylinder_capacity = 6.5, Cylinder_number = 12, Model = "Aventador", Production_year = 2011 };
            Car tesla1 = new Car() { ID = 8, BrandID = 7, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Model S Plaid", Production_year = 2020 };
            Car nissan1 = new Car() { ID = 9, BrandID = 8, Cylinder_capacity = 2.6, Cylinder_number = 6, Model = "Skyline", Production_year = 1999 };
            Car toyota1 = new Car() { ID = 10, BrandID = 9, Cylinder_capacity = 3.0, Cylinder_number = 6, Model = "Supra MK4", Production_year = 1992 };
            Car suzuki1 = new Car() { ID = 11, BrandID = 10, Cylinder_capacity = 1.0, Cylinder_number = 3, Model = "Swift", Production_year = 1989 };
            Car volkswagen3 = new Car() { ID = 12, BrandID = 1, Cylinder_capacity = 1.9, Cylinder_number = 4, Model = "Touran", Production_year = 2006 };
            Car volkswagen4 = new Car() { ID = 13, BrandID = 1, Cylinder_capacity = 2.0, Cylinder_number = 4, Model = "Tiguan", Production_year = 2016 };
            Car seat2 = new Car() { ID = 14, BrandID = 2, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Ibiza Cupra", Production_year = 2016 };
            Car audi2 = new Car() { ID = 15, BrandID = 3, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "TT", Production_year = 2000 };
            Car skoda2 = new Car() { ID = 16, BrandID = 4, Cylinder_capacity = 2.0, Cylinder_number = 4, Model = "Superb", Production_year = 2015 };
            Car porsche2 = new Car() { ID = 17, BrandID = 5, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Taycan", Production_year = 2019 };
            Car lamborghini2 = new Car() { ID = 18, BrandID = 6, Cylinder_capacity = 4.0, Cylinder_number = 8, Model = "Urus", Production_year = 2018 };
            Car tesla2 = new Car() { ID = 19, BrandID = 7, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Model X", Production_year = 2015 };
            Car nissan2 = new Car() { ID = 20, BrandID = 8, Cylinder_capacity = 3.5, Cylinder_number = 6, Model = "350Z", Production_year = 2003 };
            Car toyota2 = new Car() { ID = 21, BrandID = 9, Cylinder_capacity = 1.6, Cylinder_number = 4, Model = "AE86", Production_year = 1983 };
            Car suzuki2 = new Car() { ID = 22, BrandID = 10, Cylinder_capacity = 1.4, Cylinder_number = 4, Model = "Vitara", Production_year = 2018 };


            builder.Entity<Car>(entity =>
           {
               entity
               .HasOne(car => car.Brand)
               .WithMany(brand => brand.Cars)
               .HasForeignKey(car => car.BrandID)
               .OnDelete(DeleteBehavior.Cascade);
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
            builder.Entity<CarPart>().HasData(new { CarID = 1, PartID = 4 },
                                              new { CarID = 2, PartID = 4 },
                                              new { CarID = 3, PartID = 5 },
                                              new { CarID = 4, PartID = 5 },
                                              new { CarID = 5, PartID = 6 },
                                              new { CarID = 6, PartID = 5 },
                                              new { CarID = 7, PartID = 5 },
                                              new { CarID = 8, PartID = 6 },
                                              new { CarID = 9, PartID = 4 },
                                              new { CarID = 10, PartID = 4 },
                                              new { CarID = 11, PartID = 5 },
                                              new { CarID = 12, PartID = 6 },
                                              new { CarID = 13, PartID = 5 },
                                              new { CarID = 14, PartID = 4 },
                                              new { CarID = 15, PartID = 6 },
                                              new { CarID = 16, PartID = 4 },
                                              new { CarID = 17, PartID = 6 },
                                              new { CarID = 18, PartID = 4 },
                                              new { CarID = 19, PartID = 5 },
                                              new { CarID = 20, PartID = 6 },
                                              new { CarID = 21, PartID = 4 },
                                              new { CarID = 22, PartID = 6 },
                                              new { CarID = 1, PartID = 7 },
                                              new { CarID = 2, PartID = 7 },
                                              new { CarID = 3, PartID = 7 },
                                              new { CarID = 4, PartID = 7 },
                                              new { CarID = 5, PartID = 7 },
                                              new { CarID = 6, PartID = 7 },
                                              new { CarID = 7, PartID = 7 },
                                              new { CarID = 9, PartID = 7 },
                                              new { CarID = 10, PartID = 7 },
                                              new { CarID = 11, PartID = 7 },
                                              new { CarID = 12, PartID = 7 },
                                              new { CarID = 13, PartID = 7 },
                                              new { CarID = 14, PartID = 7 },
                                              new { CarID = 15, PartID = 7 },
                                              new { CarID = 16, PartID = 7 },
                                              new { CarID = 18, PartID = 7 },
                                              new { CarID = 20, PartID = 7 },
                                              new { CarID = 21, PartID = 7 },
                                              new { CarID = 22, PartID = 7 },
                                              new { CarID = 1, PartID = 10 },
                                              new { CarID = 1, PartID = 3 },
                                              new { CarID = 12, PartID = 1 },
                                              new { CarID = 13, PartID = 8 },
                                              new { CarID = 15, PartID = 2 },
                                              new { CarID = 14, PartID = 10 },
                                              new { CarID = 3, PartID = 8 },
                                              new { CarID = 7, PartID = 1 },
                                              new { CarID = 22, PartID = 8 },
                                              new { CarID = 21, PartID = 9 },
                                              new { CarID = 19, PartID = 6 },
                                              new { CarID = 20, PartID = 8 },
                                              new { CarID = 3, PartID = 1 },
                                              new { CarID = 5, PartID = 9 },
                                              new { CarID = 4, PartID = 1 },
                                              new { CarID = 6, PartID = 3 },
                                              new { CarID = 2, PartID = 2 },
                                              new { CarID = 3, PartID = 2 },
                                              new { CarID = 10, PartID = 10 },
                                              new { CarID = 9, PartID = 9 },
                                              new { CarID = 8, PartID = 3 },
                                              new { CarID = 3, PartID = 10 },
                                              new { CarID = 16, PartID = 2 },
                                              new { CarID = 11, PartID = 10 },
                                              new { CarID = 10, PartID = 2 },
                                              new { CarID = 11, PartID = 2 },
                                              new { CarID = 9, PartID = 8 },
                                              new { CarID = 7, PartID = 8 },
                                              new { CarID = 6, PartID = 1 },
                                              new { CarID = 5, PartID = 2 },
                                              new { CarID = 4, PartID = 9 },
                                              new { CarID = 15, PartID = 8 },
                                              new { CarID = 12, PartID = 8 },
                                              new { CarID = 12, PartID = 2 },
                                              new { CarID = 13, PartID = 1 }



            ) ;
            builder.Entity<Brand>().HasData(volkswagen, seat, audi, skoda, porsche, lamborghini, tesla, nissan, toyota, suzuki);
            builder.Entity<Car>().HasData(volkswagen1, volkswagen2, volkswagen3, volkswagen4, seat1, seat2, audi1, audi2, skoda1, skoda2, porsche1, porsche2, lamborghini1, lamborghini2, tesla1, tesla2, nissan1, nissan2, toyota1, toyota2, suzuki1, suzuki2);
            builder.Entity<Part>().HasData(part1, part2, part3, part4, part5, part6, part7, part8, part9, part10);








        }



    }
}
