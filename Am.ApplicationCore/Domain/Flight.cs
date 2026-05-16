using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Am.ApplicationCore.Domain
{
    public class Flight
    {
        public Flight()
        {
            Passengers = new List<Passenger>();
        }

        public int FlightId { get; set; }

        public string? Airline { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public Plane? Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

        [ForeignKey("Plane")]
        public int PlaneFK { get; set; }

        public override string ToString()
        {
            return $"Departure: {Departure}, Destination: {Destination}, EffectiveArrival: {EffectiveArrival}, EstimatedDuration: {EstimatedDuration}, FlightDate: {FlightDate}";
        }
    }
}
