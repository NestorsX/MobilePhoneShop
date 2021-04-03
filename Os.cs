using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class Os
    {
        [Key]
        public int osID { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Os() { }
        public Os(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
