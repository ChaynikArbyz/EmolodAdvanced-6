using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyFarm.Animals;
using NotesAndPasswordGenerator;

namespace HappyFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Farm farm = new Farm();

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            for (int i = 0; i < 50; i++)//цикл на 50 днів
            {
                farm.FeedAllAnimals(999);
                farm.CollectAllProduct();
                farm.StartNextDay();
            }

            bool Running = true;
            bool invalidInput = false;

            while (Running)
            {
                Console.Clear();
                if (invalidInput)
                {
                    ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
                    invalidInput = false;
                }
                ColorText.WriteColorLine("-< Весела Ферма >-\n", ConsoleColor.Yellow);
                Console.WriteLine("Виберіть дію:");

                Console.WriteLine("1: Погодувати тварину");
                Console.WriteLine("2: Погодувати всіх тварин");
                Console.WriteLine("3: Зібрати продукт тварини");
                Console.WriteLine("4: Зібрати продукти всіх тварин");
                Console.WriteLine("5: Показати всіх тварин");
                Console.WriteLine("6: Розпочати наступний день");
                Console.WriteLine("7: Подивитись всі результати збору продуктів");
                Console.WriteLine("esc: Вийти");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear(); 
                        farm.ShowAnimals();
                        ColorText.WriteColorLine("\nВведіть id тварини: ", ConsoleColor.Yellow);
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            id--;
                            Console.Clear();
                            ColorText.WriteColorLine("Введіть кількість їжі в кг: ", ConsoleColor.DarkYellow);
                            if (int.TryParse(Console.ReadLine(), out int kg))
                            {
                                farm.FeedAnimal(id,kg);
                            }
                            else
                            {
                                ColorText.WriteColorLine("Невірний ввід!", ConsoleColor.Red);
                            }
                        }
                        else 
                        {
                            ColorText.WriteColorLine("Невірний ввід!", ConsoleColor.Red);
                        }
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        ColorText.WriteColorLine("Введіть кількість їжі в кг для всих тварин: ", ConsoleColor.DarkYellow);
                        if (int.TryParse(Console.ReadLine(), out int kg2))
                        {
                            farm.FeedAllAnimals(kg2);
                        }
                        else
                        {
                            ColorText.WriteColorLine("Невірний ввід!", ConsoleColor.Red);
                        }
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        farm.ShowAnimals();
                        ColorText.WriteColorLine("\nВведіть id тварини: ", ConsoleColor.Yellow);
                        if (int.TryParse(Console.ReadLine(), out int id2))
                        {
                            id2--;
                            Console.Clear();
                            farm.CollectProduct(id2);
                        }
                        else
                        {
                            ColorText.WriteColorLine("Невірний ввід!", ConsoleColor.Red);
                        }
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        farm.CollectAllProduct();
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        farm.ShowAnimals();
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        farm.StartNextDay();
                        ColorText.WriteColorLine("Новий день розпочато!", ConsoleColor.Yellow);
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        farm.ShowProductResults();
                        ColorText.WriteColorLine("\nНатіснуть будь-яку клавішу для повернення в меню", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        Running = false;
                        break;
                    default:
                        invalidInput = true;
                        break;
                }
            }
        }
    }
}
