using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class CPU : ComputerComponent
    {
        private double _frequency;
        public double Frequency
        {
            get { return _frequency; }
            set 
            { 
                if (value <= 0)
                { throw new Exception("частота не може бути від'ємною"); }
                _frequency = value; 
            }
        }
        public CPU(string name, int price, double frequency) : base(name, price)
        {
            Frequency = frequency;
        }
        public override string ToString()
        {
            return $"Процессор: {Name} - {Price} грн, частота: {Frequency} МГц";
        }
    }
}
