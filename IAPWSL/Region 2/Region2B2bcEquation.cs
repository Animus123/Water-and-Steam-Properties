using static System.Math;

namespace IAPWSL
{
    internal static class Region2B2bcEquation
    {
        internal static bool is2cSubregion(double pressure, double enthalpy)
        {
            return Round((0.90584278514723 * Pow(10, 3) + (-0.67955786399241) * enthalpy + 0.12809002730136 * Pow(10, -3) * Pow(enthalpy, 2)), 6)
                    < (Round(pressure, 6));
        }
    }
}
