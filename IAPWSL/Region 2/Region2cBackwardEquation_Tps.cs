using System;

namespace IAPWSL
{
    internal static class Region2cBackwardEquation_Tps
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,s) for subregion 2c
        static int[] I =   {

                           };

        static int[] J =   {

                           };
        static double[] n =
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
                                //n11
                                //n12
                                //n13
                                //n14
                                //n15
                                //n16
                                //n17
                                //n18
                                //n19
                                //n20
                                //n21
                                //n22
                                //n23
                                //n24
                                //n25
                                //n26
                                //n27
                                //n28
                                //n29
                                //n30
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double sigma)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
