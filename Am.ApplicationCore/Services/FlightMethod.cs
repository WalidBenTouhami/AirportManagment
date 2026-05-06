using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Services
{
    public class FlightMethod: IflightMethod
    {
        public List<Flight> flights = new List<Flight>();

        public IList<Flight> GetFlight(string destination)
        {
            throw new NotImplementedException();
        }

        public IList<DateTime> GetFlightDates(string destination)
        { List<DateTime> L1 = new List<DateTime>();
            var query = from item in flights
                        where item.Destination == destination
                        select item.FlightDate;
            return query.ToList();


            /*
            foreach (var f in Flights)
            {
                if (destination == f.Destination)
                {
                    L1.Add(f.FlightDate);
                }
            }
            return L1;
            */

            /*
             for(int i = 0; i < Flights.Count; i++)
            {
                if (destination == Flights[i].Destination) 
                {
                    L1.Add(Flights[i].FlightDate);
                }
            }
            return L1;
            */

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
    }
    }

