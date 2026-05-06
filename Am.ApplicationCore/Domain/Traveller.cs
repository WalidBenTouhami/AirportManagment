using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Traveller: Passenger
    {

        public string Healthinformation { get; set; }
        public string Nationality { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a traveller");
        }
    }
}
