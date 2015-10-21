using System;

namespace IAPWSL
{
    internal static class Region2bBackwardEquation_Tph
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,h) for subregion 2b
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
                                //n31
                                //n32
                                //n33
                                //n34
                                //n35
                                //n36
                                //n37
                                //n38
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double eta)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
