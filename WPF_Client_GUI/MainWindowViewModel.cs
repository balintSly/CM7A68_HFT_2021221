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
    public class MainWindowViewModel:ObservableRecipient
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
                SetProperty(ref selectedBrand, value);
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
                SetProperty(ref selectedCar, value);
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
                SetProperty(ref selectedPart, value);
                (DeletePart as RelayCommand).NotifyCanExecuteChanged();
                (UpdatePart as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Brand BrandToAdd { get; set; }
        public Car CarToAdd { get; set; }
        public Part PartToAdd { get; set; }

        public MainWindowViewModel()
        {
            this.Brands = new RestCollection<Brand>("http://localhost:5000/","brand");
            this.Cars = new RestCollection<Car>("http://localhost:5000/", "car");
            this.Parts = new RestCollection<Part>("http://localhost:5000/", "part");

            BrandToAdd = new Brand();
            CarToAdd = new Car();
            PartToAdd= new Part();

            CreateBrand = new RelayCommand(
                () => { Brands.Add(BrandToAdd); BrandToAdd = new Brand(); }
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
               () => { },
               ()=>selectedBrand!=null
               );
            UpdateCar = new RelayCommand(
                () => { },
                () => selectedCar != null
                );
            UpdateCar = new RelayCommand(
                () => { },
                ()=>selectedPart!=null
                );

            DeleteBrand = new RelayCommand(
               () => { Brands.Delete(selectedBrand.ID); },
               () => selectedBrand != null
               );
            DeleteCar = new RelayCommand(
                () => { },
                () => selectedCar != null
                );
            DeletePart = new RelayCommand(
                () => { },
                () => selectedPart != null
                );




        }

    }
}
