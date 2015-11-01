using System;
using static System.Math;

namespace IAPWSL
{
    internal static class BoundaryRegion2Region3
    {
        internal static double CalculateBoundaryPressure(double temperature)
        {
            return (0.34805185628969 * Pow(10, 3) + (-0.11671859879975 * 10) * temperature + 0.10192970039326 * Pow(10, -2) * Pow(temperature, 2));
        }
        internal static double CalculateBoundaryTemperature(double pressure)
        {
            return (0.57254459862746 * Pow(10, 3)
                        + Math.Sqrt(
                                        (pressure - 0.13918839778870 * Pow(10, 2)) / (0.10192970039326 * Pow(10, -2))
                                  )
                   );
        }
    }
}
