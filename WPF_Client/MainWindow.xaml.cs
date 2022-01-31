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
    }
}
