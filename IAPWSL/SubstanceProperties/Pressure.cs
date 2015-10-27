using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL.SubstanceProperties
{
    public class Pressure : AbstractProperty
    {
        public Pressure(double pressure, Measure measure = Measure.MPa)
        {
            switch (measure)
            {
                case Measure.Pa:
                    base.Value = pressure * Math.Pow(10, -6);
                    break;
                case Measure.kPa:
                    base.Value = pressure * Math.Pow(10, -3);
                    break;
                case Measure.MPa:
                    base.Value = pressure;
                    break;
                case Measure.bar:
                    base.Value = pressure / 10;
                    break;
                case Measure.mmH2O:
                    base.Value = pressure * Math.Pow(10, -5);
                    break;
                case Measure.mH2O:
                    base.Value = pressure * Math.Pow(10, -2);
                    break;
                case Measure.mmHg:
                    base.Value = pressure * 133.3 * Math.Pow(10, -6);
                    break;
                case Measure.psf:
                    base.Value = pressure * 4.78 * Math.Pow(10, -5);
                    break;
                case Measure.psi:
                    base.Value = pressure * 6.89476 * Math.Pow(10, -3);
                    break;
                case Measure.inchesHg:
                    base.Value = pressure * 3.377 * Math.Pow(10, -3);
                    break;
                case Measure.inchesH2O:
                    base.Value = pressure * 2.488 * Math.Pow(10, -2);
                    break;
                default:
                    base.Value = pressure;
                    break;
            }
        }

        public enum Measure
        {
            Pa,
            kPa,
            MPa,
            bar,
            mmH2O,
            mH2O,
            mmHg,
            psf, //pound square feet
            psi, //pound square inches
            inchesHg,
            inchesH2O
        }


    }
}