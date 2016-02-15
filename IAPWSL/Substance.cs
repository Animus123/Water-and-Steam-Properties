using System;
using System.Text;
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

        public double SpecificInternalEnergy { get; private set; }
        public Entropy SpecificEntropy { get; private set; }
        public Enthalpy SpecificEnthalpy { get; private set; }
        public double SpecificIsobaricHeatCapacity { get; private set; }
        public double SpecificIsochoricHeatCapacity { get; private set; }
        public double SpeedOfSound { get; private set; }
        public Temperature Temperature { get; private set; }
        public Pressure Pressure { get; private set; }

        /// <summary>
        /// State of aggregate. Need to determine if calculateions concerns Region 4 (Saturation line)
        /// </summary>
        public enum State
        {
            Water,
            Steam
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Get substance properties using temperature and pressure as input
        /// </summary>
        /// <param name="temperatureValue">Temperature in Kelvin</param>
        /// <param name="pressureValue">Pressure in MPa</param>
        public Substance(double temperatureValue, double pressureValue) : this(new Temperature(temperatureValue), new Pressure(pressureValue))
        { }

        public Substance(Temperature temperature, Pressure pressure)
        {
            CalculateProperties(temperature, pressure);
        }

        public Substance(Pressure pressure, Enthalpy enthalpy)
        {
            Pressure = pressure;

            //Checking what region the Substanse belong to:

            //1. check if it is region 1
            try
            {
                Temperature = new Temperature(Region1BackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(Temperature, Pressure);
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
                Temperature = new Temperature(Region2aBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(Temperature, Pressure);
                if (Math.Round(SpecificEnthalpy.Value, 1) == Math.Round(enthalpy.Value, 1))
                {
                    //it is region 2a
                    return;
                }
            }
            else if (Region2B2bcEquation.is2cSubregion(pressure.Value, enthalpy.Value) == false)
            {
                Temperature = new Temperature(Region2bBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(Temperature, Pressure);
                if (Math.Round(SpecificEnthalpy.Value, 1) == Math.Round(enthalpy.Value, 1))
                {
                    //it is region 2b
                    return;
                }
            }
            else if (Region2B2bcEquation.is2cSubregion(pressure.Value, enthalpy.Value))
            {
                Temperature = new Temperature(Region2cBackwardEquation_Tph.CalculateTemperature(pressure.Value, enthalpy.Value));
                CalculateProperties(Temperature, Pressure);
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
            Pressure = pressure;

            //Checking what region the Substanse belong to:

            //1. check if it is region 1
            try
            {
                Temperature = new Temperature(Region1BackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(Temperature, Pressure);
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
                Temperature = new Temperature(Region2aBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value ));
                CalculateProperties(Temperature, Pressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2a
                    return;
                }
            }
            else if (entropy.Value>=5.85)
            {
                Temperature = new Temperature(Region2bBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(Temperature, Pressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2b
                    return;
                }
            }
            else
            {
                Temperature = new Temperature(Region2cBackwardEquation_Tps.CalculateTemperature(pressure.Value, entropy.Value));
                CalculateProperties(Temperature, Pressure);
                if (Math.Round(SpecificEntropy.Value, 3) == Math.Round(entropy.Value, 3))
                {
                    //it is region 2c
                    return;
                }
            }

        }

        /// <summary>
        /// Get saturation line substance properties
        /// </summary>
        public Substance(Pressure pressure, State state)
        {
            Temperature temperature = new Temperature(Region4.CalculateSaturationTemperature(pressure.Value));
            Region4Calculations(temperature, pressure, state);
        }

        /// <summary>
        /// Get saturation line substance properties
        /// </summary>
        public Substance(Temperature temperature, State state)
        {
            Pressure pressure = new Pressure(Region4.CalculateSaturationPressure(temperature.Value));
            Region4Calculations(temperature, pressure, state);
        }

        #endregion

        #region Checking what region substance belongs to
        private static bool IsRegion5(Temperature temperature, Pressure pressure)
        {
            return temperature.Value >= 1073.15 && temperature.Value <= 2273.15
                                && pressure.Value > 0 && pressure.Value <= 50;
        }

        private static bool IsRegion2(Temperature temperature, Pressure pressure)
        {
            return
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
                                    );
        }

        private static bool IsRegion1(Temperature temperature, Pressure pressure)
        {
            return temperature.Value >= 273.15 &&
                            temperature.Value <= 623.15 &&
                            Math.Round(pressure.Value, 9) >= Math.Round(Region4.CalculateSaturationPressure(temperature.Value), 9) &&
                            pressure.Value <= 100;
        }
        #endregion

        #region Methods calculate Substance Properties
        private void CalculateProperties(Temperature temperature, Pressure pressure)
        {
            //check if it is region 1
            if (IsRegion1(temperature, pressure))
            {
                Region1Calculations(temperature, pressure);
            }

            //check if it is region 2
            else if (IsRegion2(temperature, pressure))
            {
                Region2Calculations(temperature, pressure);
            }

            //check if it is region 5
            else if (IsRegion5(temperature, pressure))
            {
                Region5Calculations(temperature, pressure);
            }

            else
            {
                throw new CantDetermineRegionException
                    ("Can not determine what region substance belongs to, temperature or pressure value may be out of range");
            }
        }

        private void Region1Calculations(Temperature temperature, Pressure pressure)
        {
            Temperature = temperature;
            Pressure = pressure;
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
            Temperature = temperature;
            Pressure = pressure;
            SpecificVolume = Region2.CalculateSpecificVolume(temperature.Value, pressure.Value);
            SpecificEnthalpy = new Enthalpy(Region2.CalculateSpecificEnthalpy(temperature.Value, pressure.Value));
            SpecificInternalEnergy = Region2.CalculateSpecificInternalEnergy(temperature.Value, pressure.Value);
            SpecificEntropy = new Entropy(Region2.CalculateSpecificEntropy(temperature.Value, pressure.Value));
            SpecificIsobaricHeatCapacity = Region2.SpecificIsobaricHeatCapacity(temperature.Value, pressure.Value);
            SpeedOfSound = Region2.SpeedOfSound(temperature.Value, pressure.Value);
            SpecificIsochoricHeatCapacity = Region2.SpecificIsochoricHeatCapacity(temperature.Value, pressure.Value);
        }

        private void Region4Calculations(Temperature temperature, Pressure pressure, State state)
        {
            switch (state)
            {
                case State.Water:
                    if (IsRegion1(temperature, pressure))
                    {
                        Region1Calculations(temperature, pressure);
                    }
                    break;
                case State.Steam:
                    if (IsRegion2(temperature, pressure))
                    {
                        Region2Calculations(temperature, pressure);
                    }
                    break;
                default:
                    throw new CantDetermineRegionException
                        ("The pressure value may be out of range. If you do not trying to find saturation line properties, you must not specify the state");
            }
        }

        private void Region5Calculations(Temperature temperature, Pressure pressure)
        {
            Temperature = temperature;
            Pressure = pressure;
            SpecificVolume = Region5.CalculateSpecificVolume(temperature.Value, pressure.Value);
            SpecificEnthalpy = new Enthalpy(Region5.CalculateSpecificEnthalpy(temperature.Value, pressure.Value));
            SpecificInternalEnergy = Region5.CalculateSpecificInternalEnergy(temperature.Value, pressure.Value);
            SpecificEntropy = new Entropy(Region5.CalculateSpecificEntropy(temperature.Value, pressure.Value));
            SpecificIsobaricHeatCapacity = Region5.SpecificIsobaricHeatCapacity(temperature.Value, pressure.Value);
            SpeedOfSound = Region5.SpeedOfSound(temperature.Value, pressure.Value);
            SpecificIsochoricHeatCapacity = Region5.SpecificIsochoricHeatCapacity(temperature.Value, pressure.Value);
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(180);

            sb.AppendLine($"Specific Internal Energy: {SpecificInternalEnergy} kJ/kg");
            sb.AppendLine($"Specific Entropy: {SpecificEntropy?.Value ?? double.NaN} kJ/(kg * K)");
            sb.AppendLine($"Specific Enthalpy: {SpecificEnthalpy?.Value ?? double.NaN} kJ/kg");
            sb.AppendLine($"Specific Isobaric Heat Capacity: {SpecificIsobaricHeatCapacity} kJ/(kg * K)");
            sb.AppendLine($"Specific Isochoric Heat Capacity: {SpecificIsochoricHeatCapacity} kJ/(kg * K)");
            sb.AppendLine($"Speed of Sound: {SpeedOfSound} m/s");
            sb.AppendLine($"Temperature: {Temperature?.Value ?? double.NaN} K");
            sb.AppendLine($"Substance Pressure: {Pressure?.Value ?? double.NaN} MPa");

            return sb.ToString();
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
