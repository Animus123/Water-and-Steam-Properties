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
    public class Region2Tests
    {
        [TestMethod]
        public void Region2_Test()
        {
            //Arrange
            double temperature1 = 300; //K
            double pressure1 = 0.0035; //MPa

            double temperature2 = 700; //K
            double pressure2 = 0.0035; //MPa

            double temperature3 = 700; //K
            double pressure3 = 30; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(temperature1, pressure1);
            substance2 = new Substance(temperature2, pressure2);
            substance3 = new Substance(temperature3, pressure3);
            //Assert
            Assert.AreEqual(0.394913866 * Math.Pow(10, 2), (double)substance1.SpecificVolume, 0.0000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(0.254991145 * Math.Pow(10, 4), (double)substance1.SpecificEnthalpy.Value, 0.0001,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.241169160 * Math.Pow(10, 4), (double)substance1.SpecificInternalEnergy, 0.0001,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(8.52238967, (double)substance1.SpecificEntropy.Value, 0.0000001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.191300162 * Math.Pow(10, 1), (double)substance1.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.427920172 * Math.Pow(10, 3), (double)substance1.SpeedOfSound, 0.001,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(1.441, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.923015898 * Math.Pow(10, 2), (double)substance2.SpecificVolume, 0.0000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(0.333568375 * Math.Pow(10, 4), (double)substance2.SpecificEnthalpy.Value, 0.0001,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.301262819 * Math.Pow(10, 4), (double)substance2.SpecificInternalEnergy, 0.0001,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(0.101749996 * Math.Pow(10, 2), (double)substance2.SpecificEntropy.Value, 0.0000001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.208141274 * Math.Pow(10, 1), (double)substance2.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.644289068 * Math.Pow(10, 3), (double)substance2.SpeedOfSound, 0.001,
                "Substance2: Substance has wrong specific speed of sound");
            Assert.AreEqual(1.620, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.542946619 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.0000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(0.263149474 * Math.Pow(10, 4), (double)substance3.SpecificEnthalpy.Value, 0.0001,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.246861076 * Math.Pow(10, 4), (double)substance3.SpecificInternalEnergy, 0.0001,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(0.517540298 * Math.Pow(10, 1), (double)substance3.SpecificEntropy.Value, 0.0000001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.103505092 * Math.Pow(10, 2), (double)substance3.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.480386523 * Math.Pow(10, 3), (double)substance3.SpeedOfSound, 0.001,
                "Substance3: Substance has wrong specific speed of sound");
            Assert.AreEqual(2.976, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2aBackwardEquation_Tph_Test()
        {
            //Arrange
            double enthalpy1 = 3000; //kJ/kg
            double pressure1 = 0.001; //MPa

            double enthalpy2 = 3000; //kJ/kg
            double pressure2 = 3; //MPa

            double enthalpy3 = 4000; //kJ/kg
            double pressure3 = 3; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Enthalpy(enthalpy1));
            substance2 = new Substance(new Pressure(pressure2), new Enthalpy(enthalpy2));
            substance3 = new Substance(new Pressure(pressure3), new Enthalpy(enthalpy3));

            //Assert
            Assert.AreEqual(0.534433241 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(246.6, (double)substance1.SpecificVolume, 0.1,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(3000, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2753, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(10.21, (double)substance1.SpecificEntropy.Value, 0.01,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(1.976, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(567.3, (double)substance1.SpeedOfSound, 0.1,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(1.514, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.575373370 * Math.Pow(10, 3), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(8.161 * Math.Pow(10, -2), (double)substance2.SpecificVolume, 0.0001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(3000, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(2755, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(6.551, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.53, (double)substance2.SpecificIsobaricHeatCapacity, 0.01,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(562, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1.794, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.101077577 * Math.Pow(10, 4), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(0.1544, (double)substance3.SpecificVolume, 0.0001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(4000, (double)substance3.SpecificEnthalpy.Value, 0.1,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(3537, (double)substance3.SpecificInternalEnergy, 0.1,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(7.847, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.34, (double)substance3.SpecificIsobaricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(761.9, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1.853, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2bBackwardEquation_Tph_Test()
        {
            //Arrange
            double enthalpy1 = 3500; //kJ/kg
            double pressure1 = 5; //MPa

            double enthalpy2 = 4000; //kJ/kg
            double pressure2 = 5; //MPa

            double enthalpy3 = 3500; //kJ/kg
            double pressure3 = 25; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Enthalpy(enthalpy1));
            substance2 = new Substance(new Pressure(pressure2), new Enthalpy(enthalpy2));
            substance3 = new Substance(new Pressure(pressure3), new Enthalpy(enthalpy3));

            //Assert
            Assert.AreEqual(0.801299102 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(7.147 * Math.Pow(10, -2), (double)substance1.SpecificVolume, 0.001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(3500, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(3143, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(7.061, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.324, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(674.9, (double)substance1.SpeedOfSound, 0.1,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(1.761, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.101531583 * Math.Pow(10, 4), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(9.259 * Math.Pow(10, -2), (double)substance2.SpecificVolume, 0.0001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(4000, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(3537, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(7.614, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.37, (double)substance2.SpecificIsobaricHeatCapacity, 0.01,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(762.1, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong speed of sound");
            Assert.AreEqual(1.866, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.875279054 * Math.Pow(10, 3), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(1.42 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.01,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(3500, (double)substance3.SpecificEnthalpy.Value, 0.1,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(3145, (double)substance3.SpecificInternalEnergy, 0.1,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(6.371, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.96, (double)substance3.SpecificIsobaricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(678.3, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong speed of sound");
            Assert.AreEqual(1.999, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2cBackwardEquation_Tph_Test()
        {
            //Arrange
            double enthalpy1 = 2700; //kJ/kg
            double pressure1 = 40; //MPa

            double enthalpy2 = 2700; //kJ/kg
            double pressure2 = 60; //MPa

            double enthalpy3 = 3200; //kJ/kg
            double pressure3 = 60; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Enthalpy(enthalpy1));
            substance2 = new Substance(new Pressure(pressure2), new Enthalpy(enthalpy2));
            substance3 = new Substance(new Pressure(pressure3), new Enthalpy(enthalpy3));

            //Assert
            Assert.AreEqual(0.743056411 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(4.564 * Math.Pow(10, -3), (double)substance1.SpecificVolume, 0.001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(2700, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2517, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(5.202, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(8.157, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(528.8, (double)substance1.SpeedOfSound, 0.1,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(2.757, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.791137067 * Math.Pow(10, 3), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(3.319 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(2700, (double)substance2.SpecificEnthalpy.Value, 0.5,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(2501, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(5.101, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(6.862, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(607.8, (double)substance2.SpeedOfSound, 0.1,
                "Substance2: Substance has wrong speed of sound");
            Assert.AreEqual(2.635, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.882756860 * Math.Pow(10, 3), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(4.987 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(3200, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(2901, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(5.702, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.397, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(670.4, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong speed of sound");
            Assert.AreEqual(2.313, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2aBackwardEquation_Tps_Test()
        {
            //Arrange
            double entropy1 = 7.5; //kJ/kg
            double pressure1 = 0.1; //MPa

            double entropy2 = 8; //kJ/kg
            double pressure2 = 0.1; //MPa

            double entropy3 = 8; //kJ/kg
            double pressure3 = 2.5; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Entropy(entropy1));
            substance2 = new Substance(new Pressure(pressure2), new Entropy(entropy2));
            substance3 = new Substance(new Pressure(pressure3), new Entropy(entropy3));

            //Assert
            Assert.AreEqual(0.399517097 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(1.824, (double)substance1.SpecificVolume, 0.001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(2729, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2547, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(7.5, (double)substance1.SpecificEntropy.Value, 0.1,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.009, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(490, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(1.509, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.514127081 * Math.Pow(10, 3), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(2.364, (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(2957, (double)substance2.SpecificEnthalpy.Value, 0.5,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(2720, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(8, (double)substance2.SpecificEntropy.Value, 0.01,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(1.986, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(555.8, (double)substance2.SpeedOfSound, 0.1,
                "Substance2: Substance has wrong speed of sound");
            Assert.AreEqual(1.514, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.103984917 * Math.Pow(10, 4), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(0.1909, (double)substance3.SpecificVolume, 0.0001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(4071, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(3593, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(8, (double)substance3.SpecificEntropy.Value, 0.01,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.35, (double)substance3.SpecificIsobaricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(772.6, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong speed of sound");
            Assert.AreEqual(1.869, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2bBackwardEquation_Tps_Test()
        {
            //Arrange
            double entropy1 = 6; //kJ/kg
            double pressure1 = 8; //MPa

            double entropy2 = 7.5; //kJ/kg
            double pressure2 = 8; //MPa

            double entropy3 = 6; //kJ/kg
            double pressure3 = 90; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Entropy(entropy1));
            substance2 = new Substance(new Pressure(pressure2), new Entropy(entropy2));
            substance3 = new Substance(new Pressure(pressure3), new Entropy(entropy3));

            //Assert
            Assert.AreEqual(0.600484040 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(2.767 * Math.Pow(10, -2), (double)substance1.SpecificVolume, 0.001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(2907, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2686, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(6, (double)substance1.SpecificEntropy.Value, 0.1,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(3.84, (double)substance1.SpecificIsobaricHeatCapacity, 0.01,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(530.7, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(2.276, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.106495556 * Math.Pow(10, 4), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(6.05 * Math.Pow(10, -2), (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(4104, (double)substance2.SpecificEnthalpy.Value, 0.5,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(3620, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(7.5, (double)substance2.SpecificEntropy.Value, 0.01,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(2.429, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(778.9, (double)substance2.SpeedOfSound, 0.1,
                "Substance2: Substance has wrong speed of sound");
            Assert.AreEqual(1.909, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.103801126 * Math.Pow(10, 4), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(4.544 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.0001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(3628, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(3219, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(6, (double)substance3.SpecificEntropy.Value, 0.01,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(3.633, (double)substance3.SpecificIsobaricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(793.2, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong speed of sound");
            Assert.AreEqual(2.229, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region2cBackwardEquation_Tps_Test()
        {
            //Arrange
            double entropy1 = 5.75; //kJ/kg
            double pressure1 = 20; //MPa

            double entropy2 = 5.25; //kJ/kg
            double pressure2 = 80; //MPa

            double entropy3 = 5.75; //kJ/kg
            double pressure3 = 80; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(new Pressure(pressure1), new Entropy(entropy1));
            substance2 = new Substance(new Pressure(pressure2), new Entropy(entropy2));
            substance3 = new Substance(new Pressure(pressure3), new Entropy(entropy3));

            //Assert
            Assert.AreEqual(0.697992849 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.0001,
                "Substance1: Substance has wrong temperature");
            Assert.AreEqual(1.147 * Math.Pow(10, -2), (double)substance1.SpecificVolume, 0.001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(2952, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2723, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(5.75, (double)substance1.SpecificEntropy.Value, 0.01,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.769, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(545.2, (double)substance1.SpeedOfSound, 0.1,
                "Substance1: Substance has wrong speed of sound");
            Assert.AreEqual(2.417, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.854011484 * Math.Pow(10, 3), (double)substance2.Temperature.Value, 0.0001,
                "Substance2: Substance has wrong temperature");
            Assert.AreEqual(3.146 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(2887, (double)substance2.SpecificEnthalpy.Value, 0.5,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(2635, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(5.25, (double)substance2.SpecificEntropy.Value, 0.01,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(5.456, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(695, (double)substance2.SpeedOfSound, 0.1,
                "Substance2: Substance has wrong speed of sound");
            Assert.AreEqual(2.488, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.949017998 * Math.Pow(10, 3), (double)substance3.Temperature.Value, 0.0001,
                "Substance3: Substance has wrong temperature");
            Assert.AreEqual(4.261 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.0001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(3336, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(2995, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(5.75, (double)substance3.SpecificEntropy.Value, 0.01,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.129, (double)substance3.SpecificIsobaricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(735, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong speed of sound");
            Assert.AreEqual(2.297, (double)substance3.SpecificIsochoricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }
    }
}
