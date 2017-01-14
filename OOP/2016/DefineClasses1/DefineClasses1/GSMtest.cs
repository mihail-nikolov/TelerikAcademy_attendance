using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    class GSMtest
    {
        private uint numOfGSMs;
        private GSM[] gsmArr;

        public GSMtest(uint numOfGSMs)
        {
            this.NumOfGSMs = numOfGSMs;
            this.gsmArr = new GSM[this.NumOfGSMs]; 
        }

        public uint NumOfGSMs
        {
            get { return numOfGSMs; }
            set { this.numOfGSMs = value; }
        }
        public GSM[] GsmArr
        {
            get { return this.gsmArr; }
           // set { return gsmArr; }
        }

        public void GenerateGSMs()
        {
            for (uint i = 0; i < this.NumOfGSMs; i++)
            {
                uint hoursIdle = 50 + 3 * i;
                uint hoursTalk = 20 + 5 * i;
                Battery newBat = new Battery("Nokia", hoursIdle, hoursTalk, BatType.LiIon);
                byte dispSize = (byte)(1 + 2 * i);
                uint numCols = 200 + 11 * i;
                Display newDisplay = new Display(dispSize, numCols);
                uint price = 45 + 13 * i;
                string owner = string.Format("Person # {0}", i + 1);
                GSM newGSM = new GSM("nokia", "nokiaEOOD", owner, price, newBat, newDisplay);
                this.GsmArr[i] = newGSM;
            }
        }

        public void PrintGSMs()
        {
            foreach (var gsm in this.GsmArr)
            {
                Console.WriteLine(gsm.ToString());
            }
        }
        public void DisplayIphone4SInfo()
        {
            Console.WriteLine(GSM.Iphone4S);
        }
    }
}
