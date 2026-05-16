using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Am.ApplicationCore.Domain
{
    public class Staff: Passenger
    {

        public DateTime EmployementDate { get; set; }
        public string? Function { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff member");
        }

        public override string ToString()
        {
            return base.ToString() + $", Function: {Function}, Salary: {Salary}, EmployementDate: {EmployementDate}";
        }
    }
}
