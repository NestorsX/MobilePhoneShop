using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class Admin
    {
        [Key]
        public int userID { get; set; }
        private int adminFlag;
        public int AdminFlag
        {
            get { return adminFlag; }
            set { adminFlag = value; }
        }
        public Admin() { }
        public Admin(int adminFlag)
        {
            this.adminFlag = adminFlag;
        }
    }
}
