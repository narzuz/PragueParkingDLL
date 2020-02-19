using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly1
{
    public enum Type { Mc = 2, Car = 4 };
    public interface IVehicle
    {
        Type Type { get; }
        DateTime Arrival { get; }
        string RegNum { get; }
        decimal Getcost { get; }

        string ToString();
    }
}
