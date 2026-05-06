using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Flight
    {
        public object Flights;

        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatiDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int Flightid { get; set; }
        public  ICollection<Passenger>  Passengers  { get; set; }


        public override string ToString()
        {
            return "Departure" + Departure+ "Destination" + Destination + "EffectiveArrival" + EffectiveArrival + "EstimatiDuration" + EstimatiDuration + "FightDate" + FightDate;
        }
    }
}
