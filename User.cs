using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class User
    {
        private int id { get; set; }
        private string login, password;
        private int DataId { get; set; }
        public User() { }
        public User(string login, string password, int DataId)
        {
            this.login = login;
            this.password = password;
            this.DataId = DataId;
        }
    }
}
