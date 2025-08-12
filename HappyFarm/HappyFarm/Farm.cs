using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace HappyFarm.Animals
{
    internal class Farm
    {
        private List<Dictionary<string, int>> productList = new List<Dictionary<string, int>>();
        private Dictionary<string, int> defList = new Dictionary<string, int> { };


        private static List<BaseAnimal> animalTypes = new List<BaseAnimal>
        {
            new Sheep(),
            new Cow(),
            new Chicken()
        };
        private List<BaseAnimal> animals = new List<BaseAnimal>();
        
        public Farm() 
        {
            BaseAnimal.nextId = 1;
            for (int i = 0; i <= RANDOM.Random.Next(1, 77); i++)
            {
                int index = RANDOM.Random.Next(animalTypes.Count);
                BaseAnimal newAnimal;
                if (animalTypes[index] is Cow)
                    newAnimal = new Cow();
                else if (animalTypes[index] is Sheep)
                    newAnimal = new Sheep();
                else if (animalTypes[index] is Chicken)
                    newAnimal = new Chicken();
                else
                    continue;
                animals.Add(newAnimal);
            }
            for (int i = 0; i < animalTypes.Count; i++)
            {
                defList.Add(animalTypes[i].GetProductType(), 0);
            }
        }
        public void FeedAnimal(int animalId, int kgOfFood)
        {
            if (animalId >= 0 && animalId < animals.Count())
            {
            animals[animalId].Feed(kgOfFood);
            }
            else
            {
                ColorText.WriteColorLine("Невірний ID тварини", ConsoleColor.Red);
            }
        }
        public void FeedAllAnimals(int kgOfFood)
        {

            foreach (BaseAnimal animal in animals)
            {
                animal.Feed(animal.GetDailyFoodConsumption());
                kgOfFood = kgOfFood - animal.GetDailyFoodConsumption();
                if (kgOfFood <= 0)
                {
                    Console.WriteLine("Їжа закінчилась");
                    break;
                }
            }
        }
        public void ShowAnimals()
        {
            if (animals.Count == 0)
            {
                ColorText.WriteColorLine("На фермі немає тварин", ConsoleColor.DarkGray);
                return;
            }
            ColorText.WriteColorLine("Зелений - не голодна", ConsoleColor.Green);
            ColorText.WriteColorLine("Червоний - голодна\n", ConsoleColor.Red);
            foreach (BaseAnimal animal in animals)
            {
                if (animal.GetIsHungry())
                { ColorText.WriteColorLine($"{animal.GetId()}. {animal.GetName()}", ConsoleColor.Red); }
                else
                { ColorText.WriteColorLine($"{animal.GetId()}. {animal.GetName()}", ConsoleColor.Green); }
            }
        }
        public void CollectProduct(int animalId)
        {
            if (animalId >= 0 && animalId < animals.Count())
            {
                BaseAnimal animal = animals[animalId];
                int products = animal.ProduceGoods();
                if (products > 0)
                {
                    defList[animal.GetProductType()] += products;
                    ColorText.WriteColorLine($"{animal.GetName()} виробила {products} одиниць {animal.GetProductType()}", ConsoleColor.Green);
                }
            }
            else
            {
                ColorText.WriteColorLine("Невірний ID тварини", ConsoleColor.Red);
            }
        }
        public void CollectAllProduct()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                CollectProduct(i);
            }
        }

        public void StartNextDay()
        {
            foreach (BaseAnimal animal in animals)
            {
                animal.ResetIsProducted();
                animal.MakeHungry();
            }
            productList.Add(new Dictionary<string, int>(defList));
            foreach (var key in defList.Keys.ToList())
            {
                defList[key] = 0;
            }
        }

        public void ShowProductResults() 
        {
            if (productList.Count() > 0)
            {
                ColorText.WriteColorLine("--------------------", ConsoleColor.Cyan);
                for (int i = 0; i < productList.Count; i++)
                {
                    foreach (var kvp in productList[i])
                    {
                    Console.WriteLine(kvp.Key + " - " + kvp.Value);
                    }
                    ColorText.WriteColorLine("--------------------", ConsoleColor.Cyan);
                }
            }
            else { ColorText.WriteColorLine("Список пустий", ConsoleColor.DarkGray); }
        }

    }
}
