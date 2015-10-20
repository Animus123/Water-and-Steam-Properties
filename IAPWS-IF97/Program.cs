using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAPWSL;

namespace IAPWS_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Substance s = new Substance(300, 3);
            Console.WriteLine(s.SpecificVolume);
            Console.WriteLine(s.SpecificEnthalpy);
            Console.WriteLine(s.SpecificInternalEnergy);
            Console.WriteLine(s.SpecificEntropy);
            Console.WriteLine(s.SpecificIsobaricHeatCapacity);
            Console.WriteLine(s.SpeedOfSound);
            Console.WriteLine(s.SpecificIsochoricHeatCapacity);
            Console.WriteLine();

            s = new Substance(300, 80);
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
