using System;
using System.Linq;
using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

// Constructeur par défaut
Plane p1 = new Plane();
p1.Capacity = 10;
p1.ManufactureDate = new DateTime(2020, 07, 07);
p1.PlaneType = PlaneType.Boeing;

// Constructeur paramétré
Plane p2 = new Plane(300, new DateTime(2000, 07, 07), 222, PlaneType.Airbus);

Console.WriteLine(p2.ToString());
Console.WriteLine(p1.ToString());

// Initialiseur d'objet sans ordre de propriété 
Plane p3 = new Plane()
{
    Capacity = 200,
    PlaneId = 1,
    ManufactureDate = new DateTime(2010, 07, 07),
    PlaneType = PlaneType.Boeing
};

Console.WriteLine(p3.ToString());

Passenger ps1 = new Passenger
{
    FirstName = "walid",
    LastName = "walid",
};

Console.WriteLine(ps1.CheckProfile("walid", "walid"));

Passenger ps2 = new Passenger
{
    FirstName = "walid",
    LastName = "walid",
    EmailAddress = "walid@gmail.com",
};

Console.WriteLine(ps2.CheckProfile("walid", "walid", "walid@gmail.com"));
Console.WriteLine("***********test Passenger************");
ps2.PassengerType();

Console.WriteLine("***********test Traveller************");
Traveller T = new Traveller();
T.PassengerType();

Console.WriteLine("***********test Staff************");
Staff S = new Staff();
S.PassengerType();

// Instancier la classe & alimenter l'objet flights de testData
FlightMethod fm = new FlightMethod();

fm.flights = testData.listFlights;

foreach (var item in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}

fm.ShowFlightDetails(testData.BoeingPlane);

Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));

Console.WriteLine(fm.DurationAverage("Madrid"));

Console.WriteLine(
    string.Join(
        "\n",
        fm.OrderedDurationFlights()
          .Select(f => f.Destination + " - " + f.EstimatedDuration)
    )
);

Console.WriteLine(
    string.Join(
        Environment.NewLine,
        fm.SeniorTravellers(testData.listFlights[0])
          .Select(t => $"{t.FirstName} {t.LastName}")
    )
);

var groups = fm.DestinationGroupedFlights();

foreach (var group in groups)
{
    Console.WriteLine($"Destination {group.Key}");

    foreach (var flight in group.OrderBy(f => f.FlightDate))
    {
        Console.WriteLine(
            $"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}"
        );
    }
}