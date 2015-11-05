using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region2bBackwardEquation_Tph
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,h) for subregion 2b
        static int[] I =   {
                                0, 0, 0, 0, 0,
                                0, 0, 0, 1, 1,
                                1, 1, 1, 1, 1,
                                1, 2, 2, 2, 2,
                                3, 3, 3, 3, 4,
                                4, 4, 4, 4, 4,
                                5, 5, 5, 6, 7,
                                7, 9, 9
                           };

        static int[] J =   {
                                0, 1, 2, 12, 18,
                                24, 28, 40, 0, 2,
                                6, 12, 18, 24, 28,
                                40, 2, 8, 18, 40,
                                1, 2, 12, 24, 2,
                                12, 18, 24, 28, 40,
                                18, 24, 40, 28, 2,
                                28, 1, 40
                           };
        static double[] n =
                            {
                                0.14895041079516 * Pow(10, 4),//n1
                                0.74307798314034 * Pow(10, 3),//n2
                                -0.97708318797837 * Pow(10, 2),//n3
                                0.24742464705674 * Pow(10, 1),//n4
                                -0.63281320016026,//n5
                                0.11385952129658 * Pow(10, 1),//n6
                                -0.47811863648625,//n7
                                0.85208123431544 * Pow(10, -2),//n8
                                0.93747147377932,//n9
                                0.33593118604916 * Pow(10, 1),//n10
                                0.33809355601454 * Pow(10, 1),//n11
                                0.16844539671904,//n12
                                0.73875745236695,//n13
                                -0.47128737436186,//n14
                                0.15020273139707,//n15
                                -0.21764114219750 * Pow(10, -2),//n16
                                -0.21810755324761 * Pow(10, -1),//n17
                                -0.10829784403677,//n18
                                -0.46333324635812 * Pow(10, -1),//n19
                                0.71280351959551 * Pow(10, -4),//n20
                                0.11032831789999 * Pow(10, -3),//n21
                                0.18955248387902 * Pow(10, -3),//n22
                                0.30891541160537 * Pow(10, -2),//n23
                                0.13555504554949 * Pow(10, -2),//n24
                                0.28640237477456 * Pow(10, -6),//n25
                                -0.10779857357512 * Pow(10, -4),//n26
                                -0.76462712454814 * Pow(10, -4),//n27
                                0.14052392818316 * Pow(10, -4),//n28
                                -0.31083814331434 * Pow(10, -4),//n29
                                -0.10302738212103 * Pow(10, -5),//n30
                                0.28217281635040 * Pow(10, -6),//n31
                                0.12704902271945 * Pow(10, -5),//n32
                                0.73803353468292 * Pow(10, -7),//n33
                                -0.11030139238909 * Pow(10, -7),//n34
                                -0.81456365207833 * Pow(10, -13),//n35
                                -0.25180545682962 * Pow(10, -10),//n36
                                -0.17565233969407 * Pow(10, -17),//n37
                                0.86934156344163 * Pow(10, -14)//n38
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double eta)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow((pi-2), I[i]) * Pow((eta - 2.6), J[i]);
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
