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
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Price { get; set; }
        public string Item_number { get; set; }
        public string Brand { get; set; }
        [JsonIgnore]
        public virtual ICollection<CarPart> CarParts { get; set; }
        public Part()
        {
            this.CarParts = new HashSet<CarPart>();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() * ID.GetHashCode()*Weight.GetHashCode()*Item_number.GetHashCode();
        }


    }
}
