using System;
using System.Collections.Generic;

#nullable disable

namespace DLL_Ver6
{
    public partial class UserTable
    {
        public UserTable()
        {
            RentTables = new HashSet<RentTable>();
        }

        public int UserId { get; set; }
        public int UserTz { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public DateTime Bday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Role { get; set; }

        public virtual ICollection<RentTable> RentTables { get; set; }
    }
}
