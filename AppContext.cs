using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MobilePhoneShop
{
    class AppContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<UserData> userDatas { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Os> os { get; set; }
        public DbSet<DisplayTech> displayTeches { get; set; }
        public DbSet<Acc> accs { get; set; }
        public DbSet<Phone> phones { get; set; }
        public DbSet<Order> orders { get; set; }
        public AppContext() : base("DBConnection") { }
    }
}
