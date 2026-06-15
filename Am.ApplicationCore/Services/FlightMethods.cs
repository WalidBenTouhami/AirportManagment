using System;
using System.Collections.Generic;
using System.Linq;
using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Interfaces;

namespace Am.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        // Delegates
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public FlightMethods()
        {
            // Initializing delegates with method groups (as requested in TP II.2/3.10)
            // DurationAverageDel = DurationAverage;
            // FlightDetailsDel = ShowFlightDetails;

            // Initializing delegates with Lambda Expressions (TP II.2/3.10)
            FlightDetailsDel = plane =>
            {
                var query = from item in Flights
                            where item.Plane == plane
                            select new { item.Destination, item.FlightDate };

                foreach (var item in query)
                {
                    Console.WriteLine($"Destination: {item.Destination}, Flight Date: {item.FlightDate}");
                }
            };

            DurationAverageDel = destination =>
            {
                return Flights.Where(item => item.Destination == destination).Select(item => item.EstimatedDuration).Average();
            };
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            /* TP III.1: En utilisant la boucle For
            List<DateTime> result = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    result.Add(Flights[i].FlightDate);
                }
            }
            return result;
            */

            /* TP III.2: Reformuler la requête avec foreach
            List<DateTime> result = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    result.Add(flight.FlightDate);
                }
            }
            return result;
            */

            // TP I.1 (LINQ): Reformuler la méthode GetFlightDates en utilisant une requête LINQ
            var query = from item in Flights
                        where item.Destination == destination
                        select item.FlightDate;
            return query.ToList();
        }

        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();
            foreach (var flight in Flights)
            {
                switch (filterType.ToLower())
                {
                    case "destination":
                        if (flight.Destination == filterValue) result.Add(flight);
                        break;
                    case "departure":
                        if (flight.Departure == filterValue) result.Add(flight);
                        break;
                    // d'autres attributs pourraient être ajoutés
                }
            }
            return result;
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from item in Flights
                        where item.Plane == plane
                        select new { item.Destination, item.FlightDate };

            foreach (var item in query)
            {
                Console.WriteLine($"Destination: {item.Destination}, Flight Date: {item.FlightDate}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return Flights.Count(item => item.FlightDate >= startDate && (item.FlightDate - startDate).TotalDays < 7);
        }

        public double DurationAverage(string destination)
        {
            return Flights.Where(item => item.Destination == destination).Select(item => item.EstimatedDuration).Average();
        }

        public IList<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(item => item.EstimatedDuration).ToList();
        }

        public IList<Passenger> SeniorTravellers(Flight flight)
        {
            return flight.Tickets.Select(t => t.Passenger).OfType<Traveller>()
                .OrderBy(item => item.BirthDate)
                .Take(3)
                .Cast<Passenger>()
                .ToList();
        }

        public IEnumerable<IGrouping<string?, Flight>> DestinationGroupedFlights()
        {
            var query = Flights.GroupBy(f => f.Destination);
            return query;
        }
    }
}
