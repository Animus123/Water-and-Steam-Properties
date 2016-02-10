using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAPWSL;
using IAPWSL.SubstanceProperties;
using System;

namespace IAPWS_Tests
{
    [TestClass]
    public class Region4Tests
    {
        [TestMethod]
        public void Region4_Test_LiquidState()
        {
            //Arrange
            double temperature1 = 300; //K
            double temperature2 = 500; //K
            double temperature3 = 600; //K

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(new Temperature(temperature1), Substance.State.Water);
            substance2 = new Substance(new Temperature(temperature2), Substance.State.Water);
            substance3 = new Substance(new Temperature(temperature3), Substance.State.Water);
            //Assert
            Assert.AreEqual(0.353658941 * Math.Pow(10, -2), (double)substance1.Pressure.Value, 0.0000001,
               "Substance1: Substance has wrong pressure");
            Assert.AreEqual(1.003 * Math.Pow(10, -3), (double)substance1.SpecificVolume, 0.001,
               "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(112.6, (double)substance1.SpecificEnthalpy.Value, 0.1,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(112.6, (double)substance1.SpecificInternalEnergy, 0.1,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(0.3931, (double)substance1.SpecificEntropy.Value, 0.0001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.181, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1503, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(4.131, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");
            
            Assert.AreEqual(0.263889776 * Math.Pow(10, 1), (double)substance2.Pressure.Value, 0.0000001,
               "Substance2: Substance has wrong pressure");
            Assert.AreEqual(1.203 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(975.5, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(972.3, (double)substance2.SpecificInternalEnergy, 0.1,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(2.581, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.659, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1239, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.222, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.123443146 * Math.Pow(10, 2), (double)substance3.Pressure.Value, 0.0000001,
               "Substance1: Substance has wrong pressure");
            Assert.AreEqual(1.54 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.01,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(1505, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(1486, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(3.519, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(6.956, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(751.6, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.045, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region4_Test_Steam()
        {
            //Arrange
            double temperature1 = 300; //K
            double temperature2 = 500; //K
            double temperature3 = 600; //K

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(new Temperature(temperature1), Substance.State.Steam);
            substance2 = new Substance(new Temperature(temperature2), Substance.State.Steam);
            substance3 = new Substance(new Temperature(temperature3), Substance.State.Steam);
            //Assert
            Assert.AreEqual(0.353658941 * Math.Pow(10, -2), (double)substance1.Pressure.Value, 0.0000001,
               "Substance1: Substance has wrong pressure");
            Assert.AreEqual(39.08, (double)substance1.SpecificVolume, 0.01,
               "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(2550, (double)substance1.SpecificEnthalpy.Value, 0.5,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(2412, (double)substance1.SpecificInternalEnergy, 0.5,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(8.518, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(1.914, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(427.9, (double)substance1.SpeedOfSound, 0.1,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(1.442, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.263889776 * Math.Pow(10, 1), (double)substance2.Pressure.Value, 0.0000001,
               "Substance1: Substance has wrong pressure");
            Assert.AreEqual(7.577 * Math.Pow(10, -2), (double)substance2.SpecificVolume, 0.001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(2803, (double)substance2.SpecificEnthalpy.Value, 0.5,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(2603, (double)substance2.SpecificInternalEnergy, 0.5,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(6.235, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(3.463, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(504.6, (double)substance2.SpeedOfSound, 0.1,
                "Substance2: Substance has wrong specific speed of sound");
            Assert.AreEqual(2.271, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.123443146 * Math.Pow(10, 2), (double)substance3.Pressure.Value, 0.0000001,
               "Substance1: Substance has wrong pressure");
            Assert.AreEqual(1.373 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.01,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(2678, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(2508, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(5.473, (double)substance3.SpecificEntropy.Value, 0.001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(9.169, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(457.1, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.331, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region4BackwardEquateion_Test_LiquidState()
        {
            //Arrange
            double pressure1 = 0.1; //MPa
            double pressure2 = 1; //MPa
            double pressure3 = 10; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(new Pressure(pressure1), Substance.State.Water);
            substance2 = new Substance(new Pressure(pressure2), Substance.State.Water);
            substance3 = new Substance(new Pressure(pressure3), Substance.State.Water);

            //Assert
            Assert.AreEqual(0.372755919 * Math.Pow(10, 3), (double)substance1.Temperature.Value, 0.000001,
               "Substance1: Substance has wrong temperature");
            Assert.AreEqual(1.043 * Math.Pow(10, -3), (double)substance1.SpecificVolume, 0.00001,
               "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(417.4, (double)substance1.SpecificEnthalpy.Value, 0.1,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(417.3, (double)substance1.SpecificInternalEnergy, 0.1,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(1.303, (double)substance1.SpecificEntropy.Value, 0.001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.216, (double)substance1.SpecificIsobaricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1545, (double)substance1.SpeedOfSound, 0.5,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.77, (double)substance1.SpecificIsochoricHeatCapacity, 0.01,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.453035632 * Math.Pow(10, 3), (double)substance2.Temperature.Value, 0.000001,
               "Substance2: Substance has wrong temperature");
            Assert.AreEqual(1.127 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.00001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(762.7, (double)substance2.SpecificEnthalpy.Value, 0.1,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(761.6, (double)substance2.SpecificInternalEnergy, 0.1,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(2.138, (double)substance2.SpecificEntropy.Value, 0.001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(4.405, (double)substance2.SpecificIsobaricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(1392, (double)substance2.SpeedOfSound, 0.5,
                "Substance2: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.397, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.584149488 * Math.Pow(10, 3), (double)substance3.Temperature.Value, 0.000001,
               "Substance3: Substance has wrong pressure");
            Assert.AreEqual(1.453 * Math.Pow(10, -3), (double)substance3.SpecificVolume, 0.01,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(1408, (double)substance3.SpecificEnthalpy.Value, 0.5,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(1393, (double)substance3.SpecificInternalEnergy, 0.5,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(3.36, (double)substance3.SpecificEntropy.Value, 0.01,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(6.127, (double)substance3.SpecificIsobaricHeatCapacity, 0.001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(847.7, (double)substance3.SpeedOfSound, 0.1,
                "Substance3: Substance has wrong specific speed of sound");
            Assert.AreEqual(3.044, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }



    }
}
