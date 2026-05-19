using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Passenger
    {
        public Passenger()
        {
            Flights = new List<Flight>();
        }

        [Key]
        [StringLength(7, ErrorMessage = "Le numéro de passeport ne doit pas dépasser 7 caractères")]
        public string PassportNumber { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
        public string? EmailAddress { get; set; }

        [MinLength(3, ErrorMessage = "La longueur minimale est de 3 caractères")]
        [MaxLength(25, ErrorMessage = "La longueur maximale est de 25 caractères")]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Le numéro de téléphone doit contenir 8 chiffres")]
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
