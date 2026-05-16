using System;
using Am.ApplicationCore.Domain;

namespace Am.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger passenger)
        {
            if (!string.IsNullOrEmpty(passenger.FirstName))
            {
                passenger.FirstName = char.ToUpper(passenger.FirstName[0]) + passenger.FirstName.Substring(1);
            }

            if (!string.IsNullOrEmpty(passenger.LastName))
            {
                passenger.LastName = char.ToUpper(passenger.LastName[0]) + passenger.LastName.Substring(1);
            }
        }
    }
}
