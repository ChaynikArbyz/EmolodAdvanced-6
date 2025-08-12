using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Vehicles;
using NotesAndPasswordGenerator;

namespace DeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            List<Vehicles.Vehicle> vehicles = new List<Vehicles.Vehicle>();
            vehicles.Add(new Vehicles.Truck("Mercedes", "Actros", 10000));
            vehicles.Add(new Vehicles.Van("Ford", "Transit", 3000));
            vehicles.Add(new Vehicles.Drone("DJI", "Phantom 4"));
            vehicles.Add(new Vehicles.Truck("Scania", "R 500", 12000));
            vehicles.Add(new Vehicles.Van("Mercedes", "Sprinter", 2500));
            vehicles.Add(new Vehicles.Drone("Parrot", "Anafi"));
            vehicles.Add(new Vehicles.Truck("Volvo", "FH16", 15000));
            vehicles.Add(new Vehicles.Van("Renault", "Master", 3000));
            vehicles.Add(new Vehicles.Drone("Yuneec", "Typhoon H"));
            //назви транспорту від АІ

            for (int i = 0; i <= 99; i++)
            { 
                ColorText.WriteColorLine($"Замовлення №{i + 1}", ConsoleColor.Green);
                int weight = rand.Next(1, 2000);
                int distance = rand.Next(1, 2000);
                Vehicle vehicle = vehicles[rand.Next(0, vehicles.Count)];
                float cost = vehicle.calculateDeliveryCost(distance, weight);
                if (cost != -1)
                {
                    if (vehicle is Truck)
                    {
                        ColorText.WriteColor("\nВантажівка: ", ConsoleColor.DarkYellow);
                        Console.WriteLine($"{vehicle.getBrand()} {vehicle.getModel()}\nВідстань: {distance} км\nВага: {weight} кг\nВартість доставки: {cost} грн\nВитрати дизельного пального: {vehicle.calculateFuelConsumption(distance)} л");
                    }
                    else if (vehicle is Van)
                    {
                        ColorText.WriteColor("\nФургон:", ConsoleColor.Red);
                        Console.WriteLine($"{vehicle.getBrand()} {vehicle.getModel()}\nВідстань: {distance} км\nВага: {weight} кг\nВартість доставки: {cost} грн\nВитрати бензину: {vehicle.calculateFuelConsumption(distance)} л");
                    }
                    else if (vehicle is Drone)
                    {
                        ColorText.WriteColor("\nДрон:", ConsoleColor.Cyan);
                        Console.WriteLine($"{vehicle.getBrand()} {vehicle.getModel()}\nВідстань: {distance} км\nВага: {weight} кг\nВартість доставки: {cost} грн\nВитрати бензину: {vehicle.calculateFuelConsumption(distance)} л");
                    }
                }

            }
        }
    }
}
