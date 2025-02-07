using System;
using System.Collections.Generic;

namespace CustomerRelationshipManager.Model
{
class Customer
{
    public int CustomerId { get; }
    public string Forename { get; }
    public string Surname { get; }
    public DateTime DateOfBirth { get; }
    public List<Vehicle> Vehicles { get; }

    public Customer(int customerId, string forename, string surname, DateTime dateOfBirth)
    {
        CustomerId = customerId;
        Forename = forename;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Vehicles = new List<Vehicle>();
    }
}
}
