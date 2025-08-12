using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class PowerSupply : ComputerComponent
    {
        private int _power;
        public int Power
        {
            get { return _power; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Потужність не може бути від'ємною");
                }
                _power = value;
            }
        }
        public PowerSupply(string name, int price, int power) : base(name, price)
        {
            Power = power;
        }
        public override string ToString()
        {
            return $"Блок живлення: {Name} - {Price} грн, Потужність: {Power} Вт";
        }
    }
}
