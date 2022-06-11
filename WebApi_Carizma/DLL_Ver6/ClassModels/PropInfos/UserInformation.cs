using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.ClassModels.PropInfos
{
  public  class UserInformation
    {
        public int userTz { get; set; }
        public string nickName { get; set; }
        public string fullName { get; set; }
        public DateTime bDay { get; set; }
        public Gender gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
        public Role role { get; set; }
    }
}
