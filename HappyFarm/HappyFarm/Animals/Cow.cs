using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace HappyFarm.Animals
{
    internal class Cow : BaseAnimal
    {
        public Cow() : base()
        {
            name = "Корова";
            productType = "молоко";
            ProductPerDay = 5;
            DailyFoodConsumption = 5;
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
                    return ProductPerDay + RANDOM.Random.Next(-2, 3);
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
