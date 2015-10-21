using System;

/*This code based on "Revised Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam"*/
namespace IAPWSL
{
    /// <summary>
    /// The basic equation for region 1
    /// </summary>
    internal static class Region1BasicEquation
    {
        private const double R = 0.461526; // specific gas constant, kJ/(kg*K)

        #region Numerical values of the coefficients and exponents of the dimensionless Gibbs free energy for region 1
        static int[] I =   {
                                0, 0, 0, 0, 0,
                                0, 0, 0, 1, 1,
                                1, 1, 1, 1, 2,
                                2, 2, 2, 2, 3,
                                3, 3, 4, 4, 4,
                                5, 8, 8, 21, 23,
                                29, 30, 31, 32
                            };

        static int[] J =   {
                                -2, -1, 0, 1, 2,
                                3, 4, 5, -9, -7,
                                -1, 0, 1, 3, -3,
                                0, 1, 3, 17, -4,
                                0, 6, -5, -2, 10,
                                -8, -11, -6, -29, -31,
                                -38, -39, -40, -41
                            };
        static double[] n =
                            {
                                0.14632971213167,                   //n1
                                -0.84548187169114,                  //n2
                                -0.37563603672040*10,               //n3
                                0.33855169168385*10,                //n4
                                -0.95791963387872,                  //n5
                                0.15772038513228,                   //n6
                                -0.16616417199501*Math.Pow(10,-1),  //n7
                                0.81214629983568*Math.Pow(10,-3),   //n8
                                0.28319080123804*Math.Pow(10,-3),   //n9
                                -0.60706301565874*Math.Pow(10,-3),  //n10
                                -0.18990068218419*Math.Pow(10,-1),  //n11
                                -0.32529748770505*Math.Pow(10,-1),  //n12
                                -0.21841717175414*Math.Pow(10,-1),  //n13
                                -0.52838357969930*Math.Pow(10,-4),  //n14
                                -0.47184321073267*Math.Pow(10,-3),  //n15
                                -0.30001780793026*Math.Pow(10,-3),  //n16
                                0.47661393906987*Math.Pow(10,-4),   //n17
                                -0.44141845330846*Math.Pow(10,-5),  //n18
                                -0.72694996297594*Math.Pow(10,-15), //n19
                                -0.31679644845054*Math.Pow(10,-4),  //n20
                                -0.28270797985312*Math.Pow(10,-5),  //n21
                                -0.85205128120103*Math.Pow(10,-9),  //n22
                                -0.22425281908000*Math.Pow(10,-5),  //n23
                                -0.65171222895601*Math.Pow(10,-6),  //n24
                                -0.14341729937924*Math.Pow(10,-12), //n25
                                -0.40516996860117*Math.Pow(10,-6),  //n26
                                -0.12734301741641*Math.Pow(10,-8),  //n27
                                -0.17424871230634*Math.Pow(10,-9),  //n28
                                -0.68762131295531*Math.Pow(10,-18), //n29
                                0.14478307828521*Math.Pow(10,-19),  //n30
                                0.26335781662795*Math.Pow(10,-22),  //n31
                                -0.11947622640071*Math.Pow(10,-22), //n32
                                0.18228094581404*Math.Pow(10,-23),  //n33
                                -0.93537087292458*Math.Pow(10,-25)  //n34
                            };
        #endregion

        #region Calculation of basic equation for region 1 and its derivatives
        /// <summary>
        /// Basic equation for region 1 γ(π,τ), where γ is specific Gibbs free energy devided by temperature (T, K) and specific gas constant.
        /// In other words γ is dimensionless Gibbs free energy
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns>dimensionless Gibbs free energy, γ</returns>
        private static double CountBasicEquation(double tao, double pi)
        {
            double gamma=0;

            for (int i = 0; i < n.Length; i++)
            {
                gamma += n[i] * Math.Pow((7.1 - pi), I[i]) * Math.Pow((tao - 1.222), J[i]);
            }

            return gamma;
        }

        /// <summary>
        /// Count derivative γ with respect to π
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns>derivative γ with respect to π</returns>
        private static double CountDerivative_dGamma_dPi(double tao, double pi)
        {
            double dGamma_dPi = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGamma_dPi += -n[i] * I[i]*Math.Pow((7.1 - pi), I[i]-1) * Math.Pow((tao - 1.222), J[i]);
            }

            return dGamma_dPi;
        }

        /// <summary>
        /// Count derivative γ with respect to τ
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns></returns>
        private static double CountDerivative_dGamma_dTao(double tao, double pi)
        {
            double dGamma_dTao = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGamma_dTao += n[i] * Math.Pow((7.1 - pi), I[i]) *J[i]* Math.Pow((tao - 1.222), J[i]-1);
            }

