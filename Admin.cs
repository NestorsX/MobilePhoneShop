using System.ComponentModel.DataAnnotations;

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
