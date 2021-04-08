using System.ComponentModel.DataAnnotations;

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
