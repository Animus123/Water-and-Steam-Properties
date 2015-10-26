using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL
{
    //This class used for both determination saturation temperature for given saturation pressure and vice versa
    internal static class Region4
    {
        #region Numerical values of the coefficients of the dimensionless saturation equations
        static double[] n0 =
                            {
                                //n1
                                //n2
                                //n3
                                //n4
                                //n5
                                //n6
                                //n7
                                //n8
                                //n9
                                //n10
                            };
        #endregion

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessPressure(double p)
        {
            return p / 1;	// 1 MPa
        }

        private static double CountDimensionlessTemperature(double t)
        {
            return t / 1;	// 1 K
        }

        #endregion

        internal static double CalculateSaturationPressure(double saturationTemperature)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSaturationTemperature(double saturationPressure)
        {
            throw new NotImplementedException();
        }
    }
}
