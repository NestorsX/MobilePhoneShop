using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class UserData
    {
        private int dataId { get; set; }
        private string firstName, secondName, thirdName, telNumber, email, registerDate, lastAccessDate;
        private int bankCardId { get; set; }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string ThirdName
        {
            get { return thirdName; }
            set { thirdName = value; }
        }
        public string TelNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }
        public string LastAccessDate
        {
            get { return lastAccessDate; }
            set { lastAccessDate = value; }
        }
        public UserData() { }
        public UserData(string firstName, string email, string registerDate)
        {
            this.firstName = firstName;
            this.email = email;
            this.registerDate = registerDate;
        }
    }
}
