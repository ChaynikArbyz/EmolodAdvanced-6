using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class SSD : ComputerComponent
    {
private int _GBcapacity;
        public int GBcapacity
        {
            get { return _GBcapacity; }
            set 
            { 
                if (value < 1)
                { throw new Exception("ємність не може бути від'ємною"); }
                _GBcapacity = value; 
            }
        }
        public SSD(string name, int price, int GBcapacity) : base(name, price)
        {
            this.GBcapacity = GBcapacity;
        }
        public override string ToString()
        {
            return $"ССД: {Name} - {GBcapacity}GB - {Price} грн";
        }
    }
}
