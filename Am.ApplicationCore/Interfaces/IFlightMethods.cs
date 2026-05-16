using Am.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Am.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        IList<DateTime> GetFlightDates(string destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IList<Flight> OrderedDurationFlights();
        IList<Passenger> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string?, Flight>> DestinationGroupedFlights();
        
        // Added from specifications
        IList<Flight> GetFlights(string filterType, string filterValue);
    }
}