            return dGamma_dTao;
        }

        /// <summary>
        /// Count second derivative γ with respect to π
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns>derivative γ with respect to π</returns>
        private static double CountDerivative_dGamma_dPi2(double tao, double pi)
        {
            double dGamma_dPi2 = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGamma_dPi2 += n[i] * I[i] * (I[i] - 1) * Math.Pow((7.1 - pi), I[i] - 2) * Math.Pow((tao - 1.222), J[i]);
            }

            return dGamma_dPi2;
        }

        /// <summary>
        /// Count second derivative γ with respect to τ
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns>derivative γ with respect to π</returns>
        private static double CountDerivative_dGamma_dTao2(double tao, double pi)
        {
            double dGamma_dTao2 = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGamma_dTao2 += n[i] * Math.Pow((7.1 - pi), I[i]) * J[i] * (J[i] - 1) * Math.Pow((tao - 1.222), J[i] - 2);
            }

            return dGamma_dTao2;
        }

        /// <summary>
        /// Count derivative γ with respect to π and derivative with respect to τ
        /// </summary>
        /// <param name="tao">dimensionless temperature</param>
        /// <param name="pi">dimensionless  pressure</param>
        /// <returns></returns>
        private static double CountDerivative_dGamma_dPidTao(double tao, double pi)
        {
            double dGamma_dPidTao = 0;

            for (int i = 0; i < n.Length; i++)
            {
                dGamma_dPidTao += -n[i] * I[i] * Math.Pow((7.1 - pi), I[i] - 1) * J[i] * Math.Pow((tao - 1.222), J[i] - 1);
            }

            return dGamma_dPidTao;
        }
        #endregion

        /// <summary>
        /// Count dimensionless temperature, τ
        /// </summary>
        /// <param name="t">temperature, K</param>
        /// <returns>dimesionless temperature</returns>
        private static double CountDimensionlessTemperature(double t)
        {
            return 1386 / t;
        }

        /// <summary>
        /// Count dimensionless pressure, π
        /// </summary>
        /// <param name="p">pressure, MPa</param>
        /// <returns>dimensionless pressure</returns>
        private static double CountDimensionlessPressure(double p)
        {
            return p / 16.53;
        }

        #region Calculation of thermodynamic properties taking temperature and pressure as input
        /*
        This methods count various properties of substance in 2 steps.
        1. count dimensionless parameters tao and pi
        2. count property (see table 3 IAPWS documentation).
        */
        internal static double CalculateSpecificVolume(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            //pressure must be multiplied by 1000 to be in kPa
            double specificVolume = pi * CountDerivative_dGamma_dPi(tao, pi) / (pressure*1000) * R * temperature; //(m^3)/kg

            return specificVolume;
        }

        internal static double CalculateSpecificEnthalpy(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double specificEnthalpy = tao * CountDerivative_dGamma_dTao(tao, pi) * R * temperature;
            return specificEnthalpy;
        }

        internal static double CalculateSpecificInternalEnergy(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double specificInternalEnergy = (tao * CountDerivative_dGamma_dTao(tao, pi) - pi * CountDerivative_dGamma_dPi(tao, pi)) * R * temperature;
            return specificInternalEnergy;
        }

        internal static double CalculateSpecificEntropy(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double specificEntropy = (tao * CountDerivative_dGamma_dTao(tao, pi) - CountBasicEquation(tao, pi))*R;
            return specificEntropy;
        }

        internal static double SpecificIsobaricHeatCapacity(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double isobaricHeatCapacity = (-Math.Pow(tao, 2) * CountDerivative_dGamma_dTao2(tao, pi)) * R;
            return isobaricHeatCapacity;
        }

        internal static double SpecificIsochoricHeatCapacity(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double specificIsochoricHeatCapacity = (-Math.Pow(tao, 2) * CountDerivative_dGamma_dTao2(tao, pi) +
                (Math.Pow(CountDerivative_dGamma_dPi(tao, pi) - tao * CountDerivative_dGamma_dPidTao(tao, pi), 2) / CountDerivative_dGamma_dPi2(tao, pi))) * R;
            return specificIsochoricHeatCapacity;
        }

        internal static double SpeedOfSound(double temperature, double pressure)
        {
            double tao = CountDimensionlessTemperature(temperature);
            double pi = CountDimensionlessPressure(pressure);

            double speedOfSound = Math.Sqrt(
                                                  (
                                                        Math.Pow(CountDerivative_dGamma_dPi(tao, pi), 2) /
                                                        (
                                                            (Math.Pow(CountDerivative_dGamma_dPi(tao, pi) - tao * CountDerivative_dGamma_dPidTao(tao, pi), 2)) /
                                                            (Math.Pow(tao, 2) * CountDerivative_dGamma_dTao2(tao, pi)) - CountDerivative_dGamma_dPi2(tao, pi)
                                                        )
                                                  ) * R * temperature*1000 //dont't know why this must be multiplied by 1000
                                            );
            return speedOfSound;
        }
        #endregion
    }
}
