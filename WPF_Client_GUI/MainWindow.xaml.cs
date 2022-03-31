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

namespace WPF_Client_GUI
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

        private void btn_close_menu_Click(object sender, RoutedEventArgs e)
        {
            btn_openmenu.Visibility = Visibility.Visible;
            btn_close_menu.Visibility = Visibility.Collapsed;
        }

        private void btn_openmenu_Click(object sender, RoutedEventArgs e)
        {
            btn_openmenu.Visibility = Visibility.Collapsed;
            btn_close_menu.Visibility = Visibility.Visible;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvitem_brands.IsSelected)
            {
                grid_brands.Visibility = Visibility.Visible;
                grid_cars.Visibility = Visibility.Collapsed;
                grid_parts.Visibility = Visibility.Collapsed;
            }
            else if (lvitem_cars.IsSelected)
            {
                grid_brands.Visibility = Visibility.Collapsed;
                grid_cars.Visibility = Visibility.Visible;
                grid_parts.Visibility = Visibility.Collapsed;
            }
            else if (lvitem_parts.IsSelected)
            {
                grid_brands.Visibility = Visibility.Collapsed;
                grid_cars.Visibility = Visibility.Collapsed;
                grid_parts.Visibility = Visibility.Visible;
            }
           
        }
        double windowWidth;
        double windowHeight;
        private void exit_button_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        bool isloaded;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            windowWidth = this.ActualWidth;
            windowHeight = this.ActualHeight;
            isloaded = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (isloaded)
            {
                
                maingrid.Width *=(this.ActualWidth/windowWidth);
                maingrid.Height*=(this.ActualHeight/windowHeight);
            }
        }
    }
}
