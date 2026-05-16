using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Passenger
    {


        public int PassengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email == null)
                return FirstName == firstName && LastName == lastName;
                
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
