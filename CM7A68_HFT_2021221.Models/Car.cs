using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        public string Model { get; set; }
        public int Production_year { get; set; }
        public int  Cylinder_number { get; set; }
        public int Cylinder_capacity { get; set; }
        public Brand Brand { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandID { get; set; }

    }
}
