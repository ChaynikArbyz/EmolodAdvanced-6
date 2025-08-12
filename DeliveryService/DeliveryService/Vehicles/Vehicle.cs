using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Vehicles
{
    internal abstract class Vehicle
    {
        protected string brand;
        protected string model;

       protected int maxCapacity;
      //protected int pricePerKm;
      //protected float pricePerKg;

      //protected float fuelPerKm;

        public Vehicle(string brand, string model, int maxCapacity)
        {
            this.brand = brand;
            this.model = model;
            this.maxCapacity = maxCapacity;
        }

        public abstract float calculateDeliveryCost(float distance, float cargoWeight);
        public abstract float calculateFuelConsumption(float distance);
        public string getBrand() => brand;
        public string getModel() => model;

        protected bool loadCargo(float cargoWeight)
        {
            if (cargoWeight <= maxCapacity)
            {
                return true;
            }
            else { return false; }
        }
    }
}
