using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        public string Model { get; set; }
        public int Production_year { get; set; }
        public int  Cylinder_number { get; set; }
        public double Cylinder_capacity { get; set; }
        [NotMapped]
        [JsonIgnore]
        public  virtual Brand Brand { get; set; }
        //[JsonIgnore]
        public virtual ICollection<CarPart> CarParts { get; set; }
        public Car()
        {
            this.CarParts = new HashSet<CarPart>();
        }

        [ForeignKey(nameof(Brand))]
        public int BrandID { get; set; }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return Model.GetHashCode() * ID.GetHashCode()*Production_year.GetHashCode()*Cylinder_number.GetHashCode();
        }
    }
}
