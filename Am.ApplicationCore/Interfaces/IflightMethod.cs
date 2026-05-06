using System;
using System.Collections.Generic;
using System.Text;

namespace Am.ApplicationCore.Interfaces
{
    public interface IflightMethod
    {
        IList<DateTime> GetFlightDates(string destination);
    }
}
