using System;
using System.Collections.Generic;



#nullable disable

namespace DLL_Ver6
{
    public partial class CarInfo
    {
        public CarInfo()
        {
            RentTables = new HashSet<RentTable>();
        }

        public int CarId { get; set; }
        public string CarType { get; set; }
        public int Km { get; set; }
        public string Pic { get; set; }
        public string Rentable { get; set; }
        public string Available { get; set; }
        public int CarNum { get; set; }

        public virtual CarType Car { get; set; }
        public virtual ICollection<RentTable> RentTables { get; set; }
    }
}
