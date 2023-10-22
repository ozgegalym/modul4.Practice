using System;
using System.Collections.Generic;

class Vehicle
{
    public string Brand { get; set; }
    public string NumberPlate { get; set; }
    public bool RequiresMaintenance { get; set; }

    public Vehicle(string brand, string numberPlate)
    {
        Brand = brand;
        NumberPlate = numberPlate;
        RequiresMaintenance = false;
    }
}

class Trip
{
    public string DestinationCity { get; set; }
    public bool IsTripCompleted { get; set; }

    public Trip(string destinationCity)
    {
        DestinationCity = destinationCity;
        IsTripCompleted = false;
    }
}

class Driver
{
    public string FullName { get; set; }
    public Vehicle AssignedVehicle { get; set; }
    public List<Trip> TripsCompleted { get; set; }

    public Driver(string fullName)
    {
        FullName = fullName;
        TripsCompleted = new List<Trip>();
    }

    public void RequestForMaintenance()
    {
        if (AssignedVehicle != null)
        {
            AssignedVehicle.RequiresMaintenance = true;
        }
    }

    public void FinishTrip(Trip trip)
    {
        if (trip != null)
        {
            trip.IsTripCompleted = true;
        }
    }
}

class Dispatcher
{
    public void AssignVehicleToDriver(Driver driver, Vehicle vehicle)
    {
        driver.AssignedVehicle = vehicle;
    }

    public void RemoveDriverFromDuty(Driver driver)
    {
        driver.AssignedVehicle = null;
    }

    public void InitiateTrip(Driver driver, string destinationCity)
    {
        Trip trip = new Trip(destinationCity);
        driver.TripsCompleted.Add(trip);
    }
}

class Program
{
    static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();

        Vehicle vehicle1 = new Vehicle("NissanGTR", "DEF456");
        Vehicle vehicle2 = new Vehicle("Suprra", "GHI789");

        Driver driver1 = new Driver("Баука");
        Driver driver2 = new Driver("Сека");

        dispatcher.AssignVehicleToDriver(driver1, vehicle1);
        dispatcher.AssignVehicleToDriver(driver2, vehicle2);

        dispatcher.InitiateTrip(driver1, "Chicago");
        dispatcher.InitiateTrip(driver2, "Miami");

        driver1.RequestForMaintenance();

        foreach (var trip in driver1.TripsCompleted)
        {
            Console.WriteLine($"Крутой водила {driver1.FullName} едет на  {trip.DestinationCity}. Trip completed: {trip.IsTripCompleted}");
        }

        Console.WriteLine($"Крутая машина {vehicle1.Brand} требует ремонта: {vehicle1.RequiresMaintenance}");

        Console.ReadLine();
    }
}
