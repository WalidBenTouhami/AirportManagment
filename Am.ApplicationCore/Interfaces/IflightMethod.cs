using Am.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Am.ApplicationCore.Interfaces
{
    public interface IflightMethod
    {
        IList<DateTime> GetFlightDates(string destination);

        public IList<Flight> GetFlight(string destination);

        public void ShowFlightDetails(Plane plane);
        
           
    }
}
