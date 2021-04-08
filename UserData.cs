using System;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneShop
{
    class UserData
    {
        [Key]
        public int dataID { get; set; }
        private string firstName, secondName, thirdName, telNumber, email;
        private DateTime registerDate, lastAccessDate;
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
        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }
        public DateTime LastAccessDate
        {
            get { return lastAccessDate; }
            set { lastAccessDate = value; }
        }
        public UserData() { }
        public UserData(string firstName, string email, DateTime registerDate)
        {
            this.firstName = firstName;
            this.email = email;
            this.registerDate = registerDate;
        }
    }
}
