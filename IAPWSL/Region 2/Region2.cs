using System;

namespace IAPWSL
{
    /// <summary>
    /// The basic equation for region 2.
    /// </summary>
    internal static class Region2
    {
        private const double R = 0.461526; // specific gas constant, kJ/(kg*K)

        #region Numerical values of the coefficients and exponents of the ideal-gas part γ^0 of the dimensionless Gibbs free energy for region 2
        static int[] J0 =   {
                                0, 1, -5, -4, -3,
                                -2, -1, 2, 3
                            };

        static double[] n0 =
                            {
                                -0.96927686500217 * Math.Pow(10, 1),//n1
                                0.10086655968018 * Math.Pow(10, 2),//n2
                                -0.56087911283020 * Math.Pow(10, -2),//n3
                                0.71452738081455 * Math.Pow(10, -1),//n4
                                -0.40710498223928,//n5
                                0.14240819171444 * Math.Pow(10, 1),//n6
                                -0.43839511319450 * Math.Pow(10, 1),//n7
                                -0.28408632460772,//n8
                                0.21268463753307 * Math.Pow(10, -1)//n9
                            };
        #endregion

        #region Numerical values of the coefficients and exponents of the residual part γ^r of the dimensionless Gibbs free energy for region 2
        static int[] I =   {
                               1, 1, 1, 1, 1,
                               2, 2, 2, 2, 2,
                               3, 3, 3, 3, 3,
                               4, 4, 4, 5, 6,
                               6, 6, 7, 7, 7,
                               8, 8, 9, 10, 10,
                               10, 16, 16, 18, 20,
                               20, 20, 21, 22, 23,
                               24, 24, 24
                           };

        static int[] J =   {
                               0, 1, 2, 3, 6,
                               1, 2, 4, 7, 36,
                               0, 1, 3, 6, 35,
                               1, 2, 3, 7, 3,
                               16, 35, 0, 11, 25,
                               8, 36, 13, 4, 10,
                               14, 29, 50, 57, 20,
                               35, 48, 21, 53, 39,
                               26, 40, 58
                           };
        static double[] n =
                            {
                                -0,17731742473213 * Math.Pow(10, -2),//n1
                                -0,17834862292358 * Math.Pow(10, -1),//n2
                                -0,45996013696365 * Math.Pow(10, -1),//n3
                                -0,57581259083432 * Math.Pow(10, -1),//n4
                                -0,50325278727930 * Math.Pow(10, -1),//n5
                                0,33032641670203 * Math.Pow(10, -4),//n6
                                -0,18948987516315 * Math.Pow(10, -3),//n7
                                -0,39392777243355 * Math.Pow(10, -2),//n8
                                -0,43797295650573 * Math.Pow(10, -1),//n9
                                -0,26674547914087 * Math.Pow(10, -4),//n10
                                0,20481737692309 * Math.Pow(10, -7),//n11
                                0,43870667284435 * Math.Pow(10, -6),//n12
                                -0,32277677238570 * Math.Pow(10, -4),//n13
                                -0,15033924542148 * Math.Pow(10, -2),//n14
                                -0,40668253562649 * Math.Pow(10, -1),//n15
                                -0,78847309559367 * Math.Pow(10, -9),//n16
                                0,12790717852285 * Math.Pow(10, -7),//n17
                                0,48225372718507 * Math.Pow(10, -6),//n18
                                0,22922076337661 * Math.Pow(10, -5),//n19
                                -0,16714766451061 * Math.Pow(10, -10),//n20
                                -0,21171472321355 * Math.Pow(10, -2),//n21
                                -0,23895741934104 * Math.Pow(10, 2),//n22
                                -0,59059564324270 * Math.Pow(10, -17),//n23
                                -0,12621808899101 * Math.Pow(10, -5),//n24
                                -0,38946842435739 * Math.Pow(10, -1),//n25
                                0,11256211360459 * Math.Pow(10, -10),//n26
                                -0,82311340897998 * Math.Pow(10, 1),//n27
                                0,19809712802088 * Math.Pow(10, -7),//n28
                                0,10406965210174 * Math.Pow(10, -18),//n29
                                -0,10234747095929 * Math.Pow(10, -12),//n30
                                -0,10018179379511 * Math.Pow(10, -8),//n31
                                -0,80882908646985 * Math.Pow(10, -10),//n32
                                0,10693031879409,//n33
                                -0,33662250574171,//n34
                                0,89185845355421 * Math.Pow(10, -24),//n35
                                0,30629316876232 * Math.Pow(10, -12),//n36
                                -0,42002467698208 * Math.Pow(10, -5),//n37
                                -0,59056029685639 * Math.Pow(10, -25),//n38
                                0,37826947613457 * Math.Pow(10, -5),//n39
                                -0,12768608934681 * Math.Pow(10, -14),//n40
                                0,73087610595061 * Math.Pow(10, -28),//n41
                                0,55414715350778 * Math.Pow(10, -16),//n42
                                -0,94369707241210 * Math.Pow(10, -6),//n43
                            };
        #endregion

        #region Calculation of basic equation for region 2 and its derivatives

        private static double CountBasicEquation(double pi, double tao)
        {
            double gamma = Math.Log(pi);

            for (int i = 0; i < n0.Length; i++)
            {
                gamma += n0[i] * Math.Pow(tao, J0[i]);
            }
            for (int i = 0; i < n.Length; i++)
            {
                gamma += n[i] *Math.Pow(pi, I[i])* Math.Pow((tao-0.5), J[i]);
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
                dGamma0_dTao += n0[i] * J0[i] * Math.Pow(tao, (J0[i]-1));
            }

            return dGamma0_dTao;
        }

