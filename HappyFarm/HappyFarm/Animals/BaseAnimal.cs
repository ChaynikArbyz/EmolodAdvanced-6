using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace HappyFarm.Animals
{
    internal abstract class BaseAnimal
    {
        protected int id;
        public static int nextId = 1;
        protected string name; //ім'я для тварин?
        protected bool isHungry = true;
        protected bool isProducted = false;
        protected int DailyFoodConsumption = 2;
        protected int ProductPerDay;
        protected string productType;

        public BaseAnimal()
        {
            id = nextId++;
        }
        public void Feed(int kgOfFood)
        {
            if (kgOfFood <= 0)
            {
                ColorText.WriteColorLine("Кількість їжі не може бути від'ємною", ConsoleColor.Red);
                return;
            }
            if (isHungry)
            {
                if (kgOfFood >= DailyFoodConsumption)
                {
                    ColorText.WriteColorLine($"{name} нагодовано {kgOfFood} кг їжі", ConsoleColor.Green);
                    isHungry = false;
                }
                else
                {
                    ColorText.WriteColorLine($"{name} треба більше їжі, ніж {kgOfFood} кг", ConsoleColor.Red);
                }
            }
            else
            {
                ColorText.WriteColorLine($"{name} не голодна", ConsoleColor.Yellow);
            }
        }


        public abstract int ProduceGoods();

        public string GetName()
        {
            return name;
        }
        public string GetProductType()
        {
            return productType;
        }
        public bool GetIsHungry()
        {
            return isHungry;
        }
        public void MakeHungry() { isHungry = true; }
        public void ResetIsProducted() { isProducted = false; }
        public int GetDailyFoodConsumption()
        {
            return DailyFoodConsumption;
        }
        public int GetId()
        {
            return id;
        }
    }
}
