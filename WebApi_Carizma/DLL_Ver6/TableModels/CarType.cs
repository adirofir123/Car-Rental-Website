using System;
using System.Collections.Generic;

#nullable disable

namespace DLL_Ver6
{
    public partial class CarType
    {
        public CarType()
        {
            CarInfos = new HashSet<CarInfo>();
        }

        public int CarId { get; set; }
        public int Quantity { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int Dprice { get; set; }
        public int DelayPrice { get; set; }
        public int Year { get; set; }

        public virtual ICollection<CarInfo> CarInfos { get; set; }
    }
} 
