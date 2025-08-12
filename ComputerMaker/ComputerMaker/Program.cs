using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerMaker.Components;

namespace ComputerMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            try 
            {
            CPU cpu = new CPU("Ryzen 5 5600G",5500, 3900);
            GPU gpu = new GPU("NVIDIA RTX 4060", 15000, 12);
            RAM ram1 = new RAM("Kingston DDR4", 1100, 8, 3600);
            RAM ram2 = new RAM("Kingston DDR4", 1100, 8, 3600);
            SSD ssd = new SSD("noNameSSD", 1500, 512);
            MotherBoard motherBoard = new MotherBoard("AORUS ELITE B550M", 5000);
                motherBoard.AddCPU(cpu);
                motherBoard.AddGPU(gpu);
                motherBoard.AddRAM(ram1);
                motherBoard.AddRAM(ram2);
                motherBoard.AddSSD(ssd);
            PowerSupply powerSupply = new PowerSupply("DEEPCOOL PF700", 2200, 700);
            Computer computer = new Computer(motherBoard, powerSupply);
            computer.ShowInfo();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
