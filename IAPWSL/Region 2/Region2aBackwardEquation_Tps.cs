using static System.Math;

namespace IAPWSL
{
    internal static class Region2aBackwardEquation_Tps
    {
        #region Numerical values of the coefficients and exponents of the backward equation T(p,s) for subregion 2a
        static double[] I =   {
                                    -1.5, -1.5, -1.5, -1.5, -1.5,
                                    -1.5, -1.25, -1.25, -1.25, -1.0,
                                    -1.0, -1.0, -1.0, -1.0, -1.0,
                                    -0.75, -0.75, -0.5, -0.5, -0.5,
                                    -0.5, -0.25, -0.25, -0.25, -0.25,
                                    0.25, 0.25, 0.25, 0.25, 0.5,
                                    0.5, 0.5, 0.5, 0.5, 0.5,
                                    0.5, 0.75, 0.75, 0.75, 0.75,
                                    1.0, 1.0, 1.25, 1.25, 1.5,
                                    1.5 
                              };

        static int[] J =   {
                                -24, -23, -19, -13, -11,
                                -10, -19, -15, -6, -26,
                                -21, -17, -16, -9, -8,
                                -15, -14, -26, -13, -9,
                                -7, -27, -25, -11, -6,
                                1, 4, 8, 11, 0,
                                1, 5, 6, 10, 14,
                                16, 0, 4, 9, 17,
                                7, 18, 3, 15, 5,
                                18
                           };
        static double[] n =
                            {
                                -0.39235983861984 * Pow(10, 6),//n1
                                0.51526573827270 * Pow(10, 6),//n2
                                0.40482443161048 * Pow(10, 5),//n3
                                -0.32193790923902 * Pow(10, 3),//n4
                                0.96961424218694 * Pow(10, 2),//n5
                                -0.22867846371773 * Pow(10, 2),//n6
                                -0.44942914124357 * Pow(10, 6),//n7
                                -0.50118336020166 * Pow(10, 4),//n8
                                0.35684463560015,//n9
                                0.44235335848190 * Pow(10, 5),//n10
                                -0.13673388811708 * Pow(10, 5),//n11
                                0.42163260207864 * Pow(10, 6),//n12
                                0.22516925837475 * Pow(10, 5),//n13
                                0.47442144865646 * Pow(10, 3),//n14
                                -0.14931130797647 * Pow(10, 3),//n15
                                -0.19781126320452 * Pow(10, 6),//n16
                                -0.23554399470760 * Pow(10, 5),//n17
                                -0.19070616302076 * Pow(10, 5),//n18
                                0.55375669883164 * Pow(10, 5),//n19
                                0.38293691437363 * Pow(10, 4),//n20
                                -0.60391860580567 * Pow(10, 3),//n21
                                0.19363102620331 * Pow(10, 4),//n22
                                0.42660643698610 * Pow(10, 4),//n23
                                -0.59780638872718 * Pow(10, 4),//n24
                                -0.70401463926862 * Pow(10, 3),//n25
                                0.33836784107553 * Pow(10, 3),//n26
                                0.20862786635187 * Pow(10, 2),//n27
                                0.33834172656196 * Pow(10, -1),//n28
                                -0.43124428414893 * Pow(10, -4),//n29
                                0.16653791356412 * Pow(10, 3),//n30
                                -0.13986292055898 * Pow(10, 3),//n31
                                -0.78849547999872,//n32
                                0.72132411753872 * Pow(10, -1),//n33
                                -0.59754839398283 * Pow(10, -2),//n34
                                -0.12141358953904 * Pow(10, -4),//n35
                                0.23227096733871 * Pow(10, -6),//n36
                                -0.10538463566194 * Pow(10, 2),//n37
                                0.20718925496502 * Pow(10, 1),//n38
                                -0.72193155260427 * Pow(10, -1),//n39
                                0.20749887081120 * Pow(10, -6),//n40
                                -0.18340657911379 * Pow(10, -1),//n41
                                0.29036272348696 * Pow(10, -6),//n42
                                0.21037527893619,//n43
                                0.25681239729999 * Pow(10, -3),//n44
                                -0.12799002933781 * Pow(10, -1),//n45
                                -0.82198102652018 * Pow(10, -5)//n46
                            };
        #endregion

        private static double CountBackwardEquation(double pi, double sigma)
        {
            double theta = 0;

            for (int i = 0; i < n.Length; i++)
            {
                theta += n[i] * Pow(pi, I[i]) * Pow((sigma - 2), J[i]);
            }

            return theta;
        }

        #region Methods for converting value to dimensionless

        private static double CountDimensionlessEntropy(double s)
        {
            return s / 2;	//2 kJ/(kg*K)
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
            double sigma = CountDimensionlessEntropy(entropy);
            double pi = CountDimensionlessPressure(pressure);

            double temperature = CountBackwardEquation(pi, sigma) * 1; //1 K
            return temperature;
        }
    }
}
