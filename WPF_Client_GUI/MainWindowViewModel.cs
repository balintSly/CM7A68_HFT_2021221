using CM7A68_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Client_GUI
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Part> Parts { get; set; }
        public ICommand CreateBrand { get; set; }
        public ICommand ReadAllBrand { get; set; }
        public ICommand ReadBrand { get; set; }
        public ICommand UpdateBrand { get; set; }
        public ICommand DeleteBrand { get; set; }

        public ICommand CreateCar { get; set; }
        public ICommand ReadAllCar { get; set; }
        public ICommand ReadCar { get; set; }
        public ICommand UpdateCar { get; set; }
        public ICommand DeleteCar { get; set; }

        public ICommand CreatePart { get; set; }
        public ICommand ReadAllPart { get; set; }
        public ICommand ReadPart { get; set; }
        public ICommand UpdatePart { get; set; }
        public ICommand DeletePart { get; set; }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {

                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        ID = value.ID,
                        Name = value.Name
                    };
                }
                OnPropertyChanged();
                (DeleteBrand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        ID = value.ID,
                        CarParts = value.CarParts,
                        Brand = value.Brand,
                        BrandID = value.BrandID,
                        Cylinder_capacity = value.Cylinder_capacity,
                        Cylinder_number = value.Cylinder_number,
                        Model = value.Model,
                        Production_year = value.Production_year,
                    };
                }
                OnPropertyChanged();
                (DeleteCar as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCar as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Part selectedPart;

        public Part SelectedPart
        {
            get { return selectedPart; }
            set
            {
                if (value != null)
                {
                    selectedPart = new Part()
                    {
                        ID = value.ID,
                        Name = value.Name,
                        Brand= value.Brand,
                        CarIndexes = value.CarIndexes,
                        CarParts= value.CarParts,
                        Item_number = value.Item_number,
                        Price = value.Price,
                        Weight = value.Weight,

                    };
                }
                OnPropertyChanged();
                (DeletePart as RelayCommand).NotifyCanExecuteChanged();
                (UpdatePart as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Brand BrandToAdd { get; set; }
        public Car CarToAdd { get; set; }
        public Part PartToAdd { get; set; }

        public MainWindowViewModel()
        {
            this.Brands = new RestCollection<Brand>("http://localhost:5000/", "brand", "hub");
            this.Cars = new RestCollection<Car>("http://localhost:5000/", "car", "hub");
            this.Parts = new RestCollection<Part>("http://localhost:5000/", "part", "hub");

            BrandToAdd = new Brand();
            CarToAdd = new Car();
            PartToAdd = new Part();

            CreateBrand = new RelayCommand(
                () => { Brands.Add(new Brand() { Name = BrandToAdd.Name }); BrandToAdd.Name = ""; }
                );
            CreateCar = new RelayCommand(
                () => { }
                );
            CreatePart = new RelayCommand(
                () => { }
                );

            ReadAllBrand = new RelayCommand(
               () => { }
               );
            ReadAllCar = new RelayCommand(
                () => { }
                );
            ReadAllPart = new RelayCommand(
                () => { }
                );

            ReadBrand = new RelayCommand(
               () => { }
               );
            ReadCar = new RelayCommand(
                () => { }
                );
            ReadPart = new RelayCommand(
                () => { }
                );

            UpdateBrand = new RelayCommand(
               () => { Brands.Update(selectedBrand); },
               () => selectedBrand != null
               );
            UpdateCar = new RelayCommand(
                () => { Cars.Update(selectedCar); },
                () => selectedCar != null
                );
            UpdatePart = new RelayCommand(
                () => { Parts.Update(selectedPart); },
                () => selectedPart != null
                );

            DeleteBrand = new RelayCommand(
               () => { Brands.Delete(selectedBrand.ID); },
               () => selectedBrand != null
               );
            DeleteCar = new RelayCommand(
                () => { Cars.Delete(selectedCar.ID); },
                () => selectedCar != null
                );
            DeletePart = new RelayCommand(
                () => { Parts.Delete(selectedPart.ID); },
                () => selectedPart != null
                );




        }

    }
}
