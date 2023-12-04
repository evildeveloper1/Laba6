using System;
using System.Collections.Generic;
abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }
    public abstract void Move();
}
class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving.");
    }
}
class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving.");
    }
}
class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving.");
    }
}
class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving.");
    }
}
class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}
class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public string CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        return $"Optimal route from {route.StartPoint} to {route.EndPoint} for {vehicle.GetType().Name}";
    }
    public void PassengerHandling(Vehicle vehicle)
    {
        Console.WriteLine($"Passengers are boarding and disembarking from {vehicle.GetType().Name}");
    }
}
class Program
{
    static void Main()
    {
        TransportNetwork transportNetwork = new TransportNetwork();

        Car car = new Car();
        Bus bus = new Bus();
        Train train = new Train();

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.MoveAllVehicles();

        Route route = new Route { StartPoint = "A", EndPoint = "B" };

        Console.WriteLine(transportNetwork.CalculateOptimalRoute(route, car));

        transportNetwork.PassengerHandling(bus);

        Console.WriteLine("Програма завершила роботу.");
    }
}
