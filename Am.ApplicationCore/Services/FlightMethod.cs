using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Services
{
    public class FlightMethod: IflightMethod
    {
        public List<Flight> Flights = new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        { List<DateTime> L1 = new List<DateTime>();
            foreach (var f in Flights)
            {
                if (destination == f.Destination)
                {
                    L1.Add(f.FlightDate);
                }
            }
            return L1;

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
    }
}
