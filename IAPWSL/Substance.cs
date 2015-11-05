using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAPWSL.SubstanceProperties;

namespace IAPWSL
{
    public class Substance
    {
        #region Properties

        private double? specificVolume;

        public double? SpecificVolume
        {
            get { return specificVolume; }
            set { specificVolume = value; }
        }

        public double SpecificInternalEnergy { get; internal set; }
        public Entropy SpecificEntropy { get; private set; }
        public Enthalpy SpecificEnthalpy { get; private set; }
        public double SpecificIsobaricHeatCapacity { get; internal set; }
        public double SpecificIsochoricHeatCapacity { get; internal set; }
        public double SpeedOfSound { get; internal set; }
        public Temperature SubstanceTemperature { get; private set; }
        public Pressure SubstancePressure { get; private set; }

        #endregion

        #region Constructors

        public Substance(double temperatureValue, double pressureValue) : this(new Temperature(temperatureValue), new Pressure(pressureValue))
        { }

        public Substance(Temperature temperature, Pressure pressure)
        {
            CalculateProperties(temperature, pressure);
        }

        public Substance(Pressure pressure, Enthalpy enthalpy)
        {
            SubstancePressure = pressure;

            //Checking what region the Substanse belong to:

            //1. check if it is region 1
            try
            {
                SubstanceTemperature = new Temperature(Region1BackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
            }
            catch (CantDetermineRegionException)
            { }
            if (SpecificEnthalpy!=null && Math.Round(SpecificEnthalpy.Value) == Math.Round(enthalpy.Value))
            {
                //it is region 1
                return;
            }

            //2. check if it is region 2

            if (pressure.Value<=4)
            {
                SubstanceTemperature = new Temperature(Region2aBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEnthalpy.Value, 1) == Math.Round(enthalpy.Value, 1))
                {
                    //it is region 2a
                    return;
                }
            }
            else if (Region2B2bcEquation.is2cSubregion(pressure.Value, enthalpy.Value) == false)
            {
                SubstanceTemperature = new Temperature(Region2bBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEnthalpy.Value, 1) == Math.Round(enthalpy.Value, 1))
                {
                    //it is region 2b
                    return;
                }
            }
            else if (Region2B2bcEquation.is2cSubregion(pressure.Value, enthalpy.Value))
            {
                SubstanceTemperature = new Temperature(Region2cBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEnthalpy.Value, 1) == Math.Round(enthalpy.Value, 1))
                {
                    //it is region 2c
                    return;
                }
            }
            else
            {
                throw new CantDetermineRegionException("It seems no region fits to these values pressure and enthalpy");
            }
        }

        public Substance(Pressure pressure, Entropy entropy)
        {
            SubstancePressure = pressure;

            //Checking what region the Substanse belong to:

            //1. check if it is region 1
            try
            {
                SubstanceTemperature = new Temperature(Region1BackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
            }
            catch (CantDetermineRegionException)
            { }

            if (SpecificEntropy!=null && Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
            {
                //it is region 1
                return;
            }

            //2. check if it is region 2

            if (pressure.Value <= 4)
            {
                SubstanceTemperature = new Temperature(Region2aBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value ));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2a
                    return;
                }
            }
            else if (entropy.Value>=5.85)
            {
                SubstanceTemperature = new Temperature(Region2bBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2b
                    return;
                }
            }
            else
            {
                SubstanceTemperature = new Temperature(Region2cBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(SubstanceTemperature, SubstancePressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2c
                    return;
                }
            }

        }

        public Substance(Pressure pressure) : this(new Temperature(Region4.CalculateSaturationTemperature(pressure.Value)), pressure)
        {
            //
        }

        public Substance(Temperature temperature) : this(temperature, new Pressure(Region4.CalculateSaturationPressure(temperature.Value)))
        {

        }

        #endregion

        private void CalculateProperties(Temperature temperature, Pressure pressure)
        {
            //check if it is region 1
            if (temperature.Value >= 273.15 &&
                temperature.Value <= 623.15 &&
                pressure.Value >= Region4.CalculateSaturationPressure(temperature.Value) &&
                pressure.Value <= 100)
            {
                Region1Calculations(temperature, pressure);
            }

            //check if it is region 2
            else if (
                        (
                            temperature.Value >= 273.15 && temperature.Value <= 623.15 &&
                             pressure.Value > 0 && pressure.Value <= Region4.CalculateSaturationPressure(temperature.Value)
                        )
                        ||
                        (
                            temperature.Value >= 623.15 && temperature.Value <= 863.15 &&
                             pressure.Value > 0 && pressure.Value <= BoundaryRegion2Region3.CalculateBoundaryPressure(temperature.Value)
                        )
                        ||
                        (
                            temperature.Value > 863.15 && temperature.Value <= 1073.15 &&
                            pressure.Value > 0 && pressure.Value <= 100
                        )
                    )
            {
                Region2Calculations(temperature, pressure);
            }

            //check if it is region 5
            else if (temperature.Value >= 1073.15 && temperature.Value <= 2273.15
                    && pressure.Value > 0 && pressure.Value <= 50)
            {

            }

            else
            {
                throw new CantDetermineRegionException
                    ("Can not determine what region substance belongs to, temperature or pressure value may be out of range");
            }
        }

        private void Region1Calculations(Temperature temperature, Pressure pressure)
        {
            SubstanceTemperature = temperature;
            SubstancePressure = pressure;
            SpecificVolume = Region1BasicEquation.CalculateSpecificVolume(temperature.Value, pressure.Value);
            SpecificEnthalpy = new Enthalpy(Region1BasicEquation.CalculateSpecificEnthalpy(temperature.Value, pressure.Value));
            SpecificInternalEnergy = Region1BasicEquation.CalculateSpecificInternalEnergy(temperature.Value, pressure.Value);
            SpecificEntropy = new Entropy(Region1BasicEquation.CalculateSpecificEntropy(temperature.Value, pressure.Value));
            SpecificIsobaricHeatCapacity = Region1BasicEquation.SpecificIsobaricHeatCapacity(temperature.Value, pressure.Value);
            SpeedOfSound = Region1BasicEquation.SpeedOfSound(temperature.Value, pressure.Value);
            SpecificIsochoricHeatCapacity = Region1BasicEquation.SpecificIsochoricHeatCapacity(temperature.Value, pressure.Value);
        }

        private void Region2Calculations(Temperature temperature, Pressure pressure)
        {
            SubstanceTemperature = temperature;
            SubstancePressure = pressure;
            SpecificVolume = Region2.CalculateSpecificVolume(temperature.Value, pressure.Value);
            SpecificEnthalpy = new Enthalpy(Region2.CalculateSpecificEnthalpy(temperature.Value, pressure.Value));
            SpecificInternalEnergy = Region2.CalculateSpecificInternalEnergy(temperature.Value, pressure.Value);
            SpecificEntropy = new Entropy(Region2.CalculateSpecificEntropy(temperature.Value, pressure.Value));
            SpecificIsobaricHeatCapacity = Region2.SpecificIsobaricHeatCapacity(temperature.Value, pressure.Value);
            SpeedOfSound = Region2.SpeedOfSound(temperature.Value, pressure.Value);
            SpecificIsochoricHeatCapacity = Region2.SpecificIsochoricHeatCapacity(temperature.Value, pressure.Value);
        }


        [Serializable]
        public class CantDetermineRegionException : Exception
        {
            public CantDetermineRegionException() { }
            public CantDetermineRegionException(string message) : base(message) { }
            public CantDetermineRegionException(string message, Exception inner) : base(message, inner) { }
            protected CantDetermineRegionException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context)
            { }
        }
    }
}
