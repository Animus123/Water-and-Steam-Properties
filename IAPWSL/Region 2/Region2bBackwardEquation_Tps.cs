using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region2bBackwardEquation_Tps
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,s) for subregion 2b
        static int[] I =   {
                                -6, -6, -5, -5, -4,
                                -4, -4, -3, -3, -3,
                                -3, -2, -2, -2, -2,
                                -1, -1, -1, -1, -1,
                                0, 0, 0, 0, 0,
                                0, 0, 1, 1, 1,
                                1, 1, 1, 2, 2,
                                2, 3, 3, 3, 4,
                                4, 5, 5, 5
                           };

        static int[] J =   {
                                0, 11, 0, 11, 0,
                                1, 11, 0, 1, 11,
                                12, 0, 1, 6, 10,
                                0, 1, 5, 8, 9,
                                0, 1, 2, 4, 5,
                                6, 9, 0, 1, 2,
                                3, 7, 8, 0, 1,
                                5, 0, 1, 3, 0,
                                1, 0, 1, 2
                           };
        static double[] n =
                            {
                                0.31687665083497 * Pow(10, 6),//n1
                                0.20864175881858 * Pow(10, 2),//n2
                                -0.39859399803599 * Pow(10, 6),//n3
                                -0.21816058518877 * Pow(10, 2),//n4
                                0.22369785194242 * Pow(10, 6),//n5
                                -0.27841703445817 * Pow(10, 4),//n6
                                0.99207436071480 * Pow(10, 1),//n7
                                -0.75197512299157 * Pow(10, 5),//n8
                                0.29708605951158 * Pow(10, 4),//n9
                                -0.34406878548526 * Pow(10, 1),//n10
                                0.38815564249115,//n11
                                0.17511295085750 * Pow(10, 5),//n12
                                -0.14237112854449 * Pow(10, 4),//n13
                                0.10943803364167 * Pow(10, 1),//n14
                                0.89971619308495,//n15
                                -0.33759740098958 * Pow(10, 4),//n16
                                0.47162885818355 * Pow(10, 3),//n17
                                -0.19188241993679 * Pow(10, 1),//n18
                                0.41078580492196,//n19
                                -0.33465378172097,//n20
                                0.13870034777505 * Pow(10, 4),//n21
                                -0.40663326195838 * Pow(10, 3),//n22
                                0.41727347159610 * Pow(10, 2),//n23
                                0.21932549434532 * Pow(10, 1),//n24
                                -0.10320050009077 * Pow(10, 1),//n25
                                0.35882943516703,//n26
                                0.52511453726066 * Pow(10, -2),//n27
                                0.12838916450705 * Pow(10, 2),//n28
                                -0.28642437219381 * Pow(10, 1),//n29
                                0.56912683664855,//n30
                                -0.99962954584931 * Pow(10, -1),//n31
                                -0.32632037778459 * Pow(10, -2),//n32
                                0.23320922576723 * Pow(10, -3),//n33
                                -0.15334809857450,//n34
                                0.29072288239902 * Pow(10, -1),//n35
                                0.37534702741167 * Pow(10, -3),//n36
                                0.17296691702411 * Pow(10, -2),//n37
                                -0.38556050844504 * Pow(10, -3),//n38
                                -0.35017712292608 * Pow(10, -4),//n39
                                -0.14566393631492 * Pow(10, -4),//n40
                                0.56420857267269 * Pow(10, -5),//n41
                                0.41286150074605 * Pow(10, -7),//n42
                                -0.20684671118824 * Pow(10, -7),//n43
                                0.16409393674725 * Pow(10, -8),//n44
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double sigma)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow(pi, I[i]) * Pow((10 - sigma), J[i]);
            }

            return theta;
        }

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessEntropy(double s)
        {
            return s / 0.7853;	//0.7853 kJ/(kg*K)
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
