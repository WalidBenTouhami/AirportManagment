using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Plane
    {
        /* TP Partie II.2 : Constructeur demandé
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }
        */

        // TP Partie II.3 : Supprimer le constructeur paramétré (commenté ci-dessus)
        // et utiliser les initialiseurs d'objets (voir Program.cs)

        public Plane()
        {
            // Initialisation de la collection pour éviter le warning CS8618
            Flights = new List<Flight>();
        }

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
