using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace HappyFarm.Animals
{
    internal class Chicken : BaseAnimal
    {
        public Chicken() : base()
        {
            name = "Курка";
            productType = "яйця";
            ProductPerDay = 2;
            DailyFoodConsumption = 1;
        }
        public override int ProduceGoods()
        {
            if (!isHungry)
            {
                if (isProducted)
                {
                    ColorText.WriteColorLine($"{name} не може виробляти {productType}, бо сьогодні вже виробила", ConsoleColor.Yellow);
                    return 0;
                }
                else
                {
                    isProducted = true;
                    return ProductPerDay + RANDOM.Random.Next(-1, 2);
                }
            }
            else
            {
                ColorText.WriteColorLine($"{name} не може виробляти {productType}, бо голодна", ConsoleColor.Red);
                return 0;
            }
        }
    }
}
