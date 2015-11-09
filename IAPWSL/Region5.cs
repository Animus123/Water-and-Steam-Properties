using System;
using static System.Math;

namespace IAPWSL
{
    internal static class Region5
    {
        private const double R = 0.461526; // specific gas constant, kJ/(kg*K)

        #region Numerical values of the coefficients and exponents of the ideal-gas part γ^0 of the dimensionless Gibbs free energy for region 5
        static int[] J0 =   {
                                0, 1, -3, -2, -1, 2
                            };

        static double[] n0 =
                            {
                                -0.13179983674201 * Pow(10, 2),//n1
                                0.68540841634434 * Pow(10, 1),//n2
                                -0.24805148933466 * Pow(10, -1),//n3
                                0.36901534980333,//n4
                                -0.31161318213925 * Pow(10, 1),//n5
                                -0.32961626538917//n6
                            };
        #endregion

        #region Numerical values of the coefficients and exponents of the residual part γ^r of the dimensionless Gibbs free energy for region 5
        static int[] I =   {
                                1, 1, 1, 2, 2, 3
                           };

        static int[] J =   {
                                1, 2, 3, 3, 9, 7
                           };
        static double[] n =
                            {
                                0.15736404855259 * Pow(10, -2),//n1
                                0.90153761673944 * Pow(10, -3),//n2
                                -0.50270077677648 * Pow(10, -2),//n3
                                0.22440037409485 * Pow(10, -5),//n4
                                -0.41163275453471 * Pow(10, -5),//n5
                                0.37919454822955 * Pow(10, -7)//n6
                            };
        #endregion

        #region Calculation of basic equation for region 2 and its derivatives

        private static double CountBasicEquation(double pi, double tao)
        {
            double gamma = Log(pi);

            for (int i = 0; i < n0.Length; i++)
            {
                gamma += n0[i] * Math.Pow(tao, J0[i]);
            }
            for (int i = 0; i < n.Length; i++)
            {
                gamma += n[i] * Math.Pow(pi, I[i]) * Math.Pow(tao, J[i]);
            }

            return gamma;
        }

        #region ideal-gas part γ^0 derivatives
        private static double CountDerivative_dGamma0_dPi(double pi)
        {
            return 1 / pi;
        }

        private static double CountDerivative_dGamma0_dTao(double tao)
        {
            double dGamma0_dTao = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGamma0_dTao += n0[i] *J0[i]* Pow(tao, (J0[i]-1));
            }

            return dGamma0_dTao;
        }

        private static double CountDerivative_dGamma0_dPi2(double pi)
        {
            return 1 / (Pow(pi, 2));
        }

        private static double CountDerivative_dGamma0_dTao2(double tao)
        {
            double dGamma0_dTao2 = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGamma0_dTao2 += n0[i] * J0[i] * (J0[i]-1) * Pow(tao, (J0[i] - 2));
            }

