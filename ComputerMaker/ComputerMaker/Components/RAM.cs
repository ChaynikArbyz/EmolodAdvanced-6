using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class RAM : ComputerComponent
    {
        private int _GBamount;
        private int _MHzspeed; 
        public int GBamount
        {
            get { return _GBamount; }
            set 
            { 
                if (value < 1)
                { throw new Exception("Об'єм пам'яті не може бути від'ємним"); }
                _GBamount = value; 
            }
        }
        public int MHzspeed
        {
            get { return _MHzspeed; }
            set 
            { 
                if (value < 1)
                { throw new Exception("Швидкість пам'яті не може бути від'ємною"); }
                _MHzspeed = value; 
            }
        }
        public RAM(string name, int price, int GBamount, int MHzspeed) : base(name, price)
        {
            this.GBamount = GBamount;
            this.MHzspeed = MHzspeed;
        }
        public override string ToString()
        {
            return $"Оперативна пам'ять: {Name} - {GBamount}GB - {MHzspeed}MHz - {Price} грн";
        }
    }
}
