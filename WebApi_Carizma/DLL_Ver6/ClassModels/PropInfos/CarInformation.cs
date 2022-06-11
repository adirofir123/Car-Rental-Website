using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.ClassModels.PropInfos
{
  public  class CarInformation
    {
        public int carId { get; set; }
        public int carNumber { get; set; }
        public int quantity { get; set; }
        public string manufactor { get; set; }
        public string model { get; set; }
        public int km { get; set; }
        public int year { get; set; }
        public int dayPrice { get; set; }
        public int delayPrice { get; set; }
        public string available { get; set; }
        public string rentable { get; set; }
        public string picture { get; set; }
    }
}
