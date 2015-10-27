using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL.SubstanceProperties
{
    /// <summary>
    /// Temperature (can be in K, Celsius, F, R). Default measure and output is always in Kalvin.
    /// </summary>
    public class Temperature : AbstractProperty
    {
        /// <summary>
        /// Constructor always set temperature in Kalvin.
        /// </summary>
        /// <param name="temerature">temperature</param>
        /// <param name="measure">measure in K, C, F or R</param>
        internal Temperature(double temerature, Measure measure = Measure.K)
        {
            switch (measure)
            {
                case Measure.K:
                    base.Value = temerature;
                    break;
                case Measure.Celsius:
                    base.Value = temerature + 273.15;
                    break;
                case Measure.F:
                    base.Value = ((5 / 9) * (temerature - 32) + 273.15);
                    break;
                case Measure.R:
                    base.Value = ((5 / 4) * temerature + 273.15);
                    break;
                default:
                    base.Value = temerature;
                    break;
            }
        }

        internal enum Measure
        {
            K,
            Celsius,
            F,
            R
        }
    }
}
