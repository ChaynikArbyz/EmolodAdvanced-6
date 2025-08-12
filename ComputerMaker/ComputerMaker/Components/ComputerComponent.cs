using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker
{
    internal abstract class ComputerComponent
    {
        protected string _name;
        protected int _price;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Price
        {
            get { return _price; }
            set 
            { 
                if (value < 1)
                { throw new Exception("ціна не може бути від'ємною"); }
                _price = value;
            }
        }

        public ComputerComponent(string name, int price)
        {
            Name = name;
            Price = price;
        }

    }
}
