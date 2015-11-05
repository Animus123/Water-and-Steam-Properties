using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAPWSL;
using IAPWSL.SubstanceProperties;
using Moq;

namespace IAPWS_Tests
{
    /*
    Test carrys out for 3 different substances.
    It checks property values of substances.
    */
    [TestClass]
    public class Region1Tests
    {
        [TestMethod]
        public void Region1_Test()
        {
            //Arrange
            double temperature1 = 300; //K
            double pressure1 = 3; //MPa

            double temperature2 = 300; //K
            double pressure2 = 80; //MPa

            double temperature3 = 500; //K
            double pressure3 = 3; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(temperature1, pressure1);
            substance2 = new Substance(temperature2, pressure2);
            substance3 = new Substance(temperature3, pressure3);
            //Assert
            Assert.AreEqual(0.100215168 * Math.Pow(10, -2), (double)substance1.SpecificVolume, 0.0000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(0.115331273 * Math.Pow(10, 3), (double)substance1.SpecificEnthalpy.Value, 0.0001,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.112324818 * Math.Pow(10, 3), (double)substance1.SpecificInternalEnergy, 0.0001,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(0.392294792, (double)substance1.SpecificEntropy.Value, 0.0000001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.417301218 * Math.Pow(10, 1), (double)substance1.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.150773921 * Math.Pow(10, 4), (double)substance1.SpeedOfSound, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(4.121, (double)substance1.SpecificIsochoricHeatCapacity, 0.01,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.971180894 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.0000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(0.184142828 * Math.Pow(10, 3), (double)substance2.SpecificEnthalpy.Value, 0.0001,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.106448356 * Math.Pow(10, 3), (double)substance2.SpecificInternalEnergy, 0.0001,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(0.368563852, (double)substance2.SpecificEntropy.Value, 0.0000001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.401008987 * Math.Pow(10, 1), (double)substance2.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.163469054 * Math.Pow(10, 4), (double)substance2.SpeedOfSound, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.917, (double)substance2.SpecificIsochoricHeatCapacity, 0.01,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.120241800 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.0000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(0.975542239 * Math.Pow(10, 3), (double)substance3.SpecificEnthalpy.Value, 0.0001,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.971934985 * Math.Pow(10, 3), (double)substance3.SpecificInternalEnergy, 0.0001,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(0.258041912 * Math.Pow(10, 1), (double)substance3.SpecificEntropy.Value, 0.0000001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.465580682 * Math.Pow(10, 1), (double)substance3.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.124071337 * Math.Pow(10, 4), (double)substance3.SpeedOfSound, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.221, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region1BackwardEquation_Tph_Test()
        {
            //Arrange
            double enthalpy1 = 500; //kJ/kg
            double pressure1 = 3; //MPa

            double enthalpy2 = 500; //kJ/kg
            double pressure2 = 80; //MPa

            double enthalpy3 = 1500; //kJ/kg
            double pressure3 = 80; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Enthalpy(enthalpy1));
            substance2 = new Substance(new Pressure(pressure2), new Enthalpy(enthalpy2));
            substance3 = new Substance(new Pressure(pressure3), new Enthalpy(enthalpy3));

            //Assert
            Assert.AreEqual(0.391798509 * Math.Pow(10, 3), (double)substance1.SubstanceTemperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(1.058 * Math.Pow(10, -3), (double)substance1.SpecificVolume, 0.000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(500, (double)substance1.SpecificEnthalpy.Value, 0.1,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(496.8, (double)substance1.SpecificInternalEnergy, 0.1,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(1.511, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.237, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1529, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(3.671, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.378108626 * Math.Pow(10, 3), (double)substance2.SubstanceTemperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(1.011 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(500, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(419.1, (double)substance2.SpecificInternalEnergy, 0.1,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(1.304, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.072, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1697, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.640, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.611041229 * Math.Pow(10, 3), (double)substance3.SubstanceTemperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(1.322 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(1500, (double)substance3.SpecificEnthalpy.Value, 0.1,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(1394, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(3.353, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.731, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1187, (double)substance3.SpeedOfSound, 0.5,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(2.915, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region1BackwardEquation_Tps_Test()
        {
            //Arrange
            double entropy1 = 0.5; //kJ/(kg*K)
            double pressure1 = 3; //MPa

            double entropy2 = 0.5; //kJ/(kg*K)
            double pressure2 = 80; //MPa

            double entropy3 = 3; //kJ/(kg*K)
            double pressure3 = 80; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Entropy(entropy1));
            substance2 = new Substance(new Pressure(pressure2), new Entropy(entropy2));
            substance3 = new Substance(new Pressure(pressure3), new Entropy(entropy3));

            //Assert
            Assert.AreEqual(0.307842258 * Math.Pow(10, 3), (double)substance1.SubstanceTemperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(1.005 * Math.Pow(10, -3), (double)substance1.SpecificVolume, 0.000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(148.1, (double)substance1.SpecificEnthalpy.Value, 0.1,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(145, (double)substance1.SpecificInternalEnergy, 0.1,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(0.5, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.172, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1526, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(4.088, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.309979785 * Math.Pow(10, 3), (double)substance2.SubstanceTemperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(9.748 * Math.Pow(10, -4), (double)substance2.SpecificVolume, 0.000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(224.2, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(146.2, (double)substance2.SpecificInternalEnergy, 0.1,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(0.5, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.021, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1657, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.893, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.565899909 * Math.Pow(10, 3), (double)substance3.SubstanceTemperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(1.226 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(1292, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(1194, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(3, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.484, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1325, (double)substance3.SpeedOfSound, 0.5,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.013, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

    }
}
