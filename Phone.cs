using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneShop
{
    class Phone
    {
        [Key]
        public int phoneID { get; set; }
        private int osID, displayTechID;
        private string models;
        private int simCount;
        private string processor;
        private int mainCameraRes, frontCameraRes, ramCapacity, romCapacity;
        private string colour;
        private double weight;
        private int accID;
        private double cost;
        public int OsID
        {
            get { return osID; }
            set { osID = value; }
        }
        public int DisplayTechID
        {
            get { return displayTechID; }
            set { displayTechID = value; }
        }
        public int AccID
        {
            get { return accID; }
            set { accID = value; }
        }
        public int SimCount
        {
            get { return simCount; }
            set { simCount = value; }
        }
        public int MainCameraRes
        {
            get { return mainCameraRes; }
            set { mainCameraRes = value; }
        }
        public int FrontCameraRes
        {
            get { return frontCameraRes; }
            set { frontCameraRes = value; }
        }
        public int RamCapacity
        {
            get { return ramCapacity; }
            set { ramCapacity = value; }
        }
        public int RomCapacity
        {
            get { return romCapacity; }
            set { romCapacity = value; }
        }
        public string Models
        {
            get { return models; }
            set { models = value; }
        }
        public string Processor
        {
            get { return processor; }
            set { processor = value; }
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public Phone() { }
        public Phone(int osID, int displayTechID, string models, int simCount, string processor, int mainCameraRes, int frontCameraRes, int ramCapacity, 
            int romCapacity, string colour, double weight, int accID, double cost)
        {
            this.osID = osID;
            this.displayTechID = displayTechID;
            this.models = models;
            this.simCount = simCount;
            this.processor = processor;
            this.mainCameraRes = mainCameraRes;
            this.frontCameraRes = frontCameraRes;
            this.ramCapacity = ramCapacity;
            this.romCapacity = romCapacity;
            this.colour = colour;
            this.weight = weight;
            this.accID = accID;
            this.cost = cost;
        }
        public override string ToString()
        {
            return models;
        }
    }
}
