using System;
using IAPWSL;
using IAPWSL.SubstanceProperties;

namespace IAPWS_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Substance s = new Substance(new Pressure(5), new Enthalpy(3500));
            Console.WriteLine(s.ToString());

            s = new Substance(new Pressure(2), new Entropy(6));
            Console.WriteLine(s.ToString());

            s = new Substance(new Pressure(2, Pressure.Measure.MPa),
                new Entropy(6, Entropy.Measure.kJ_kgK));
            Console.WriteLine(s.ToString());

            s = new Substance(1500, 0.5);
            Console.WriteLine(s.ToString());

            s = new Substance(new Temperature(150, Temperature.Measure.Celsius), Substance.State.Steam);
            Console.WriteLine(s.ToString());

            s = new Substance(new Pressure(20, Pressure.Measure.bar), Substance.State.Water);
            Console.WriteLine(s.ToString());

            Console.Read();
        }
    }
}