            return dGamma0_dTao2;
        }

        private static double CountDerivative_dGamma0_dPidTao()
        {
            return 0;
        }
        #endregion

        #region residual part γ^r derivatives
        private static double CountDerivative_dGammaR_dPi(double pi, double tao)
        {
            double dGammaR_dPi = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGammaR_dPi += n[i] * I[i] * Pow(pi, (I[i] - 1)) * Pow(tao, J[i]);
            }

            return dGammaR_dPi;
        }

        private static double CountDerivative_dGammaR_dTao(double pi, double tao)
        {
            double dGammaR_dTao = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGammaR_dTao += n[i] * Pow(pi, (I[i])) * J[i] * Pow(tao, (J[i]-1));
            }

            return dGammaR_dTao;
        }

        private static double CountDerivative_dGammaR_dPi2(double pi, double tao)
        {
            double dGammaR_dPi2 = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGammaR_dPi2 += n[i] * I[i] * (I[i]-1) * Pow(pi, (I[i] - 2)) * Pow(tao, J[i]);
            }

            return dGammaR_dPi2;
        }

        private static double CountDerivative_dGammaR_dTao2(double pi, double tao)
        {
            double dGammaR_dTao2 = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGammaR_dTao2 += n[i] * Pow(pi, (I[i])) * J[i] * (J[i]-1) * Pow(tao, (J[i] - 2));
            }

            return dGammaR_dTao2;
        }

        private static double CountDerivative_dGammaR_dPidTao(double pi, double tao)
        {
            double dGammaR_dPidTao = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGammaR_dPidTao += n[i] * I[i] * Pow(pi, (I[i]-1)) * J[i] * Pow(tao, (J[i] - 1));
            }

            return dGammaR_dPidTao;
        }
        #endregion

        #endregion

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessTemperature(double t)
        {
            return 1000 / t; // 540 K
        }

        private static double CountDimensionlessPressure(double p)
        {
            return p / 1; //1 MPa
        }
        #endregion

        #region Calculation of thermodynamic properties taking temperature and pressure as input
        internal static double CalculateSpecificVolume(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificVolume = (pi * (CountDerivative_dGamma0_dPi(pi) + CountDerivative_dGammaR_dPi(pi, tao)) * R * temperature) / (pressure * 1000);
            return specificVolume;
        }

        internal static double CalculateSpecificEnthalpy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificEnthalpy = (
                                            tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao))
                                      ) * R * temperature;
            return specificEnthalpy;
        }

        internal static double CalculateSpecificInternalEnergy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificInternalEnergy = (
                                            tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao))
                                            - pi * (CountDerivative_dGamma0_dPi(pi) + CountDerivative_dGammaR_dPi(pi, tao))
                                      ) * R * temperature;
            return specificInternalEnergy;
        }

        internal static double CalculateSpecificEntropy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificInternalEnergy = (
                                                tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao))
                                                - CountBasicEquation(pi, tao)
                                            ) * R;
            return specificInternalEnergy;
        }

        internal static double SpecificIsobaricHeatCapacity(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificIsobaricHeatCapacity = (
                                                        -Pow(tao, 2) * (CountDerivative_dGamma0_dTao2(tao) + CountDerivative_dGammaR_dTao2(pi, tao))
                                                  ) * R;
            return specificIsobaricHeatCapacity;
        }

        internal static double SpecificIsochoricHeatCapacity(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificIsobaricHeatCapacity = (
                                                        -Pow(tao, 2) * (CountDerivative_dGamma0_dTao2(tao) + CountDerivative_dGammaR_dTao2(pi, tao))
                                                        -
                                                        Pow((1+pi*CountDerivative_dGammaR_dPi(pi, tao)-tao*pi*CountDerivative_dGammaR_dPidTao(pi,tao)),2)
                                                        /
                                                        (1 - Pow(pi, 2)*CountDerivative_dGammaR_dPi2(pi, tao))
                                                  ) * R;

            return specificIsobaricHeatCapacity;
        }

        internal static double SpeedOfSound(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double speedOfSound = Math.Sqrt
                                (
                                        (
                                           (1+2*pi*CountDerivative_dGammaR_dPi(pi, tao)+Pow(pi,2)*Pow(CountDerivative_dGammaR_dPi(pi, tao), 2))
                                           /
                                           (
                                                (1-Pow(pi, 2)*CountDerivative_dGammaR_dPi2(pi, tao))
                                                +
                                                Pow((1 + pi * CountDerivative_dGammaR_dPi(pi, tao) - tao * pi * CountDerivative_dGammaR_dPidTao(pi, tao)), 2)
                                                /
                                                (Pow(tao,2)*(CountDerivative_dGamma0_dTao2(tao) + CountDerivative_dGammaR_dTao2(pi, tao)))
                                           )  
                                        ) * R * temperature * 1000
                                 );

            return speedOfSound;
        }
        #endregion
    }
}
