using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace DeliveryService.Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck(string brand, string model, int maxCapacity) : base(brand, model, maxCapacity)
        {
            //this.pricePerKm = 5;
            //this.pricePerKg = 0.1f;
            //this.fuelPerKm = 0.1f;
        } //можна зробити конструктор з параметрами та написати ці 2 функції в абстктному классі, але це в завданні треба робити через абстракцію

        public override float calculateDeliveryCost(float distance, float cargoWeight)
        {
            if (loadCargo(cargoWeight))
            {
                return (distance * 5) + (cargoWeight * 0.1f);
            }
            else
            {
                ColorText.WriteColorLine("Вага товару перевищую максимальну вагу вантажівки!", ConsoleColor.Red);
                return -1;
            }
        }
        public override float calculateFuelConsumption(float distance)
        {
            return distance * 0.1f;
        }
    }
}
