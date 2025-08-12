using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace HappyFarm.Animals
{
    internal class Sheep : BaseAnimal
    {
        private int daysToCollect = 0;
        private int daysNotHungry = 0;
        public Sheep() : base()
        {
            name = "Вівця";
            productType = "хутро";
            ProductPerDay = 0;
            DailyFoodConsumption = 1;
        }
        public override int ProduceGoods()
        {
            if (!isHungry)
            {
                if (daysToCollect == 0)
                {
                daysToCollect = RANDOM.Random.Next(7, 14);
                }
                daysNotHungry++;
                if (daysNotHungry >= daysToCollect)
                {
                    if (isProducted)
                    {
                        ColorText.WriteColorLine($"{name} не може виробляти {productType}, бо сьогодні вже виробила", ConsoleColor.Yellow);
                        return 0;
                    }
                    else
                    {
                        isProducted = true;
                        daysNotHungry = 0;
                        daysToCollect = 0;
                        return 10;
                    }
                }
                    ColorText.WriteColorLine($"{name} не виробляє {productType}, бо ще не готова", ConsoleColor.Yellow);
                    return 0;
            }
            else
            {
                ColorText.WriteColorLine($"{name} не може виробляти {productType}, бо голодна", ConsoleColor.Red);
                return 0;
            }
        }
    }
}
