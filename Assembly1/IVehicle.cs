using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly1
{
    internal enum Type { Mc = 2, Car = 4 };
    public interface IVehicle
    {
        Type type { get; }
        DateTime Arrival { get; }
        string RegNum { get; }
        decimal Getcost { get; }

        string ToString();
    }
}
