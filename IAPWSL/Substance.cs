using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPWSL
{
    public class Substance
    {

        private double? specificVolume;

        public double? SpecificVolume
        {
            get { return specificVolume; }
            set { specificVolume = value; }
        }

        public double SpecificInternalEnergy { get; internal set; }
        public double SpecificEntropy { get; internal set; }
        public double SpecificEnthalpy { get; internal set; }
        public double SpecificIsobaricHeatCapacity { get; internal set; }
        public double SpecificIsochoricHeatCapacity { get; internal set; }
        public double SpeedOfSound { get; internal set; }
        public double Temperature { get; internal set; }
        public double Pressure { get; internal set; }

        public Substance(double temperature, double pressure)
        {
            Temperature = temperature;
            Pressure = pressure;
            SpecificVolume = Region1BasicEquation.CalculateSpecificVolume(Temperature, Pressure);
            SpecificEnthalpy = Region1BasicEquation.CalculateSpecificEnthalpy(Temperature, Pressure);
            SpecificInternalEnergy = Region1BasicEquation.CalculateSpecificInternalEnergy(Temperature, Pressure);
            SpecificEntropy = Region1BasicEquation.CalculateSpecificEntropy(Temperature, Pressure);
            SpecificIsobaricHeatCapacity = Region1BasicEquation.SpecificIsobaricHeatCapacity(Temperature, Pressure);
            SpeedOfSound = Region1BasicEquation.SpeedOfSound(Temperature, Pressure);
            SpecificIsochoricHeatCapacity = Region1BasicEquation.SpecificIsochoricHeatCapacity(Temperature, Pressure);
        }
        
        //Возможно добавлю
        private void OnPropertyChanged() { }

    }
}
