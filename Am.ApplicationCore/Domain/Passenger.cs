using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Passenger
    {
        public Passenger()
        {
            Flights = new List<Flight>();
        }

        public int PassengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNumber { get; set; }
        public string? TelNumber { get; set; }

        public ICollection<Flight> Flights { get; set; }

        /* TP Partie I.1 Polymorphisme par signature : 
           1. Une méthode pour vérifier le profile (nom, prénom)
        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

           2. Une méthode pour vérifier le profile (nom, prénom, email)
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }
        */

        // 3. Une méthode pour remplacer à la fois les deux méthodes précédentes
        public bool CheckProfile(string firstName, string lastName, string? email = null)
        {
            if (email == null)
                return FirstName == firstName && LastName == lastName;
                
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}, Email: {EmailAddress}, Phone: {TelNumber}";
        }
    }
}
