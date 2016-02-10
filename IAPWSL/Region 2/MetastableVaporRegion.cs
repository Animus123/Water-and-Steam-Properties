using System;

namespace IAPWSL
{

    //TODO
    internal static class MetastableVaporRegion
    {
        #region Numerical values of the coefficients and exponents of the ideal-gas part γ^0 of the dimensionless Gibbs free energy for Metastable-Vapor Region
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

        #region Numerical values of the coefficients and exponents of the residual part γ^r of the dimensionless Gibbs free energy for Metastable-Vapor Region
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
                            };
        #endregion

        #region Calculation of basic equation for region Metastable-Vapor Region and its derivatives

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
