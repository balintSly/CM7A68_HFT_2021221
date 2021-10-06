using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Models
{
    public class Part
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public string Item_number { get; set; }
        public string Brand { get; set; }

        public ICollection<Car> Compatible_cars { get; set; }
        public Part()
        {
            Compatible_cars = new HashSet<Car>();
        }



    }
}
