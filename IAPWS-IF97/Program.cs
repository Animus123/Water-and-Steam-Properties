using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAPWSL;
using IAPWSL.SubstanceProperties;

namespace IAPWS_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Substance s = new Substance(new Pressure(5), new Enthalpy(3500));
            Console.WriteLine(s.SpecificVolume);
            Console.WriteLine(s.SpecificEnthalpy);
            Console.WriteLine(s.SpecificInternalEnergy);
            Console.WriteLine(s.SpecificEntropy);
            Console.WriteLine(s.SpecificIsobaricHeatCapacity);
            Console.WriteLine(s.SpeedOfSound);
            Console.WriteLine(s.SpecificIsochoricHeatCapacity);
            Console.WriteLine();

            s = new Substance(new IAPWSL.SubstanceProperties.Pressure(0.001), new IAPWSL.SubstanceProperties.Enthalpy(3000));
            Console.WriteLine(s.SpecificVolume);
            Console.WriteLine(s.SpecificEnthalpy);
            Console.WriteLine(s.SpecificInternalEnergy);
            Console.WriteLine(s.SpecificEntropy);
            Console.WriteLine(s.SpecificIsobaricHeatCapacity);
            Console.WriteLine(s.SpeedOfSound);
            Console.WriteLine(s.SpecificIsochoricHeatCapacity);
            Console.WriteLine();

            s = new Substance(500, 3);
            Console.WriteLine(s.SpecificVolume);
            Console.WriteLine(s.SpecificEnthalpy);
            Console.WriteLine(s.SpecificInternalEnergy);
            Console.WriteLine(s.SpecificEntropy);
            Console.WriteLine(s.SpecificIsobaricHeatCapacity);
            Console.WriteLine(s.SpeedOfSound);
            Console.WriteLine(s.SpecificIsochoricHeatCapacity);
            Console.WriteLine();

            Console.Read();
        }
    }
}
