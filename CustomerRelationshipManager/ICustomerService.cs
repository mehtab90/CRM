using System;

namespace CustomerRelationshipManager
{
    public interface ICustomerService
    {
        void LoadData(string filePath);
        void PrintAllCustomersAndVehicles();
        void PrintCustomersBetweenAges(int minAge, int maxAge);
        void PrintVehiclesRegisteredBefore(DateTime date);
        void PrintVehiclesWithEngineSizeGreaterThan(int size);
    }
}
