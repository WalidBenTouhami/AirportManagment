using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Plane
    {


        // nous avons 2 constructeurs : un constructeur paramétré et un constructeur par défaut
        // constructeur paramétré : il prend des paramètres pour initialiser les propriétés de la classe
        // constructeur par défaut : il ne prend pas de paramètres et initialise les propriétés de la classe avec des valeurs par défaut 
        // LE PARDEFAUT AJOUTER POUR RESOUDRE LE PROBLEME DE SERIALIZATION DANS PROGRAMMS.CS 
        public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneId = planeId;
            PlaneType = planeType;
        }



        public Plane()
        {

        }


        // version C# light : prop +tab 
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int PlaneId { get; set; }

        public PlaneType PlaneType  { get; set; }

        public ICollection <Flight> Flights { get; set; }


        public override string ToString()
        {
            return $"Capacity: {Capacity}, ManufactureDate: {ManufactureDate}, PlaneType: {PlaneType}";
        }








    }
}
