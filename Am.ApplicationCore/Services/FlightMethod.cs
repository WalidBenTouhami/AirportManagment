using System;
using System.Collections.Generic;
using System.Linq;
using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Interfaces;

namespace Am.ApplicationCore.Services
{
    public class FlightMethod : IFlightMethod
    {
        public List<Flight> flights = new List<Flight>();

        public IList<Flight> GetFlight(string destination)
        {
            return flights.Where(f => f.Destination == destination).ToList();
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            var query = from item in flights
                        where item.Destination == destination
                        select item.FlightDate;
            return query.ToList();
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from item in flights
                        where item.Plane == plane
                        select new { item.Destination, item.FlightDate };

            foreach (var item in query)
            {
                Console.WriteLine($"Destination: {item.Destination}, Flight Date: {item.FlightDate}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return flights.Count(item => item.FlightDate >= startDate && (item.FlightDate - startDate).TotalDays < 7);
        }

        public double DurationAverage(string destination)
        {
            return flights.Where(item => item.Destination == destination).Select(item => item.EstimatedDuration).Average();
        }

        public IList<Flight> OrderedDurationFlights()
        {
            return flights.OrderByDescending(item => item.EstimatedDuration).ToList();
        }

        public IList<Passenger> SeniorTravellers(Flight flight)
        {
            return flight.Passengers.Where(item => item is Traveller)
                .OrderBy(item => item.BirthDate)
                .Take(3)
                .ToList();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = flights.GroupBy(f => f.Destination);
            return query;
        }
    }
}
