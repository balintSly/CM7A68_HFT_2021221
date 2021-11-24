using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Figgle;
using ConsoleTables;
using CM7A68_HFT_2021221.Models;

namespace CM7A68_HFT_2021221.Client
{
    class GUI
    {
        public GUI()
        {
            Intro();
        }
        MethodTranslator MethodTranslator;
        public void Intro()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            this.MethodTranslator = new MethodTranslator();
            foreach (var item in FiggleFonts.Doom.Render("               Spare Part Inventory System"))
            {
                Console.Write(item);
                Thread.Sleep(1);
            }

            Console.WriteLine(FiggleFonts.Doom.Render("                                                                    ( SPIS )"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Small.Render("                                    Made by Szilveszter Balint"));
            Console.WriteLine(FiggleFonts.Small.Render("                                    from SlyTech Industries"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            string press = "(Press any key to continue)";
            Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
            Console.WriteLine(press);
            Console.ReadKey();
            MainMenu();
        }
        public void MainMenu()
        {
            Console.Clear();

            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                       -] Main Menu [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Database operations   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Description   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Exit   [ 3 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int brandnumber = MethodTranslator.GetAllBrand().Count;
            int carnumber = MethodTranslator.GetAllCar().Count;
            int partnumber = MethodTranslator.GetAllPart().Count;

            Console.WriteLine(FiggleFonts.Small.Render("Statistics, contents in the database: "));
            Console.WriteLine(FiggleFonts.Small.Render(brandnumber + " Brands"));
            Console.WriteLine(FiggleFonts.Small.Render(carnumber + " Cars"));
            Console.WriteLine(FiggleFonts.Small.Render(partnumber + " Parts"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                MainMenu();
            }
            switch (num)
            {
                case 1:
                    OperationOptions();
                    break;
                case 2:
                    Description();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }

            ;
        }
        public void Description()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                       -] Description [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("This is a database application for spare part retailers.\nThis program helps to register spare parts by car brand and model. You can do basic operations on your data, which are the following ones:\nRead All: It gives back all brands/cars/parts with parameters.\nRead: It gives back one brand/car/part with parameters.\nCreate: You can add a brand/car/part to the database.\nUpdate: If a brand's/car's/part's parameter have changed, you can update it.\nDelete: You can delete a brand/car/part from the database.\n\nA brand can have more cars, but a car can belong to only one brand\nA car can have more parts, and a part can belong to more cars. ");
            Console.WriteLine();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            string press = "(Press any key to get back to the main menu)";
            Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
            Console.WriteLine(press);
            Console.ReadKey();
            MainMenu();

        }
        public void OperationOptions()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                       -] Options [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Brand options   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Car options   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Part options   [ 3 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Special queries   [ 4 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Main menu   [ 5 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                OperationOptions();
            }
            switch (num)
            {
                case 1:
                    BrandOptions();
                    break;
                case 2:
                    CarOptions();
                    break;
                case 3:
                    PartOptions();
                    break;
                case 4:
                    Queries();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    OperationOptions();
                    break;
            }


        }
        public void BrandOptions()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Read All   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Read   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Create   [ 3 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Update  [ 4 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Delete   [ 5 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Back   [ 6 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                BrandOptions();
            }
            if (num == 1)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Name");
                foreach (var item in brands)
                {
                    table.AddRow(item.ID, item.Name);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                BrandOptions();
                ;

            }
            if (num == 2)
            {
                Brand wanted = new Brand();
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Find the brand with the following id :"));
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
                    Console.Write(" ");
                    Console.Write(FiggleFonts.Small.Render(id.ToString()));
                    wanted = MethodTranslator.GetBrand(id);
                    if (wanted == null)
                    {
                        Console.WriteLine("Error: There is no brand with this ID.");
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        BrandOptions();
                    }
                    else
                    {
                        var table = new ConsoleTable("ID", "Name");
                        table.AddRow(wanted.ID, wanted.Name);
                        Console.WriteLine("The wanted brand:");
                        table.Write(Format.Alternative);
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        BrandOptions();
                    }


                    ;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();

                }


                ;
            }
            if (num == 3)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Enter the name of the brand:"));
                string name = Console.ReadLine();
                int idx = MethodTranslator.GetAllBrand().Count+1;
                Brand toadd = new Brand { Name = name, ID = idx };
                try
                {
                    MethodTranslator.CreateBrand(toadd);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();

                }
                
                Console.WriteLine(FiggleFonts.Small.Render("Brand added"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                BrandOptions();
                ;
            }
            if (num == 4)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Name");
                foreach (var item in brands)
                {
                    table.AddRow(item.ID, item.Name);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the brand,"));
                Console.Write(FiggleFonts.Small.Render("that you want to update:"));
                List<int> indexes = new List<int>();
                foreach (var item in brands)
                {
                    indexes.Add(item.ID);
                }
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no brand with this ID.");
                    }
                    Brand toupdate = MethodTranslator.GetBrand(idx);
                    Console.WriteLine("Old name: " +toupdate.Name);
                    Console.Write("New name: ");
                    toupdate.Name = Console.ReadLine();
                    MethodTranslator.UpdateBrand(toupdate);
                    Console.Write(FiggleFonts.Small.Render("Brand updated."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                     press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();
                }

            }
            if (num == 5)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Brands [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Name");
                foreach (var item in brands)
                {
                    table.AddRow(item.ID, item.Name);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the brand,"));
                Console.Write(FiggleFonts.Small.Render("that you want to delete:"));
                List<int> indexes = new List<int>();
                foreach (var item in brands)
                {
                    indexes.Add(item.ID);
                }
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no brand with this ID.");
                    }

                    MethodTranslator.DeleteBrand(idx);
                    Console.Write(FiggleFonts.Small.Render("Brand deleted."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();
                }
            }
            if (num == 6)
            {
                OperationOptions();
            }
            else
            {
                BrandOptions();
            }
        }
        public void CarOptions()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Read All   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Read   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Create   [ 3 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Update  [ 4 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Delete   [ 5 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Back   [ 6 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                CarOptions();
            }
            if (num == 1)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var cars = MethodTranslator.GetAllCar();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");

                foreach (var item in cars)
                {
                    table.AddRow(item.ID, item.Model, brands.Find(x=>x.ID==item.BrandID).Name, item.Cylinder_capacity, item.Cylinder_number);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                CarOptions();
                ;

            }
            if (num == 2)
            {
                Car wanted = new Car();
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Find the car with the following id :"));
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
                    Console.Write(" ");
                    Console.Write(FiggleFonts.Small.Render(id.ToString()));
                    wanted = MethodTranslator.GetCar(id);
                    if (wanted == null)
                    {
                        Console.WriteLine("Error: There is no car with this ID.");
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        CarOptions();
                    }
                    else
                    {
                        var brands = MethodTranslator.GetAllBrand();
                        var table = new ConsoleTable("ID", "Name", "Brand", "Cylinder_capacity", "Cylinder_number");
                        table.AddRow(wanted.ID, wanted.Model, brands.Find(x=>x.ID==wanted.BrandID).Name, wanted.Cylinder_capacity, wanted.Cylinder_number);
                        Console.WriteLine("The wanted car:");
                        table.Write(Format.Alternative);
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        CarOptions();
                    }


                    ;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    BrandOptions();

                }


                ;
            }
            if (num == 3)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
   
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Name");
                foreach (var item in brands)
                {
                    table.AddRow(item.ID, item.Name);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                
                try
                {
                    Console.Write("Enter the model of the car: ");
                    string model = Console.ReadLine();
                    Console.Write("Enter the ID of the car's brand: ");
                    int id = int.Parse(Console.ReadLine());
                    var ids = brands.Select(x => x.ID);
                    if (!ids.Contains(id))
                    {
                        throw new ArgumentException("There is no brand with this ID!");
                    }
                    Console.Write("Enter the production year of the car: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Enter the cylinder capacity of the car: ");
                    double cap =double.Parse(Console.ReadLine());
                    Console.Write("Enter the cylinder number of the car: ");
                    int cyl = int.Parse(Console.ReadLine());

                    int idx = MethodTranslator.GetAllCar().Count + 1;
                    Car toadd = new Car() { Model = model, ID = idx, BrandID=id, Production_year=year, Cylinder_capacity=cap, Cylinder_number=cyl, Brand=brands.Find(x=>x.ID==id)};

                    MethodTranslator.CreateCar(toadd);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    CarOptions();

                }

                Console.WriteLine(FiggleFonts.Small.Render("Car added"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                CarOptions();
                ;
            }
            if (num == 4)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var cars = MethodTranslator.GetAllCar();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");

                foreach (var item in cars)
                {
                    table.AddRow(item.ID, item.Model, brands.Find(x => x.ID == item.BrandID).Name, item.Cylinder_capacity, item.Cylinder_number);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the car,"));
                Console.Write(FiggleFonts.Small.Render("that you want to update:"));
                var indexes = cars.Select(x => x.ID);
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no car with this ID.");
                    }
                    Car toupdate = MethodTranslator.GetCar(idx);
                    Console.WriteLine("Old model: " + toupdate.Model);
                    Console.Write("New Model: ");
                    toupdate.Model = Console.ReadLine();

                    Console.WriteLine("Old production year: " + toupdate.Production_year);
                    Console.Write("New production year: ");
                    toupdate.Production_year = int.Parse(Console.ReadLine());

                    Console.WriteLine("Old cylinder capacity: " + toupdate.Cylinder_capacity);
                    Console.Write("New cylinder capacity: ");
                    toupdate.Cylinder_capacity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Old cylinder number: " + toupdate.Cylinder_number);
                    Console.Write("New cylinder number: ");
                    toupdate.Cylinder_number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Old brand name: " + toupdate.Brand.Name);
                    Console.Write("New brand name: ");
                    var names= brands.Select(x => x.Name);
                    string newname = Console.ReadLine();
                    if (names.Contains(newname))
                    {
                        toupdate.Brand = brands.Find(x => x.Name == newname);
                        toupdate.BrandID = toupdate.Brand.ID;
                    }
                    else
                    {
                        throw new ArgumentException("There is no brand in the database with this name, add it to the database first.");
                    }
                    

                    MethodTranslator.UpdateCar(toupdate);
                    Console.Write(FiggleFonts.Small.Render("Car updated."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    CarOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    CarOptions();
                }

            }
            if (num == 5)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Cars [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var cars = MethodTranslator.GetAllCar();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");

                foreach (var item in cars)
                {
                    table.AddRow(item.ID, item.Model, brands.Find(x => x.ID == item.BrandID).Name, item.Cylinder_capacity, item.Cylinder_number);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the car,"));
                Console.Write(FiggleFonts.Small.Render("that you want to delete:"));

                var indexes = cars.Select(x => x.ID);
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no car with this ID.");
                    }

                    MethodTranslator.DeleteCar(idx);
                    Console.Write(FiggleFonts.Small.Render("Car deleted."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    CarOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    CarOptions();
                }
            }
            if (num == 6)
            {
                OperationOptions();
            }
            else
            {
                CarOptions();
            }
        }
        public void PartOptions()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Read All   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Read   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Create   [ 3 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Update  [ 4 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Delete   [ 5 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Back   [ 6 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                CarOptions();
            }
            if (num == 1)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var parts = MethodTranslator.GetAllPart();
                var table = new ConsoleTable("ID", "Name", "Brand", "Item number", "Price", "Weight");
                foreach (var item in parts)
                {
                    table.AddRow(item.ID, item.Name, item.Brand, item.Item_number, item.Price, item.Weight);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                PartOptions();
                ;

            }
            if (num == 2)
            {
                Part wanted = new Part();
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();

                Console.Write(FiggleFonts.Small.Render("Find the part with the following id :"));
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
                    Console.Write(" ");
                    Console.Write(FiggleFonts.Small.Render(id.ToString()));
                    wanted = MethodTranslator.GetPart(id);
                    if (wanted == null)
                    {
                        Console.WriteLine("Error: There is no part with this ID.");
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        PartOptions();
                    }
                    else
                    {
                        var table = new ConsoleTable("ID", "Name", "Brand", "Item number", "Price", "Weight");
                        table.AddRow(wanted.ID, wanted.Name, wanted.Brand, wanted.Item_number, wanted.Price, wanted.Weight);
                 
                        Console.WriteLine("The wanted part:");
                        table.Write(Format.Alternative);
                        for (int i = 0; i < Console.LargestWindowWidth; i++)
                        {
                            Console.Write("-");
                        }
                        press = "(Press any key to get back)";
                        Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(press);
                        Console.ReadKey();
                        PartOptions();
                    }


                    ;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();

                }


                ;
            }
            if (num == 3)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();

                var cars = MethodTranslator.GetAllCar();
                var brands = MethodTranslator.GetAllBrand();
                var table = new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");

                foreach (var item in cars)
                {
                    table.AddRow(item.ID, item.Model, brands.Find(x => x.ID == item.BrandID).Name, item.Cylinder_capacity, item.Cylinder_number);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }

                try
                {
                    Console.Write("Enter the name of the part: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter the brand  of the part: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the item number  of the part: ");
                    string  itemnumber = Console.ReadLine();

                    Console.Write("Enter the price  of the part: ");
                    int price = int.Parse(Console.ReadLine());

                    Console.Write("Enter the weight of the part: ");
                    double weight = double.Parse(Console.ReadLine());

                    int idx = MethodTranslator.GetAllCar().Count + 1;
                    Part toadd = new Part() { ID = MethodTranslator.GetAllPart().Count + 1, Name = name, Brand = brand, Item_number = itemnumber, Price = price, Weight = weight };

                    Console.WriteLine("Enter the ID-s of the compatible cars. Press enter without content, to end the loading process.");
                    string input = "0";
                    while (input!="")
                    {
                        
                        Console.Write("Enter an ID: ");
                        input = Console.ReadLine();
                        if (input!="")
                        {
                            int carid = int.Parse(input);
                            if (cars.Select(x=>x.ID).Contains(carid))
                            {
                                CarPart carPart= new CarPart() { Car = cars.Find(x => x.ID == carid), CarID = cars.Find(x => x.ID == carid).ID};
                                toadd.CarParts.Add(carPart);

                                //var car = MethodTranslator.GetCar(carid);
                                //car.CarParts.Add(new CarPart() { Part = toadd, PartID = toadd.ID });
                                //MethodTranslator.UpdateCar(car);
                            }
                        }
                    }
                    MethodTranslator.CreatePart(toadd);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();

                }

                Console.WriteLine(FiggleFonts.Small.Render("Part added"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                press = "(Press any key to get back)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                PartOptions();
                ;
            }
            if (num == 4)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var parts = MethodTranslator.GetAllPart();
                var table = new ConsoleTable("ID", "Name", "Brand", "Item number", "Price", "Weight");
                foreach (var item in parts)
                {
                    table.AddRow(item.ID, item.Name, item.Brand, item.Item_number, item.Price, item.Weight);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the part,"));
                Console.Write(FiggleFonts.Small.Render("that you want to update:"));
                var indexes = parts.Select(x => x.ID);
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no part with this ID.");
                    }
                    Part toupdate = MethodTranslator.GetPart(idx);

                    Console.WriteLine("Old name: " + toupdate.Name);
                    Console.Write("New name: ");
                    toupdate.Name = Console.ReadLine();

                    Console.WriteLine("Old brand name: " + toupdate.Brand);
                    Console.Write("New brand name: ");
                    toupdate.Brand = Console.ReadLine();

                    Console.WriteLine("Old item number : " + toupdate.Item_number);
                    Console.Write("New item number : ");
                    toupdate.Item_number = Console.ReadLine();

                    Console.WriteLine("Old price : " + toupdate.Price);
                    Console.Write("New price : ");
                    toupdate.Price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Old weight : " + toupdate.Weight);
                    Console.Write("New weight : ");
                    toupdate.Weight = double.Parse(Console.ReadLine());
                    Console.WriteLine("Old compatible cars: ");
                    var brands = MethodTranslator.GetAllBrand();
                    var oldcarstable= new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");
                    foreach (var item in toupdate.CarParts)
                    {
                        oldcarstable.AddRow(item.Car.ID, item.Car.Model, brands.Find(x => x.ID == item.Car.BrandID).Name, item.Car.Cylinder_capacity, item.Car.Cylinder_number);
                    }
                    var cars = MethodTranslator.GetAllCar();
                    var stroldctb = oldcarstable.ToStringAlternative();
                    foreach (var item in stroldctb.Split("\n"))
                    {
                        Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine("All cars in the database, that you are able to choose:");
                    var tablenew = new ConsoleTable("ID", "Model", "Brand", "Cylinder_capacity", "Cylinder_number");
                    foreach (var item in cars)
                    {
                        tablenew.AddRow(item.ID, item.Model, brands.Find(x => x.ID == item.BrandID).Name, item.Cylinder_capacity, item.Cylinder_number);
                    }
                    string tablewenstr = tablenew.ToStringAlternative();
                    foreach (var item in tablewenstr.Split("\n"))
                    {
                        Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                        Console.WriteLine(item);
                    }
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine("Enter the ID-s of the compatible cars. Press enter without content, to end the loading process.");
                    string input = "0";
                    toupdate.CarParts = new List<CarPart>();
                    while (input != "")
                    {
                        Console.Write("Enter an ID: ");
                        input = Console.ReadLine();
                        if (input != "")
                        {
                            int carid = int.Parse(input);
                            if (cars.Select(x => x.ID).Contains(carid))
                            {
                                //CarPart carPart = new CarPart() { Car = cars.Find(x => x.ID == carid), CarID = cars.Find(x => x.ID == carid).ID };
                                //toupdate.CarParts.Add(carPart);
                                toupdate.CarIndexes.Add(carid);

                                
                            }
                        }
                    }


                    MethodTranslator.UpdatePart(toupdate);
                    Console.Write(FiggleFonts.Small.Render("Part updated."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();
                }

            }
            if (num == 5)
            {
                string press;
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Parts [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                var cars = MethodTranslator.GetAllCar();
                var parts = MethodTranslator.GetAllPart();
                var table = new ConsoleTable("ID", "Name", "Brand", "Item number", "Price", "Weight");
                foreach (var item in parts)
                {
                    table.AddRow(item.ID, item.Name, item.Brand, item.Item_number, item.Price, item.Weight);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                Console.Write(FiggleFonts.Small.Render("Enter the ID of the part,"));
                Console.Write(FiggleFonts.Small.Render("that you want to delete:"));

                var indexes = parts.Select(x => x.ID);
                try
                {
                    int idx = int.Parse(Console.ReadLine());
                    if (!indexes.Contains(idx))
                    {
                        throw new ArgumentException("There is no part with this ID.");
                    }

                    MethodTranslator.DeletePart(idx);
                    Console.Write(FiggleFonts.Small.Render("Part deleted."));
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    for (int i = 0; i < Console.LargestWindowWidth; i++)
                    {
                        Console.Write("-");
                    }
                    press = "(Press any key to get back)";
                    Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(press);
                    Console.ReadKey();
                    PartOptions();
                }
            }
            if (num == 6)
            {
                OperationOptions();
            }
            else
            {
                PartOptions();
            }
        }
        public void Queries()
        {
            Console.Clear();
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(FiggleFonts.Small.Render("Brembo spare part user brands   [ 1 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Brands with electric cars   [ 2 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Brand with the most 4 cylinder cars   [ 3 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Cars with the most compatible parts   [ 4 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Average cylinder capacity by brands   [ 5 ]"));
            Console.WriteLine(FiggleFonts.Small.Render("Back   [ 6 ]"));
            for (int i = 0; i < Console.LargestWindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Queries();
            }
            if (num==1)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Brembo spare part user brands"));
                var q = MethodTranslator.BremboUserBrands();
                var table = new ConsoleTable("Brand");
                
                foreach (var item in q)
                {
                    table.AddRow(item.Value);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to continue)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                Queries();
            }
            if (num==2)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Brands with electric cars"));
                var q = MethodTranslator.BrandsWithElectricCars();
                var table = new ConsoleTable("Brand");

                foreach (var item in q)
                {
                    table.AddRow(item.Value);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to continue)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                Queries();
            }
            if (num==3)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Brand with the most 4 cylinder cars"));
                var q = MethodTranslator.BrandWithTheMost4CylinderCar();
                var table = new ConsoleTable("Brand");

                foreach (var item in q)
                {
                    table.AddRow(item.Value);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to continue)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                Queries();
            }
            if (num==4)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Cars with the most compatible parts "));
                var q = MethodTranslator.Top3CarsWithTheMostCompatibleParts();
                var table = new ConsoleTable("Brand", "Model","Compatible part amount" );

                foreach (var item in q)
                {
                        table.AddRow(item.Value[0].Value, item.Value[1].Value, item.Value[2].Value );
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to continue)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                Queries();
            }
            if (num==5)
            {
                Console.Clear();
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(FiggleFonts.Doom.Render("                                                           -] Queries [-"));
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                Console.Write(FiggleFonts.Small.Render("Average cylinder capacity by brands "));
                var q = MethodTranslator.AvgCylinderCapBrands();
                var table = new ConsoleTable("Brand", "Average cylinder capacity");

                foreach (var item in q)
                {
                    table.AddRow(item.Value.Key, item.Value.Value.Value);
                }
                string test = table.ToStringAlternative();
                foreach (var item in test.Split("\n"))
                {
                    Console.SetCursorPosition((169 - item.Length) / 2, Console.GetCursorPosition().Top);
                    Console.WriteLine(item);
                }
                for (int i = 0; i < Console.LargestWindowWidth; i++)
                {
                    Console.Write("-");
                }
                string press = "(Press any key to continue)";
                Console.SetCursorPosition((169 - press.Length) / 2, Console.GetCursorPosition().Top);
                Console.WriteLine(press);
                Console.ReadKey();
                Queries();
            }
            if (num==6)
            {
                OperationOptions();
            }
        }
    }
}
