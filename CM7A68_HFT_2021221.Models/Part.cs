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
        private List<int> carIndexes;
        [NotMapped]    //I hope it will work this way
        public List<int> CarIndexes
        {
            get 
            {
                if (this.carIndexes.Count == 0)
                {
                    List<int> indexes = new List<int>();
                    foreach (var item in this.CarParts)
                    {
                        indexes.Add(item.CarID);
                    }
                    return indexes;
                }
                else {return carIndexes; }
                    
            }
            set { this.carIndexes = value; } 
        }
        public Part()
        {
            this.CarParts = new HashSet<CarPart>();
            this.CarIndexes = new List<int>();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() * ID.GetHashCode()*Weight.GetHashCode()*Item_number.GetHashCode();
        }
        public void AddCarId(int id)
        {
            this.carIndexes.Add(id);
        }


    }
}
