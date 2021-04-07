using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class Order
    {
        AppContext apc = new AppContext();
        [Key]
        public int orderID { get; set; }
        private int dataID, phoneID;
        private double cost;
        private string address;
        DateTime orderDate;
        public int DataID
        {
            get { return dataID; }
            set { dataID = value; }
        }
        public int PhoneID
        {
            get { return phoneID; }
            set { phoneID = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        public Order() { }
        public Order(int dataID, int phoneID, double cost, string address, DateTime orderDate)
        {
            this.dataID = dataID;
            this.phoneID = phoneID;
            this.cost = cost;
            this.address = address;
            this.orderDate = orderDate;
        }
        public override string ToString()
        {
            return "Заказ по адресу: " + address.Trim() + " на телефон: " + apc.phones.Where(phone => phone.phoneID == phoneID).FirstOrDefault().Models.Trim();
        }
    }
}
