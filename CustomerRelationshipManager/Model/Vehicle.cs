using System;

namespace CustomerRelationshipManager.Model
{
    class Vehicle
    {
        public int VehicleId { get; }
        public string RegistrationNumber { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public int EngineSize { get; }
        public DateTime RegistrationDate { get; }
        public string InteriorColour { get; }

        public Vehicle(int vehicleId, string regNumber, string manufacturer, string model, int engineSize, DateTime regDate, string interiorColour)
        {
            VehicleId = vehicleId;
            RegistrationNumber = regNumber;
            Manufacturer = manufacturer;
            Model = model;
            EngineSize = engineSize;
            RegistrationDate = regDate;
            InteriorColour = interiorColour;
        }
    }
}
