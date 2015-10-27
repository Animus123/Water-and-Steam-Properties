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
        static double[] n =
                            {
                                0.11670521452767 * Math.Pow(10, 4),//n1
                                -0.72421316703206 * Math.Pow(10, 6),//n2
                                -0.17073846940092 * Math.Pow(10, 2),//n3
                                0.12020824702470 * Math.Pow(10, 5),//n4
                                -0.32325550322333 * Math.Pow(10, 7),//n5
                                0.14915108613530 * Math.Pow(10, 2),//n6
                                -0.48232657361591 * Math.Pow(10, 4),//n7
                                0.405113405420557 * Math.Pow(10, 6),//n8
                                -0.23855557567849,//n9
                                0.65017534844798 * Math.Pow(10, 3)//n10
                            };
        #endregion


        internal static double CalculateSaturationPressure(double saturationTemperature)
        {
            double theta = saturationTemperature / 1 + n[8] / (saturationTemperature / 1 - n[9]);
            double _A = Math.Pow(theta, 2) + n[0] * theta + n[1];
            double _B = n[2] * Math.Pow(theta, 2) + n[3] * theta + n[4];
            double _C = n[5] * Math.Pow(theta, 2) + n[6] * theta + n[7];

            double saturationPressure = Math.Pow((2 * _C / (-_B + Math.Sqrt((Math.Pow(_B, 2) - 4 * _A * _C)))), 4) * 1;

            return saturationPressure;       
        }

        internal static double CalculateSaturationTemperature(double saturationPressure)
        {
            double beta = Math.Pow(saturationPressure / 1, 0.25);
            double _E = Math.Pow(beta, 2) + n[2] * beta + n[5];
            double _F = n[0] * Math.Pow(beta, 2) + n[3] * beta + n[6];
            double _G = n[1] * Math.Pow(beta, 2) + n[4] * beta + n[7];
            double _D = 2 * _G / (-_F - Math.Pow((Math.Pow(_F, 2) - 4 * _E * _G), 0.5));

            double saturationTemperature = (n[9] + _D - Math.Pow(
                                                                    (
                                                                        Math.Pow((n[9] + _D), 2) - 4 * (n[8] + n[9] * _D)
                                                                    )
                                                            , 0.5)
                                            ) / 2 * 1;

            return saturationTemperature;
        }
    }
}
