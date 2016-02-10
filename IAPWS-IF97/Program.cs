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

            s = new Substance(new Pressure(0.001), new Enthalpy(3000));
            Console.WriteLine(s.ToString());
            
            s = new Substance(1500, 0.5);
            Console.WriteLine(s.ToString());

            Console.Read();
        }
    }
}