        private static double CountDerivative_dGamma0_dPi2(double pi)
        {
            double dGamma0_dPi2 = -1/(Math.Pow(pi,2));
            return dGamma0_dPi2;

        }

        private static double CountDerivative_dGamma0_dTao2(double tao)
        {
            double dGamma0_dTao2 = 0;
            for (int i = 0; i < n0.Length; i++)
            {
                dGamma0_dTao2 += n0[i] * J0[i] * (J0[i]-1) * Math.Pow(tao, (J0[i] - 2));
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

            for (int i = 0; i < n.Length; i++)
            {
                dGammaR_dPi += n[i] * I[i] * Math.Pow(pi, (I[i]-1)) * Math.Pow((tao - 0.5), J[i]);
            }

            return dGammaR_dPi;
        }

        private static double CountDerivative_dGammaR_dTao(double pi, double tao)
        {
            double dGammaR_dTao = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGammaR_dTao += n[i] * J[i] * Math.Pow(pi, I[i]) * Math.Pow((tao - 0.5), (J[i]-1));
            }

            return dGammaR_dTao;
        }

        private static double CountDerivative_dGammaR_dPi2(double pi, double tao)
        {
            double dGammaR_dPi2 = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGammaR_dPi2 += n[i] * I[i]* (I[i] - 1) * Math.Pow(pi, (I[i] - 2)) * Math.Pow((tao - 0.5), J[i]);
            }

            return dGammaR_dPi2;
        }

        private static double CountDerivative_dGammaR_dTao2(double pi, double tao)
        {
            double dGammaR_dTao2 = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGammaR_dTao2 += n[i] * J[i] * (J[i] - 1) * Math.Pow(pi, I[i]) * Math.Pow((tao - 0.5), (J[i] - 2));
            }

            return dGammaR_dTao2;
        }

        private static double CountDerivative_dGammaR_dPidTao(double pi, double tao)
        {
            double dGammaR_dPidTao = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGammaR_dPidTao += n[i] * I[i] * Math.Pow(pi, (I[i] - 1)) * J[i] * Math.Pow((tao - 0.5), (J[i]-1));
            }

            return dGammaR_dPidTao;
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
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificVolume = (pi * (CountDerivative_dGamma0_dPi(pi) + CountDerivative_dGammaR_dPi(pi, tao))) * R * temperature / pressure;
            return specificVolume;
        }

        internal static double CalculateSpecificEnthalpy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificEnthalpy = (tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao)))*R*temperature;
            return specificEnthalpy;
        }

        internal static double CalculateSpecificInternalEnergy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificInternalEnergy = (tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao)) -
                                            pi * (CountDerivative_dGamma0_dPi(pi) + CountDerivative_dGammaR_dPi(pi, tao))) * R * temperature;
            return specificInternalEnergy;

        }

        internal static double CalculateSpecificEntropy(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificInternalEnergy = (tao * (CountDerivative_dGamma0_dTao(tao) + CountDerivative_dGammaR_dTao(pi, tao)) -
                                            (CountBasicEquation(pi, tao)))*R;
            return specificInternalEnergy;
        }

        internal static double SpecificIsobaricHeatCapacity(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificIsobaricHeatCapacity = (-Math.Pow(tao, 2) * (CountDerivative_dGamma0_dTao2(tao)
                                                  + CountDerivative_dGammaR_dTao2(pi, tao)))*R;
            return specificIsobaricHeatCapacity;
        }

        internal static double SpecificIsochoricHeatCapacity(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double specificIsobaricHeatCapacity = (
                                                      -Math.Pow(tao, 2) * (CountDerivative_dGamma0_dTao2(tao) + CountDerivative_dGammaR_dTao2(pi, tao))
                                                      - (
                                                            Math.Pow(
                                                                        1 + pi * CountDerivative_dGammaR_dPi(pi, tao)
                                                                        - tao * pi * CountDerivative_dGammaR_dPidTao(pi, tao)
                                                                  , 2)
                                                        )
                                                        /
                                                        (
                                                            1 - Math.Pow(pi, 2) * CountDerivative_dGammaR_dPi2(pi, tao)
                                                        )
                                                  ) *R;

            return specificIsobaricHeatCapacity;                                      
        }
        
        internal static double SpeedOfSound(double temperature, double pressure)
        {
            double pi = CountDimensionlessPressure(pressure);
            double tao = CountDimensionlessTemperature(temperature);

            double speedOfSound = (
                                          (
                                                1 + 2 * pi * CountDerivative_dGammaR_dPi(pi, tao)
                                                + Math.Pow(pi, 2) * Math.Pow(CountDerivative_dGammaR_dPi(pi, tao), 2)
                                          )
                                          /
                                          (
                                                (1 - Math.Pow(pi, 2) * CountDerivative_dGammaR_dPi2(pi, tao))
                                                +
                                                (
                                                       Math.Pow(
                                                                   1 + pi * CountDerivative_dGammaR_dPi(pi, tao)
                                                                   - tao * pi * CountDerivative_dGammaR_dPidTao(pi, tao)
                                                            , 2)
                                                )
                                                /
                                                (
                                                       Math.Pow(tao, 2) * (CountDerivative_dGamma0_dTao2(tao) + CountDerivative_dGammaR_dTao2(pi, tao))
                                                )
                                          )
                                  ) * R * temperature;

            return speedOfSound;
        }
        #endregion
    }
}
