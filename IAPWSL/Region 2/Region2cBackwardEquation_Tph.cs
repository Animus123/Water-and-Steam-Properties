using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region2cBackwardEquation_Tph
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,h) for subregion 2c
        static int[] I =   {
                                -7, -7, -6, -6, -5,
                                -5, -2, -2, -1, -1,
                                0, 0, 1, 1, 2,
                                6, 6, 6, 6, 6,
                                6, 6, 6
                           };

        static int[] J =   {
                                0, 4, 0, 2, 0,
                                2, 0, 1, 0, 2,
                                0, 1, 4, 8, 4,
                                0, 1, 4, 10, 12,
                                16, 20, 22
                           };
        static double[] n =
                            {
                                -0.32368398555242 * Pow(10, 13),//n1
                                0.73263350902181 * Pow(10, 13),//n2
                                0.35825089945447 * Pow(10, 12),//n3
                                -0.58340131851590 * Pow(10, 12),//n4
                                -0.10783068217470 * Pow(10, 11),//n5
                                0.20825544563171 * Pow(10, 11),//n6
                                0.61074783564516 * Pow(10, 6),//n7
                                0.85977722535580 * Pow(10, 6),//n8
                                -0.25745723604170 * Pow(10, 5),//n9
                                0.31081088422714 * Pow(10, 5),//n10
                                0.12082315865936 * Pow(10, 4),//n11
                                0.48219755109255 * Pow(10, 3),//n12
                                0.37966001272486 * Pow(10, 1),//n13
                                -0.10842984880077 * Pow(10, 2),//n14
                                -0.45364172676660 * Pow(10, -1),//n15
                                0.14559115658698 * Pow(10, -12),//n16
                                0.11261597407230 * Pow(10, -11),//n17
                                -0.17804982240686 * Pow(10, -10),//n18
                                0.12324579690832 * Pow(10, -6),//n19
                                -0.11606921130984 * Pow(10, -5),//n20
                                0.27846367088554 * Pow(10, -4),//n21
                                -0.59270038474176 * Pow(10, -3),//n22
                                0.12918582991878 * Pow(10, -2)//n23
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double eta)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow((pi + 25), I[i]) * Pow((eta - 1.8), J[i]);
            }

            return theta;
        }

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessEnthalpy(double h)
        {
            return h / 2000;	//2000 kJ/kg
        }

        private static double CountDimensionlessPressure(double p)
        {
            return p / 1;	// 1 MPa
        }

        private static double CountDimensionlessTemperature(double t)
        {
            return t / 1;	// 1 K
        }

        #endregion

        internal static double CalculateTemperature(double pressure, double enthalpy)
        {
            double eta = CountDimensionlessEnthalpy(enthalpy);
            double pi = CountDimensionlessPressure(pressure);

            double temperature = CountBackwardEquation(pi, eta) * 1; //1 K
            return temperature;
        }
    }
}
