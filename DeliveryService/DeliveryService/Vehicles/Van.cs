using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace DeliveryService.Vehicles
{
    internal class Van : Vehicle
    {
        public Van(string brand, string model, int maxCapacity) : base(brand, model, maxCapacity) { }
        public override float calculateDeliveryCost(float distance, float cargoWeight)
        {
            if (loadCargo(cargoWeight))
            {
                return (distance * 3) + (cargoWeight * 0.2f);
            }
            else
            {
                ColorText.WriteColorLine("Вага товару перевищую максимальну вагу фургону!", ConsoleColor.Red);
                return -1;
            }
        }
        public override float calculateFuelConsumption(float distance)
        {
            return distance * 0.07f;
        }
    }
}
