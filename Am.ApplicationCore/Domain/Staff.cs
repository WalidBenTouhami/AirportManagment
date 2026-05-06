using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Staff: Passenger
    {

        public  DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        public  double Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff member");
        }
    }
}
