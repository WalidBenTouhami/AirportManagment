using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Am.ApplicationCore.Domain
{
    public class Flight
    {
        public Flight()
        {
            Tickets = new List<Ticket>();
        }

        public int FlightId { get; set; }

        public string? Airline { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public virtual Plane? Plane { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        [ForeignKey("Plane")]
        public int PlaneFK { get; set; }

        public override string ToString()
        {
            return $"Departure: {Departure}, Destination: {Destination}, EffectiveArrival: {EffectiveArrival}, EstimatedDuration: {EstimatedDuration}, FlightDate: {FlightDate}";
        }
    }
}
