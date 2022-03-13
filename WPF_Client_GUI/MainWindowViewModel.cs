using CM7A68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Client_GUI
{
    public class MainWindowViewModel
    {
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Part> Parts { get; set; }
        public MainWindowViewModel()
        {
            this.Brands = new RestCollection<Brand>("http://localhost:5000/", "brand");
            this.Cars = new RestCollection<Car>("http://localhost:5000/", "car");
            this.Parts = new RestCollection<Part>("http://localhost:5000/part", "part");
            ;
        }
    }
}
