using System.ComponentModel.DataAnnotations;

namespace MobilePhoneShop
{
    class Acc
    {
        [Key]
        public int accID { get; set; }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Acc() { }
        public Acc(string type)
        {
            this.type = type;
        }
        public override string ToString()
        {
            return type;
        }
    }
}
