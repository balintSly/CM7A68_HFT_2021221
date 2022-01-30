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
        public List<object> Items { get; set; }
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
                Items = new List<object>();
                Items=methodTranslator.BremboUserBrands().Select(x => (object)x.Value).ToList();
                lvDataBinding.ItemsSource = Items;
            }
            else if (special2.IsSelected)
            {
                Items = new List<object>();
                Items=methodTranslator.BrandsWithElectricCars().Select(x => (object)x.Value).ToList();
                lvDataBinding2.ItemsSource = Items;
            }
            else if (special3.IsSelected)
            {
                Items = new List<object>();
                Items=methodTranslator.BrandWithTheMost4CylinderCar().Select(x => (object)x.Value).ToList();
                lvDataBinding3.ItemsSource = Items;
            }
            else if(special4.IsSelected)
            {
                Items=new List<object>();
                var query = methodTranslator.Top3CarsWithTheMostCompatibleParts();
                foreach (var item in query)
                {
                    Items.Add(new { Car = item.Value[0].Value + " " + item.Value[1].Value, Parts = item.Value[2].Value + " parts" });
                }
                lvDataBinding4.ItemsSource = Items;
            }
            else if (special5.IsSelected)
            {
                Items = new List<object>();
                var query = methodTranslator.AvgCylinderCapBrands();
                foreach (var item in query)
                {
                    Items.Add(new {Brand=item.Value.Key, AvgCap=item.Value.Value.Value +"l"});
                }
                lvDataBinding5.ItemsSource = Items;
            }
        }

        private void brands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brandRead.IsSelected)
            {
                Items=new List<object>();
                var brands = methodTranslator.GetAllBrand();
                brandId.ItemsSource = brands.Select(x =>x.ID).ToList();
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
    }
}
