using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CM7A68_HFT_2021221.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
        public Brand()
        {
            Cars = new HashSet<Car>();
            this.Name = "";
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode()==obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() * ID.GetHashCode();
        }


    }
}
