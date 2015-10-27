using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL.SubstanceProperties
{
    public class Enthalpy : AbstractProperty
    {
        public Enthalpy(double enthalpy, Measure measure = Measure.kJ_kg)
        {
            switch (measure)
            {
                case Measure.J_kg:
                    base.Value = enthalpy * Math.Pow(10, -3);
                    break;
                case Measure.kJ_kg:
                    base.Value = enthalpy;
                    break;
                case Measure.MJ_kg:
                    base.Value = enthalpy * Math.Pow(10, 3);
                    break;
                case Measure.cal_kg:
                    base.Value = enthalpy * 4.1868 * Math.Pow(10, -3);
                    break;
                case Measure.kcal_kg:
                    base.Value = enthalpy * 4.1868;
                    break;
                default:
                    base.Value = enthalpy;
                    break;
            }
        }

        public enum Measure
        {
            J_kg,   // J/kg
            kJ_kg,  // kJ/kg
            MJ_kg,  // MJ/kg
            cal_kg, // cal/kg
            kcal_kg // kcal/kg
        }
    }
}
