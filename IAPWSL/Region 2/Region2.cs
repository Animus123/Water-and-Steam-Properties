using System;

namespace IAPWSL
{
    /// <summary>
    /// The basic equation for region 2.
    /// </summary>
    internal static class Region2
    {
        #region Numerical values of the coefficients and exponents of the ideal-gas part γ^0 of the dimensionless Gibbs free energy for region 2
        static int[] J0 =   {

                            };

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
                            };
        #endregion

        #region Numerical values of the coefficients and exponents of the residual part γ^r of the dimensionless Gibbs free energy for region 2
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
                                //n39
                                //n40
                                //n41
                                //n42
                                //n43
                            };
        #endregion

        #region Calculation of basic equation for region 2 and its derivatives

        private static double CountBasicEquation(double pi, double tao)
        {
            throw new NotImplementedException();
        }

        #region ideal-gas part γ^0 derivatives
        private static double CountDerivative_dGamma0_dPi(double pi)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGamma0_dTao(double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGamma0_dPi2(double pi)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGamma0_dTao2(double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGamma0_dPidTao()
        {
            return 0;
        }
        #endregion
        #region residual part γ^r derivatives
        private static double CountDerivative_dGammaR_dPi(double pi, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGammaR_dTao(double pi, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGammaR_dPi2(double pi, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGammaR_dTao2(double pi, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dGammaR_dPidTao(double pi, double tao)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessTemperature(double t)
        {
            return 540 / t; // 540 K
        }

        private static double CountDimensionlessPressure(double p)
        {
            return p / 1; //1 MPa
        }
        #endregion

        #region Calculation of thermodynamic properties taking temperature and pressure as input
        internal static double CalculateSpecificVolume(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificEnthalpy(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificInternalEnergy(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificEntropy(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double SpecificIsobaricHeatCapacity(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double SpecificIsochoricHeatCapacity(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }

        internal static double SpeedOfSound(double temperature, double pressure)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
