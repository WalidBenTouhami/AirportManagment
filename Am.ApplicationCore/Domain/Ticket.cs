using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Am.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }

        public virtual Flight? Flight { get; set; }
        public virtual Passenger? Passenger { get; set; }

        [ForeignKey("Flight")]
        public int FlightFK { get; set; }

        [ForeignKey("Passenger")]
        public string PassengerFK { get; set; } = null!;
    }
}
