using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region2cBackwardEquation_Tps
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,s) for subregion 2c
        static int[] I =   {
                                -2, -2, -1, 0, 0,
                                0, 0, 1, 1, 1,
                                1, 2, 2, 2, 3,
                                3, 3, 4, 4, 4,
                                5, 5, 5, 6, 6,
                                7, 7, 7, 7, 7
                           };

        static int[] J =   {
                                0, 1, 0, 0, 1,
                                2, 3, 0, 1, 3,
                                4, 0, 1, 2, 0,
                                1, 5, 0, 1, 4,
                                0, 1, 2, 0, 1,
                                0, 1, 3, 4, 5
                           };
        static double[] n =
                            {
                                0.90968501005365 * Pow(10, 3),//n1
                                0.24045667088420 * Pow(10, 4),//n2
                                -0.59162326387130 * Pow(10, 3),//n3
                                0.54145404128074 * Pow(10, 3),//n4
                                -0.27098308411192 * Pow(10, 3),//n5
                                0.97976525097926 * Pow(10, 3),//n6
                                -0.46966772959435 * Pow(10, 3),//n7
                                0.14399274604723 * Pow(10, 2),//n8
                                -0.19104204230429 * Pow(10, 2),//n9
                                0.53299167111971 * Pow(10, 1),//n10
                                -0.21252975375934 * Pow(10, 2),//n11
                                -0.31147334413760,//n12
                                0.60334840894623,//n13
                                -0.42764839702509 * Pow(10, -1),//n14
                                0.58185597255259 * Pow(10, -2),//n15
                                -0.14597008284753 * Pow(10, -1),//n16
                                0.56631175631027 * Pow(10, -2),//n17
                                -0.76155864584577 * Pow(10, -4),//n18
                                0.22440342919332 * Pow(10, -3),//n19
                                -0.12561095013413 * Pow(10, -4),//n20
                                0.63323132660934 * Pow(10, -6),//n21
                                -0.20541989675375 * Pow(10, -5),//n22
                                0.36405370390082 * Pow(10, -7),//n23
                                -0.29759897789215 * Pow(10, -8),//n24
                                0.10136618529763 * Pow(10, -7),//n25
                                0.59925719692351 * Pow(10, -11),//n26
                                -0.20677870105164 * Pow(10, -10),//n27
                                -0.20874278181886 * Pow(10, -10),//n28
                                0.10162166825089 * Pow(10, -9),//n29
                                -0.16429828281347 * Pow(10, -9)//n30
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double sigma)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow(pi, I[i]) * Pow((2 - sigma), J[i]);
            }

            return theta;
        }

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessEntropy(double s)
        {
            return s / 2.9251;	//0.7853 kJ/(kg*K)
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

        internal static double CalculateTemperature(double pressure, double entropy)
        {
            double sigma = CountDimensionlessEntropy(entropy);
            double pi = CountDimensionlessPressure(pressure);

            double temperature = CountBackwardEquation(pi, sigma) * 1; //1 K
            return temperature;
        }
    }
}
