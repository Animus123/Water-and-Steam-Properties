using System;

namespace IAPWSL
{
	public static class Region1BackwardEquation_Tph
	{
		#region Numerical values of the coefficients and exponents of the backward equation T(p,h) for region 1
		static int[] I =	{
								0, 0, 0, 0, 0,
								0, 1, 1, 1, 1,
								1, 1, 1, 2, 2,
								3, 3, 4, 5, 6
							};
		static int[] J =	{
								0, 1, 2, 6, 22,
								32, 0, 1, 2, 3,
								4, 10, 32, 10, 32,
								10, 32, 32, 32, 32
							};
		static double[] n =	{
								-0.23872489924521*Math.Pow(10,3),//n1
								0.40421188637945*Math.Pow(10,3),//n2
								0.11349746881718*Math.Pow(10,3),//n3
								-0.58457616048039*Math.Pow(10,1),//n4
								-0.15285482413140*Math.Pow(10,-3),//n5
								-0.10866707695377*Math.Pow(10,-5),//n6
								-0.13391744872602*Math.Pow(10,2),//n7
								0.43211039183559*Math.Pow(10,2),//n8
								-0.54010067170506*Math.Pow(10,2),//n9
								0.30535892203916*Math.Pow(10,2),//n10
								-0.65964749423638*Math.Pow(10,1),//n11
								0.93965400878363*Math.Pow(10,-2),//n12
								0.11573647505340*Math.Pow(10,-6),//n13
								-0.25858641282073*Math.Pow(10,-4),//n14
								-0.40644363084799*Math.Pow(10,-8),//n15
								0.66456186191635*Math.Pow(10,-7),//n16
								0.80670734103027*Math.Pow(10,-10),//n17
								-0.93477771213947*Math.Pow(10,-12),//n18
								0.58265442020601*Math.Pow(10,-14),//n19
								-0.15020185953503*Math.Pow(10,-16)//n20
							};
        #endregion

        /// <summary>
        /// Backward equation θ(π,η) for region 1
        /// </summary>
        /// <param name="pi">dimensionless pressure, π</param>
        /// <param name="eta">dimensionless enthalpy, η</param>
        /// <returns>dimensionless temperature, θ</returns>
        private static double CountBackwardEquation(double pi, double eta)
		{
			double theta=0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Math.Pow(pi, I[i]) * Math.Pow((eta+1), J[i]);
            }

            return theta;
		}
		
        /// <summary>
        /// Method counts dimensionless enthalpy
        /// </summary>
        /// <param name="h">enthalpy, kJ/kg</param>
        /// <returns>dimnsionless enthalpy</returns>
		private static double CountDimensionlessEnthalpy(double h)
        {
            return h / 2500;	//2500 kJ/kg
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
        /// <param name="enthalpy">enthalpy, kJ/kg</param>
        /// <returns>temperature, K</returns>
        internal static double CalculateTemperature(double pressure, double enthalpy)
		{
			double pi = CountDimensionlessPressure(pressure);
			double eta = CountDimensionlessEnthalpy(enthalpy);
			
			double temperature = CountBackwardEquation(pi, eta)*1;	//1 - is 1K temperature
			return temperature;
		}
		
	}
}