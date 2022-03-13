using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Models
{
    public class CarPart
    {
        [JsonIgnore]
        public virtual Car Car { get; set; }     
        public int CarID { get; set; }     
        public virtual Part Part { get; set; }     
        public int PartID { get; set; }     
    }
}
