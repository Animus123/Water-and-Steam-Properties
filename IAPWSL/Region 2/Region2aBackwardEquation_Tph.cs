using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region2aBackwardEquation_Tph
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,h) for subregion 2a
        static int[] I =   {
                                0, 0, 0, 0, 0,
                                0, 1, 1, 1, 1,
                                1, 1, 1, 1, 1,
                                2, 2, 2, 2, 2,
                                2, 2, 2, 3, 3,
                                4, 4, 4, 5, 5,
                                5, 6, 6, 7
                           };

        static int[] J =   {
                                0, 1, 2, 3, 7,
                                20, 0, 1, 2, 3,
                                7, 9, 11, 18, 44,
                                0, 2, 7, 36, 38,
                                40, 42, 44, 24, 44,
                                12, 32, 44, 32, 36,
                                42, 34, 44, 28                                
                           };
        static double[] n =
                            {
                                0.10898952318288*Pow(10, 4),//n1
                                0.84951654495535*Pow(10, 3),//n2
                                -0.10781748091826*Pow(10, 3),//n3
                                0.33153654801263*Pow(10, 2),//n4
                                -0.74232016790248*Pow(10, 1),//n5
                                0.11765048724356*Pow(10, 2),//n6
                                0.18445749355790*Pow(10, 1),//n7
                                -0.41792700549624*Pow(10, 1),//n8
                                0.62478196935812*Pow(10, 1),//n9
                                -0.17344563108114*Pow(10, 2),//n10
                                -0.20058176862096*Pow(10, 3),//n11
                                0.27196065473796*Pow(10, 3),//n12
                                -0.45511318285818*Pow(10, 3),//n13
                                0.30919688604755*Pow(10, 4),//n14
                                0.25226640357872*Pow(10, 6),//n15
                                -0.61707422868339*Pow(10, -2),//n16
                                -0.31078046629583,//n17
                                0.11670873077107*Pow(10, 2),//n18
                                0.12812798404046*Pow(10, 9),//n19
                                -0.98554909623276*Pow(10, 9),//n20
                                0.28224546973002*Pow(10, 10),//n21
                                -0.35948971410703*Pow(10, 10),//n22
                                0.17227349913197*Pow(10, 10),//n23
                                -0.13551334240775*Pow(10, 5),//n24
                                0.12848734664650*Pow(10, 8),//n25
                                0.13865724283226*Pow(10, 1),//n26
                                0.23598832556514*Pow(10, 6),//n27
                                -0.13105236545054*Pow(10, 8),//n28
                                0.73999835474766*Pow(10, 4),//n29
                                -0.55196697030060*Pow(10, 6),//n30
                                0.37154085996233*Pow(10, 7),//n31
                                0.19127729239660*Pow(10, 5),//n32
                                -0.41535164835634*Pow(10, 6),//n33
                                -0.62459855192507*Pow(10, 2)//n34
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double eta)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow(pi, I[i]) * Pow((eta - 2.1), J[i]);
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
