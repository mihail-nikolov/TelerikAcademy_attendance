using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    public class GSM
    {
        private const double PRICE_PER_SEC = 0.37;
        private static string iphone4s = "here is all the info about Iphone4S";
        private string model;
        private string manufacturer;
        private string owner;
        private uint price;
        private List<Call> callHistory;
        private Battery battery;
        private Display display;

        public static string Iphone4S
        {
            get { return iphone4s; }
        }
        public GSM(string model, string manufacturer, string owner, uint price, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Price = price;
            this.Battery = battery;
            this.Display = display;
            this.callHistory = new List<Call> { };
        }
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.callHistory = new List<Call> { };
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public uint Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }
        public override string ToString()
        {
            return string.Format(
@"model: {0}, manufacturer: {1}, price: {2}, owner: {3};
  Battery: model: {4}, type: {5}, hoursIdle: {6}, hoursTalk: {7}
  Display: size: {8}, numberOfColors: {9}", this.Model, this.Manufacturer,
                                           this.Price, this.Owner, this.Battery.Model,
                                           this.Battery.TheType, this.Battery.HoursIdle, this.Battery.HoursTalk, 
                                           this.Display.Size, this.Display.NumberOfColors);
        }

        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }
        public void DelCall(Call callTodel)
        {
            this.CallHistory.Remove(callTodel);
        }
        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        public double CallPriceCalc()
        {
            double price = 0; //leva
            foreach (var call in this.CallHistory)
            {
                price += (call.Duration * PRICE_PER_SEC);
            }
            return price;//leva
        }
        public void PrintCallHistory()
        {
            foreach (var call in this.CallHistory)
            {
                Console.WriteLine("dateTime: {0}, dialedNum: {1}, duration: {2}", call.DateTimeCall, call.DialedNum, call.Duration);
            }
        }
    }
}
