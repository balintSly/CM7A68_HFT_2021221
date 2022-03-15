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
        #region commands
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
        #endregion

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
                        Name = value.Name,
                    };
                }
                OnPropertyChanged();
                (DeleteBrand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrand as RelayCommand).NotifyCanExecuteChanged();
                ;

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
                        Brand = Brands.Where(x => x.ID == value.BrandID).First(),
                        BrandID = value.BrandID,
                        Cylinder_capacity = value.Cylinder_capacity,
                        Cylinder_number = value.Cylinder_number,
                        Model = value.Model,
                        Production_year = value.Production_year,
                    };
                }
                CarToUpdatesBrand = Brands.Where(x => x.ID == value.BrandID).First();
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
                        Brand = value.Brand,
                        CarIndexes = value.CarIndexes,
                        CarParts = value.CarParts,
                        Item_number = value.Item_number,
                        Price = value.Price,
                        Weight = value.Weight,

                    };
                }
                SelectedCarsToPart = new List<Car>();
                OnPropertyChanged();
                (DeletePart as RelayCommand).NotifyCanExecuteChanged();
                (UpdatePart as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Brand BrandToAdd { get; set; }
        public Car CarToAdd { get; set; }
        public Brand CarToAddsBrand { get; set; }
        public Brand CarToUpdatesBrand { get; set; }

        public Part PartToAdd { get; set; }
        public List<Car> SelectedCarsToPart { get; set; }
        private Car selectedCarAddToPart;

        public Car SelectedCarAddToPart
        {
            get { return selectedCarAddToPart; }
            set 
            { 
                selectedCarAddToPart = value;
                if (SelectedCarsToPart.Where(x=>x.ID==value.ID).FirstOrDefault()==null)
                {
                    SelectedCarsToPart.Add(new Car
                    {
                        BrandID = value.BrandID,
                        ID= value.ID,
                        CarParts = value.CarParts,
                        Cylinder_capacity = value.Cylinder_capacity,
                        Cylinder_number = value.Cylinder_number,
                        Model = value.Model,
                        Production_year = value.Production_year
                    });
                }
               
            }
        }

        public MainWindowViewModel()
        {
            this.Brands = new RestCollection<Brand>("http://localhost:5000/", "brand", "hub");
            this.Cars = new RestCollection<Car>("http://localhost:5000/", "car", "hub");
            this.Parts = new RestCollection<Part>("http://localhost:5000/", "part", "hub");


            BrandToAdd = new Brand();
            CarToAdd = new Car();
            CarToAddsBrand = new Brand();
            PartToAdd = new Part();
            SelectedCarsToPart = new List<Car>();
            CarToUpdatesBrand = Brands.FirstOrDefault();

            CreateBrand = new RelayCommand(
                () => { Brands.Add(new Brand() { Name = BrandToAdd.Name }); });
            CreateCar = new RelayCommand(
                () =>
                {
                    var newCar = new Car()
                    {
                        Model = CarToAdd.Model,
                        Cylinder_capacity = CarToAdd.Cylinder_capacity,
                        Cylinder_number = CarToAdd.Cylinder_number,
                        Production_year = CarToAdd.Production_year,
                        //Brand = CarToAddsBrand,
                        BrandID = CarToAddsBrand.ID
                    };
                    Cars.Add(newCar);
                    OnPropertyChanged();
                    ;
                }
                );
            CreatePart = new RelayCommand(
                () =>
                {
                    var newPart = new Part()
                    {
                        Brand = PartToAdd.Brand,
                        Name = PartToAdd.Name,
                        Weight = PartToAdd.Weight,
                        Item_number = PartToAdd.Item_number,
                        Price = PartToAdd.Price,
                        CarIndexes= SelectedCarsToPart.Select(x=>x.ID).ToList()
                    };
                    Parts.Add(newPart);
                    OnPropertyChanged();
                }
                );
            #region reads
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
            #endregion
            UpdateBrand = new RelayCommand(
               () =>
               { Brands.Update(selectedBrand); },
               () => selectedBrand != null
               );
            UpdateCar = new RelayCommand(
                () =>
                {
                    selectedCar.BrandID = CarToUpdatesBrand.ID;
                    selectedCar.Brand = null;
                    Cars.Update(selectedCar);
                },
                () => selectedCar != null
                );
            UpdatePart = new RelayCommand(
                () => 
                {
                    selectedPart.CarParts.Clear();
                    selectedPart.CarIndexes.Clear();
                    selectedPart.CarIndexes= SelectedCarsToPart.Select(x=>x.ID).ToList();
                    Parts.Update(selectedPart);
                    SelectedCarsToPart.Clear();
                },
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
                () => { 
                    Parts.Delete(selectedPart.ID); 
                },
                () => selectedPart != null
                );




        }

    }
}
