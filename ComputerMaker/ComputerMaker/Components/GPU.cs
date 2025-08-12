using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class GPU : ComputerComponent
    {
        private int GBamount;
        private double frequency;
        public double Frequency
        {
            get { return frequency; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Частота не може бути від'ємною");
                }
                frequency = value;
            }
        }
        public int GBAmount
        {
            get { return GBamount; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Кількість ГБ не може бути від'ємною");
                }
                GBamount = value;
            }
        }
        public GPU(string name, int price, int gbAmount) : base(name, price)
        {
            GBAmount = gbAmount;
        }
        public override string ToString()
        {
            return $"Відеокарта: {Name} - {Price} грн, {GBAmount} ГБ";
        }
    }
}
