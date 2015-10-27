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
            SubstanceTemperature = new Temperature(Region1BackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
            CalculateProperties(SubstanceTemperature, SubstancePressure);
        }

        public Substance(Pressure pressure, Entropy entropy)
        {
            SubstancePressure = pressure;
            SubstanceTemperature = new Temperature(Region1BackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
            CalculateProperties(SubstanceTemperature, SubstancePressure);
        }

        public Substance(Pressure pressure) : this(new Temperature(Region4.CalculateSaturationTemperature(pressure.Value)), pressure)
        {
            //
        }

        public Substance(Temperature temperature) : this(temperature, new Pressure(Region4.CalculateSaturationPressure(temperature.Value)))
        {

        }

        #endregion
        //TODO
        private void OnPropertyChanged() { }

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

            }

            //check if it is region 5
            else if (temperature.Value >= 1073.15 && temperature.Value <= 2273.15
                    && pressure.Value > 0 && pressure.Value <= 50)
            {

            }

            else
            {
                throw new NotImplementedException("temperature or pressure value is out of range");
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
    }
}
