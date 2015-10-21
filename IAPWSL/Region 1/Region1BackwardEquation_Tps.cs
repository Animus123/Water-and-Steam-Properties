using System;

namespace IAPWSL
{
    /// <summary>
    /// Backward equation for region 1. This equation takes pressure and entropy as input and returns temperature.
    /// </summary>
    internal static class Region1BackwardEquation_Tps
	{
		#region Numerical values of the coefficients and exponents of the backward equation T(p,s) for region 1
		static int[] I =	{
								0, 0, 0, 0, 0,
								0, 1, 1, 1, 1,
								1, 1, 2, 2, 2,
								2, 2, 3, 3, 4 
							};
		static int[] J =	{
								0, 1, 2, 3, 11,
								31, 0, 1, 2, 3,
								12, 31, 0, 1, 2,
								9, 31, 10, 32, 32
							};
		static double[] n =	{
								0.17478268058307*Math.Pow(10,3),//n1
								0.34806930892873*Math.Pow(10,2),//n2
								0.65292584978455*Math.Pow(10,1),//n3
								0.33039981775489,//n4
								-0.19281382923196*Math.Pow(10,-6),//n5
								-0.24909197244573*Math.Pow(10,-22),//n6
								-0.26107636489332,//n7
								0.22592965981586,//n8
								-0.64256463395226*Math.Pow(10,-1),//n9
								0.78876289270526*Math.Pow(10,-2),//n10
								0.35672110607366*Math.Pow(10,-9),//n11
								0.17332496994895*Math.Pow(10,-23),//n12
								0.56608900654837*Math.Pow(10,-3),//n13
								-0.32635483139717*Math.Pow(10,-3),//n14
								0.44778286690632*Math.Pow(10,-4),//n15
								-0.51322156908507*Math.Pow(10,-9),//n16
								-0.42522657042207*Math.Pow(10,-25),//n17
								0.26400441360689*Math.Pow(10,-12),//n18
								0.78124600459723*Math.Pow(10,-28),//n19
								-0.30732199903668*Math.Pow(10,-30)//n20
							};
        #endregion

        /// <summary>
        /// Backward equation θ(π,σ) for region 1
        /// </summary>
        /// <param name="pi">dimensionless pressure, π</param>
        /// <param name="sigma">dimensionless entropy, σ</param>
        /// <returns>dimensionless temperature, θ</returns>
        private static double CountBackwardEquation(double pi, double sigma)
		{
			double theta=0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Math.Pow(pi, I[i]) * Math.Pow((sigma + 2), J[i]);
            }

            return theta;
		}

        /// <summary>
        /// Method counts dimensionless enthalpy
        /// </summary>
        /// <param name="s">entropy, kJ/(kg*K)</param>
        /// <returns>dimensionless entropy</returns>
        private static double CountDimensionlessEntropy(double s)
        {
            return s / 1;	//1 kJ/(kg*K)
        }

        /// <summary>
        /// Method counts dimensionless pressure
        /// </summary>
        /// <param name="p">pressure, MPa</param>
        /// <returns>dimensionless pressure</returns>
        private static double CountDimensionlessPressure(double p)
        {
            return p / 1;	// 1 MPa
        }

        /// <summary>
        /// Method counts dimensionless temperature
        /// </summary>
        /// <param name="t">temperature, К</param>
        /// <returns>dimensionless temperature</returns>
        private static double CountDimensionlessTemperature(double t)
        {
            return t / 1;	// 1 K
        }

        /// <summary>
        /// Calculates temperature using backward equation for region 1
        /// </summary>
        /// <param name="pressure">pressure, MPa</param>
        /// <param name="entropy">entropy, kJ/(kg*K)</param>
        /// <returns>temperature, K</returns>
        internal static double CalculateTemperature(double pressure, double entropy)
		{
			double pi = CountDimensionlessPressure(pressure);
			double sigma = CountDimensionlessEntropy(entropy);
			
			double temperature = CountBackwardEquation(pi, sigma)*1;	//1 - is 1K temperature
			return temperature;
		}
	}
}