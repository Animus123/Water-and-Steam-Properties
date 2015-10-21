using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL
{
    internal static class Region3
    {
        #region Numerical values of the coefficients and exponents of the dimensionless Helmholtz free energy for region 3
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
                            };
        #endregion

        #region Calculation of basic equation for region 3 and its derivatives

        private static double CountBasicEquation(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dFi_dDelta(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dFi_dTao(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dFi_dDelta2(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dFi_dTao2(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        private static double CountDerivative_dFi_dDeltadTao(double delta, double tao)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessDensity(double ro)
        {
            return ro / 322; // kg/m3
        }

        private static double CountDimensionlessTemperature(double t)
        {
            return 647.096 / t; // K
        }
        #endregion

        #region Calculation of thermodynamic properties taking density and temperature as input
        internal static double CalculatePressure(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificEnthalpy(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificInternalEnergy(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateSpecificEntropy(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double SpecificIsobaricHeatCapacity(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double SpecificIsochoricHeatCapacity(double density, double temperature)
        {
            throw new NotImplementedException();
        }

        internal static double SpeedOfSound(double density, double temperature)
        {
            throw new NotImplementedException();
        }
        #endregion

        // !!! For some reason this region has Phase-equilibrium condition (it is added to table 31) !!!
    }
}
