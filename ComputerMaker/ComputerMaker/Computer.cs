using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerMaker.Components;

namespace ComputerMaker
{
    internal class Computer
    {
        MotherBoard motherBoard;
        PowerSupply powerSupply;
        private int totalPrice;

        public Computer(MotherBoard motherBoard, PowerSupply powerSupply)
        {
            this.motherBoard = motherBoard ?? throw new ArgumentNullException("Материнська плата не може бути null");
            if (motherBoard.GetCPU() == null)
            {
                throw new ArgumentException("Материнська плата повинна мати встановлений процесор");
            }
            if (motherBoard.GetGPU() == null)
            {
                throw new ArgumentException("Материнська плата повинна мати встановлену відеокарту");
            }
            if (motherBoard.GetRAMs().Count(r => r != null) < 2)
            {
                throw new ArgumentException("Материнська плата повинна мати встановлену як мінімум 2 оперативної пам'яті");
            }
            if (motherBoard.GetSSDs().All(r => r == null))
            {
                throw new ArgumentException("Материнська плата повинна мати встановлений SSD");
            }
            this.powerSupply = powerSupply ?? throw new ArgumentNullException("Блок живлення не може бути null");
            foreach (RAM component in motherBoard.GetRAMs())
            {
                if (component != null)
                {
                    totalPrice += component.Price;
                }
            }
            foreach (SSD component in motherBoard.GetSSDs())
            {
                if (component != null)
                {
                    totalPrice += component.Price;
                }
            }
            totalPrice += motherBoard.Price + powerSupply.Price + motherBoard.GetCPU().Price + motherBoard.GetGPU().Price;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Комп'ютер:\nЦіна: " + totalPrice);
            Console.WriteLine("\nКомпоненти:");
            Console.WriteLine(motherBoard.ToString());
            Console.WriteLine(motherBoard.GetCPU().ToString());
            Console.WriteLine(motherBoard.GetGPU().ToString());
            foreach (RAM ram in motherBoard.GetRAMs())
            {
                if (ram != null)
                {
                    Console.WriteLine(ram.ToString());
                }
            }
            foreach (SSD ssd in motherBoard.GetSSDs())
            {
                if (ssd != null)
                {
                    Console.WriteLine(ssd.ToString());
                }
            }

            Console.WriteLine(powerSupply.ToString());


        }

    }
}
