using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class DisplayTech
    {
        [Key]
        public int displayTechID { get; set; }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public DisplayTech() { }
        public DisplayTech(string type)
        {
            this.type = type;
        }
        public override string ToString()
        {
            return type;
        }
    }
}
