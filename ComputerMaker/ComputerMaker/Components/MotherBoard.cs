using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMaker.Components
{
    internal class MotherBoard : ComputerComponent
    {
       private CPU cpu;
       private GPU gpu;
       private RAM[] rams = new RAM[4];
       private SSD[] ssds = new SSD[2];

        public CPU GetCPU() => cpu;
        public GPU GetGPU() => gpu;
        public RAM[] GetRAMs() => rams;
        public SSD[] GetSSDs() => ssds;

        public MotherBoard(string name, int price) : base(name, price) { }
        public void AddCPU(CPU cpu)
        {
            if (this.cpu != null)
            {
                throw new Exception("Процесор вже встановлено");
            }
            this.cpu = cpu;
        }
        public void AddGPU(GPU gpu)
        {
            if (this.gpu != null)
            {
                throw new Exception("Відеокарта вже встановлена");
            }
            this.gpu = gpu;
        }
        public void AddRAM(RAM ram)
        {
            for (int i = 0; i < rams.Length; i++)
            {
                if (rams[i] == null)
                {
                    rams[i] = ram;
                    return;
                }
            }
            throw new Exception("Максимальна кількість оперативної пам'яті досягнута");
        }
        public void AddSSD(SSD ssd)
        {
            for (int i = 0; i < ssds.Length; i++)
            {
                if (ssds[i] == null)
                {
                    ssds[i] = ssd;
                    return;
                }
            }
            throw new Exception("Максимальна кількість SSD досягнута");
        }

        public override string ToString()
        {
            return $"Материнська плата: {Name}, Ціна: {Price}";
        }
    }
}
