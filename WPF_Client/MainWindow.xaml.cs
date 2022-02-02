using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using CM7A68_HFT_2021221.Models;
using System.Threading;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MethodTranslator methodTranslator=new MethodTranslator();
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void themeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);

            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
              Application.Current.Shutdown();
        }

        private void specials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (special1.IsSelected)
            {
                lvDataBinding.ItemsSource = methodTranslator.BremboUserBrands().Select(x => (object)x.Value).ToList();
            }
            else if (special2.IsSelected)
            {
                lvDataBinding2.ItemsSource = methodTranslator.BrandsWithElectricCars().Select(x => (object)x.Value).ToList();
            }
            else if (special3.IsSelected)
            {
                lvDataBinding3.ItemsSource = methodTranslator.BrandWithTheMost4CylinderCar().Select(x => (object)x.Value).ToList();
            }
            else if(special4.IsSelected)
            {
                var items=new List<object>();
                var query = methodTranslator.Top3CarsWithTheMostCompatibleParts();
                foreach (var item in query)
                {
                    items.Add(new { Car = item.Value[0].Value + " " + item.Value[1].Value, Parts = item.Value[2].Value + " parts" });
                }
                lvDataBinding4.ItemsSource = items;
            }
            else if (special5.IsSelected)
            {
                var items = new List<object>();
                var query = methodTranslator.AvgCylinderCapBrands();
                foreach (var item in query)
                {
                    items.Add(new {Brand=item.Value.Key, AvgCap=item.Value.Value.Value +"l"});
                }
                lvDataBinding5.ItemsSource = items;
            }
        }

        private void brands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brandRead.IsSelected)
            {
                var brands = methodTranslator.GetAllBrand();
                brandId.ItemsSource = brands.Select(x =>x.ID).ToList();
            }
            else if(readAllBrand.IsSelected)
            {
                readedAllBrand.ItemsSource=methodTranslator.GetAllBrand();
            }
            else if(updateBrands.IsSelected)
            {
                updatebrandID.ItemsSource = methodTranslator.GetAllBrand().Select(x => x.ID).ToList();
                updateAllBrand.ItemsSource = methodTranslator.GetAllBrand();
            }
            else if (deleteBrand.IsSelected)
            {
                deletebrandID.ItemsSource = methodTranslator.GetAllBrand().Select(x => x.ID).ToList();
                deleteAllBrand.ItemsSource = methodTranslator.GetAllBrand();
            }
        }

        private void createBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            var brandnames = methodTranslator.GetAllBrand().Select(x => x.Name).ToList();
            if ((((TextBox)brandName).Text).Length==0)
            {
                brandCreateResponse.Text = "The field of the name can't be empty!";
            }
            else if (brandnames.Contains(((TextBox)brandName).Text))
            {
                brandCreateResponse.Text = "There is already a brand with this name in the database!";
            }
            else
            {
                methodTranslator.CreateBrand(new Brand() {Name= ((TextBox)brandName).Text });
                brandCreateResponse.Text = "Brand successfully added to the database!";
            }

        }

        private void brandId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int id = (int)((ComboBox)brandId).SelectedItem;
            var brand = methodTranslator.GetAllBrand().Where(x => x.ID == id).First();
            readedBrand.ItemsSource = new List<Brand>() {brand};
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void updateBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            var brands = methodTranslator.GetAllBrand();
            Brand brand= brands.Where(x => x.ID == (int)((ComboBox)updatebrandID).SelectedItem).First();
            var brandnames = brands.Select(x => x.Name).ToList();
            if ((((TextBox)updatebrandName).Text).Length == 0)
            {
                brandupdateResponse.Text = "The field of the name can't be empty!";
            }
            else if (brandnames.Contains(((TextBox)brandName).Text))
            {
                brandupdateResponse.Text = "There is already a brand with this name in the database!";
            }
            else
            {
                brand.Name = ((TextBox)updatebrandName).Text;
                methodTranslator.UpdateBrand(brand);
                brandupdateResponse.Text = "Brand successfully updated in the database!";
                updateAllBrand.ItemsSource = methodTranslator.GetAllBrand();
            }
        }

        private void deleteBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            methodTranslator.DeleteBrand((int)((ComboBox)deletebrandID).SelectedItem);
            branddeleteResponse.Text = "Brand successfully deleted from the database!";
            deleteAllBrand.ItemsSource = methodTranslator.GetAllBrand();            
        }

        private void createCarBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if ((((TextBox)carModel).Text).Length == 0)
            {
                carCreateResponse.Text = "The field of the model can't be empty!";
            }
            else
            {
                var brands=methodTranslator.GetAllBrand();
                Car car = new Car();
                Brand carsbrand=brands.First(x => x.Name == (string)((ComboBox)brandnameBox).SelectedItem);
                car.Brand = carsbrand;
                car.Model = ((TextBox)carModel).Text;
                car.Production_year = (int)((ComboBox)yearsBox).SelectedItem;
                car.Cylinder_number = (int)((ComboBox)cilnumBox).SelectedItem;
                car.Cylinder_capacity = (double)((ComboBox)cilcapBox).SelectedItem;
                car.BrandID = carsbrand.ID;
                methodTranslator.CreateCar(car);
                carCreateResponse.Text = "Car successfully added to the database!";
            }
        }

        private void cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carCreate.IsSelected)
            {
                int yearnow = DateTime.Now.Year;
                List<int> years = new List<int>();
                for (int i = yearnow; i >= 1886; i--)
                {
                    years.Add(i);
                }
                yearsBox.ItemsSource = years;
                List<int> cylnums = new List<int>();
                for (int i = 16; i >= 0; i--)
                {
                    cylnums.Add(i);
                }
                cilnumBox.ItemsSource = cylnums;
                double maxcap = 8.4;
                List<double> caps = new List<double>();
                while (maxcap >= 1)
                {
                    caps.Add(Math.Round(maxcap, 1));
                    maxcap -= 0.1;
                }
                caps.Add(0.5);
                caps.Add(0);
                cilcapBox.ItemsSource = caps;
                var brandsnames = methodTranslator.GetAllBrand().Select(x => x.Name).ToList();
                brandnameBox.ItemsSource = brandsnames;

            }
            else if (carRead.IsSelected)
            {
                carIds.ItemsSource = methodTranslator.GetAllCar().Select(x => x.ID).ToList();
            }
            else if (readAllCar.IsSelected)
            {
                var cars = methodTranslator.GetAllCar();
                List<object> list = new List<object>();
                var brands = methodTranslator.GetAllBrand();
                foreach (var car in cars)
                {
                    list.Add(new {ID=car.ID, Brand= brands.Where(x=>x.ID==car.BrandID).Select(y=>y.Name).First(),Model=car.Model, Production_year=car.Production_year, Cylinder_number=car.Cylinder_number, Cylinder_capacity=car.Cylinder_capacity });
                }
                readedAllCar.ItemsSource=list;
            }
            else if (updateCar.IsSelected)
            {
                updateCarID.ItemsSource = methodTranslator.GetAllCar().Select(x => x.ID).ToList();
                var cars = methodTranslator.GetAllCar();
                List<object> list = new List<object>();
                var brands = methodTranslator.GetAllBrand();
                foreach (var car in cars)
                {
                    list.Add(new { ID = car.ID, Brand = brands.Where(x => x.ID == car.BrandID).Select(y => y.Name).First(), Model = car.Model, Production_year = car.Production_year, Cylinder_number = car.Cylinder_number, Cylinder_capacity = car.Cylinder_capacity });
                }
                int yearnow = DateTime.Now.Year;
                List<int> years = new List<int>();
                for (int i = yearnow; i >= 1886; i--)
                {
                    years.Add(i);
                }
                List<int> cylnums = new List<int>();
                for (int i = 16; i >= 0; i--)
                {
                    cylnums.Add(i);
                }
                double maxcap = 8.4;
                List<double> caps = new List<double>();
                while (maxcap >= 1)
                {
                    caps.Add(Math.Round(maxcap, 1));
                    maxcap -= 0.1;
                }
                caps.Add(0.5);
                caps.Add(0);

                updateAllCar.ItemsSource = list;
                updateCarBrand.ItemsSource = brands.Select(x => x.Name).ToList();
                updateCarProd.ItemsSource = years;
                updateCarCylNum.ItemsSource = cylnums;
                updateCarCylCap.ItemsSource = caps;
                

            }
            else if (deleteCar.IsSelected)
            {
                deleteCarID.ItemsSource = methodTranslator.GetAllCar().Select(x => x.ID).ToList();
                var cars = methodTranslator.GetAllCar();
                List<object> list = new List<object>();
                var brands = methodTranslator.GetAllBrand();
                foreach (var car in cars)
                {
                    list.Add(new { ID = car.ID, Brand = brands.Where(x => x.ID == car.BrandID).Select(y => y.Name).First(), Model = car.Model, Production_year = car.Production_year, Cylinder_number = car.Cylinder_number, Cylinder_capacity = car.Cylinder_capacity });
                }
                deleteAllCar.ItemsSource = list;
            }
        }
        private void carIds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (int)((ComboBox)carIds).SelectedItem;
            var car = methodTranslator.GetAllCar().Where(x => x.ID == id).First();
            var brandname = methodTranslator.GetBrand(car.ID).Name;
            readedCar.ItemsSource = new List<object>() { new {ID=car.ID, Model=car.Model,Brand=brandname, Production_year=car.Production_year, Cylinder_number=car.Cylinder_number, Cylinder_capacity=car.Cylinder_capacity} };
        }
        private void updateCarBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((((TextBox)updateCarModel).Text).Length == 0)
            {
                carupdateResponse.Text = "The field of the model can't be empty!";
            }
            else
            {
                var car = methodTranslator.GetAllCar().Where(x=>x.ID==(int)updateCarID.SelectedValue).First();
                var brands = methodTranslator.GetAllBrand();
                Brand carsbrand = brands.First(x => x.Name == (string)((ComboBox)updateCarBrand).SelectedItem);
                car.Brand = carsbrand;
                car.Model = ((TextBox)updateCarModel).Text;
                car.Production_year = (int)((ComboBox)updateCarProd).SelectedItem;
                car.Cylinder_number = (int)((ComboBox)updateCarCylNum).SelectedItem;
                car.Cylinder_capacity = (double)updateCarCylCap.SelectedItem;
                car.BrandID = carsbrand.ID;
                methodTranslator.UpdateCar(car);
                carupdateResponse.Text = "Car successfully updated in the database!";
                updateAllCar.ItemsSource = methodTranslator.GetAllCar();
            }
        }

        private void updateCarID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cars = methodTranslator.GetAllCar();
            var brands = methodTranslator.GetAllBrand();
            var combo = updateCarID.SelectedItem;
            int id = (int)combo;
            Car cartoupdate = cars.Where(x => x.ID == id).First();
            carUpdateStack.Visibility = Visibility.Visible;
            updateCarBrand.SelectedValue = brands.Where(x => x.ID == cartoupdate.BrandID).First().Name;
            updateCarModel.Text = cartoupdate.Model;
            updateCarProd.SelectedValue = cartoupdate.Production_year;
            updateCarCylNum.SelectedValue = cartoupdate.Cylinder_number;
            updateCarCylCap.SelectedValue = cartoupdate.Cylinder_capacity;
        }

        private void updateCarCylNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (updateCarCylNum.SelectedValue!=null && (int)updateCarCylNum.SelectedValue ==0)
            {
                updateCarCylCap.Visibility = Visibility.Hidden;
                updateCarCylCap.SelectedValue = 0;
               
            }
            else
            {
                updateCarCylCap.Visibility = Visibility.Visible;
            }
        }

        private void updateCarCylCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (updateCarCylCap.SelectedValue != null && (double)updateCarCylCap.SelectedValue == 0)
            {
                updateCarCylNum.Visibility = Visibility.Hidden;
                updateCarCylNum.SelectedValue = 0;
  
            }
            else
            {
                updateCarCylNum.Visibility = Visibility.Visible;
            }
        }

        private void deleteCarBtn_Click(object sender, RoutedEventArgs e)
        {
     
            if (deleteCarID.SelectedItem == null)
            {
                cardeleteResponse.Text = "Select an ID!";
            }
            else
            {
                var id = (int)deleteCarID.SelectedItem;
                methodTranslator.DeleteCar(id);
                cardeleteResponse.Text = "Car successfully deleted from the database!";
                var cars = methodTranslator.GetAllCar();
                List<object> list = new List<object>();
                var brands = methodTranslator.GetAllBrand();
                foreach (var car in cars)
                {
                    list.Add(new { ID = car.ID, Brand = brands.Where(x => x.ID == car.BrandID).Select(y => y.Name).First(), Model = car.Model, Production_year = car.Production_year, Cylinder_number = car.Cylinder_number, Cylinder_capacity = car.Cylinder_capacity });
                }
                deleteAllCar.ItemsSource = list;
            }
        }

        private void parts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (partCreate.IsSelected)
            { 
            
            }
            else if(partRead.IsSelected)
            {

            }
            else if (partReadAll.IsSelected)
            {

            }
            else if (partUpdate.IsSelected)
            {

            }
            else if (partDelete.IsSelected)
            {

            }

        }

        private void createPartBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
