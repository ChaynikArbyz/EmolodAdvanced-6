using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace DeliveryService.Vehicles
{
    internal class Drone : Vehicle
    {
        public Drone(string brand, string model) : base(brand, model, 5) { }
        public override float calculateDeliveryCost(float distance, float cargoWeight)
        {
            if (loadCargo(cargoWeight))
            {
                float cost = distance + (cargoWeight * 0.2f);
                if (distance > 50) { cost = cost * 2; }
                return cost;
            }
            else
            {
                ColorText.WriteColorLine("Вага товару перевищую максимальну вагу Дрону!", ConsoleColor.Red);
                return -1;
            }
        }
        public override float calculateFuelConsumption(float distance)
        {
            return distance * 0.07f;
        }
    }
}
