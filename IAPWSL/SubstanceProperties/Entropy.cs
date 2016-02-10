using System;

namespace IAPWSL.SubstanceProperties
{
    public class Entropy : AbstractProperty
    {
        public Entropy(double entropy, Measure measure = Measure.kJ_kgK)
        {
            switch (measure)
            {
                case Measure.J_kgK:
                    base.Value = entropy * Math.Pow(10, -3);
                    break;
                case Measure.kJ_kgK:
                    base.Value = entropy;
                    break;
                case Measure.MJ_kgK:
                    base.Value = entropy * Math.Pow(10, 3);
                    break;
                case Measure.cal_kgK:
                    base.Value = entropy *4.1868* Math.Pow(10, -3);
                    break;
                case Measure.kcal_kgK:
                    base.Value = entropy * 4.1868;
                    break;
                default:
                    base.Value = entropy;
                    break;
            }
        }

        public enum Measure
        {
            J_kgK, //J/(kg*K)
            kJ_kgK, //kj/(kg*K)
            MJ_kgK, //MJ/(kg*K)
            cal_kgK, //cal/(kg*K)
            kcal_kgK, //kcal/(kg*K)
        }
    }
}
