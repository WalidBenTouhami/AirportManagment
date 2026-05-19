using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Plane
    {
        // TP Partie II.3 : Supprimer le constructeur paramétré (commenté)
        // et utiliser les initialiseurs d'objets (voir Program.cs)

        public Plane()
        {
            Flights = new List<Flight>();
        }

        [Range(1, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"Capacity: {Capacity}, ManufactureDate: {ManufactureDate}, PlaneType: {PlaneType}";
        }
    }
}
