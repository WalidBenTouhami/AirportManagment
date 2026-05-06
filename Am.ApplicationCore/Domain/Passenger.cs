using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Passenger
    {


        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PassporttNumber { get; set; }
        public int TelNumber { get; set; }

        public ICollection<Flight> Flights { get; set; }


        public bool checkProfile1(string Nom, string Prenom)
        {
            return FirstName == Prenom && LastName == Nom;
        }

        public bool checkProfile1(string Nom, string Prenom, string Email)
        {
            return FirstName == Prenom && LastName == Nom && Email == EmailAddress;
        }

        public bool checkProfile2(string Nom, string Prenom, string Email = null)
        {
            if (Email==null)
            
                 return FirstName == Prenom && LastName == Nom;
               return checkProfile1( Nom, Prenom, Email);       
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
